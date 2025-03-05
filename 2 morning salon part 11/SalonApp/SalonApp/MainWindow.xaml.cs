using System;
using System.Windows;
using System.Windows.Controls;
using SalonApp.Views;

namespace SalonApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }
        
        
        // Navigation Button Click Events
        private void Customers_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new CustomersPage();
        }

        private void Bookings_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new BookingsPage();
        }

        private void Employees_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new EmployeesPage();
        }

        private void Services_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new ServicesPage();
        }

        // Sign Out
        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You have signed out.");
            // Redirect to login window (if applicable)
        }

        // Exit Application
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
