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

namespace Programming_122_Lecture_9_Radio_CheckBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Preload();
        }

        void Preload()
        {
            rbSmall.IsChecked = true;
            rbDrinkSmall.IsChecked = true;
        }

        private void btnCheckBoxResult_Click(object sender, RoutedEventArgs e)
        {
            // checkbox name, .IsChecked.Value
            bool isChecked = ckFirstCheckBox.IsChecked.Value;

            MessageBox.Show(isChecked.ToString());
        }

        private void btnOrderPizza_Click(object sender, RoutedEventArgs e)
        {
            runReciept.Text = txtCustomerName.Text + "\n";
            double amount = 0;

            bool hasPepperoni = ckPepperoni.IsChecked.Value;
            bool hasExtraCheese = ckCheese.IsChecked.Value;
            bool hasMushrooms = ckMushRooms.IsChecked.Value;
            bool hasPineapple = ckPineapple.IsChecked.Value;

            bool sizeSmall = rbSmall.IsChecked.Value;
            bool sizeMedium = rbMedium.IsChecked.Value;
            bool sizeLarge = rbLarge.IsChecked.Value;
            bool sizeExtraLarge = rbExtraLarge.IsChecked.Value;

            bool drinkSmall = rbDrinkSmall.IsChecked.Value;
            bool drinkMedium = rbDrinkMedium.IsChecked.Value;
            bool drinkLarge = rbDrinkLarge.IsChecked.Value;
            bool drinkXL = rbDrinkExtraLarge.IsChecked.Value;

            double price = 0;
            // Check for pizza size
            if (sizeSmall)
            {
                price = 13;
                runReciept.Text += "Small";
            } 
            else if (sizeMedium)
            {
                price = 15;
                runReciept.Text += "Medium";

            }
            else if (sizeLarge)
            {
                price = 18;
                runReciept.Text += "Large";

            }
            else if (sizeExtraLarge)
            {
                runReciept.Text += "Extra Large";
                price = 20;

            }

            
            runReciept.Text += " - " + price.ToString("c");
            amount += price;

            runReciept.Text += "\nToppings: \n";

            if(hasPepperoni == true)
            {
                double toppingPrice = 4;
                runReciept.Text += $"Pepperoni - {toppingPrice.ToString("c")}\n";
                amount += toppingPrice;
            }

            if(hasExtraCheese)
            {
                double toppingPrice = 5;
                runReciept.Text += $"Extra Cheese - {toppingPrice.ToString("c")}\n";
                amount += toppingPrice;
            }

            if (hasMushrooms)
            {
                double toppingPrice = 2;
                runReciept.Text += $"Mushrooms - {toppingPrice.ToString("c")}\n";
                amount += toppingPrice;
                
            }

            if (hasPineapple)
            {
                double toppingPrice = 20;
                runReciept.Text += $"Pineapple - {toppingPrice.ToString("c")}\n";
                amount += toppingPrice;
            }


            // CHeck for drink size'
            runReciept.Text += "\nDrink Size: ";

            if (drinkSmall)
            {
                double drinkPrice = 2;
                runReciept.Text += $"Small Drink - {drinkPrice.ToString("c")}\n";
                amount += drinkPrice;
            }
            else if (drinkMedium)
            {
                double drinkPrice = 2.69;
                runReciept.Text += $"Medium Drink - {drinkPrice.ToString("c")}\n";
                amount += drinkPrice;
            }
            else if (drinkLarge)
            {
                double drinkPrice = 3.25;
                runReciept.Text += $"Large Drink - {drinkPrice.ToString("c")}\n";
                amount += drinkPrice;
            }
            else if (drinkXL)
            {
                double drinkPrice = 7.50;
                //runReciept.Text += $"XL Drink - {drinkPrice.ToString("c")}\n";
                FormatItem("XL Drink", drinkPrice);
                amount += drinkPrice;
            }

            double taxAmount = .1;
            double calculatedTax = amount * taxAmount;
            double totalAmount = amount + calculatedTax;



            runReciept.Text += $"\n\n" +
                $"Subtotal: {amount.ToString("c")}\n" +
                $"Tax Amount: {calculatedTax.ToString("c")}\n" +
                $"Total Price: {totalAmount.ToString("c")} ";

        }

        public string FormatItem(string item, double amount)
        {

            return $"{item} - {amount.ToString("c")}\n";

        }
    }
}
