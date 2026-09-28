class Program
{
    public static void Main()
    {
        EnterChoice();
    }

    static int ReadChoice(string userChoice)
    {
        int choice;
        Console.Write($"{userChoice}");
        while (!int.TryParse(Console.ReadLine(), out choice))
        {
            Console.WriteLine("Enter a valid option!");
        }
        return choice;
    }
    static string ReadAnswer(string userAnswer)
    {
        Console.Write($"{userAnswer}");
        string? answer = Console.ReadLine();
        while (string.IsNullOrWhiteSpace((answer)))
        {
            Console.WriteLine("Enter a valid option!");
            Console.Write($"{userAnswer}");
            answer = Console.ReadLine();
        }
        return answer;
    }
    static double ReadAmount(string subject)
    {
        double entAmount;
        Console.Write($"{subject}");
        while (!double.TryParse(Console.ReadLine(), out entAmount) || entAmount <= 0)
        {
            Console.WriteLine("Enter a positive number!");
            Console.Write($"{subject}");
        }
        return entAmount;
    }

    static void EnterChoice()
    {
        bool state = true;
        BankAccount account1 = new BankAccount("Lucas", 0001, 200.00);
        while (state)
        {
            Console.WriteLine("===== Bank Account =====");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Check balance");
            Console.WriteLine("4. Exit");
            Console.WriteLine("====================");
            int userChoice = ReadChoice("Enter your choice: ");

            if (userChoice == 1)
            {
                double amount = ReadAmount("How much would you like to deposit? €");
                if (account1.Deposit(amount))
                {
                    Console.WriteLine($"Deposited: €{amount} | Current balance: €{account1.GetBalance()}");
                }
                else
                {
                    Console.WriteLine("Enter a valid amount!");
                }
                

            }
            else if (userChoice == 2 && account1.GetBalance() <= 0)
            {
                Console.WriteLine("Your balance is €0,00. Withdraw option not available!");
            }
            else if (userChoice == 2)
            {
                double amount = ReadAmount("How much would you like to withdraw? €");
                if (account1.WithDraw(amount))
                {
                    Console.WriteLine($"Withdrew: €{amount} | Current balance: €{account1.GetBalance()}");
                }
                else
                {
                    Console.WriteLine($"Insufficient balance! €{account1.GetBalance()} available.");
                }
            }
            else if (userChoice == 3)
            {
                double balance = account1.GetBalance();
                Console.WriteLine($"Current Balance: €{balance}");
            }
            else if (userChoice == 4)
            {
                state = false;
            }
            else
            {
                Console.WriteLine("This option is not available");
            }
        }
    }
}