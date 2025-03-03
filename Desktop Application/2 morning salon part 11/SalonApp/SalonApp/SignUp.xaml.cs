using System.Windows;

namespace SalonApp
{
    public partial class SignUp : Window
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            string username = txtNewUsername.Text;
            string password = txtNewPassword.Password;
            string confirmPassword = txtConfirmPassword.Password;

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBox.Show("Account Created Successfully!");
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}
