using LAB03;

namespace LAB4
{
    internal static class Program
    {
        // Đặt false khi đã chạy ổn để tắt hộp thoại chẩn đoán
        private const bool HIEN_CHAN_DOAN = true;

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            if (Lab04_Bai04_Server.LaMayChu)
            {
                Lab04_Bai04_Server.StartServer();
                System.Threading.Thread.Sleep(700);   // chờ Server khởi động
            }

            if (HIEN_CHAN_DOAN)
            {
                MessageBox.Show(
                    "ServerIp = " + Lab04_Bai04_Server.ServerIp +
                    "\nLaMayChu = " + Lab04_Bai04_Server.LaMayChu +
                    "\nServer dang nghe cong " + Lab04_Bai04_Server.Port + " = " + Lab04_Bai04_Server.DaNghe +
                    "\nLoi = " + (Lab04_Bai04_Server.LoiKhoiDong ?? "(khong co)"),
                    "Chan doan Server");
            }
            else if (Lab04_Bai04_Server.LoiKhoiDong != null)
            {
                MessageBox.Show(
                    "Không mở được Server cổng 9090:\n" + Lab04_Bai04_Server.LoiKhoiDong,
                    "Cảnh báo Server", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            Application.Run(new Lab04_Bai04());
        }
    }
}