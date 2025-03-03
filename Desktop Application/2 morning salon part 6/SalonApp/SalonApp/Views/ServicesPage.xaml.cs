using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SalonApp.Views
{
    public partial class ServicesPage : UserControl
    {
        public ServicesPage()
        {
            InitializeComponent();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string query = txtSearch.Text.ToLower();

            // Loop through each service card and update visibility
            foreach (UIElement child in ServiceContainer.Children)
            {
                if (child is Border serviceCard)
                {
                    // Retrieve the Tag (which holds the service title)
                    string serviceTitle = serviceCard.Tag?.ToString().ToLower() ?? "";

                    // Check if the service title contains the search query
                    serviceCard.Visibility = serviceTitle.Contains(query) ? Visibility.Visible : Visibility.Collapsed;
                }
            }
        }
    }
}

