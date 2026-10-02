# Bank Account — Version 2 (Classes)

A rewrite of my [Bank Account](../bankaccount/) console app using a `BankAccount` class. The menu now supports multiple accounts, deposits, withdrawals, transfers and transaction history, while the account class handles its own data and rules.

## Features

* Multiple bank accounts with login and logout
* Deposit and withdraw money
* Transfer money between accounts
* View account balance with **decimal and euro formatting**
* View transaction history
* Input validation and withdrawal confirmation
* Encapsulated account data and rules

## What changed from version 1

| Version 1                                  | Version 2                                                   |
| ------------------------------------------ | ----------------------------------------------------------- |
| One `static double balance`                | Each `BankAccount` has its own private balance              |
| Rules lived in the menu code               | Rules are enforced inside the account                       |
| Only one account                           | Multiple account objects can exist                          |
| Methods handled logic and user interaction | `BankAccount` handles logic, `Program` handles input/output |
| No transaction history                     | Each account keeps its own transaction history              |

## How it's structured

* **`BankAccount.cs`**: represents an account and manages its owner, account number, balance and transaction history. It handles deposits, withdrawals and transfers while enforcing the account's rules.
* **`Program.cs`**: handles the menu, login/logout, input validation and user interaction.

## What I learned

* **Classes and objects:** a class is a blueprint, while each object created with `new` has its own data.
* **Encapsulation:** private fields can only be accessed through the class that owns them, so each `BankAccount` controls and protects its own state.
* **Private is per class:** `private` means other classes cannot access the member directly, but every `BankAccount` object can still access its own private fields.
* **Reference types:** objects and lists are reference types, so assigning them to another variable can make both variables refer to the same object.
* **Returning a copy of a list:** returning a new copy of the transaction list prevents outside code from directly modifying the account's internal history.
* **Constructors:** constructors initialise each account with its starting information.
* **Returning `bool` for success:** operations such as `Deposit` and `WithDraw` report whether they succeeded, allowing `Program` to decide what message to display.
* **`decimal` for money:** using `decimal` instead of `double` is better suited to financial calculations, while formatting values as euros makes the output clearer.
* **Separation of responsibilities:** keeping account logic inside `BankAccount` and user interaction inside `Program` makes the code easier to understand and extend.

## Next steps

* Improve the login system
* Add persistent data so accounts survive after the program closes
* Add more transaction types
