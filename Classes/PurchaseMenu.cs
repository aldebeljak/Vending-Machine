using System;
using System.IO;
using System.Collections.Generic;

namespace Capstone.Classes
{
    /// <summary>
    /// Instantiates purchase menu
    /// </summary>
    public class PurchaseMenu
    {
        public void Run(VendingMachine vendingMachine)
        {
            Console.Clear();
            while (true)
            {
                vendingMachine.DisplayItems();
                Console.WriteLine($"1. Add Funds Balance: ${vendingMachine.Balance}");
                Console.WriteLine("2. Enter Product ID");
                Console.WriteLine("3. Finish vending");
                Console.WriteLine("Q  Quit");
                Console.Write("Choice: ");
                string choice = Console.ReadLine();
                Console.WriteLine();

                if (choice == "1")
                {
                    List<int> nums = new List<int>() { 1, 2, 5, 10 };
                    int enteredBills = 0;

                    // checking for valid input data type
                    while (true)
                    {
                        Console.Write("Please Enter Dollar Amount 1,2,5 or 10 $");
                        try
                        {
                            enteredBills = int.Parse(Console.ReadLine());
                            break;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Choice not valid, please try again");
                        }
                    }

                    // if the input is of correct data type, check it it is in allowable bills (1,2,5,10)
                    if (nums.Contains(enteredBills))
                    {
                        decimal startingBalance = vendingMachine.Balance;
                        decimal updatedBalance = vendingMachine.AddFunds(enteredBills);

                        // we log the activity to add funds and add funds to the balance
                        this.CreateLog(startingBalance, updatedBalance, "FEED MONEY");
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Invalid dollar amount");
                    }
                }
                else if (choice == "2")
                {
                    Console.Write("Please enter LetterNumber item slot to purchase from: ");
                    string itemSlot = Console.ReadLine().ToUpper();
                    Console.WriteLine();

                    if (!vendingMachine.Stock.ContainsKey(itemSlot))
                    {
                        Console.WriteLine("Selection not valid\n");
                    }
                    else if (vendingMachine.Stock.ContainsKey(itemSlot) && vendingMachine.Stock[itemSlot].Price < vendingMachine.Balance && vendingMachine.Stock[itemSlot].Quantity > 0)
                    {
                        decimal startingBalance = vendingMachine.Balance;
                        decimal updatedBalance = vendingMachine.SelectProduct(itemSlot);

                        // log transaction
                        this.CreateLog(startingBalance, updatedBalance, vendingMachine.LoggingInfo);
                        Console.WriteLine($"{vendingMachine.Stock[itemSlot].Name} purchased\n");
                    }
                    else if (vendingMachine.Stock[itemSlot].Price > vendingMachine.Balance)
                    {
                        Console.WriteLine("PLEASE ADD MORE FUNDS!\n");
                    }
                    else if (vendingMachine.Stock[itemSlot].Quantity == 0)
                    {
                        Console.WriteLine("ITEM SOLD OUT!\n");
                    }
                }
                else if (choice == "3")
                {
                    decimal beginningBalance = vendingMachine.Balance;
                    decimal endingBalance;

                    // makes change on remaining balance
                    Console.WriteLine($"Here is the remaining balance of ${vendingMachine.Balance}");
                    Console.WriteLine(vendingMachine.MakeChange());

                    // take fully decremented balance and save as ending balance
                    endingBalance = vendingMachine.Balance;

                    // create log with starting balance, final balance $0, and message
                    this.CreateLog(beginningBalance, endingBalance, "GIVE CHANGE");

                    Console.WriteLine();
                    Console.WriteLine("Time to mange!");
                    Console.WriteLine(vendingMachine.ConsumeItems());
                    vendingMachine.Cart.Clear();
                }
                else if (choice.ToLower() == "q")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Choice Not Valid");
                    Console.WriteLine("Please try again");
                    Console.WriteLine();
                }
            }
        }

        /// <summary>
        /// Creates log file for each transaction (feeding money, withdrawing Item)
        /// </summary>
        /// <param name="totalBalance">machine balance</param>
        /// <param name="updatedBalance">new balance</param>
        /// <param name="logAction">log activity</param>
        public void CreateLog(decimal totalBalance, decimal updatedBalance, string logAction)
        {
            string logMessage = $"{DateTime.Now.ToString("MM/dd/yyyy HH:mm")} ${totalBalance, -6} ${updatedBalance, -6} {logAction, 1}";

            try
            {
                using (StreamWriter sw = new StreamWriter("Log.txt", true))
                {
                    sw.WriteLine($"{logMessage}");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error writing to log: {ex.Message}");
            }
        }
    }
}
