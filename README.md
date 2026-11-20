<h1 align="center">🖥️ LAB 4 – WORKING WITH WEB SERVER IN C#</h1>
<div align="center">

### TRUYỀN THÔNG VỚI WEB SERVER TRONG C#

*Bài thực hành nhóm môn Lập trình mạng căn bản – Xây dựng ứng dụng giao tiếp với Web Server, xử lý HTTP Request/Response, khai thác dữ liệu website và tích hợp Web API bằng C#.*

<a href ="https://learn.microsoft.com/vi-vn/dotnet/csharp/" target="_blank" rel="noopener noreferrer">
    <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white" alt="C#" />
  </a>
   <a href ="https://dotnet.microsoft.com/" target="_blank" rel="noopener noreferrer">
     <img src="https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt=".NET" />
  </a>
  <a href ="https://learn.microsoft.com/vi-vn/dotnet/desktop/winforms/" target="_blank" rel="noopener noreferrer">
     <img src="https://img.shields.io/badge/Windows_Forms-0078D4?style=for-the-badge&logo=windows&logoColor=white" alt="Windows Forms" />
  </a>
  <a href="https://www.w3schools.com/tags/ref_httpmethods.asp" target="_blank" rel="noopener noreferrer">
    <img src="https://img.shields.io/badge/HTTP_GET-005C97?style=for-the-badge" alt="HTTP GET" />
  </a>
  <a href="https://viblo.asia/p/html5-overview-jlA7GKByMKZQ" target="_blank" rel="noopener noreferrer">
    <img src="https://img.shields.io/badge/HTML5-E34F26?style=for-the-badge&logo=html5&logoColor=white" alt="HTML5" />
  </a>
  <a href="https://www.json.org/json-en.html" target="_blank" rel="noopener noreferrer">
    <img src="https://img.shields.io/badge/JSON-333333?style=for-the-badge&logo=json&logoColor=white" alt="JSON" />
  </a>
  <a href="https://developer.microsoft.com/vi-vn/microsoft-edge/webview2?form=MA13LH&cs=1190118532"target="_blank" rel="noopener noreferrer">
    <img src="https://img.shields.io/badge/WebView2-176DA8?style=for-the-badge&logo=microsoftedge&logoColor=white" alt="WebView2" />
  </a>
  <a href="https://blog-postman-com.translate.goog/rest-api-examples/?_x_tr_sl=en&_x_tr_tl=vi&_x_tr_hl=vi&_x_tr_pto=tc" target="_blank" rel="noopener noreferrer">
    <img src="https://img.shields.io/badge/REST_API-009688?style=for-the-badge" alt="REST API" />
  </a>
  <a href ="https://git-scm.com/" target="_blank" rel="noopener noreferrer">
     <img src="https://img.shields.io/badge/Git-F05032?style=for-the-badge&logo=git&logoColor=white" alt="Git" />
  </a>
  <a href ="https://github.com/hongmynhu18years-svg/LAB03_NT106" target="_blank" rel="noopener noreferrer">
     <img src="https://img.shields.io/badge/GitHub-181717?style=for-the-badge&logo=github&logoColor=white" alt="GitHub" />
  </a>
  
</div>

---

## 👥 Thông tin nhóm thực hiện

| Nội dung | Thông tin |
|---|---|
| **Môn học** | Lập trình mạng căn bản |
| **Bài thực hành** | Lab 4 – Working with Web Server in C# |
| **Nhóm** | 3 |
| **Lớp** | NT106.R14.2 |

## 🧑‍💻 Danh sách thành viên

| STT | Họ và tên | MSSV | 
|:---:|---|:---:|
| 1 | Hồng Mỹ Như | 25521342 | 
| 2 | Tô Thị Thanh Nhi | 25521332 | 
| 3 | Trương Vũ Hoàng Ngân | 25521185 | 
| 4 | Võ Thị Minh Thư | 25521816 |
| 5 | Lê Hoàn Phúc | 25521422 |

---

## 📖 Giới thiệu

**LAB 4 – Working with Web Server in C#** là bài thực hành nhóm thuộc môn **Lập trình mạng căn bản**, tập trung xây dựng các ứng dụng giao tiếp với Web Server bằng ngôn ngữ C# trên nền tảng Windows Forms.

Bài thực hành giúp sinh viên tìm hiểu cơ chế **HTTP Request/Response**, sử dụng các phương thức **GET, POST** để gửi và nhận dữ liệu, tải nội dung website, xử lý HTML và JSON, đồng thời khai thác Web API để xây dựng các ứng dụng thực tế.

Ngoài ra, Lab 04 giới thiệu cách tạo website đơn giản bằng **HTML**, triển khai Web Server cục bộ bằng **IIS (localhost)** và sử dụng **Postman** để kiểm tra API.

Các bài tập được tổ chức thành những project riêng trong cùng một solution, kết hợp giao diện Windows Forms để thực hiện các chức năng tương ứng.

<p align="center">

<img width="986" height="580" alt="ẢNH NỀN LAB4" src="https://github.com/user-attachments/assets/1cb4b831-1c07-459e-8432-b09c2ae820e5" />

</p>

### 🎯 Mục tiêu thực hành

- Hiểu nguyên lý giao tiếp giữa Client và Web Server thông qua HTTP/HTTPS.
- Sử dụng `WebRequest`, `WebResponse`, `WebClient` và `HttpClient` để gửi, nhận dữ liệu.
- Thực hiện HTTP GET và POST để truy xuất thông tin và gửi dữ liệu lên Web Server.
- Xây dựng website HTML đơn giản và triển khai trên localhost bằng IIS.
- Sử dụng `WebView2` để hiển thị website trong ứng dụng Windows Forms.
- Tải nội dung HTML, trích xuất dữ liệu và tài nguyên website.
- Xử lý dữ liệu **JSON** và khai thác **REST API**.
- Tìm hiểu cơ chế xác thực bằng **JWT (JSON Web Token)**.
- Kết hợp API để xây dựng các ứng dụng quản lý và xử lý dữ liệu thực tế.
- Sử dụng **Postman** để kiểm tra các yêu cầu HTTP và phản hồi từ API.

### 📚 Nội dung thực hành

| Bài | Tên bài thực hành | Mô hình / Công nghệ |
|---|---|---|
| **01** | Hiển thị mã nguồn HTML của website | HTTP GET, `WebRequest`, `WebResponse` |
| **02** | Download nội dung website thành file HTML | `WebClient`, `DownloadFile()` |
| **03** | Xây dựng trình duyệt Web cơ bản | `WebView2`, HTML Agility Pack |
| **04** | Quản lý phòng vé – Phiên bản 4 | Web Scraping, JSON, Windows Forms |
| **07** | Hôm nay ăn gì? – Phiên bản 4 | REST API, quản lý và chọn ngẫu nhiên món ăn |

### 🛠️ Công nghệ sử dụng

- **Ngôn ngữ lập trình:** C#
- **Nền tảng:** .NET, Windows Forms
- **IDE:** Microsoft Visual Studio
- **Giao thức:** HTTP/HTTPS
- **Web Server:** IIS, localhost
- **Thư viện:** `System.Net`, `System.IO`, `System.Net.Http`
- **Web Browser:** Microsoft Edge WebView2
- **Xử lý HTML:** HTML Agility Pack
- **Định dạng dữ liệu:** HTML, JSON
- **Quản lý mã nguồn:** Git, GitHub

---

## 📄 BÀI 1 – HIỂN THỊ MÃ NGUỒN HTML (VIEW HTML SOURCE)

### 🖼️ Giao diện chương trình

**Giao diện View HTML Source**

<p align="center">

<img width="796" height="515" alt="ẢNH BÀI 1" src="https://github.com/user-attachments/assets/242a41ea-2ebe-42eb-9895-8809d4e919d2" />
   
</p>

### 🎯 Nội dung thực hành

- Xây dựng ứng dụng **C# Windows Forms** để lấy và hiển thị mã nguồn HTML của website.
- Sử dụng **HTTP/HTTPS** và phương thức **GET** để giao tiếp với Web Server.
- Sử dụng `WebRequest`, `WebResponse`, `Stream` và `StreamReader` để gửi yêu cầu, nhận và đọc dữ liệu.
- Kiểm tra tính hợp lệ của URL và xử lý lỗi kết nối.
- Hiển thị HTML trong `RichTextBox`, hỗ trợ tự động xuống dòng và thanh cuộn dọc.

### 🛠️ Cách thức thực hiện

**1. Khởi tạo giao diện (`Bai01Form`)**

- Khởi tạo Windows Forms bằng `InitializeComponent()`.
- Sử dụng `txtURL` để nhập địa chỉ website.
- Sử dụng `btnGET` để thực hiện yêu cầu lấy HTML.
- Sử dụng `rtbHTML` để hiển thị nội dung nhận được.
- Thiết lập `WordWrap = true`, `ScrollBars = Vertical` và `ReadOnly = true` cho `rtbHTML`.

**2. Xử lý sự kiện GET (`btnGET_Click()`)**

- Khi người dùng nhấn **GET**, sự kiện `btnGET_Click()` được kích hoạt.
- Lấy URL bằng `txtURL.Text.Trim()`.
- Kiểm tra URL rỗng bằng `string.IsNullOrEmpty()`.
- Kiểm tra định dạng URL bằng `Uri.TryCreate()` và giao thức bằng `uri.Scheme`.
- Chỉ chấp nhận URL sử dụng **HTTP/HTTPS**.
- Nếu hợp lệ, gọi hàm `getHTML(url)` để lấy dữ liệu.
- Xóa nội dung cũ và hiển thị HTML mới trong `rtbHTML`.

**3. Gửi yêu cầu HTTP GET (`getHTML()`)**

- Sử dụng `WebRequest.Create(szURL)` để khởi tạo HTTP Request.
- Thiết lập `request.Timeout = 10000` để giới hạn thời gian chờ 10 giây.
- Gọi `GetResponse()` để nhận phản hồi từ Web Server.
- Sử dụng `GetResponseStream()` để lấy luồng dữ liệu.
- Sử dụng `StreamReader.ReadToEnd()` để đọc toàn bộ HTML thành chuỗi.
- Sử dụng `using` để tự động giải phóng tài nguyên sau khi xử lý.

**4. Hiển thị kết quả và xử lý lỗi**

- Gán nội dung HTML bằng `rtbHTML.Text = html`.
- Sử dụng `SelectionStart = 0` và `ScrollToCaret()` để đưa nội dung về đầu.
- Hỗ trợ xuống dòng tự động và thanh cuộn dọc.
- Sử dụng `try-catch` để xử lý các lỗi phát sinh.
- Sử dụng `WebException` để bắt lỗi liên quan đến kết nối Web Server.
- Hiển thị thông báo lỗi bằng `MessageBox.Show()`.

### 📡 Giao thức trao đổi dữ liệu

| Thành phần | Chức năng |
|---|---|
| `HTTP GET` | Yêu cầu lấy nội dung website |
| `WebRequest` | Tạo và gửi HTTP Request |
| `WebResponse` | Nhận HTTP Response |
| `StreamReader` | Đọc dữ liệu HTML |
| `RichTextBox` | Hiển thị mã nguồn HTML |

**Quy trình xử lý:**

1. Người dùng nhập URL và nhấn **GET**.
2. Chương trình kiểm tra tính hợp lệ của URL.
3. Client gửi HTTP GET Request đến Web Server.
4. Web Server xử lý yêu cầu và trả về HTTP Response.
5. Client sử dụng `StreamReader` để đọc nội dung HTML.
6. Hiển thị mã nguồn HTML lên `rtbHTML`.

**Sơ đồ hoạt động:**

```text
Người dùng
    |
    v
Nhập URL (txtURL)
    |
    v
Nhấn GET (btnGET_Click)
    |
    v
Kiểm tra URL hợp lệ
    |
    v
WebRequest -> Web Server
    |
    v
WebResponse -> StreamReader
    |
    v
Hiển thị HTML (rtbHTML)
```

### ▶️ Hướng dẫn sử dụng

1. Mở solution `Lab04` bằng Microsoft Visual Studio.
2. Chọn project `Bai01` làm **Startup Project**.
3. Nhấn `Ctrl + Shift + B` để Build Solution.
4. Nhấn `F5` để chạy chương trình.
5. Nhập URL, ví dụ `https://example.com`.
6. Nhấn **GET** để lấy nội dung HTML.
7. Xem mã nguồn trong `rtbHTML` và cuộn dọc khi cần.
8. Nhập URL mới và nhấn GET để cập nhật nội dung.

> [!NOTE]
> Chương trình hiển thị mã nguồn HTML dưới dạng văn bản, không render thành giao diện website.

---

