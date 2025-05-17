namespace Less21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("|____ МехМаркет ____|");

            // инициализация склада
            var warehouse = new Warehouse();
            Console.WriteLine("\nСклад создан\n");

            // инициализация продуктов
            var laptop = new Product("Ноутбук", Product.ProductCategory.Gadgets, 120000.0);
            var phone = new Product("Смартфон", Product.ProductCategory.Gadgets, 40000.0);
            var shirt = new Product("Рубашка", Product.ProductCategory.Clothes, 1500.0);
            var bread = new Product("Хлеб", Product.ProductCategory.Food, 40.0);
            var milk = new Product("Молоко", Product.ProductCategory.Food, 100.0);
            var sofa = new Product("Диван", Product.ProductCategory.Furniture, 25000.0);
            
            Console.WriteLine("\nСозданы товары:");
            Console.WriteLine(laptop);
            Console.WriteLine(phone);
            Console.WriteLine(shirt);
            Console.WriteLine(bread);
            Console.WriteLine(milk);
            Console.WriteLine(sofa);

            // добавление товаров на склад
            warehouse.AddProduct(laptop.ID, 10);
            warehouse.AddProduct(phone.ID, 15);
            warehouse.AddProduct(shirt.ID, 30);
            warehouse.AddProduct(bread.ID, 100);
            warehouse.AddProduct(milk.ID, 150);
            warehouse.AddProduct(sofa.ID, 5);

            Console.WriteLine("\nТовары добавлены на склад:");
            Console.WriteLine($"{laptop.Name} кол-во: {warehouse[laptop.ID]}");
            Console.WriteLine($"{phone.Name} кол-во: {warehouse[phone.ID]}");
            Console.WriteLine($"{shirt.Name} кол-во: {warehouse[shirt.ID]}");
            Console.WriteLine($"{bread.Name} кол-во: {warehouse[bread.ID]}");

            // инициализация пользователей
            var regularCustomer = new Customer("Иван Федоров", 5); // 5% скидка
            var vipCustomer = new Customer("Дмитрий Калинин", 15); // 15% скидка

            Console.WriteLine("\nСозданы пользователи:");
            Console.WriteLine(regularCustomer);
            Console.WriteLine(vipCustomer);

            // инициализация заказов
            var order1 = new Order(regularCustomer, new[] { laptop, shirt });
            var order2 = new Order(vipCustomer, new[] { phone, phone, bread });

            Console.WriteLine("\nСозданы заказы:");
            Console.WriteLine(order1 + "\n");
            Console.WriteLine(order2 + "\n");


            // проверка обработки заказов
            try
            {
                Console.WriteLine("\nОбработка заказов:");

                // Проверка и списывание товаров для order1
                warehouse.PickUpProduct(laptop.ID, 1);
                warehouse.PickUpProduct(shirt.ID, 1);
                Console.WriteLine($"Заказ #{order1.ID} обработан успешно!");

                // Проверка и списывание товаров для order2
                warehouse.PickUpProduct(phone.ID, 2);
                warehouse.PickUpProduct(bread.ID, 1);
                Console.WriteLine($"Заказ #{order2.ID} обработан успешно!");


            }
            catch (Exception e)
            {
                Console.WriteLine($"\nОшибка обработки заказа: {e.Message}");
            }


            // вывод остатков на складе после обработки заказов
            Console.WriteLine("\nОстатки на складе:");
            Console.WriteLine($"Ноутбуков: {warehouse[laptop.ID]} (было 10)");
            Console.WriteLine($"Смартфонов: {warehouse[phone.ID]} (было 15)");
            Console.WriteLine($"Рубашек: {warehouse[shirt.ID]} (было 30)");
            Console.WriteLine($"Хлеба: {warehouse[bread.ID]} (было 100)");
            Console.WriteLine($"Молока: {warehouse[milk.ID]} (было 150)");
            Console.WriteLine($"Диванов: {warehouse[sofa.ID]} (было 5)");
            Console.WriteLine("\n=== Работа Мехмаркета завершена ===");
        }
    }
}
