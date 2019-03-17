using System;
using System.Collections.Generic;
using System.IO;

namespace Capstone.Classes
{
    /// <summary>
    /// creates vending machine
    /// </summary>
    public class VendingMachine
    {
        /// <summary>
        /// Complete inventory on instantiation
        /// </summary>
        public Dictionary<string, Item> Stock = new Dictionary<string, Item>();

        /// <summary>
        /// Used to keep track of and generate report for total sales while vending machine is instantiated
        /// </summary>
        public Dictionary<string, int> TotalSales = new Dictionary<string, int>();

        /// <summary>
        /// All purchased items
        /// </summary>
        public List<Item> Cart = new List<Item>();

        /// <summary>
        /// machine balance
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// item info to be logged after every transation
        /// </summary>
        public string LoggingInfo { get; private set; }

        /// <summary>
        /// Gets and accumulates total value of items purchased in vending machine
        /// </summary>
        public decimal SalesOutput { get; private set; }

        public bool IsValidSlot(string slot)
        {
            return this.Stock.ContainsKey(slot);
        }
        /// <summary>
        /// Initializes new instance of VendingMachine.
        /// </summary>
        public VendingMachine()
        {
            // default with $0 balance
            this.Balance = 0.0M;
            const int Pos_Type = 3;
            // read in inventory file
            using (StreamReader sr = new StreamReader("vendingmachine.csv"))
            {
                // itterate throuhg file line by line creating appropriate subclass with properties
                while (!sr.EndOfStream)
                {
                    // string array of all read in values, one line at a time
                    string[] items = sr.ReadLine().Split("|");

                    // create new subclass item object with read in values (slot location, name, price, type)
                    if (items[Pos_Type] == "Gum")
                    {
                        Item item = new Gum(items[0], items[1], decimal.Parse(items[2]), items[3]);
                        this.Stock[items[0]] = item;
                    }
                    else if (items[3] == "Drink")
                    {
                        Item item = new Drink(items[0], items[1], decimal.Parse(items[2]), items[3]);
                        this.Stock[items[0]] = item;
                    }
                    else if (items[3] == "Chip")
                    {
                        Item item = new Chip(items[0], items[1], decimal.Parse(items[2]), items[3]);
                        this.Stock[items[0]] = item;
                    }
                    else if (items[3] == "Candy")
                    {
                        Item item = new Candy(items[0], items[1], decimal.Parse(items[2]), items[3]);
                        this.Stock[items[0]] = item;
                    }
                }
            }
        }

        /// <summary>
        /// Display Vending Machine items
        /// </summary>
        public void DisplayItems()
        {
            // loop through Stock dictionary that uses the slot location as the key and the item object as the value
            foreach (KeyValuePair<string, Item> kvp in this.Stock)
            {
                string key = kvp.Key;
                Item value = kvp.Value;

                string quantityDisplay = value.Quantity.ToString();
                if (value.Quantity == 0)
                {
                    quantityDisplay = "SOLD OUT";
                }

                Console.WriteLine($"{value.SlotLocationn,-1} {value.Name,-20} Price {value.Price,-8:C2} {value.Type,-7} Available {quantityDisplay}");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Takes bassed bill denomination and adds to current balance
        /// </summary>
        /// <param name="bill">bill</param>
        /// <returns>decimal value of balance with added funds</returns>
        public decimal AddFunds(int bill)
        {
             this.Balance += bill;

             return this.Balance;
        }

        /// <summary>
        /// Allows product selection, balance updated, and quantity of item decremented
        /// </summary>
        /// <param name="itemSlot"></param>
        /// <returns>Balance after funds deducted for purchase</returns>
        public decimal SelectProduct(string itemSlot)
        {
            string name = this.Stock[itemSlot].Name;

            // decremenets balance by item price
            this.Balance -= this.Stock[itemSlot].Price;

            // decrements remaining quantity of item
            this.Stock[itemSlot].Quantity--;

            // Item added to Cart for later recall of purchased items
            this.Cart.Add(this.Stock[itemSlot]);

            // crates item selected info for use in transaction log
            this.LoggingInfo = $"{itemSlot} {this.Stock[itemSlot].Name}";

            // populating a total sales dictionary with item name as key and number purchased as value
            if (!this.TotalSales.ContainsKey(name))
            {
                this.TotalSales[name] = 1;
                this.SalesOutput += this.Stock[itemSlot].Price;
            }
            else
            {
                this.TotalSales[name] += 1;
                this.SalesOutput += this.Stock[itemSlot].Price;
            }

            // updated balance after validated purchase
            return this.Balance;
        }

        /// <summary>
        /// Creates sales report generated once main menu is quit from.
        /// </summary>
        public void TotalSalesReport()
        {
            // string to be returned for each item and total quantity purchased
            string itemTotals = string.Empty;

            try
            {
                using (StreamWriter sr = new StreamWriter("salesReport.txt"))
                {
                    foreach (KeyValuePair<string, int> item in this.TotalSales)
                    {
                        sr.WriteLine($"{item.Key}|{item.Value}");
                    }

                    sr.WriteLine($"**Total Sales** {this.SalesOutput:C2}");
                }
            }
            catch (IOException)
            {
                Console.WriteLine("error writing to file");
            }
        }

        /// <summary>
        /// When a single vending session ends, but machine still operating, change is produced form the remaining balance
        /// </summary>
        /// <returns>string of change</returns>
        public string MakeChange()
        {
            this.Balance *= 100;
            int quarters = 0;
            int dimes = 0;
            int nickels = 0;
            string changeMessage = string.Empty;

            while (this.Balance > 0)
            {
                if (this.Balance % 25 == 0 && this.Balance >= 25)
                {
                    quarters++;
                    this.Balance -= 25;
                }
                else if (this.Balance % 10 == 0 && this.Balance >= 10)
                {
                    dimes++;
                    this.Balance -= 10;
                }
                else if (this.Balance % 5 == 0 && this.Balance >= 5)
                {
                    nickels++;
                    this.Balance -= 5;
                }
            }

            // return message of total change given
            return changeMessage = $"{quarters} Quarter(s), {dimes} Dime(s), {nickels} Nickel(s)";
        }

        /// <summary>
        /// Called after change is given as we hear the customer consumer their items right on the street
        /// </summary>
        /// <returns>string off all consumption</returns>
        public string ConsumeItems()
        {
            string allItemsConsumed = string.Empty;

            foreach (Item item in this.Cart)
            {
                allItemsConsumed += item.MakeSound() + "\n";
            }

            Console.WriteLine();
            return allItemsConsumed;
        }
    }
}
