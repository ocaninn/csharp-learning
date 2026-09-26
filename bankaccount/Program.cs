class Program
{
    static double balance = 0.00;
    static void Main()
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
                Deposit();
            }
            else if (userChoice == 2 && balance == 0)
            {
                Console.WriteLine("Your balance is €0,00. Withdraw option not available!");
            }
            else if (userChoice == 2)
            {
                WithDraw();
            }
            else if (userChoice == 3)
            {
                CheckBalance();
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
    static void Deposit()
    {
        double deposit = ReadAmount("How much would you like to deposit? €");
        Console.WriteLine($"Your balance was €{balance}, after €{deposit} deposit, your current balance is €{balance + deposit}");
        balance = balance + deposit;
    }

    static void WithDraw()
    {
        bool state = true;
        while (state)
        {
            double withdraw = ReadAmount("How much would you like to withdraw? €");
            if (withdraw > balance)
            {
                string difAnswer = ReadAnswer("Insufficient balance! Try a different amount? (Y/N)");
                difAnswer = difAnswer.ToUpper();
                if (difAnswer == "Y")
                {/* Nothing to do: the loop repeats and asks for a new amount. */}
                else if (difAnswer == "N")
                {
                    Console.WriteLine($"Withdrawal cancelled");
                    state = false;
                }
                else
                {
                    Console.WriteLine($"Not a valid option! Try it again.");
                }
            }
            else
            {

                Console.WriteLine($"You current balance is €{balance}, after withdrawing €{withdraw}, it will be €{balance - withdraw}");
                string confirm = ReadAnswer($"Would you like to proceed? (Y/N)");
                confirm = confirm.ToUpper();
                if (confirm == "Y")
                {
                    Console.WriteLine($"You withdrew €{withdraw}!");
                    balance = balance - withdraw;
                    Console.WriteLine($"Current Balance: €{balance}!");
                    state = false;
                }
                else if (confirm == "N")
                {
                    Console.WriteLine($"Withdrawing process cancelled!");
                    Console.WriteLine($"Current Balance | €{balance}!");
                    state = false;
                }
                else
                {
                    Console.WriteLine($"Not a valid option! Try it again.");
                }
            }
        }

    }
    static void CheckBalance()
    {
        Console.WriteLine($"You current balance is €{balance}");
    }

}