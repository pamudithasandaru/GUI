using System.Configuration;
using System.Data;
using System.Windows;

namespace SalonApp
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            SplashScreen splashScreen = new SplashScreen();
            splashScreen.Show();
        }
    }

}
