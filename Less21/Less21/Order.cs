using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less21
{
    internal class Order
    {
        public int ID { get; }
        public Customer Customer { get; }
        public Product[] Cart { get; }

        private static int _nextOrderId;


         
        public Order(Customer customerInfo, Product[] cart)
        { 
            ID = _nextOrderId++;
            Customer = customerInfo;
            Cart = cart;

            // Логирование создания заказа
            Console.WriteLine($"Order #{ID} created for customer {Customer.Name}\n");
        }

        public double TotalPrice()
        {
            double total = 0.0;

            // Суммируем цены всех товаров в корзине
            foreach (var item in Cart)
            { 
                total += item.Price;
            }

            // Применяем скидку пользователя
            double totalDiscount = total * (Customer.Discount / 100);
            double finalResult = total - totalDiscount;

            // Логирование расчета стоимости
            Console.WriteLine($"Calculating total price for order #{ID}:\n" +
                             $"Subtotal: {total},\nDiscount: {Customer.Discount}% ({totalDiscount}),\n" +
                             $"Final: {finalResult}\n");

            return finalResult;
        }
        public override string ToString()
        {
            string productsList = string.Join("\n", Cart.Select(product => $"{product.Name} - {product.Price}RUB"));

            return $"Order #{ID}\n" +
               $"Customer: {Customer.Name} (Discount: {Customer.Discount}%)\n" +
               $"Products:\n{productsList}\n" +
               $"Total: {TotalPrice():C}"; ;
        }
    }
}
