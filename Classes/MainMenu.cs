using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// Instantiates program to run at main menu
    /// </summary>
    public class MainMenu
    {
        public void Run(VendingMachine vendingMachine)
        {
            while (true)
            {
                Console.WriteLine("1. Display Vending Machine Items.");
                Console.WriteLine("2. Purchase Item(s)");
                Console.WriteLine("Q  Quit");
                Console.Write("Choice: ");
                string choice = Console.ReadLine();
                Console.WriteLine();

                if (choice == "1")
                {
                    // Display read in inventory
                    Console.Clear();
                    vendingMachine.DisplayItems();
                }
                else if (choice == "2")
                {
                    // instantiate purchase menu and pass vendingMachine object
                    PurchaseMenu purchaseMenu = new PurchaseMenu();
                    purchaseMenu.Run(vendingMachine);
                }
                else if (choice.ToLower() == "q")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Not a valid choice, please try again.");
                    Console.WriteLine();
                }
            }

            // computing total sale resport for life cycle of instantiated vending machine
            vendingMachine.TotalSalesReport();
        }
    }
}
