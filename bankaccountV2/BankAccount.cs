class BankAccount
{
    string name;
    double balance;
    string accountNumber;
    public BankAccount(string name, string accountNumber, double balance)
    {
        this.name = name;
        this.accountNumber = accountNumber;
        this.balance = balance;
    }

    public bool CheckAccount(string accName, string accNumber)
    {
        name = name.ToLower();
        accName = accName.ToLower();
        if (accName == name && accNumber == accountNumber)
        {
            return true;
        }
        else
        {
            return false;
        }
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