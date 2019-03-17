using System;

namespace Capstone.Classes
{
    /// <summary>
    /// Chip IS-A Item
    /// </summary>
    public class Chip : Item
    {
        public Chip(string slotLocation, string name, decimal price, string type)
        : base(slotLocation, name, price, type)
        {
        }

        public override string MakeSound()
        {
            return "Crunch Crunch, Yum!";
        }
    }
}
