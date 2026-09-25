A console app that asks how many items you're buying, then the price and quantity of each one. It prints a line total for every item and the overall total, and applies a 10% discount when the total is over €50.

## What I learned

- Splitting a program into methods with one job each (`ReadInt`, `ReadDouble`, `Shopping`)
- Validating user input with `TryParse` so typing text never crashes the program
- Keeping a running total: declare it before the loop, add to it inside, use it after
- Passing values between methods with parameters instead of sharing variables