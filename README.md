# MonitoringSystem-MangalosWaterRefillingStation  
(2025)

**Monitoring System: A Desktop-Based Application for Mangalos Water Refilling Station** is a desktop-based **VB.NET** application designed to automate and monitor daily operations of a water refilling business.  

<img width="400" alt="image" src="https://github.com/user-attachments/assets/3bd57d10-0d6a-400b-9f2b-f991b359c5dc" />
<img width="400" alt="image" src="https://github.com/user-attachments/assets/5d31da9c-a5a5-4845-8c63-d7d6f433cb78" />
<img width="400" alt="image" src="https://github.com/user-attachments/assets/635aa071-56cf-4884-8003-b7635a8b77be" />
<img width="400" alt="image" src="https://github.com/user-attachments/assets/367026e6-dbf2-40cd-bf8e-44ddbd099c12" />
<img width="400" alt="image" src="https://github.com/user-attachments/assets/82ff853a-4d94-4322-a1fa-6191cf00defd" />
<img width="400" alt="image" src="https://github.com/user-attachments/assets/5f7bcab5-87f9-489c-a744-d6d931368bab" />



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

