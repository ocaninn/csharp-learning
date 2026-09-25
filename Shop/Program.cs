class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to our store! Let's start shopping");
        int itemCount = ReadInt("How many Items would You like to buy today? ");
        Shopping(itemCount);
    }
    static int ReadInt(string subject)
    {
        int items;
        Console.Write($"{subject}");
        while (!int.TryParse(Console.ReadLine(), out items))
        {
            Console.WriteLine("We only sell full items, enter a valid number!");
        }
        return items;
    }
    static void Shopping(int itemCount)
    {
        int loopCount = 1;
        double total = 0;
        while (loopCount <= itemCount)
        {
            double product = ReadDouble($"Price | Item {loopCount}: €");
            int quantity = ReadInt($"Quantity | Item {loopCount}: ");
            double price = product * quantity;
            Console.WriteLine($"Item {loopCount}: {quantity} x {product} = €{price}");
            total = total + price;
            loopCount++;
        }
        Console.WriteLine($"Total of your shopping: €{total}");
        if (total > 50)
        {
            double discount = total * 0.1;
            double finalPrice = total - discount;
            Console.WriteLine($"Discount applied! New total: €{finalPrice}");

        }
        else
        {
            Console.WriteLine("Unfortunately, no discount was applied!");
        }
    }

    static double ReadDouble(string subject)
    {
        double prices;
        Console.Write($"{subject}");
        while (!double.TryParse(Console.ReadLine(), out prices))
        {
            Console.WriteLine("Enter a valid price!");
        }

        return prices;

    }

}