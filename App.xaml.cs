using System;
using System.IO;
using System.Windows;

namespace BioReviewGame
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            if (File.Exists($"{Environment.CurrentDirectory}\\DevMode.txt")) 
            {
                DevWindow devWindow = new DevWindow();
                devWindow.Show();
            }
            else
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }
        }
    }
}
