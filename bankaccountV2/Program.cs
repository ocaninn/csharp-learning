using System.Globalization;

class Program
{
    public static void Main()
    {
        CultureInfo.CurrentCulture = new CultureInfo("en-IE");
        List<BankAccount> accounts = new List<BankAccount>();
        accounts.Add(new BankAccount("Lucas", "001", 200));
        accounts.Add(new BankAccount("Pedro", "002", 220));
        accounts.Add(new BankAccount("marcos", "003", 250));
        BankAccount? current = null;
        bool running = true;
        while (running)
        {
            Console.WriteLine("===== Login =====");
            current = null;
            while (current == null)
            {
                string accName = ReadAnswer("Insert your Name: ");
                string accNumber = ReadAnswer("Insert your Account Number: ");
                foreach (BankAccount acc in accounts)
                {
                    if (acc.CheckAccount(accName, accNumber))
                    {
                        current = acc;
                        Console.WriteLine("Account Found!");
                    }
                }
                if (current == null)
                {
                    Console.WriteLine("Invalid Details!");
                }
            }
            EnterChoice(current, accounts);
            string answer = ReadAnswer("Log in with another account? (Y/N)");
            if (answer.ToUpper() == "Y") { }
            else
            {
                running = false;
            }

        }



    }

    static BankAccount? FindAccount(List<BankAccount> accounts, string number)
    {
        foreach (BankAccount acc in accounts)
        {
            if (acc.GetAccountNumber() == number)
            {
                return acc;
            }
        }
        return null;
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
    static decimal ReadAmount(string subject)
    {
        decimal entAmount;
        Console.Write($"{subject}");
        while (!decimal.TryParse(Console.ReadLine(), out entAmount) || entAmount <= 0)
        {
            Console.WriteLine("Enter a positive number!");
            Console.Write($"{subject}");
        }
        return entAmount;
    }

    static void EnterChoice(BankAccount account, List<BankAccount> accounts)
    {
        bool state = true;
        while (state)
        {

            Console.WriteLine("===== Bank Account =====");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Check balance");
            Console.WriteLine("4. Transfer");
            Console.WriteLine("5. View history");
            Console.WriteLine("6. Logout");
            Console.WriteLine("====================");
            int userChoice = ReadChoice("Enter your choice: ");


            if (userChoice == 1)
            {
                decimal amount = ReadAmount("How much would you like to deposit? €");
                if (account.Deposit(amount))
                {
                    Console.WriteLine($"Deposited: {amount:C} | Current balance: {account.GetBalance():C}");
                }
                else
                {
                    Console.WriteLine("Enter a valid amount!");
                }


            }
            else if (userChoice == 2 && account.GetBalance() <= 0)
            {
                Console.WriteLine($"Your balance is {account.GetBalance():C}. Withdraw option not available!");
            }
            else if (userChoice == 2)
            {
                decimal amount = ReadAmount("How much would you like to withdraw? €");
                if (account.WithDraw(amount))
                {
                    Console.WriteLine($"Withdrew: {amount:C} | Current balance: {account.GetBalance():C}");
                }
                else
                {
                    Console.WriteLine($"Insufficient balance! {account.GetBalance():C} available.");
                }
            }
            else if (userChoice == 3)
            {
                decimal balance = account.GetBalance();
                Console.WriteLine($"Current Balance: {balance:C}");
            }
            else if (userChoice == 4)
            {
                BankAccount? recipient;
                string recipientsNumber = ReadAnswer("Recipients Account Number: ");
                recipient = FindAccount(accounts, recipientsNumber);
                if (recipient == null)
                {
                    Console.WriteLine("Account not found");
                }
                else if (recipient == account)
                {
                    Console.WriteLine("You cannot transfer money to yourself!");
                }

                else
                {
                    decimal amount = ReadAmount("How much would you like to transfer? €");
                    if (account.TransferTo(recipient, amount))
                    {
                        Console.WriteLine($"Your transfer was made successfully!");
                        Console.WriteLine($"Amount sent: {amount:C}");
                        Console.WriteLine($"Current Balance: {account.GetBalance():C}");
                    }
                    else
                    {
                        Console.WriteLine($"Insufficient balance!");
                    }

                }

            }
            else if (userChoice == 5)
            {
                List<string> history = account.GetHistory();
                if (history.Count == 0)
                {
                    Console.WriteLine("No transactions yet!");
                }
                else
                {
                    Console.WriteLine(" ===== Transaction History ===== ");
                    foreach (string entry in history)
                    {
                        Console.WriteLine(entry);
                    }
                }
            }
            else if (userChoice == 6)
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