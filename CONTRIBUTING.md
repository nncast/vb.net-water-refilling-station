# Contributing to Mangalos Water Refilling Station

Thanks for helping out. Bug reports, fixes and small improvements are all welcome.

## Reporting bugs and ideas

Open an [issue](https://github.com/nncast/vb.net-water-refilling-station/issues) with:

- what you did, what you expected, and what happened instead
- the version (see [Releases](https://github.com/nncast/vb.net-water-refilling-station/releases)) and whether you ran the Windows build or built from source
- your MySQL/MariaDB setup (XAMPP, WAMP, other) if the problem involves the database, and your Crystal Reports runtime if it involves the Report screen

Security problems do not go in issues; see [SECURITY.md](SECURITY.md).

## Setting up

Follow **From source** in the [README](README.md#setup-and-run-instructions): import `database/dbmwrs.sql`, open `MWRS.sln` in Visual Studio, and set the `MwrsDb` connection string in `MWRS/App.config` if your MySQL settings differ from the defaults. The Report screen also needs SAP Crystal Reports for Visual Studio (see [Reports](README.md#reports-optional)).

## Making a change

1. Fork the repository and create a branch from `main` (for example `fix-delivery-status`).
2. Keep each pull request to one fix or feature.
3. Build and try your change as both an **admin** and an **employee** account. If it touches orders, follow one through Sales → Orders → Delivery and check the stock and the customer's balance.
4. Open a pull request that says what changed and how you tested it. Screenshots help for form changes.

## Code guidelines

- **Database access** goes through the helpers in `Conn.vb` (`GetQuery`, `SetQuery`, `GetValue`, `Execute`). Pass every value with `P("@name", value)`; never build SQL by joining strings with user input.
- **Orders, payments and deliveries** go through `OrderLogic.vb` (`CreateOrder`, `AddPayment`, `ChangeOrderStatus`, `AssignDelivery` and the rest), so stock, balances and deliveries stay in step. Don't update those tables from a form directly.
- **Multi-step writes** go inside `BeginTransaction` / `CommitTransaction`, with `RollbackTransaction` on failure.
- **Money** stays `Decimal`, never `Double`.
- **Passwords** are stored only through `PasswordHasher.HashPassword` and checked with `VerifyPassword`, with at least 8 characters for new ones. Never store, log or display a plain-text password.
- **Connection settings** stay in `App.config`. Do not hard-code server names, users or passwords.
- **Schema changes** go into `database/dbmwrs.sql` so a fresh import matches the code. Mention in the pull request whether existing databases need a manual change.
- Match the style of the surrounding code: admin sections under `Dashboard/Admin/Sections-A/`, employee sections under `Dashboard/Employee/Sections-E/`, dialogs named like `DlgAddProduct` under `Dialogs/`.
- Do not commit `bin/`, `obj/` or personal `App.config` changes such as your local database password.
