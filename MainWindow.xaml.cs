using MaryDinerCalculator.Model;
using MaryDinerCalculator.ViewModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace MaryDinerCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MaryDinerViewModel();
      

        }


        private MaryDinerViewModel?ViewModel => DataContext as MaryDinerViewModel;

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            if (comboBox.SelectedItem is FoodItem selectedItem)
            {
                AddOrUpdateItemInBill(selectedItem);
            }
        }

        private void AddOrUpdateItemInBill(FoodItem item)
        {
            var existingItem = ViewModel.BillItems.FirstOrDefault(fi => fi.Name == item.Name);
            if (existingItem != null)
            {
                // If item exists, just update the quantity
                existingItem.Quantity++;
            }
            else
            {
                // If item doesn't exist, add a new one
              ViewModel.BillItems.Add(new FoodItem
                {
                    Name = item.Name,
                    Price = item.Price,
                    Quantity = 1 , // Initial quantity
                    Category = item.Category,   
                });
            }
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var item = button.DataContext as FoodItem;
            if (item != null)
            {
                // Assuming BillItems is your collection bound to the DataGrid
               ViewModel.BillItems.Remove(item);
            }
        }
        private void AddBill_Click(object sender, RoutedEventArgs e)
        {
            decimal subtotal = 0;
            const decimal taxRate = 0.08m; // Example tax rate of 8%

            // Calculate subtotal
            foreach (var item in ViewModel.BillItems)
            {
                subtotal += item.Price * item.Quantity;
            }

            // Calculate tax and total
            decimal tax = subtotal * taxRate;
            decimal total = subtotal + tax;

            // Update UI
            txtSubtotal.Text = $"Subtotal: ${subtotal:F2}";
            txtTax.Text = $"Tax: ${tax:F2}";
            txtTotal.Text = $"Total: ${total:F2}";
        }
        private void ClearBill_Click(object sender, RoutedEventArgs e)
        {
            // Assuming you have a ViewModel named 'viewModel' and it has a collection 'BillItems'
            ViewModel.BillItems.Clear();

            // Reset the subtotal, tax, and total text blocks
            txtSubtotal.Text = "Subtotal: $0.00";
            txtTax.Text = "Tax: $0.00";
            txtTotal.Text = "Total: $0.00";
        }
        private void Logo_Click(object sender, RoutedEventArgs e)
        {
            
            string url = "https://www.centennialcollege.ca/";
            string chromePath = @"C:\Program Files\Google\Chrome\Application\chrome.exe";

            System.Diagnostics.Process.Start(chromePath, url);
        }


    }
}
