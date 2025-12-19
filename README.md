# MonitoringSystem-MangalosWaterRefillingStation  
(2025)

**Monitoring System: A Desktop-Based Application for Mangalos Water Refilling Station** is a desktop-based **VB.NET** application designed to automate and monitor daily operations of a water refilling business.  
The system centralizes **sales, inventory, customer debts, and delivery records**, replacing manual logs and spreadsheets with a structured digital solution.

## Features

### **Administrator Functions**
- Manage user accounts and access roles
- View and manage customer records including barangay, purok, and outstanding balances
- Monitor sales, inventory levels, and delivery logs
- Generate basic summary reports for sales, inventory, and deliveries
- Maintain system data consistency and accuracy

### **Employee Functions**
- Secure login authentication
- Record sales transactions linked to customers
- Update inventory automatically based on sales
- Track customer payments and unpaid balances
- Process orders and record delivery or pick-up status using guided navigation

## System Highlights
- Desktop-based POS and monitoring system
- Digital database for reliable storage and retrieval of records
- Clear transaction flow: **Sales → Orders → Delivery**
- Customer debt tracking with paid and pending status
- Separate address fields (Barangay and Purok) for accurate delivery records
- Role-based access for admin and employees

## Requirements
- Visual Studio 2012 or later  
  [Download Visual Studio](https://visualstudio.microsoft.com/downloads/)
- .NET Framework 4.8.1 or later  
  [Download .NET Framework 4.8.1](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net481)
- XAMPP or WAMP (for MySQL database)  
  [Download XAMPP](https://www.apachefriends.org/index.html)
  [Download WAMP](https://www.wampserver.com/en/)
- MySQL Client (e.g., SQLYog, phpMyAdmin, or MySQL Workbench)
  [Download SQLYog](https://github.com/webyog/sqlyog-community/wiki/Downloads)
- MySQL .NET Connector (`MySql.Data.dll`)  
  [Download Connector/NET](https://dev.mysql.com/downloads/connector/net/)

## Installation
1. Download and extract the project `.zip` file.
2. Start MySQL using XAMPP, WAMP, or another MySQL service.
3. Import the provided `.sql` file to create and configure the database.
4. Open the solution file (`.sln`) in Visual Studio.
5. Ensure the following before running:
   - The project targets **.NET Framework 4.8.1 or later**
   - `MySql.Data.dll` is properly referenced in the project
6. Build and run the application.

---


**Developers:**  
- Kimberly S. Bernabe  
- Janelle Ann F. Castillo  
- Romar D. De Asis  

