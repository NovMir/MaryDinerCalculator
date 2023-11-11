using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaryDinerCalculator.Model
{
    public class FoodItem : INotifyPropertyChanged
    {
        private uint _quantity;
        public string Category { get; set; } // Beverage, Appetizer, Main Course, Dessert
        public string Name { get; set; } // Name of the food item
        public decimal Price { get; set; } // Price of the food item

        public uint Quantity {
            get { return _quantity; }
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    OnPropertyChanged(nameof(Quantity));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
