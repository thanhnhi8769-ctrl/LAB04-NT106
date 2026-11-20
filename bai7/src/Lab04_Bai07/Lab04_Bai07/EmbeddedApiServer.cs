using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace Lab04_Bai07
{
    public static class EmbeddedApiServer
    {
        private const string NgrokStaticDomain = "kettle-plausible-outscore.ngrok-free.dev";

        private static readonly string DbPath = Path.Combine(AppContext.BaseDirectory, "homnayangi.db");
        private static readonly string ConnectionString = $"Data Source={DbPath}";
        private static readonly ConcurrentDictionary<string, string> ActiveTokens = new();
        private static readonly JsonSerializerOptions JsonOptions = new() { PropertyNameCaseInsensitive = true };

        private static HttpListener? _listener;
        private static Process? _ngrokProcess;
        public static bool IsHostingLocally { get; private set; } = false;

        // Phiên bản dữ liệu để đồng bộ tự động giữa Server và các máy Client
        public static long DataVersion { get; private set; } = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        public static void NotifyDataChanged()
        {
            DataVersion = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        }

        public static bool TryStartBackgroundServer()
        {
            if (IsHostingLocally) return true;

            try
            {
                InitDatabase();
                _listener = new HttpListener();
                _listener.Prefixes.Add("http://+:8080/");
                _listener.Start();

                IsHostingLocally = true;
                _ = Task.Run(() => ListenLoopAsync(_listener));
                StartNgrokTunnel();
                return true;
            }
            catch
            {
                // Nếu máy không có quyền Admin hoặc cổng 8080 đã có Server khác chiếm,
                // bỏ qua êm ái để máy này hoạt động như một Client thuần túy.
                IsHostingLocally = false;
                try { _listener?.Close(); } catch { }
                return false;
            }
        }

        public static void StopServer()
        {
            IsHostingLocally = false;
            try { _listener?.Stop(); _listener?.Close(); } catch { }
            try { if (_ngrokProcess != null && !_ngrokProcess.HasExited) _ngrokProcess.Kill(); } catch { }
        }

        private static void StartNgrokTunnel()
        {
            var psi = new ProcessStartInfo
            {
                FileName = "ngrok",
                Arguments = $"http --url={NgrokStaticDomain} 8080",
                UseShellExecute = false,
                CreateNoWindow = true
            };

            try
            {
                _ngrokProcess = Process.Start(psi);
            }
            catch { }
        }

        private static async Task ListenLoopAsync(HttpListener listener)
        {
            while (listener.IsListening)
            {
                try
                {
                    var context = await listener.GetContextAsync();
                    _ = Task.Run(() => HandleRequestAsync(context));
                }
                catch (HttpListenerException) { break; }
                catch { }
            }
        }

        private static string ResolveImagesDirectory()
        {
            string[] candidates =
            [
                Path.Combine(AppContext.BaseDirectory, "images"),
                Path.Combine(AppContext.BaseDirectory, "Images"),
                Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\..\images")),
                Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\..\..\images"))
            ];

            foreach (string path in candidates)
            {
                if (Directory.Exists(path)) return path;
            }
            return Path.Combine(AppContext.BaseDirectory, "images");
        }

        private static void InitDatabase()
        {
            using var conn = new SqliteConnection(ConnectionString);
            conn.Open();

            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Users (
                        Username TEXT PRIMARY KEY,
                        PasswordHash TEXT NOT NULL,
                        Email TEXT,
                        Firstname TEXT,
                        Lastname TEXT,
                        Phone TEXT,
                        Birthday TEXT,
                        Language TEXT,
                        Sex TEXT
                    );
                    CREATE TABLE IF NOT EXISTS MonAn (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        TenMonAn TEXT NOT NULL,
                        Gia INTEGER NOT NULL DEFAULT 0,
                        DiaChi TEXT,
                        HinhAnh TEXT,
                        MoTa TEXT,
                        NguoiDongGop TEXT
                    );
                    DELETE FROM MonAn
                    WHERE Id NOT IN (
                        SELECT MIN(Id)
                        FROM MonAn
                        GROUP BY LOWER(TRIM(TenMonAn))
                    );";
                cmd.ExecuteNonQuery();
            }

            EnsureDefaultUser(conn, "baonv", "123456", "Bảo", "Nguyễn");
            EnsureDefaultUser(conn, "phatpt", "123456", "Phát", "Phạm");

            EnsureDefaultMonAn(conn, "Bún Bò Huế", 35000, "123 - ABC - DEF", "images/bunbo.png", "Đậm đà hương vị Huế");
            EnsureDefaultMonAn(conn, "Bánh mì", 25000, "123 - ABC - DEF", "images/banhmi.png", "Bánh mì giòn rụm");
            EnsureDefaultMonAn(conn, "Phở", 40000, "345 - ABC - DEF", "images/pho.png", "Phở bò tái nạm");
            EnsureDefaultMonAn(conn, "Cơm tấm", 40000, "Cơm tấm - ABC - DEF", "images/comtam.png", "Sườn bì chả");
            EnsureDefaultMonAn(conn, "Hủ tiếu", 30000, "Hủ tiếu - ABC - DEF", "images/hutieu.png", "Hủ tiếu Nam Vang");
            EnsureDefaultMonAn(conn, "Bún chả", 45000, "456 - ABC - DEF", "images/buncha.png", "Bún chả nướng thơm lừng");
            EnsureDefaultMonAn(conn, "Mì quảng", 40000, "789 - ABC - DEF", "images/miquang.png", "Mì quảng đậm đà");
        }

        private static void EnsureDefaultMonAn(SqliteConnection conn, string tenMon, int gia, string diaChi, string relativeImagePath, string moTa)
        {
            using var findCmd = conn.CreateCommand();
            findCmd.CommandText = "SELECT COUNT(*) FROM MonAn WHERE LOWER(TRIM(TenMonAn)) = LOWER(TRIM($ten));";
            findCmd.Parameters.AddWithValue("$ten", tenMon);
            if (Convert.ToInt64(findCmd.ExecuteScalar() ?? 0) > 0) return;

            using var insCmd = conn.CreateCommand();
            insCmd.CommandText = @"
                INSERT INTO MonAn (TenMonAn, Gia, DiaChi, HinhAnh, MoTa, NguoiDongGop)
                VALUES ($ten, $gia, $dc, $img, $mota, 'Quản lí');";
            insCmd.Parameters.AddWithValue("$ten", tenMon);
            insCmd.Parameters.AddWithValue("$gia", gia);
            insCmd.Parameters.AddWithValue("$dc", diaChi);
            insCmd.Parameters.AddWithValue("$img", relativeImagePath);
            insCmd.Parameters.AddWithValue("$mota", moTa);
            insCmd.ExecuteNonQuery();
        }

        private static void EnsureDefaultUser(SqliteConnection conn, string username, string password, string firstname, string lastname)
        {
            using var checkCmd = conn.CreateCommand();
            checkCmd.CommandText = "SELECT COUNT(*) FROM Users WHERE Username = $u;";
            checkCmd.Parameters.AddWithValue("$u", username);
            if (Convert.ToInt64(checkCmd.ExecuteScalar() ?? 0) > 0) return;

            using var insCmd = conn.CreateCommand();
            insCmd.CommandText = @"
                INSERT INTO Users (Username, PasswordHash, Email, Firstname, Lastname, Phone, Birthday, Language, Sex)
                VALUES ($u, $p, $e, $f, $l, '', '2005-01-01', 'vi', 'Male');";
            insCmd.Parameters.AddWithValue("$u", username);
            insCmd.Parameters.AddWithValue("$p", HashPassword(password));
            insCmd.Parameters.AddWithValue("$e", $"{username}@uit.edu.vn");
            insCmd.Parameters.AddWithValue("$f", firstname);
            insCmd.Parameters.AddWithValue("$l", lastname);
            insCmd.ExecuteNonQuery();
        }

        private static string HashPassword(string password)
        {
            return Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(password)));
        }

        private static string? GetAuthenticatedUsername(HttpListenerRequest req)
        {
            string? auth = req.Headers["Authorization"];
            if (string.IsNullOrWhiteSpace(auth)) return null;
            const string prefix = "Bearer ";
            string token = auth.StartsWith(prefix, StringComparison.OrdinalIgnoreCase) ? auth[prefix.Length..].Trim() : auth.Trim();
            return ActiveTokens.TryGetValue(token, out string? username) ? username : null;
        }

        private static async Task HandleRequestAsync(HttpListenerContext context)
        {
            var req = context.Request;
            var res = context.Response;
            res.ContentEncoding = Encoding.UTF8;
            res.ContentType = "application/json; charset=utf-8";

            string path = (req.Url?.AbsolutePath ?? "/").TrimEnd('/').ToLowerInvariant();
            string method = req.HttpMethod.ToUpperInvariant();

            try
            {
                if (method == "GET" && path == "/api/version")
                {
                    res.StatusCode = 200;
                    await WriteJsonAsync(res, new { version = DataVersion });
                }
                else if (method == "GET" && path.StartsWith("/images/", StringComparison.OrdinalIgnoreCase))
                    await HandleGetImageAsync(req, res);
                else if (method == "POST" && path == "/api/signup")
                    await HandleSignupAsync(req, res);
                else if (method == "POST" && path == "/api/login")
                    await HandleLoginAsync(req, res);
                else if (method == "GET" && (path == "/api/monan/all" || path == "/api/monan/mine"))
                    await HandleGetMonAnAsync(req, res, path == "/api/monan/mine");
                else if (method == "POST" && path == "/api/monan")
                    await HandleAddMonAnAsync(req, res);
                else if (method == "DELETE" && path == "/api/monan")
                    await HandleDeleteMonAnAsync(req, res);
                else if (method == "GET" && path == "/api/monan/random")
                    await HandleRandomMonAnAsync(req, res);
                else
                {
                    res.StatusCode = 404;
                    await WriteJsonAsync(res, new { message = "Endpoint không tồn tại." });
                }
            }
            catch (Exception ex)
            {
                res.StatusCode = 500;
                await WriteJsonAsync(res, new { message = "Lỗi Server: " + ex.Message });
            }
            finally
            {
                try { res.OutputStream.Close(); } catch { }
            }
        }

        private static async Task HandleGetImageAsync(HttpListenerRequest req, HttpListenerResponse res)
        {
            string fileName = Path.GetFileName(Uri.UnescapeDataString(req.Url?.AbsolutePath ?? ""));
            string fullPath = Path.Combine(ResolveImagesDirectory(), fileName);

            if (string.IsNullOrWhiteSpace(fileName) || !File.Exists(fullPath))
            {
                res.StatusCode = 404;
                await WriteJsonAsync(res, new { message = "Không tìm thấy ảnh." });
                return;
            }

            string ext = Path.GetExtension(fullPath).ToLowerInvariant();
            res.ContentType = ext switch
            {
                ".jpg" or ".jpeg" => "image/jpeg",
                ".gif" => "image/gif",
                ".bmp" => "image/bmp",
                ".webp" => "image/webp",
                _ => "image/png"
            };

            byte[] bytes = await File.ReadAllBytesAsync(fullPath);
            res.ContentLength64 = bytes.Length;
            await res.OutputStream.WriteAsync(bytes, 0, bytes.Length);
        }

        private static async Task HandleSignupAsync(HttpListenerRequest req, HttpListenerResponse res)
        {
            using var reader = new StreamReader(req.InputStream, req.ContentEncoding);
            var dto = JsonSerializer.Deserialize<SignupDto>(await reader.ReadToEndAsync(), JsonOptions);

            if (dto == null || string.IsNullOrWhiteSpace(dto.Username) || string.IsNullOrWhiteSpace(dto.Password))
            {
                res.StatusCode = 400;
                await WriteJsonAsync(res, new { message = "Username và Password không được để trống." });
                return;
            }

            using var conn = new SqliteConnection(ConnectionString);
            conn.Open();

            using (var checkCmd = conn.CreateCommand())
            {
                checkCmd.CommandText = "SELECT COUNT(*) FROM Users WHERE Username = $u;";
                checkCmd.Parameters.AddWithValue("$u", dto.Username.Trim());
                if (Convert.ToInt64(checkCmd.ExecuteScalar() ?? 0) > 0)
                {
                    res.StatusCode = 409;
                    await WriteJsonAsync(res, new { message = "Username đã tồn tại!" });
                    return;
                }
            }

            using (var insCmd = conn.CreateCommand())
            {
                insCmd.CommandText = @"
                    INSERT INTO Users (Username, PasswordHash, Email, Firstname, Lastname, Phone, Birthday, Language, Sex)
                    VALUES ($u, $p, $e, $f, $l, $ph, $b, $lang, $sex);";
                insCmd.Parameters.AddWithValue("$u", dto.Username.Trim());
                insCmd.Parameters.AddWithValue("$p", HashPassword(dto.Password));
                insCmd.Parameters.AddWithValue("$e", dto.Email.Trim());
                insCmd.Parameters.AddWithValue("$f", dto.Firstname.Trim());
                insCmd.Parameters.AddWithValue("$l", dto.Lastname.Trim());
                insCmd.Parameters.AddWithValue("$ph", dto.Phone.Trim());
                insCmd.Parameters.AddWithValue("$b", dto.Birthday.Trim());
                insCmd.Parameters.AddWithValue("$lang", dto.Language.Trim());
                insCmd.Parameters.AddWithValue("$sex", dto.Sex.Trim());
                insCmd.ExecuteNonQuery();
            }

            res.StatusCode = 200;
            await WriteJsonAsync(res, new { message = "Đăng ký tài khoản thành công!" });
        }

        private static async Task HandleLoginAsync(HttpListenerRequest req, HttpListenerResponse res)
        {
            using var reader = new StreamReader(req.InputStream, req.ContentEncoding);
            var dto = JsonSerializer.Deserialize<LoginDto>(await reader.ReadToEndAsync(), JsonOptions);

            if (dto == null || string.IsNullOrWhiteSpace(dto.Username) || string.IsNullOrWhiteSpace(dto.Password))
            {
                res.StatusCode = 400;
                await WriteJsonAsync(res, new { message = "Vui lòng nhập Username và Password." });
                return;
            }

            using var conn = new SqliteConnection(ConnectionString);
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Username, Firstname FROM Users WHERE Username = $u AND PasswordHash = $p;";
            cmd.Parameters.AddWithValue("$u", dto.Username.Trim());
            cmd.Parameters.AddWithValue("$p", HashPassword(dto.Password));

            using var rd = cmd.ExecuteReader();
            if (!rd.Read())
            {
                res.StatusCode = 401;
                await WriteJsonAsync(res, new { message = "Sai Username hoặc Password!" });
                return;
            }

            string dbUser = rd.GetString(0);
            string firstname = rd.IsDBNull(1) ? dbUser : rd.GetString(1);
            string token = Guid.NewGuid().ToString("N");
            ActiveTokens[token] = dbUser;

            res.StatusCode = 200;
            await WriteJsonAsync(res, new { token, username = dbUser, firstname, message = "Đăng nhập thành công!" });
        }

        private static async Task HandleGetMonAnAsync(HttpListenerRequest req, HttpListenerResponse res, bool onlyMine)
        {
            string? username = null;
            if (onlyMine)
            {
                username = GetAuthenticatedUsername(req);
                if (string.IsNullOrEmpty(username))
                {
                    res.StatusCode = 401;
                    await WriteJsonAsync(res, new { message = "Vui lòng đăng nhập để xem món ăn của bạn." });
                    return;
                }
            }

            int page = int.TryParse(req.QueryString["page"], out int p) && p > 0 ? p : 1;
            int pageSize = int.TryParse(req.QueryString["pageSize"], out int ps) && ps > 0 ? ps : 5;

            using var conn = new SqliteConnection(ConnectionString);
            conn.Open();

            long totalItems;
            using (var countCmd = conn.CreateCommand())
            {
                if (onlyMine)
                {
                    countCmd.CommandText = "SELECT COUNT(*) FROM MonAn WHERE NguoiDongGop = $u;";
                    countCmd.Parameters.AddWithValue("$u", username);
                }
                else
                {
                    countCmd.CommandText = "SELECT COUNT(*) FROM MonAn;";
                }
                totalItems = Convert.ToInt64(countCmd.ExecuteScalar() ?? 0);
            }

            int totalPages = Math.Max(1, (int)Math.Ceiling((double)totalItems / pageSize));
            if (page > totalPages) page = totalPages;
            int offset = (page - 1) * pageSize;

            var list = new List<MonAnRecord>();
            using (var cmd = conn.CreateCommand())
            {
                if (onlyMine)
                {
                    cmd.CommandText = @"
                        SELECT Id, TenMonAn, Gia, DiaChi, HinhAnh, MoTa, NguoiDongGop
                        FROM MonAn WHERE NguoiDongGop = $u ORDER BY Id DESC LIMIT $limit OFFSET $offset;";
                    cmd.Parameters.AddWithValue("$u", username);
                }
                else
                {
                    cmd.CommandText = @"
                        SELECT Id, TenMonAn, Gia, DiaChi, HinhAnh, MoTa, NguoiDongGop
                        FROM MonAn ORDER BY Id DESC LIMIT $limit OFFSET $offset;";
                }
                cmd.Parameters.AddWithValue("$limit", pageSize);
                cmd.Parameters.AddWithValue("$offset", offset);

                using var rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    list.Add(new MonAnRecord
                    {
                        Id = rd.GetInt32(0),
                        TenMonAn = rd.IsDBNull(1) ? "" : rd.GetString(1),
                        Gia = rd.IsDBNull(2) ? 0 : rd.GetInt32(2),
                        DiaChi = rd.IsDBNull(3) ? "" : rd.GetString(3),
                        HinhAnh = rd.IsDBNull(4) ? "" : rd.GetString(4),
                        MoTa = rd.IsDBNull(5) ? "" : rd.GetString(5),
                        NguoiDongGop = rd.IsDBNull(6) ? "" : rd.GetString(6)
                    });
                }
            }

            res.StatusCode = 200;
            await WriteJsonAsync(res, new { page, pageSize, totalItems, totalPages, data = list });
        }

        private static async Task HandleAddMonAnAsync(HttpListenerRequest req, HttpListenerResponse res)
        {
            string? username = GetAuthenticatedUsername(req);
            if (string.IsNullOrEmpty(username))
            {
                res.StatusCode = 401;
                await WriteJsonAsync(res, new { message = "Bạn cần đăng nhập trước khi thêm món ăn!" });
                return;
            }

            using var reader = new StreamReader(req.InputStream, req.ContentEncoding);
            var dto = JsonSerializer.Deserialize<MonAnRecord>(await reader.ReadToEndAsync(), JsonOptions);

            string tenMonNormalized = (dto?.TenMonAn ?? "").Trim();
            if (string.IsNullOrWhiteSpace(tenMonNormalized))
            {
                res.StatusCode = 400;
                await WriteJsonAsync(res, new { message = "Tên món ăn không được để trống." });
                return;
            }

            using var conn = new SqliteConnection(ConnectionString);
            conn.Open();

            using (var checkCmd = conn.CreateCommand())
            {
                checkCmd.CommandText = "SELECT COUNT(*) FROM MonAn WHERE LOWER(TRIM(TenMonAn)) = LOWER($ten);";
                checkCmd.Parameters.AddWithValue("$ten", tenMonNormalized);
                if (Convert.ToInt64(checkCmd.ExecuteScalar() ?? 0) > 0)
                {
                    res.StatusCode = 409;
                    await WriteJsonAsync(res, new { message = $"Món '{tenMonNormalized}' đã tồn tại trong danh sách!" });
                    return;
                }
            }

            string savedImagePath = (dto!.HinhAnh ?? "").Trim();

            if (!string.IsNullOrWhiteSpace(dto.ImageBase64))
            {
                try
                {
                    string imagesDir = ResolveImagesDirectory();
                    Directory.CreateDirectory(imagesDir);

                    string ext = Path.GetExtension(savedImagePath);
                    if (string.IsNullOrWhiteSpace(ext)) ext = ".png";

                    string uniqueFileName = $"{Guid.NewGuid():N}{ext}";
                    string fullSavePath = Path.Combine(imagesDir, uniqueFileName);

                    byte[] imageBytes = Convert.FromBase64String(dto.ImageBase64);
                    await File.WriteAllBytesAsync(fullSavePath, imageBytes);

                    savedImagePath = $"images/{uniqueFileName}";
                }
                catch { }
            }

            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    INSERT INTO MonAn (TenMonAn, Gia, DiaChi, HinhAnh, MoTa, NguoiDongGop)
                    VALUES ($ten, $gia, $dc, $img, $mota, $user);";
                cmd.Parameters.AddWithValue("$ten", tenMonNormalized);
                cmd.Parameters.AddWithValue("$gia", dto!.Gia);
                cmd.Parameters.AddWithValue("$dc", (dto.DiaChi ?? "").Trim());
                cmd.Parameters.AddWithValue("$img", savedImagePath);
                cmd.Parameters.AddWithValue("$mota", (dto.MoTa ?? "").Trim());
                cmd.Parameters.AddWithValue("$user", username);
                cmd.ExecuteNonQuery();
            }

            NotifyDataChanged();

            res.StatusCode = 200;
            await WriteJsonAsync(res, new { message = "Thêm món ăn thành công!" });
        }

        private static async Task HandleDeleteMonAnAsync(HttpListenerRequest req, HttpListenerResponse res)
        {
            string? username = GetAuthenticatedUsername(req);
            if (string.IsNullOrEmpty(username))
            {
                res.StatusCode = 401;
                await WriteJsonAsync(res, new { message = "Bạn cần đăng nhập để xoá món ăn!" });
                return;
            }

            if (!int.TryParse(req.QueryString["id"], out int id) || id <= 0)
            {
                res.StatusCode = 400;
                await WriteJsonAsync(res, new { message = "ID món ăn không hợp lệ." });
                return;
            }

            using var conn = new SqliteConnection(ConnectionString);
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM MonAn WHERE Id = $id;";
            cmd.Parameters.AddWithValue("$id", id);
            int affected = cmd.ExecuteNonQuery();

            if (affected > 0)
            {
                NotifyDataChanged();
            }

            res.StatusCode = 200;
            await WriteJsonAsync(res, new { message = "Đã xoá món ăn thành công!" });
        }

        private static async Task HandleRandomMonAnAsync(HttpListenerRequest req, HttpListenerResponse res)
        {
            string type = (req.QueryString["type"] ?? "all").ToLowerInvariant();
            string? username = null;

            if (type == "mine")
            {
                username = GetAuthenticatedUsername(req);
                if (string.IsNullOrEmpty(username))
                {
                    res.StatusCode = 401;
                    await WriteJsonAsync(res, new { message = "Vui lòng đăng nhập để chọn món từ danh sách của bạn." });
                    return;
                }
            }

            using var conn = new SqliteConnection(ConnectionString);
            conn.Open();

            using var cmd = conn.CreateCommand();
            if (type == "mine")
            {
                cmd.CommandText = "SELECT Id, TenMonAn, Gia, DiaChi, HinhAnh, MoTa, NguoiDongGop FROM MonAn WHERE NguoiDongGop = $u ORDER BY RANDOM() LIMIT 1;";
                cmd.Parameters.AddWithValue("$u", username);
            }
            else
            {
                cmd.CommandText = "SELECT Id, TenMonAn, Gia, DiaChi, HinhAnh, MoTa, NguoiDongGop FROM MonAn ORDER BY RANDOM() LIMIT 1;";
            }

            using var rd = cmd.ExecuteReader();
            if (!rd.Read())
            {
                res.StatusCode = 404;
                await WriteJsonAsync(res, new { message = "Chưa có món ăn nào để lựa chọn." });
                return;
            }

            var item = new MonAnRecord
            {
                Id = rd.GetInt32(0),
                TenMonAn = rd.IsDBNull(1) ? "" : rd.GetString(1),
                Gia = rd.IsDBNull(2) ? 0 : rd.GetInt32(2),
                DiaChi = rd.IsDBNull(3) ? "" : rd.GetString(3),
                HinhAnh = rd.IsDBNull(4) ? "" : rd.GetString(4),
                MoTa = rd.IsDBNull(5) ? "" : rd.GetString(5),
                NguoiDongGop = rd.IsDBNull(6) ? "" : rd.GetString(6)
            };

            res.StatusCode = 200;
            await WriteJsonAsync(res, item);
        }

        private static async Task WriteJsonAsync(HttpListenerResponse res, object payload)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(payload));
            res.ContentLength64 = bytes.Length;
            await res.OutputStream.WriteAsync(bytes, 0, bytes.Length);
        }
    }

    public class SignupDto
    {
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string Email { get; set; } = "";
        public string Firstname { get; set; } = "";
        public string Lastname { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Birthday { get; set; } = "";
        public string Language { get; set; } = "vi";
        public string Sex { get; set; } = "";
    }

    public class LoginDto
    {
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
    }

    public class MonAnRecord
    {
        public int Id { get; set; }
        public string TenMonAn { get; set; } = "";
        public int Gia { get; set; }
        public string DiaChi { get; set; } = "";
        public string HinhAnh { get; set; } = "";
        public string ImageBase64 { get; set; } = "";
        public string MoTa { get; set; } = "";
        public string NguoiDongGop { get; set; } = "";
    }
}