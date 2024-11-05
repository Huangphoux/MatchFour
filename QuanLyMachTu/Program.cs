namespace QuanLyMachTu
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Uncomment this line to enable login
            Application.Run(new LoginWindow());

            Application.Run(new MainWindow());
        }
    }
}