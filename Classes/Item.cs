namespace Capstone.Classes
{
    /// <summary>
    /// instantiates new object for each item in list of items
    /// </summary>
    public abstract class Item
    {
        public string Name { get; }

        public decimal Price { get; }

        public int Quantity { get; set; }

        public string SlotLocationn { get; }

        public string Type { get; }

        /// <summary>
        /// Constructor using parameters read in from file in vendig machine class
        /// </summary>
        /// <param name="slotLocation">location</param>
        /// <param name="name">name</param>
        /// <param name="price">price</param>
        /// <param name="type">type</param>
        public Item(string slotLocation, string name, decimal price, string type)
        {
            this.Name = name;
            this.Price = price;
            this.Quantity = 5;
            this.SlotLocationn = slotLocation;
            this.Type = type;
        }

        public abstract string MakeSound();
    }
}
