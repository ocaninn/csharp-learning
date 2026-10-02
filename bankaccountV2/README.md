# Bank Account — Version 2 (Classes & Login)

A rewrite of my [Bank Account](../bankaccount/) console app using object-oriented programming. Customers log in with their name and account number, then deposit, withdraw and check their balance. Each account is an object that holds its own data and enforces its own rules.

## Features

- **Login** with name and account number (capital letters don't matter)
- **Multiple accounts**, stored in a list, so adding a new customer is a single line
- **Deposit and withdraw**, with the rules enforced by the account itself: positive amounts only, no overdrafts
- **Input validation**: typing text or negative numbers never crashes the program

## What changed from version 1

| Version 1 | Version 2 |
| --- | --- |
| One `static double balance` that any method could change | A `private` balance that only `Deposit` and `WithDraw` can change |
| Rules lived in the menu code | Rules live inside the account, which protects itself |
| Only one account possible | Any number of accounts in a `List<BankAccount>` |
| No login | Login finds the matching account and hands it to the menu |
| Methods did the work *and* talked to the user | `BankAccount` does the work, `Program` handles all input and output |

## How it's structured

- **`BankAccount.cs`**: holds the owner's name, account number and balance (all private).
  - `CheckAccount(name, number)`: returns `true` if the details match this account
  - `Deposit(amount)` / `WithDraw(amount)`: return `true`/`false` to report whether the operation was allowed
  - `GetBalance()`: returns the current balance
- **`Program.cs`**:
  - `Main`: creates the accounts and runs the login loop
  - `EnterChoice(account)`: the menu, working with whichever account logged in
  - `ReadAmount`, `ReadChoice`, `ReadAnswer`: input validation

## What I learned

- **Classes and objects:** a class is a blueprint, and each object created with `new` has its own copy of the fields.
- **Constructors and `this`:** `this.name = name` separates the field from a parameter with the same name. Giving the parameter a different name avoids the clash altogether.
- **Encapsulation:** a `private` balance can only change through methods that check the rules. The compiler blocks any direct access.
- **Returning `bool` for success:** like `TryParse`, the account reports whether an operation worked, and `Program` chooses the message.
- **Calling a method inside an `if` still runs it:** calling `WithDraw` once before the `if` and again inside it withdrew the money twice.
- **Lists of objects:** one `List<BankAccount>` instead of `account1`, `account2`, `account3`, which scales to any number of accounts.
- **Searching with `foreach`:** a failed match only means "not *this* account". I
