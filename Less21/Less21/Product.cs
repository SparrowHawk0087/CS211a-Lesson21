using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less21
{
    internal class Product
    {
        public enum ProductCategory
        {
            Food,
            Clothes,
            Gadgets,
            Furniture,
            Groceries
        }

        public string ID { get; }
        private string name;
        private ProductCategory category;
        private double price;

       
        
        public string Name
        {
            get
            {
                return name;
            }

            set 
            {
                if (value == String.Empty || value == null)
                  throw new ArgumentException(nameof(Name), "Product name can't be empty or whitespace.");
                name = value;
            }
        }

        public double Price
        { 
            get { return price; }

            set
            { 
                if (price < 0.0)
                    throw new ArgumentException(nameof(price), "Price can't be negative.");
                price = value;
            }
        }

        public ProductCategory Category
        {
            get { return category; }

            set 
            {
                if (category > ProductCategory.Groceries || category < ProductCategory.Food || category == null)
                    throw new ArgumentException(nameof(category));
                category = value;
            }

        }


        public Product(string nameOfProduct, ProductCategory ptCategory, double priceOfProduct)
        {
            var r = new Random();
            var c = (char)((int)'A' + r.Next(26));

            ID = c + r.Next(100, 1000).ToString();
            Name = nameOfProduct;
            Category = ptCategory;
            Price = priceOfProduct;
        }

        public override string ToString()
        {
            return $"Product INFO\n" +
                $"ID: {ID}\n" +
                $"Name: {Name}\n" +
                $"Category: {Category}\n" +
                $"Price: {Price}\n"; 
        }

    }
}
