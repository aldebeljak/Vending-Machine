using System;

namespace Capstone.Classes
{
    /// <summary>
    /// Candy Is-A Item
    /// </summary>
    public class Candy : Item
    {
        public Candy (string slotLocation, string name, decimal price, string type)
        : base(slotLocation, name, price, type)
        {
        }

        public override string MakeSound()
        {
            return "Munch Munch, Yum!";
        }
    }
}
