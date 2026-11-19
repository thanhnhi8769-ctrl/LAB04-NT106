# Quản lý phòng vé - Phiên bản số 4

Ứng dụng WinForms (C#) hỗ trợ nhân viên đặt vé xem phim cho khách hàng.
Danh sách phim được **lấy từ website Beta Cinemas** (https://betacinemas.vn/phim.htm),
tóm tắt và **lưu dưới dạng JSON**. Kế thừa ý tưởng từ Bài 5 (bài thực hành số 2).

## Chức năng

- **Lấy dữ liệu từ website**: tải trang danh sách phim, trích xuất tên, poster, đường link, thể loại, thời lượng và mô tả của từng phim.
- **ProgressBar** hiển thị tiến trình trích xuất, kèm dòng trạng thái cho biết phim đang xử lý.
- **Lưu JSON**: kết quả ghi vào `phim.json`. Lần sau mở lại, ứng dụng tự đọc file này, không cần tải lại.
- **Xem chi tiết phim**: bấm vào banner (poster), tên hoặc link của một phim để mở trang phim đó trên website, ngay trong ứng dụng (WebView2).
- **Đặt vé**: chọn phòng chiếu, chọn ghế, tổng tiền cập nhật ngay; thanh toán xong hiện hóa đơn gồm thông tin khách hàng, phim, ghế và tiền.
- **Chống đặt trùng ghế**: việc đặt vé đi qua một TCP Server nội bộ, ghế đã đặt chuyển sang màu đỏ ở mọi cửa sổ đang mở.
- **Quản lý hệ thống (Admin)**: đăng nhập bằng mật khẩu, xuất thống kê (vé đã bán, vé tồn, tỉ lệ bán, doanh thu, xếp hạng) và ghi ra `output5.txt`.

## Công nghệ

| Thành phần | Sử dụng |
|---|---|
| Ngôn ngữ / nền tảng | C#, .NET (WinForms), `net10.0-windows` |
| Lấy dữ liệu web | `HttpClient`, `Regex` |
| Lưu trữ | `System.Text.Json` (`phim.json`), file văn bản (`input5.txt`, `Lab03_Bai04_Seats.txt`, `output5.txt`) |
| Hiển thị trang web | `Microsoft.Web.WebView2` (NuGet) |
| Đặt vé đồng thời | `TcpListener` / `TcpClient`, cổng **9090** |

## Yêu cầu môi trường

- Windows 10/11
- Visual Studio với workload **.NET desktop development**
- Gói NuGet **Microsoft.Web.WebView2** (cài vào project LAB04)
- Máy có **kết nối Internet** ở lần lấy dữ liệu phim đầu tiên
- Cổng **9090** còn trống (kiểm tra bằng `netstat -ano | findstr :9090`)

## Cách chạy

1. Mở solution trong Visual Studio.
2. Cài gói NuGet: **Tools → NuGet Package Manager → Manage NuGet Packages**, tìm `Microsoft.Web.WebView2` và cài vào project **LAB04** (hoặc chạy `Install-Package Microsoft.Web.WebView2` trong Package Manager Console).
3. **Build → Rebuild Solution**, sau đó nhấn **F5**.

## Hướng dẫn sử dụng

1. Ở màn hình đầu, nhập **tên khách hàng**, bấm **Chọn phim đang chiếu (Beta Cinemas)**.
2. Bấm **Lấy dữ liệu từ website** (lần đầu). ProgressBar chạy đến 100%, danh sách phim hiện ra và `phim.json` được tạo.
3. Bấm vào poster, tên hoặc link của một phim để xem **thông tin chi tiết** trên website.
4. Bấm **Đặt vé** ở phim muốn đặt: chọn phòng chiếu, chọn ghế (ghế xanh là đang chọn), bấm **Thanh Toán**. Hóa đơn hiện ngay và ghế chuyển sang màu đỏ.
5. Vào **Quản lý hệ thống**, nhập mật khẩu, bấm **Xuất thống kê** để xem doanh thu; bấm **Ghi File** để lưu ra `output5.txt`.

Mật khẩu quản trị mặc định: `admin123`.

## Bảng giá ghế

Giá mỗi ghế = giá vé chuẩn × hệ số:

| Ghế | Hệ số |
|---|---|
| A1, A5, C1, C5 | 0,25 |
| B2, B3, B4 | 2,0 |
| Các ghế còn lại | 1,0 |

Giá vé chuẩn của phim lấy từ website mặc định là **45.000 VNĐ** (trường `GiaVeChuan` trong `phim.json`, có thể sửa tay).

## Cấu trúc mã nguồn

| File | Vai trò |
|---|---|
| `Program.cs` | Khởi động TCP Server rồi mở màn hình chính |
| `Lab04_Bai04.cs` | Màn hình chính: nhập tên khách hàng, vào danh sách phim, vào Admin |
| `Lab04_Bai04_PhimOnline.cs` | Lấy dữ liệu từ website (`PhimScraper`), đọc/ghi JSON, lớp `PhimOnline` |
| `Lab04_Bai04_DanhSachPhim.cs` | Danh sách phim, ProgressBar, trang chi tiết phim (WebView2) |
| `Lab04_Bai04_BookingForm.cs` | Chọn ghế, tính tiền, thanh toán, hóa đơn |
| `Lab04_Bai04_Server.cs` | TCP Server quản lý ghế đã đặt, chống đặt trùng |
| `Lab04_Bai04_PasswordForm.cs` | Màn hình đăng nhập quản trị |
| `Lab04_Bai04_AdminForm.cs` | Thống kê doanh thu và xuất file |
| `Lab04_Bai04_ThongKePhim.cs` | Lớp dữ liệu thống kê |

## Các file dữ liệu (sinh ra cạnh file .exe)

| File | Nội dung |
|---|---|
| `phim.json` | Danh sách phim lấy từ website |
| `Lab03_Bai04_Seats.txt` | Ghế đã đặt theo từng phim và phòng (do Server lưu) |
| `input5.txt` | Số vé đã bán theo phim, phòng (dùng cho thống kê) |
| `output5.txt` | Kết quả thống kê do Admin ghi ra |
| `debug_phim.html` | Chỉ sinh ra khi không tách được phim nào, dùng để kiểm tra cấu trúc trang |

Muốn **demo lại từ đầu**: đóng ứng dụng, xóa `input5.txt` và `Lab03_Bai04_Seats.txt`.

## Xử lý sự cố

| Hiện tượng | Cách xử lý |
|---|---|
| "Không thể kết nối đến Server Port 9090" / "Server không phản hồi" | Cổng 9090 đang bị chiếm hoặc Server chưa chạy. Đóng mọi bản ứng dụng cũ, kiểm tra bằng `netstat -ano \| findstr :9090`, hoặc đổi số cổng trong `Server.cs`, `BookingForm.cs`, `Program.cs` |
| "Không tìm thấy phim nào" | Website có thể đổi cấu trúc. Mở `debug_phim.html` bằng Notepad để xem HTML và chỉnh hàm `TachPhim` trong `Lab04_Bai04_PhimOnline.cs` |
| Lỗi lấy dữ liệu | Kiểm tra kết nối mạng, thử lại |
| Cửa sổ chi tiết phim báo lỗi WebView2 | Cài gói NuGet `Microsoft.Web.WebView2` và WebView2 Runtime; nếu không mở được, ứng dụng tự mở bằng trình duyệt mặc định |
| Build lỗi `MSB3552` (thiếu file ảnh) | Khai báo trong `Resources.resx` trỏ tới ảnh không còn trong thư mục `Resources`. Xóa mục ảnh thiếu hoặc chép lại ảnh |
| Popup "Tỉnh/Thành phố, Tên rạp" trên trang chi tiết | Là popup của website, bấm X để tắt |

## Ghi chú

- Dữ liệu phim phụ thuộc vào cấu trúc HTML hiện tại của website; nếu website thay đổi, cần chỉnh lại phần trích xuất.
- Cột **Doanh thu** ở màn hình Admin tính theo `số vé × giá vé chuẩn`, chưa tính hệ số theo từng ghế nên có thể khác tổng tiền trên hóa đơn.
