using System;

class Program
{
    static void Main()
    {
        // First customer and order
        Address addr1 = new Address("123 Main St", "New York", "NY", "USA");
        Customer customer1 = new Customer("John Doe", addr1);

        Product prod1 = new Product("Laptop", "L100", 999.99, 1);
        Product prod2 = new Product("Mouse", "M200", 25.50, 2);

        Order order1 = new Order(customer1);
        order1.AddProduct(prod1);
        order1.AddProduct(prod2);

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.CalculateTotalCost():0.00}\n");

        // Second customer and order
        Address addr2 = new Address("456 King St", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Jane Smith", addr2);

        Product prod3 = new Product("Book", "B300", 15.99, 3);
        Product prod4 = new Product("Pen", "P400", 1.50, 10);

        Order order2 = new Order(customer2);
        order2.AddProduct(prod3);
        order2.AddProduct(prod4);

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.CalculateTotalCost():0.00}");
    }
}