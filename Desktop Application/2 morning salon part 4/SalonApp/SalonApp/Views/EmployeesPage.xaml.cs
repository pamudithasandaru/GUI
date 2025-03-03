using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;

namespace SalonApp.Views
{
    public partial class EmployeesPage : UserControl
    {
        private ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
        private string connectionString = "Data Source=C:\\Users\\ACER\\Desktop\\SalonDatabase.db;Version=3;";

        public EmployeesPage()
        {
            InitializeComponent();
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            employees.Clear();
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Employee";
                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        employees.Add(new Employee
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            Name = reader["Name"].ToString(),
                            BasicSalary = Convert.ToDouble(reader["BasicSalary"]),
                            OTHours = Convert.ToDouble(reader["OTHours"]),
                            FullSalary = Convert.ToDouble(reader["FullSalary"])
                        });
                    }
                }
            }
            employeeTable.ItemsSource = employees;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            if (!double.TryParse(txtBasicSalary.Text, out double basicSalary) ||
                !double.TryParse(txtOTHours.Text, out double otHours))
            {
                MessageBox.Show("Invalid input for salary or OT hours.");
                return;
            }

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Employee (Name, BasicSalary, OTHours) VALUES (@Name, @BasicSalary, @OTHours)";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@BasicSalary", basicSalary);
                    command.Parameters.AddWithValue("@OTHours", otHours);
                    command.ExecuteNonQuery();
                }
            }
            LoadEmployees();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (employeeTable.SelectedItem is Employee selectedEmployee)
            {
                if (!double.TryParse(txtBasicSalary.Text, out double basicSalary) ||
                    !double.TryParse(txtOTHours.Text, out double otHours))
                {
                    MessageBox.Show("Invalid input for salary or OT hours.");
                    return;
                }
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Employee SET Name=@Name, BasicSalary=@BasicSalary, OTHours=@OTHours WHERE ID=@ID";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", selectedEmployee.ID);
                        command.Parameters.AddWithValue("@Name", txtName.Text);
                        command.Parameters.AddWithValue("@BasicSalary", basicSalary);
                        command.Parameters.AddWithValue("@OTHours", otHours);
                        command.ExecuteNonQuery();
                    }
                }
                LoadEmployees();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (employeeTable.SelectedItem is Employee selectedEmployee)
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Employee WHERE ID=@ID";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", selectedEmployee.ID);
                        command.ExecuteNonQuery();
                    }
                }
                LoadEmployees();
            }
        }
    }

    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double BasicSalary { get; set; }
        public double OTHours { get; set; }
        public double FullSalary { get; set; }
    }
}

