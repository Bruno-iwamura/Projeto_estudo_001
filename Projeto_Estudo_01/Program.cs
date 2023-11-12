using Projeto_Estudo_01.Entities;
using System;
using System.Globalization;

namespace Projeto_Estudo_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter client data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter Order Data:");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());
            Console.Write("How many itens in this order? ");
            int quantItens = int.Parse(Console.ReadLine());

            Client client = new Client(name, email, birthDate);
            Order order = new Order(DateTime.Now, status, client);

            for (int i  = 1;  i <= quantItens; i++)
            {
                Console.WriteLine($"Enter #{i} item data:");
                Console.Write("Product Name: ");
                string itemName = Console.ReadLine();
                Console.Write("Product Price: ");
                double itemPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int itemQuant = int.Parse(Console.ReadLine());

                Product product = new Product(itemName,itemPrice);
                //double totalPrice = product.subTotal(itemQuant, product.Price);
                OrderItem orderItem = new OrderItem(itemQuant,itemPrice,product);

                order.AddProduct(orderItem);

            }
            Console.WriteLine();
            Console.WriteLine("ORDER SUMMARY:");
            Console.WriteLine(order);
        }
    }
}