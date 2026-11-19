using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LAB03
{
    // ===== Model: 1 bộ phim lấy từ website =====
    public class PhimOnline
    {
        public string TenPhim { get; set; }
        public string PosterUrl { get; set; }
        public string LinkChiTiet { get; set; }
        public string MoTa { get; set; }
        public decimal GiaVeChuan { get; set; } = 45000m;
    }

    // ===== Lấy dữ liệu từ website + lưu/đọc JSON =====
    public static class PhimScraper
    {
        public const string UrlDanhSach = "https://betacinemas.vn/phim.htm";

        private static readonly HttpClient http = TaoClient();

        private static HttpClient TaoClient()
        {
            var c = new HttpClient { Timeout = TimeSpan.FromSeconds(30) };
            c.DefaultRequestHeaders.UserAgent.ParseAdd(
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 Chrome/120 Safari/537.36");
            c.DefaultRequestHeaders.AcceptLanguage.ParseAdd("vi-VN,vi;q=0.9");
            return c;
        }

        public static async Task<List<PhimOnline>> LayDanhSachAsync(
            IProgress<int> progress, IProgress<string> status)
        {
            status?.Report("Đang tải trang danh sách phim...");
            progress?.Report(5);
            string html = await http.GetStringAsync(UrlDanhSach);
            progress?.Report(20);

            status?.Report("Đang phân tích danh sách phim...");
            var ketQua = TachPhim(html);

            if (ketQua.Count == 0)
            {
                try
                {
                    File.WriteAllText(
                        Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "debug_phim.html"),
                        html, new UTF8Encoding(false));
                }
                catch { }
                progress?.Report(100);
                return ketQua;
            }

            // Vào từng trang chi tiết lấy thêm mô tả (og:description) -> ProgressBar chạy theo từng phim
            for (int i = 0; i < ketQua.Count; i++)
            {
                var p = ketQua[i];
                status?.Report($"Đang trích xuất {i + 1}/{ketQua.Count}: {p.TenPhim}");
                try
                {
                    string detail = await http.GetStringAsync(p.LinkChiTiet);
                    string moTa = LayMeta(detail, "og:description");
                    if (!string.IsNullOrWhiteSpace(moTa))
                    {
                        if (moTa.Length > 160) moTa = moTa.Substring(0, 160) + "...";
                        p.MoTa = string.IsNullOrWhiteSpace(p.MoTa) ? moTa : p.MoTa + "\n" + moTa;
                    }
                }
                catch { /* bỏ qua phim lỗi, vẫn giữ tên + poster + link */ }

                progress?.Report(20 + (int)(80.0 * (i + 1) / ketQua.Count));
            }

            return ketQua;
        }

        // ===== Tách danh sách phim từ HTML =====
        // Cấu trúc trang: div.film-item > div.row >
        //    [col: div.product-item > div.pi-img-wrapper > img(poster)]
        //    [col: div.film-info > h3[title] > a[href=/chi-tiet-phim.htm?gf=...] ; ul > li(thể loại, thời lượng)]
        private static List<PhimOnline> TachPhim(string html)
        {
            var ds = new List<PhimOnline>();
            var baseUri = new Uri(UrlDanhSach);
            var daCo = new HashSet<string>();

            var filmRx = new Regex("class\\s*=\\s*[\"'][^\"']*\\bfilm-item\\b[^\"']*[\"']",
                RegexOptions.IgnoreCase);
            var linkRx = new Regex(
                "<a\\b[^>]*?href\\s*=\\s*[\"']([^\"']*chi-tiet-phim[^\"']*)[\"'][^>]*>(.*?)</a>",
                RegexOptions.Singleline | RegexOptions.IgnoreCase);
            var h3TitleRx = new Regex("<h3\\b[^>]*?\\btitle\\s*=\\s*[\"']([^\"']*)[\"']",
                RegexOptions.Singleline | RegexOptions.IgnoreCase);
            var imgRx = new Regex("<img\\b[^>]*>", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            var liRx = new Regex("<li\\b[^>]*>(.*?)</li>", RegexOptions.Singleline | RegexOptions.IgnoreCase);

            var starts = new List<int>();
            foreach (Match m in filmRx.Matches(html)) starts.Add(m.Index);

            for (int i = 0; i < starts.Count; i++)
            {
                int s = starts[i];
                int e = (i + 1 < starts.Count) ? starts[i + 1] : html.Length;
                e = Math.Min(e, s + 10000);
                string block = html.Substring(s, e - s);

                // Link chi tiết
                var lm = linkRx.Match(block);
                if (!lm.Success) continue;
                string href = WebUtility.HtmlDecode(lm.Groups[1].Value).Trim();
                string link = new Uri(baseUri, href).ToString();
                if (!daCo.Add(link)) continue;

                // Tên phim: ưu tiên title của h3, nếu không có thì lấy chữ trong thẻ a
                string ten = WebUtility.HtmlDecode(h3TitleRx.Match(block).Groups[1].Value).Trim();
                if (string.IsNullOrWhiteSpace(ten))
                    ten = Lam(WebUtility.HtmlDecode(Regex.Replace(lm.Groups[2].Value, "<.*?>", " ")));
                if (string.IsNullOrWhiteSpace(ten)) ten = "(Chưa có tên)";

                // Poster: ảnh đầu tiên không phải icon
                string poster = null;
                foreach (Match im in imgRx.Matches(block))
                {
                    string src = Attr(im.Value, "data-src");
                    if (string.IsNullOrEmpty(src)) src = Attr(im.Value, "src");
                    if (string.IsNullOrEmpty(src)) continue;
                    if (src.IndexOf("icon", StringComparison.OrdinalIgnoreCase) >= 0) continue;
                    poster = new Uri(baseUri, WebUtility.HtmlDecode(src)).ToString();
                    break;
                }

                // Thể loại, thời lượng...
                var sb = new List<string>();
                foreach (Match li in liRx.Matches(block))
                {
                    string t = Lam(WebUtility.HtmlDecode(Regex.Replace(li.Groups[1].Value, "<.*?>", " ")));
                    if (!string.IsNullOrWhiteSpace(t)) sb.Add(t);
                }

                ds.Add(new PhimOnline
                {
                    TenPhim = ten,
                    PosterUrl = poster,
                    LinkChiTiet = link,
                    MoTa = string.Join("\n", sb)
                });
            }

            return ds;
        }

        private static string Lam(string s) => Regex.Replace(s ?? "", "\\s+", " ").Trim();

        private static string Attr(string tag, string name)
        {
            var m = Regex.Match(tag,
                "(?<![\\w-])" + Regex.Escape(name) + "\\s*=\\s*[\"']([^\"']*)[\"']",
                RegexOptions.IgnoreCase);
            return m.Success ? m.Groups[1].Value : "";
        }

        private static string LayMeta(string html, string property)
        {
            var rx = new Regex(
                "<meta\\b[^>]*?(?:property|name)\\s*=\\s*[\"']" + Regex.Escape(property) +
                "[\"'][^>]*?content\\s*=\\s*[\"']([^\"']*)[\"']",
                RegexOptions.IgnoreCase | RegexOptions.Singleline);
            var m = rx.Match(html);
            return m.Success ? WebUtility.HtmlDecode(m.Groups[1].Value).Trim() : "";
        }

        // ===== JSON =====
        private static readonly JsonSerializerOptions jsonOpt = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping // giữ nguyên tiếng Việt có dấu
        };

        public static void LuuJson(string path, List<PhimOnline> ds)
        {
            File.WriteAllText(path, JsonSerializer.Serialize(ds, jsonOpt), new UTF8Encoding(false));
        }

        public static List<PhimOnline> DocJson(string path)
        {
            if (!File.Exists(path)) return new List<PhimOnline>();
            try
            {
                return JsonSerializer.Deserialize<List<PhimOnline>>(
                    File.ReadAllText(path, Encoding.UTF8)) ?? new List<PhimOnline>();
            }
            catch { return new List<PhimOnline>(); }
        }
    }
}