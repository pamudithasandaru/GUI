using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SalonApp.Views
{
    public partial class ServicesPage : UserControl
    {
        private double totalCharge = 0;

        public ServicesPage()
        {
            InitializeComponent();
        }

        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                DependencyObject parent = button;
                while (parent != null && !(parent is Border))
                {
                    parent = VisualTreeHelper.GetParent(parent);
                }

                if (parent is Border serviceCard)
                {
                    TextBlock priceTextBlock = FindPriceTextBlock(serviceCard);
                    if (priceTextBlock != null)
                    {
                        double price = ExtractPriceFromText(priceTextBlock.Text);
                        totalCharge += price;
                        UpdateTotalChargeDisplay();
                    }
                }
            }
        }

        private TextBlock FindPriceTextBlock(Border serviceCard)
        {
            if (serviceCard.Child is StackPanel stackPanel)
            {
                foreach (var child in stackPanel.Children)
                {
                    if (child is StackPanel innerStackPanel)
                    {
                        foreach (var innerChild in innerStackPanel.Children)
                        {
                            if (innerChild is TextBlock textBlock && textBlock.Text.Contains("SEASONAL OFFER"))
                            {
                                return textBlock;
                            }
                        }
                    }
                }
            }
            return null;
        }

        private double ExtractPriceFromText(string priceText)
        {
            Match match = Regex.Match(priceText, @"(\d+)(?=\$)");
            return match.Success ? double.Parse(match.Value, CultureInfo.InvariantCulture) : 0;
        }

        private void UpdateTotalChargeDisplay()
        {
            txtTotalCharge.Text = $"Total Charge: ${totalCharge:F2}";
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string query = txtSearch.Text.ToLower();

            foreach (UIElement child in ServiceContainer.Children)
            {
                if (child is Border serviceCard)
                {
                    string serviceTitle = serviceCard.Tag?.ToString().ToLower() ?? "";
                    serviceCard.Visibility = serviceTitle.Contains(query) ? Visibility.Visible : Visibility.Collapsed;
                }
            }
        }

        private void txtSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtSearch.Text == "Search Services...")
            {
                txtSearch.Text = "";
                txtSearch.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void txtSearch_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Search Services...";
                txtSearch.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
    }
}
