class BankAccount
{
    string name;
    decimal balance;
    string accountNumber;

    private List<string> history = new();
    public BankAccount(string name, string accountNumber, decimal balance)
    {
        this.name = name;
        this.accountNumber = accountNumber;
        this.balance = balance;
    }

    public bool CheckAccount(string accName, string accNumber)
    {
        if (accName.ToLower() == name.ToLower() && accNumber == accountNumber)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Deposit(decimal deposit)
    {
        if (deposit > 0)
        {
            balance = deposit + balance;
            history.Add($"{DateTime.Now:dd/MM/yyyy HH:mm} | Deposit | {deposit:C} | Balance: {balance:C}");
            return true;
        }
        else
        {
            return false;
        }

    }

    public bool WithDraw(decimal amount)
    {
        if (amount > 0 && amount <= balance)
        {
            balance = balance - amount;
            history.Add($"{DateTime.Now:dd/MM/yyyy HH:mm} | Withdraw | {amount:C} | Balance: {balance:C}");
            return true;
        }
        else
        {
            return false;
        }

    }

    public bool TransferTo(BankAccount recipient, decimal amount)
    {
        if (amount > 0 && amount <= balance)
        {
            balance = balance - amount;
            recipient.balance = recipient.balance + amount;
            history.Add($"{DateTime.Now:dd/MM/yyyy HH:mm} | Transferred | {amount:C} | To Account: {recipient.accountNumber} | Balance: {balance:C}");
            recipient.history.Add($"{DateTime.Now:dd/MM/yyyy HH:mm} | Received | {amount:C} | From: {accountNumber} | Balance: {recipient.balance:C}");
            return true;
        }
        else
        {
            return false;
        }

    }
    public decimal GetBalance()
    {
        return balance;
    }
    public string GetAccountNumber()
    {
        return accountNumber;
    }

    public List<string> GetHistory()
    {
        return new List<string>(history);
    }

}