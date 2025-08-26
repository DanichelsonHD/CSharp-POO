using System.Globalization;

namespace Secao8.exercicio_03
{
    class Program
    {
        static void Main3(string[] args)
        {
            Order order = NewOrder;
            int quantity = int.Parse(GetInput("How many items to this order? "));
            for (int index = 0; index < quantity; index++)
            {
                Console.WriteLine($"Enter #{index + 1} item data:");
                order.AddItem(NewItem);
            }
            Console.Write($"\nORDER SUMMARY:\n{order.ToString()}");
        }
        static Order NewOrder => new Order(
            NewClient,
            DateTime.Now.ToString(), 
            GetInput("Enter order data:\nStatus: ")
        );
        static OrderItem NewItem => new OrderItem(
            new Product(GetInput("Product name: "), double.Parse(GetInput("Product price: "), CultureInfo.InvariantCulture)),
            int.Parse(GetInput("Quantity: "))
        );
        static Client NewClient => new Client(GetInput($"Enter client data:\nName: "), GetInput("Email: "), GetInput("Birth date (DD/MM/YYYY): "));
        static string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}