using System.Globalization;

namespace Secao8.exercicio_03
{
    class Order
    {
        public DateTime Moment { get; private set; }
        public OrderStatus Status { get; private set; }
        public Client Client { get; private set; }
        public List<OrderItem> Items { get; private set; } = new List<OrderItem>();

        public Order(Client Client, string Moment, string Status)
        {
            this.Moment = DateTime.Parse(Moment);
            this.Status = ToOrderStatus(Status);
            this.Client = Client;
        }
        public Order(Client Client, string Moment, string Status, List<OrderItem> Items) 
            : this(Client, Moment, Status) => this.Items = Items;

        public void AddItem(OrderItem Item) => Items.Add(Item);
        public void RemoveItem(OrderItem Item) => Items.Remove(Item);
        public double Total()
        {
            double total = 0.0;
            foreach (OrderItem item in Items) total += item.SubTotal;
            return total;
        }
        public OrderStatus ToOrderStatus(string Status)
        {
            string status = Status.ToLower();
            switch (status)
            {
                case "pending payment":
                    return OrderStatus.PENDING_PAYMENT;
                case "processing":
                    return OrderStatus.PROCESSING;
                case "shipped":
                    return OrderStatus.SHIPPED;
                case "delivered":
                    return OrderStatus.DELIVERED;
                default:
                    return OrderStatus.PENDING_PAYMENT;
            }
        }
        public override string ToString()
        {
            string status = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Status.ToString().ToLower());
            string finalString = $"Order moment: {Moment} \nOrder status: {status} \nClient: {Client.ToString()} \nOrder items:";
            foreach (OrderItem item in Items) finalString += $"\n{item.ToString()}";
            return finalString + $"\nTotal price: ${Total():F2}";
        }
    }

    class OrderItem
    {
        public int Quantity { get; private set; }
        public double Price { get; private set; }
        public Product Product { get; private set; }

        public OrderItem(Product Product, int Quantity)
        {
            this.Quantity = Quantity;
            this.Product = Product;
            Price = Product.Price;
        }
        public double SubTotal => Quantity * Price;
        public override string ToString()
        {
            return $"{Product.Name}, ${Price:F2}, Quantity: {Quantity}, Subtotal: ${SubTotal:F2}";
        }
    }

    public enum OrderStatus : int
    {
        PENDING_PAYMENT = 0,
        PROCESSING = 1,
        SHIPPED = 2,
        DELIVERED = 3
    }
}