using System;
using System.Collections.Generic;

// ===============================
// Product Class
// ===============================
class Product
{
    private string name;
    private string productId;
    private double price;
    private int quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public double GetTotalCost()
    {
        return price * quantity;
    }

    public string GetPackingInfo()
    {
        return $"{name} (ID: {productId})";
    }
}

// ===============================
// Address Class
// ===============================
class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public bool IsUSA()
    {
        return country.ToLower() == "usa" || country.ToLower() == "united states";
    }

    public string GetFullAddress()
    {
        return $"{street}\n{city}, {state}\n{country}";
    }
}

// ===============================
// Customer Class
// ===============================
class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public bool LivesInUSA()
    {
        return address.IsUSA();
    }

    public string GetName()
    {
        return name;
    }

    public string GetAddress()
    {
        return address.GetFullAddress();
    }
}

// ===============================
// Order Class
// ===============================
class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
        products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public double GetTotalCost()
    {
        double total = 0;

        foreach (Product p in products)
        {
            total += p.GetTotalCost();
        }

        // Shipping cost
        if (customer.LivesInUSA())
        {
            total += 5;
        }
        else
        {
            total += 35;
        }

        return total;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";

        foreach (Product p in products)
        {
            label += p.GetPackingInfo() + "\n";
        }

        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{customer.GetName()}\n{customer.GetAddress()}";
    }
}

// ===============================
// Main Program
// ===============================
class Program
{
    static void Main(string[] args)
    {
        // Order 1 (USA)
        Address address1 = new Address("123 Main St", "Provo", "UT", "USA");
        Customer customer1 = new Customer("John Smith", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "P100", 800, 1));
        order1.AddProduct(new Product("Mouse", "P101", 20, 2));

        // Order 2 (International)
        Address address2 = new Address("456 Calle 10", "Bogotá", "Cundinamarca", "Colombia");
        Customer customer2 = new Customer("Maria Lopez", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Phone", "P200", 600, 1));
        order2.AddProduct(new Product("Headphones", "P201", 50, 2));
        order2.AddProduct(new Product("Charger", "P202", 25, 1));

        // Display Order 1
        Console.WriteLine("=== ORDER 1 ===");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost()}");

        // Display Order 2
        Console.WriteLine("\n=== ORDER 2 ===");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost()}");
    }
}