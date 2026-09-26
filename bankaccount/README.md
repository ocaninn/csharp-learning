# Bank Account

A console app that simulates a simple bank account. A menu lets you deposit, withdraw and check your balance until you choose to exit. Withdrawals can't exceed the balance, amounts must be positive, and each withdrawal asks for confirmation before it goes through.

## What I learned

- **Menu loops:** a `while` loop controlled by a `bool` keeps showing the menu until the user chooses to exit. Unlike the Shop exercise, it doesn't run a fixed number of times.
- **`return` exits the method immediately:** putting it inside the menu loop ended the method after the first action, so the menu never came back.
- **Don't call `Main()` from inside a loop:** it doesn't restart the program. It starts a new copy inside the one already running, and when that copy finishes, the old one carries on with its old choice. The loop already goes back to the menu by itself.
- **Combining conditions with `||`:** `ReadAmount` rejects input that isn't a number *or* isn't positive, in a single check. `TryParse` has to come first, so the number exists before it's compared.