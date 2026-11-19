using LAB03;

namespace LAB4
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            Lab04_Bai04_Server.StartServer();
            System.Threading.Thread.Sleep(500);   // chờ Server khởi động

            if (Lab04_Bai04_Server.LoiKhoiDong != null)
            {
                MessageBox.Show(
                    "Không mở được Server cổng 9090:\n" + Lab04_Bai04_Server.LoiKhoiDong +
                    "\n\nCó thể app cũ (hoặc bài Lab trước) vẫn đang chạy và chiếm cổng 9090.",
                    "Cảnh báo Server", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            Application.Run(new Lab04_Bai04());
        }
    }
}