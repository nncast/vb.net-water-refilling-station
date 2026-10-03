<p align="center">
  <img src="MWRS/Resources/mwrs.png" alt="Mangalos Water Refilling Station logo" width="200"/>
</p>

<p align="center">
  <img src="https://img.shields.io/badge/version-0.1.0-4169E1?style=flat-square" alt="version">
  <img src="https://img.shields.io/badge/status-complete-2772BD?style=flat-square" alt="status">
  <img src="https://img.shields.io/badge/VB.NET-Windows_Forms-512BD4?style=flat-square&logo=dotnet&logoColor=white" alt="VB.NET">
  <img src="https://img.shields.io/badge/.NET_Framework-4.8.1-5C2D91?style=flat-square&logo=dotnet&logoColor=white" alt=".NET Framework">
  <img src="https://img.shields.io/badge/MariaDB-XAMPP-4479A1?style=flat-square&logo=mariadb&logoColor=white" alt="MariaDB">
</p>

<p align="center">
  <b>Download v0.1.0:</b>
  <a href="https://github.com/nncast/vb.net-water-refilling-station/archive/refs/tags/v0.1.0.zip">Source (.zip)</a> |
  <a href="https://github.com/nncast/vb.net-water-refilling-station/releases">All releases</a>
</p>

# MonitoringSystem-MangalosWaterRefillingStation

**Monitoring System: A Desktop-Based Application for Mangalos Water Refilling Station** is a desktop-based **VB.NET** application designed to automate and monitor daily operations of a water refilling business.
The system centralizes **sales, inventory, customer debts, and delivery records**, replacing manual logs and spreadsheets with a structured digital solution.

> **Current version: v0.1.0** — first tagged release. See [Releases](https://github.com/nncast/vb.net-water-refilling-station/releases) for the project timeline.

## Screenshots

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
| MySQL .NET Connector (`MySql.Data.dll`) | [Connector/NET](https://dev.mysql.com/downloads/connector/net/) |

## Setup and run instructions

1. Clone the repository, or download the [source .zip](https://github.com/nncast/vb.net-water-refilling-station/archive/refs/tags/v0.1.0.zip).
   ```bash
   git clone https://github.com/nncast/vb.net-water-refilling-station.git
   ```
2. Start MySQL using XAMPP, WAMP, or another MySQL service.
3. Import `database/dbmwrs.sql` to create and configure the database.
4. Open `MWRS.sln` in Visual Studio.
5. Make sure the project targets **.NET Framework 4.8.1 or later** and that `MySql.Data.dll` is referenced.
6. Build and run the application.

Sign in with `admin` / `admin`.

## Developers

- Kimberly S. Bernabe
- Janelle Ann F. Castillo
- Romar D. De Asis

---

*Mangalos Water Refilling Station · 2025 · VB.NET · Windows Forms · .NET Framework 4.8.1 · MariaDB*
