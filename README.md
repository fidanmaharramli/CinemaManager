# 🌸 Welcome to Cinema Manager CLI System 🍿

### `Cinema Management System built with C# and .NET 10` 💻

---

## 🎀 ABOUT THE PROJECT

**Cinema Manager** is a console-based cinema management system built with **C#**, **.NET 10**, **Entity Framework Core** and **SQL Server**.

The application allows users to manage movies and customers, buy and cancel tickets, search records and validate ticket purchases.

### 💮 Main Features

* 🎬 Movie management
* 👥 Customer management
* 🎟️ Ticket purchase and cancellation
* 🔎 Search by Id
* 🔒 Business validation
* 🗄️ SQL Server database integration

---

## 🛠️ TECHNOLOGIES

`C#` · `.NET 10` · `Entity Framework Core` · `SQL Server` · `LINQ` · `Git` · `GitHub`

---

## 🧠 PROJECT STRUCTURE

```text
CinemaManager
│
├── Entities
│   ├── Genre.cs
│   ├── Movies.cs
│   ├── Customer.cs
│   └── Ticket.cs
│
├── Data
│   └── AppDbContext.cs
│
├── Services
│   └── CinemaService.cs
│
└── Program.cs
```

### 📦 Main Entities

| Entity | Main Properties |
|---|---|
| **Movie** | `Id`, `Title`, `Genre`, `Duration`, `AgeLimit` |
| **Customer** | `Id`, `Name`, `Age` |
| **Ticket** | `Id`, `MovieId`, `CustomerId`, `SeatNumber`, `Price` |

---

## 🔒 VALIDATION

The system checks:

* Duplicate IDs
* Existing movies and customers
* Customer age restrictions
* Ticket price
* Occupied seats
* Invalid user input

---

## 🗄️ DATABASE

Database:

```text
CinemaManagerDb
```

SQL Server:

```text
.\SQLEXPRESS
```

Entity Framework Core is used to communicate with the database and manage relationships between **Movies, Customers and Tickets**.

---

## ▶️ RUN THE PROJECT

Create the database with Entity Framework Core:

```powershell
Add-Migration InitialCreate
Update-Database
```

Then run the project from **Visual Studio**.

---

## 🌸 GITHUB

Repository: **CinemaManager**

Built as a practical C# and .NET learning project.

---

<p align="center">
  🎀 <i>Thanks for visiting my little cinema corner!</i> 🍿🌸
</p>
