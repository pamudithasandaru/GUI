using System;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;

namespace SalonApp.Views
{
    public partial class BookingsPage : UserControl
    {
        private ObservableCollection<Booking> bookings = new ObservableCollection<Booking>();
        private string connectionString = "Data Source=C:\\Users\\ACER\\Desktop\\SalonDatabase.db;Version=3;";


        public BookingsPage()
        {
            InitializeComponent();
            bookings = new ObservableCollection<Booking>();
            bookingsTable.ItemsSource = bookings;
            LoadBookings();
        }

        private void LoadBookings()
        {
            bookings.Clear();
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Bookings";
                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bookings.Add(new Booking
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            Name = reader["Name"].ToString(),
                            NIC = reader["NIC"].ToString(),
                            BookingTime = reader["BookingTime"].ToString(),
                            BookingDate = reader["BookingDate"].ToString(),
                            Phone = reader["Phone"].ToString(),
                            Service = reader["Service"].ToString()
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
                string query = "INSERT INTO Bookings (Name, NIC, BookingTime, BookingDate, Phone, Service) VALUES (@Name, @NIC, @BookingTime, @BookingDate, @Phone, @Service)";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", txtName.Text);
                    command.Parameters.AddWithValue("@NIC", txtNIC.Text);
                    command.Parameters.AddWithValue("@BookingTime", txtTime.Text);
                    command.Parameters.AddWithValue("@BookingDate", txtDate.Text);
                    command.Parameters.AddWithValue("@Phone", txtPhone.Text);
                    command.Parameters.AddWithValue("@Service", txtService.Text);

                    command.ExecuteNonQuery();
                }
            }
            LoadBookings();
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                if (textBox == txtName) placeholderName.Visibility = Visibility.Collapsed;
                else if (textBox == txtNIC) placeholderNIC.Visibility = Visibility.Collapsed;
                else if (textBox == txtTime) placeholderTime.Visibility = Visibility.Collapsed;
                else if (textBox == txtDate) placeholderDate.Visibility = Visibility.Collapsed;
                else if (textBox == txtPhone) placeholderPhone.Visibility = Visibility.Collapsed;
                else if (textBox == txtService) placeholderService.Visibility = Visibility.Collapsed;
            }
        }
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                if (textBox == txtName) placeholderName.Visibility = Visibility.Visible;
                else if (textBox == txtNIC) placeholderNIC.Visibility = Visibility.Visible;
                else if (textBox == txtTime) placeholderTime.Visibility = Visibility.Visible;
                else if (textBox == txtDate) placeholderDate.Visibility = Visibility.Visible;
                else if (textBox == txtPhone) placeholderPhone.Visibility = Visibility.Visible;
                else if (textBox == txtService) placeholderService.Visibility = Visibility.Visible;
            }
        }


        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (bookingsTable.SelectedItem is Booking selectedBooking)
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Bookings SET Name=@name, NIC=@nic, BookingTime=@time, BookingDate=@date, Phone=@phone, Service=@service WHERE ID=@id";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", selectedBooking.ID);
                        command.Parameters.AddWithValue("@name", selectedBooking.Name);
                        command.Parameters.AddWithValue("@nic", selectedBooking.NIC);
                        command.Parameters.AddWithValue("@time", selectedBooking.BookingTime);
                        command.Parameters.AddWithValue("@date", selectedBooking.BookingDate);
                        command.Parameters.AddWithValue("@phone", selectedBooking.Phone);
                        command.Parameters.AddWithValue("@service", selectedBooking.Service);
                        command.ExecuteNonQuery();
                    }
                }
                LoadBookings();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (bookingsTable.SelectedItem is Booking selectedBooking)
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Bookings WHERE ID=@id";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", selectedBooking.ID);
                        command.ExecuteNonQuery();
                    }
                }
                LoadBookings();
            }
        }
    }

    public class Booking
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string NIC { get; set; }
        public string BookingTime { get; set; }
        public string BookingDate { get; set; }
        public string Phone { get; set; }
        public string Service { get; set; }
    }
}
