using System;
using System.Threading.Tasks;
using System.Windows;

namespace SalonApp
{
    public partial class SplashScreen : Window
    {
        public SplashScreen()
        {
            InitializeComponent();
            Loaded += SplashScreen_Loaded;
        }

        private async void SplashScreen_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i <= 100; i += 2) // Increment by 2 for a smooth animation
            {
                LoadingBar.Value = i;
                await Task.Delay(100); // Simulate loading time
            }

            await Task.Delay(50); // Short pause before transitioning

            Login loginWindow = new Login();
            loginWindow.Show();
            this.Close();


            //this will be very useful when login  --> signup --->  mainwindow


            /*MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();*/
        }
    }
}

