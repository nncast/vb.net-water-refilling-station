<p align="center">
  <img src="MWRS/Resources/mwrs.png" alt="Mangalos Water Refilling Station logo" width="100"/>
</p>

<p align="center">
  <img src="https://img.shields.io/badge/version-0.1.1-4169E1?style=flat-square" alt="version">
  <img src="https://img.shields.io/badge/status-complete-2772BD?style=flat-square" alt="status">
  <img src="https://img.shields.io/badge/VB.NET-Windows_Forms-512BD4?style=flat-square&logo=dotnet&logoColor=white" alt="VB.NET">
  <img src="https://img.shields.io/badge/.NET_Framework-4.8.1-5C2D91?style=flat-square&logo=dotnet&logoColor=white" alt=".NET Framework">
  <img src="https://img.shields.io/badge/MariaDB-XAMPP-4479A1?style=flat-square&logo=mariadb&logoColor=white" alt="MariaDB">
</p>

<p align="center">
  <b>Download v0.1.1:</b>
  <a href="https://github.com/nncast/vb.net-water-refilling-station/releases/download/v0.1.1/MWRS-v0.1.1-Windows.zip">Windows (.zip)</a> ·
  <a href="https://github.com/nncast/vb.net-water-refilling-station/archive/refs/tags/v0.1.1.zip">Source (.zip)</a> |
  <a href="https://github.com/nncast/vb.net-water-refilling-station/releases">All releases</a>
</p>

# Mangalos Water Refilling Station

**Mangalos Water Refilling Station** is a desktop-based **VB.NET** monitoring system designed to automate and monitor daily operations of a water refilling business.
The system centralizes **sales, inventory, customer debts, and delivery records**, replacing manual logs and spreadsheets with a structured digital solution.

> **Current version: v0.1.1** — security and bug-fix release: hashed passwords, parameterized queries, correct stock, balances and payments for orders, deliveries that stay in step with their orders, the connection settings in a config file, and a ready-to-run Windows build. See [Releases](https://github.com/nncast/vb.net-water-refilling-station/releases) for the release notes.

<p align="center">
  <img width="400" alt="image" src="https://github.com/user-attachments/assets/3bd57d10-0d6a-400b-9f2b-f991b359c5dc" />
  <img width="400" alt="image" src="https://github.com/user-attachments/assets/5d31da9c-a5a5-4845-8c63-d7d6f433cb78" />
  <img width="400" alt="image" src="https://github.com/user-attachments/assets/635aa071-56cf-4884-8003-b7635a8b77be" />
  <img width="400" alt="image" src="https://github.com/user-attachments/assets/367026e6-dbf2-40cd-bf8e-44ddbd099c12" />
  <img width="400" alt="image" src="https://github.com/user-attachments/assets/82ff853a-4d94-4322-a1fa-6191cf00defd" />
  <img width="400" alt="image" src="https://github.com/user-attachments/assets/5f7bcab5-87f9-489c-a744-d6d931368bab" />
</p>

## Features

**Administrator Functions**
- Manage user accounts and access roles
- View and manage customer records including barangay, purok, and outstanding balances
- Monitor sales, inventory levels, and delivery logs
- Generate basic summary reports for sales, inventory, and deliveries
- Maintain system data consistency and accuracy

**Employee Functions**
- Secure login authentication
- Record sales transactions linked to customers
- Update inventory automatically based on sales
- Track customer payments and unpaid balances
- Process orders and record delivery or pick-up status using guided navigation

## System highlights

- Desktop-based POS and monitoring system
- Digital database for reliable storage and retrieval of records
- Clear transaction flow: **Sales → Orders → Delivery**
- Customer debt tracking with paid and pending status
- Separate address fields (Barangay and Purok) for accurate delivery records
- Role-based access for admin and employees

## Development environment

| Category | Details |
| --- | --- |
| Language | Visual Basic .NET |
| UI | Windows Forms |
| Framework | .NET Framework 4.8.1 |
| Database | MariaDB / MySQL (XAMPP or WAMP) — database `dbmwrs` |
| Driver | MySql.Data (MySQL Connector/NET) |
| IDE | Visual Studio 2012 or later |

## Requirements

| Tool | Download |
| --- | --- |
| Visual Studio 2012 or later | [visualstudio.microsoft.com](https://visualstudio.microsoft.com/downloads/) |
| .NET Framework 4.8.1 or later | [dotnet.microsoft.com](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net481) |
| XAMPP or WAMP (for MySQL) | [XAMPP](https://www.apachefriends.org/index.html) · [WAMP](https://www.wampserver.com/en/) |
| MySQL client (SQLYog, phpMyAdmin, or MySQL Workbench) | [SQLYog](https://github.com/webyog/sqlyog-community/wiki/Downloads) |
| MySQL .NET Connector (`MySql.Data.dll`) | Included in `lib/` (from [Connector/NET](https://dev.mysql.com/downloads/connector/net/)) |
| SAP Crystal Reports (only for the Report screen) | [SAP downloads](https://origin.softwaredownloads.sap.com/public/site/index.html) — runtime 32-bit to run, developer version for Visual Studio to build |

## Setup and run instructions

**Windows build (no Visual Studio needed)**

1. Download [`MWRS-v0.1.1-Windows.zip`](https://github.com/nncast/vb.net-water-refilling-station/releases/download/v0.1.1/MWRS-v0.1.1-Windows.zip) from the [v0.1.1 release](https://github.com/nncast/vb.net-water-refilling-station/releases/tag/v0.1.1) and extract it.
2. Start MySQL (XAMPP, WAMP, or another server) and import `database/dbmwrs.sql` from the extracted folder.
3. If your MySQL server, port, user or password differ from `localhost:3306` / `root` / no password, open `MWRS.exe.config` in Notepad and edit the `MwrsDb` connection string.
4. Run `MWRS.exe`.

**From source**

1. Clone the repository, or download the [source .zip](https://github.com/nncast/vb.net-water-refilling-station/archive/refs/tags/v0.1.1.zip).
   ```bash
   git clone https://github.com/nncast/vb.net-water-refilling-station.git
   ```
2. Start MySQL using XAMPP, WAMP, or another server stack.
3. Import `database/dbmwrs.sql` with SQLYog or another MySQL client, or from the CLI:
   ```bash
   mysql -u root -p < database/dbmwrs.sql
   ```
4. Open `MWRS.sln` in Visual Studio.
5. If your MySQL settings differ from the defaults, edit the `MwrsDb` connection string in `MWRS/App.config`. `MySql.Data.dll` ships in the repository's `lib` folder, so nothing else needs to be installed for the reference.
6. Build and run the project.

Sign in with `admin` / `admin`, then change the password under **Users** (at least 8 characters). Passwords are stored as salted hashes.

**Upgrading from v0.1.0?** Your existing database works as it is: each plain-text password is replaced by a hash the next time that user signs in.

### Reports (optional)

The **Report** screen uses SAP Crystal Reports. To use it, install the **SAP Crystal Reports runtime for .NET Framework, 32-bit**
(`CRRuntime_32bit_13_0_*.msi`, from [SAP's download page](https://origin.softwaredownloads.sap.com/public/site/index.html) —
pick *SAP Crystal Reports, version for Visual Studio*). The reports read their data through the data source they were designed
with, `POSMWRS` (a 32-bit MySQL ODBC data source pointing to `dbmwrs`); if yours has another name, set `ReportServer` in
`MWRS.exe.config`. The database name, user and password come from the `MwrsDb` connection string. Without the runtime everything
else works, and **Report** tells you what to install.

To build from source you also need *SAP Crystal Reports, developer version for Microsoft Visual Studio* from the same page.

---

*Mangalos Water Refilling Station · Monitoring System · 2025 · VB.NET · Windows Forms · .NET Framework 4.8.1 · MariaDB*
