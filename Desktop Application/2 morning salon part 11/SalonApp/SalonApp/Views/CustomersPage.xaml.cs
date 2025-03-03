using System;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;

namespace SalonApp.Views
{
    public partial class CustomersPage : UserControl
    {
        private ObservableCollection<Customer> CustomerList = new ObservableCollection<Customer>();
        private string connectionString = "Data Source=C:\\Users\\ACER\\Desktop\\SalonDatabase.db;Version=3;";


        public CustomersPage()
        {
            InitializeComponent();
            CustomerList = new ObservableCollection<Customer>();
            CustomerListTable.ItemsSource = CustomerList;
            LoadCustomers();
        }
        
        private void LoadCustomers()
        {
            CustomerList.Clear();
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM CustomerList";
                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CustomerList.Add(new Customer
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            CustomerName = reader["CustomerName"].ToString(),
                            NIC = reader["NIC"].ToString(),
                            Phone = reader["Phone"].ToString(),
                            Email = reader["Email"].ToString(),
                        });
                    }
                }
            }
        }


        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO CustomerList (CustomerName, NIC, Phone, Email) VALUES (@CustomerName, @NIC, @Phone, @Email)";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                    command.Parameters.AddWithValue("@NIC", txtNIC.Text);
                    command.Parameters.AddWithValue("@Phone", txtPhone.Text);
                    command.Parameters.AddWithValue("@Email", txtEmail.Text);

                    command.ExecuteNonQuery();
                }
            }
            LoadCustomers();
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                if (textBox == txtCustomerName) placeholderName.Visibility = Visibility.Collapsed;
                else if (textBox == txtNIC) placeholderNIC.Visibility = Visibility.Collapsed;
                else if (textBox == txtPhone) placeholderPhone.Visibility = Visibility.Collapsed;
                else if (textBox == txtEmail) placeholderEmail.Visibility = Visibility.Collapsed;
            }
        }
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                if (textBox == txtCustomerName) placeholderName.Visibility = Visibility.Visible;
                else if (textBox == txtNIC) placeholderNIC.Visibility = Visibility.Visible;
                else if (textBox == txtPhone) placeholderPhone.Visibility = Visibility.Visible;
                else if (textBox == txtEmail) placeholderEmail.Visibility = Visibility.Visible;
            }
        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerListTable.SelectedItem is Customer selectedCustomer)
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE CustomerList SET Name=@customername, NIC=@nic, Phone=@phone, Email=@email, WHERE ID=@id";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", selectedCustomer.ID);
                        command.Parameters.AddWithValue("@name", selectedCustomer.CustomerName);
                        command.Parameters.AddWithValue("@nic", selectedCustomer.NIC);
                        command.Parameters.AddWithValue("@time", selectedCustomer.Phone);
                        command.Parameters.AddWithValue("@date", selectedCustomer.Email);
                        command.ExecuteNonQuery();
                    }
                }
                LoadCustomers();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerListTable.SelectedItem is Customer selectedCustomer)
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM CustomerList WHERE ID=@id";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", selectedCustomer.ID);
                        command.ExecuteNonQuery();
                    }
                }
                LoadCustomers();
            }
        }
    }

    public class Customer
    {
        public int ID { get; set; }
        public string CustomerName { get; set; }
        public string NIC { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
