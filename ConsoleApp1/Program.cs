using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public enum CustomerType
    {
        Regular,
        Student,
        Vip
    }

    public class Order
    {
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public decimal Price { get; set; }
        public CustomerType CustomerType { get; set; }

        public Order(string customerName, string email, decimal price, CustomerType customerType)
        {
            CustomerName = customerName;
            Email = email;
            Price = price;
            CustomerType = customerType;
        }
    }

    // OCP

    public interface IDiscount
    {
        decimal Apply(decimal price);
    }

    public class NoDiscount : IDiscount
    {
        public decimal Apply(decimal price) => price;
    }

    public class StudentDiscount : IDiscount
    {
        public decimal Apply(decimal price) => price * 0.9m;
    }

    public class VipDiscount : IDiscount
    {
        public decimal Apply(decimal price) => price * 0.8m;
    }

    public class DiscountProvider
    {
        private readonly Dictionary<CustomerType, IDiscount> _discounts;

        public DiscountProvider(Dictionary<CustomerType, IDiscount> discounts)
        {
            _discounts = discounts;
        }

        public IDiscount GetDiscount(CustomerType customerType)
        {
            return _discounts.TryGetValue(customerType, out var discount)
                ? discount
                : new NoDiscount();
        }
    }

    // SRP

    public class OrderCalculator
    {
        private readonly DiscountProvider _discountProvider;

        public OrderCalculator(DiscountProvider discountProvider)
        {
            _discountProvider = discountProvider;
        }

        public decimal CalculateFinalPrice(Order order)
        {
            IDiscount discount = _discountProvider.GetDiscount(order.CustomerType);
            return discount.Apply(order.Price);
        }
    }

    // DIP

    public interface IMessageSender
    {
        void Send(string receiver, string message);
    }

    public class EmailSender : IMessageSender
    {
        public void Send(string receiver, string message)
        {
            Console.WriteLine($"Email для {receiver}: {message}");
        }
    }

    

    public class OrderService
    {
        private readonly OrderCalculator _calculator;
        private readonly IMessageSender _messageSender;

        public OrderService(OrderCalculator calculator, IMessageSender messageSender)
        {
            _calculator = calculator;
            _messageSender = messageSender;
        }

        public void ProcessOrder(Order order)
        {
            decimal finalPrice = _calculator.CalculateFinalPrice(order);

            
            Console.WriteLine($"Заказ клиента {order.CustomerName} сохранён");

            
            _messageSender.Send(order.Email, $"Заказ оформлен. Итоговая цена: {finalPrice}");

            
            Console.WriteLine($"Клиент: {order.CustomerName}");
            Console.WriteLine($"Исходная цена: {order.Price}");
            Console.WriteLine($"Итоговая цена: {finalPrice}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var discountProvider = new DiscountProvider(new Dictionary<CustomerType, IDiscount>
            {
                { CustomerType.Regular, new NoDiscount() },
                { CustomerType.Student, new StudentDiscount() },
                { CustomerType.Vip,     new VipDiscount() }
            });

            var calculator = new OrderCalculator(discountProvider);
            IMessageSender sender = new EmailSender();
            var service = new OrderService(calculator, sender);

            var order = new Order("Иван Иванов", "ivan@example.com", 10000, CustomerType.Student);

            service.ProcessOrder(order);
        }
    }
}