# Bank Account — Version 2 (Classes)

A rewrite of my [Bank Account](../bankaccount/) console app using a `BankAccount` class. The menu works the same — deposit, withdraw, check balance — but the account is now an object that holds its own data and enforces its own rules.

## What changed from version 1

| Version 1 | Version 2 |
| --- | --- |
| One `static double balance` that any method could change | A `private` balance that only `Deposit` and `WithDraw` can change |
| Rules (positive amounts, no overdraft) lived in the menu code | Rules live inside the account, which protects itself |
| Only one balance possible | Create as many accounts as needed with `new BankAccount(...)` |
| Methods did the work *and* talked to the user | `BankAccount` does the work, `Program` handles all input and output |

## How it's structured

- **`BankAccount.cs`**: holds the owner's name, account number and balance (all private). Public methods `Deposit` and `WithDraw` return `true`/`false` to report whether the operation was allowed, and `GetBalance` returns the current balance.
- **`Program.cs`**: the menu loop and input validation (`ReadAmount`, `ReadChoice`, `ReadAnswer`). It never touches the balance directly.

## What I learned

- **Classes and objects:** a class is a blueprint, and each object created with `new` has its own copy of the fields.
- **Constructors:** they set up an object's starting data, and `this.name = name` separates the field from the parameter with the same name.
- **Encapsulation:** making `balance` private means the only way to change it is through methods that check the rules. The compiler blocks any direct access.
- **Returning `bool` for success:** like `TryParse`, `Deposit` and `WithDraw` report whether they worked, and `Program` chooses the message.
- **Calling a method inside an `if` still runs it:** calling `WithDraw` once before the `if` and again inside it withdrew the money twice.

## Next steps

- Multiple accounts with a login (name + account number)
- Transferring money between accounts