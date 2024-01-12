using System.Runtime.CompilerServices;

namespace Market.Products
{
    public class Product
    {
        public decimal Price { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        public Product()
        {
        }

        public string GetProductName()
        {
            return Name;
        }

        public decimal GetPriceForOneItem()
        {
            return Price;
        }

        public decimal GetPrice(int count)
        {
            return Price * count;
        }
    }
}
