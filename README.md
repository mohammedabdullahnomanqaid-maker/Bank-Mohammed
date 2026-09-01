# 🚀 MBank (v3.1.0)
«A robust desktop banking simulation application built with C#, Windows Forms, ADO.NET, and SQL Server, featuring a structured 3-Tier Architecture.»
---
## 📑 Table of Contents
- [Overview](#overview)
- [Key Features](#key-features)
- [Architecture & Design](#architecture--design)
- [Technologies](#technologies)
- [License](#license)
- [Author](#author)
---
## <a id="overview"></a>Overview
MBank is a desktop banking application developed as part of an incremental learning journey and practical implementation of programming concepts. The project evolved through multiple stages—starting from early iterations in C++, progressing through Object-Oriented Programming principles, transitioning to C# with file-based storage, and finally culminating in a production-style architecture backed by a relational database management system. 
The application is designed to simulate core banking operations, including client and user management, monetary transactions, currency exchange, vault tracking, and comprehensive security logging.
---

## 📸 Screenshots

<details>
<summary><strong>View Screenshots</strong></summary>

<br>

### 🔐 Login

<img src="Screenshots/Login.png" alt="Login" width="800">

### 📊 Dashboard

<img src="Screenshots/Dashboard.png" alt="Dashboard" width="800">

### 👥 Manage People

<img src="Screenshots/Manage-People.png" alt="Manage People" width="800">

### 💱 Currency Exchange

<img src="Screenshots/CurrencyExchange.png" alt="Currency Exchange" width="800">

### 🏦 Vault

<img src="Screenshots/Vault.png" alt="Vault" width="800">

</details>

---
## <a id="key-features"></a>Key Features
### 👥 Manage Clients
- **CRUD Operations:** Complete creation, reading, updating, and deletion capabilities for client accounts.
- **Data Integrity:** Prevention of duplicate account numbers.
- **Live Search:** Direct and real-time search functionality.
- **Soft Delete:** Preservation of historical data by converting accounts to an `Inactive` status rather than permanent deletion.
- **Dynamic Location Integration:** Automated population of cities upon selecting a specific country.
- **Phone Number Validation:** Rigorous validation enforcing correct country codes and digit counts based on the chosen country.
### 🔐 Manage Users
- **User Administration:** Full lifecycle management of system users.
- **Permission System:** Granular access control defining specific operational privileges per user.
- **System Protection:** Built-in safeguards protecting the primary `Admin` account from unauthorized deletion or critical modification.
### 💳 Transactions
- **Core Banking Operations:** Execution of deposits, withdrawals, and account-to-account transfers.
- **Vault Integration:** Real-time reflection of all monetary transactions on the central bank vault, accompanied by a live vault monitoring interface.
- **Transfer Log:** Comprehensive audit trail recording all internal fund transfers for complete tracking.
### 📝 Login Register
- **Activity Tracking:** Systematic logging of all user authentication and system access events.
### 💱 Currency Exchange
- **Currency Management:** Full CRUD operations for managing different currencies.
- **Currency Calculator:** Built-in utility to compute real-time exchange rates between currencies.
- **Restricted Privileges:** Secure restriction allowing only the `Admin` user to introduce new currencies due to the critical nature of the operation.
### ⚠️ Error Logging
- **Exception Tracking:** Automatic recording of application errors and exceptions into a dedicated log file to facilitate diagnostics and troubleshooting.
---
## <a id="architecture--design"></a>Architecture & Design
- **3-Tier Architecture:** The application is structurally separated into distinct layers to promote maintainability, scalability, and separation of concerns:
  - **Presentation Layer (UI):** Windows Forms interface handling user interaction.
  - **Business Logic Layer (BLL):** Core application logic and validation rules.
  - **Data Access Layer (DAL):** Database interactions utilizing ADO.NET and SQL Server.
- **Object-Oriented Programming (OOP):** Built on solid OOP principles to model entities and govern system behavior.
---
## <a id="technologies"></a>Technologies

| Technology | Purpose |
| :--- | :--- |
| **C#** | Core programming language |
| **Windows Forms (WinForms)** | Desktop user interface development |
| **ADO.NET** | Data access framework for database connectivity |
| **SQL Server** | Relational database management system |
| **3-Tier Architecture** | Software design pattern for separating application layers |

---
## <a id="license"></a>License
This project is open-source and available under the **MIT License**. You are free to use, modify, and distribute it in any way you choose, provided that proper copyright and attribution to the original author are maintained.
---
## <a id="author"></a>Author
- **Developer:** Mohammed Abdullah Noman
- **Special Acknowledgment:** Developed under the roadmap and guidance of Dr. Mohammed Abu-Hadhoud (Programming Advices).
