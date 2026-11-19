using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lab04_Bai07_Client
{
    public class UserDto
    {
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string Email { get; set; } = "";
        public string Firstname { get; set; } = "";
        public string Lastname { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Birthday { get; set; } = "";
        public string Language { get; set; } = "vi";
        public string Sex { get; set; } = "Male";
    }

    public class LoginResponse
    {
        public string Token { get; set; } = "";
        public string Username { get; set; } = "";
        public string Firstname { get; set; } = "";
        public string Message { get; set; } = "";
    }

    public class MonAnDto
    {
        public int Id { get; set; }
        public string TenMonAn { get; set; } = "";
        public int Gia { get; set; }
        public string DiaChi { get; set; } = "";
        public string HinhAnh { get; set; } = "";
        public string MoTa { get; set; } = "";
        public string NguoiDongGop { get; set; } = "";
    }

    public class PaginatedMonAnResponse
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public long TotalItems { get; set; }
        public int TotalPages { get; set; }
        public List<MonAnDto> Data { get; set; } = new List<MonAnDto>();
        public string Message { get; set; } = "";
    }

    public static class ApiClient
    {
        private static readonly HttpClient Client = new HttpClient
        {
            BaseAddress = new Uri("http://+:8080/"),
            Timeout = TimeSpan.FromSeconds(10)
        };
        public static string BaseUrl { get; private set; } = "https://possibilities-der-redhead-accessing.trycloudflare.com/";
        private static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public static string Token { get; private set; } = "";
        public static string CurrentUsername { get; private set; } = "";
        public static string CurrentFirstname { get; set; } = "";
        public static bool IsLoggedIn => !string.IsNullOrEmpty(Token);

        public static void Logout()
        {
            Token = "";
            CurrentUsername = "";
            CurrentFirstname = "";
            Client.DefaultRequestHeaders.Authorization = null;
        }

        private static void AttachToken()
        {
            if (!string.IsNullOrEmpty(Token))
            {
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            }
        }

        public static async Task<(bool Success, string Message)> SignupAsync(UserDto user)
        {
            string json = JsonSerializer.Serialize(user);
            using var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage res = await Client.PostAsync("api/signup", content);
            string body = await res.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<LoginResponse>(body, JsonOptions);
            return (res.IsSuccessStatusCode, result?.Message ?? "Lỗi không xác định");
        }

        public static async Task<(bool Success, string Message)> LoginAsync(string username, string password)
        {
            string json = JsonSerializer.Serialize(new { Username = username, Password = password });
            using var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage res = await Client.PostAsync("api/login", content);
            string body = await res.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<LoginResponse>(body, JsonOptions);

            if (res.IsSuccessStatusCode && result != null && !string.IsNullOrEmpty(result.Token))
            {
                Token = result.Token;
                CurrentUsername = result.Username;
                CurrentFirstname = string.IsNullOrWhiteSpace(result.Firstname) ? result.Username : result.Firstname;
                AttachToken();
                return (true, "Đăng nhập thành công!");
            }

            return (false, result?.Message ?? "Sai tài khoản hoặc mật khẩu!");
        }

        public static async Task<PaginatedMonAnResponse> GetMonAnAsync(bool onlyMine, int page, int pageSize)
        {
            AttachToken();
            string endpoint = onlyMine
                ? $"api/monan/mine?page={page}&pageSize={pageSize}"
                : $"api/monan/all?page={page}&pageSize={pageSize}";

            HttpResponseMessage res = await Client.GetAsync(endpoint);
            string body = await res.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<PaginatedMonAnResponse>(body, JsonOptions) ?? new PaginatedMonAnResponse();

            if (!res.IsSuccessStatusCode && string.IsNullOrEmpty(result.Message))
            {
                result.Message = "Không thể tải danh sách món ăn.";
            }
            return result;
        }

        public static async Task<(bool Success, string Message)> AddMonAnAsync(MonAnDto mon)
        {
            AttachToken();
            string json = JsonSerializer.Serialize(mon);
            using var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage res = await Client.PostAsync("api/monan", content);
            string body = await res.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<LoginResponse>(body, JsonOptions);
            return (res.IsSuccessStatusCode, result?.Message ?? "Lỗi khi thêm món ăn");
        }

        public static async Task<(bool Success, string Message)> DeleteMonAnAsync(int id)
        {
            AttachToken();
            HttpResponseMessage res = await Client.DeleteAsync($"api/monan?id={id}");
            string body = await res.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<LoginResponse>(body, JsonOptions);
            return (res.IsSuccessStatusCode, result?.Message ?? "Lỗi khi xoá món ăn");
        }

        public static async Task<(MonAnDto? Mon, string ErrorMessage)> GetRandomMonAnAsync(bool onlyMine)
        {
            AttachToken();
            string type = onlyMine ? "mine" : "all";
            HttpResponseMessage res = await Client.GetAsync($"api/monan/random?type={type}");
            string body = await res.Content.ReadAsStringAsync();

            if (res.IsSuccessStatusCode)
            {
                return (JsonSerializer.Deserialize<MonAnDto>(body, JsonOptions), "");
            }

            var err = JsonSerializer.Deserialize<LoginResponse>(body, JsonOptions);
            return (null, err?.Message ?? "Không tìm thấy món ăn nào.");
        }
    }
}