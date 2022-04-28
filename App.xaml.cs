using System.Windows;

namespace BioReviewGame
{
    public partial class App : Application
    {
        public static MainWindow window = new MainWindow();
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            window.Show();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            Game.StopThread();
        }
    }
}
