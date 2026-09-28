class BankAccount
{
    string name;
    double balance;
    double accountNumber;
    public BankAccount(string name, double accountNumber, double balance)
    {
        this.name = name;
        this.accountNumber = accountNumber;
        this.balance = balance;
    }

    public bool Deposit(double deposit)
    {
        if (deposit > 0)
        {
            balance = deposit + balance;
            return true;
        }
        else
        {
            return false;
        }

    }
    public bool WithDraw(double amount)
    {
        if (amount > 0 && amount <= balance)
        {
            balance = balance - amount;
            return true;
        }
        else
        {
            return false;
        }

    }
    public double GetBalance()
    {
        return balance;
    }
}