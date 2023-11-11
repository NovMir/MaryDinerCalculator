using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using MaryDinerCalculator.Model;


namespace MaryDinerCalculator.ViewModel
{
    public class MaryDinerViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<FoodItem> FoodItems { get; set; }

        public ObservableCollection<FoodItem> BillItems { get; private set; }
        public ObservableCollection<FoodItem> Beverages { get; private set; }
        public ObservableCollection<FoodItem> Appetizers { get; private set; }
        public ObservableCollection<FoodItem> MainCourses { get; private set; }
        public ObservableCollection<FoodItem> Desserts { get; private set; }
        public MenuItem _selectedBeverage;
        public MenuItem _selectedAppetizer;
        public MenuItem _selectedMainCourse;
        public MenuItem _selectedDessert;
        public MenuItem SelectedBeverage
        {
            get { return _selectedBeverage; }
            set
            {
                _selectedBeverage = value;
                OnPropertyChanged(nameof(SelectedBeverage));

            }
        }
        public MenuItem SelectedAppetizer
        {
            get { return _selectedAppetizer; ; }
            set
            {
                _selectedAppetizer = value;
                OnPropertyChanged(nameof(SelectedAppetizer));

            }
        }
        public MenuItem SelectedMainCourse
        {

            get { return _selectedMainCourse; }
            set
            {
                _selectedMainCourse = value;
                OnPropertyChanged(nameof(SelectedMainCourse));

            }
        }
        public MenuItem SelectedDessert
        {
            get { return _selectedDessert; }
            set
            {
                _selectedDessert = value;

                OnPropertyChanged(nameof(SelectedDessert));

            }
        }

        public MaryDinerViewModel()
        {
            FoodItems = new ObservableCollection<FoodItem>();
            Beverages = new ObservableCollection<FoodItem>();
            Appetizers = new ObservableCollection<FoodItem>();
            MainCourses = new ObservableCollection<FoodItem>();
            Desserts = new ObservableCollection<FoodItem>();
            BillItems = new ObservableCollection<FoodItem>();
        
        LoadMenuItems();
            PopulateCategoryCollections();
        }

        private void PopulateCategoryCollections()
        {
            foreach (var item in FoodItems)
            {
                switch (item.Category)
                {
                    case "Beverages":
                        Beverages.Add(item);
                        break;
                    case "Appetizer":
                        Appetizers.Add(item);
                        break;
                    case "MainCourse":
                        MainCourses.Add(item);
                        break;
                    case "Desserts":
                        Desserts.Add(item);
                        break;
                }
            }
        }




      

        public void LoadMenuItems()
        {

            FoodItems.Add(new FoodItem { Name = "Coffee", Price = 1.25m, Category="Beverages"});
            FoodItems.Add(new FoodItem { Name = "Tea", Price = 1.50m, Category = "Beverages" });
            FoodItems.Add(new FoodItem { Name = "Soda", Price = 1.95m, Category = "Beverages" });
            FoodItems.Add(new FoodItem { Name = "Water", Price = 2.95m, Category = "Beverages" });
            FoodItems.Add(new FoodItem { Name = "Juice", Price = 2.50m, Category = "Beverages" });
            FoodItems.Add(new FoodItem { Name = "Milk", Price = 1.55m, Category = "Beverages" });

            FoodItems.Add(new FoodItem { Name = "Nachos", Price = 5.00m, Category = "Appetizer" });
            FoodItems.Add(new FoodItem { Name = "Buffalo Wings", Price = 5.95m, Category = "Appetizer" });
            FoodItems.Add(new FoodItem { Name = "Buffalo Fingers", Price = 6.95m, Category = "Appetizer" });
            FoodItems.Add(new FoodItem { Name = "Potato Skins", Price = 8.95m, Category = "Appetizer" });
            FoodItems.Add(new FoodItem { Name = "Mushroom Caps", Price = 10.95m, Category = "Appetizer" });
            FoodItems.Add(new FoodItem { Name = "chips and Salsa", Price = 6.95m, Category = "Appetizer" });
            FoodItems.Add(new FoodItem { Name = "shrimp Cocktail", Price = 12.90m, Category = "Appetizer" });


            FoodItems.Add( new FoodItem { Name = "Seafood alfredo", Price = 15.95m, Category = "MainCourse" });
            FoodItems.Add(new FoodItem { Name = "Chicken alfredo", Price = 13.95m, Category = "MainCourse" });
            FoodItems.Add(new FoodItem { Name = "chicken Picatta", Price = 13.95m, Category = "MainCourse" });
            FoodItems.Add(new FoodItem { Name = "Turkey Club", Price = 11.95m, Category = "MainCourse" });
            FoodItems.Add(new FoodItem { Name = "Lobster Pie", Price = 19.95m, Category = "MainCourse" });
            FoodItems.Add(new FoodItem { Name = "Prime Rib", Price = 20.95m, Category = "MainCourse" });
            FoodItems.Add(new FoodItem { Name = "shrimp scampi", Price = 18.95m, Category = "MainCourse" });
            FoodItems.Add(new FoodItem { Name = "turkey dinner", Price = 13.95m, Category = "MainCourse" });
            FoodItems.Add(new FoodItem { Name = "Stuffed chicken", Price = 14.95m, Category = "MainCourse" });

            FoodItems.Add(new FoodItem { Name = "apple pie", Price = 5.95m, Category ="Desserts" });
            FoodItems.Add(new FoodItem { Name = "sundae", Price = 3.95m, Category = "Desserts" });
            FoodItems.Add(new FoodItem { Name = "Carrot cake", Price = 5.95m, Category = "Desserts" });
            FoodItems.Add(new FoodItem { Name = "mud pie", Price = 4.95m, Category = "Desserts" });
            FoodItems.Add(new FoodItem { Name = "apple crisp", Price = 5.95m, Category = "Desserts" });
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
