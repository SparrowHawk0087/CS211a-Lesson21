using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Less21
{
    internal class Customer
    {
        public int ID { get; }
        private string name;
        private double discount;
        private static int _nextCustomerId;
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                if (name == "" || name == null)
                   throw new ArgumentException(nameof(Name), "Customer name can't be empty or whitespace.");
                name = value;
            }
        }

        public double Discount
        {
            get { return discount; }

            set
            {
                if (discount < 0.0 || discount > 100.0)
                    throw new ArgumentException(nameof(discount), "Discount must be between 0 and 100 percent.");
                discount = value;
            }
        }


        public Customer(string nameOfCustomer, double CustomerDiscount)
        {
            ID = _nextCustomerId++;
            Name = nameOfCustomer;
            Discount = CustomerDiscount;
        }
        public override string ToString()
        {
            return $"Customer's INFO\n" +
                $"ID: {ID}\n" +
                $"Name: {Name}\n" +
                $"Discount: {Discount}%";
        }
    }
}
