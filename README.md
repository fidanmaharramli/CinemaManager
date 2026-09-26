# 🌸 Welcome to Cinema Manager CLI System 🍿

### `Robust Backend & Database System Built with C# and .NET 10` 💻

---

## 🎀 ABOUT THE PROJECT

**Cinema Manager** is a high-performance backend Console Relationship Management (CRM) prototype designed for movie theaters. It effortlessly handles movie catalogs, tracks custom audiences, manages live ticket purchases, and implements strict business logic validations.

### 💮 Key Features:
* 🎬 **Comprehensive Movie Registry:** Full CRUD operations categorized by structural genres.
* 👥 **Customer Relationship Management:** Database tracking of custom profiles and metadata.
* 🎟️ **Advanced Ticket Transaction Engine:** Multi-entity table relationships mapping customers directly to live movie screenings.
* 🔒 **Data Integrity & Validations:** Safe numeric parsing (`int.TryParse`), input checks, and zero-crash exception handling.

---

## 🧠 SYSTEM ARCHITECTURE

This project follows a strict **N-Tier Layered Architecture** to ensure clean separation of concerns and maintainable code:

```text
 ── CinemaManager.Entities (Core Domain Models: Movie, Customer, Ticket)
      ▲
      │ (References Domain)
 ── CinemaManager.Data     (AppDbContext, SQL Server Schema Configurations)
      ▲
      │ (Manages Transactions)
 ── CinemaManager.Services (CinemaService: Core Business Logic & Queries)
      ▲
      │ (Triggers Operations)
 ── Main Application       (Program.cs CLI Engine with UTF-8 UI Rendering)
```

---

## 🛠️ TECHNOLOGIES USED

* 💻 **Languages & Frameworks:** `C#` | `.NET 10` | `Entity Framework Core`
* 🗄️ **Database & Data Access:** `Microsoft SQL Server` | `LINQ Queries`
* 🔧 **Development Tools:** `Git & GitHub` | `Visual Studio` | `SQL Server Management Studio (SSMS)`

---

## 🗄️ DATABASE DATA MATRIX

| 🌷 System Entity | 💗 Properties & Fields Managed | 🎀 Relational Status |
|---|---|---|
| **Movie** | `Id`, `Title`, `Genre` (Enum), `Duration` (min), `AgeLimit` | Core Catalog |
| **Customer** | `Id`, `Name`, `Age` | User Directory |
| **Ticket** | `Id`, `MovieId` (FK), `CustomerId` (FK), `SeatNumber`, `Price` | Transactional Mapping |

---

## 🌸 CORE DESIGN PRINCIPLES
> *"Clean code always looks like it was written by someone who cares."*

* **Progress Over Perfection:** Constantly refactoring code and learning advanced database features.
* **Graceful Debugging:** Conquered the trickiest Entity Framework `IDENTITY_INSERT` bugs like a real engineer! 💻
* **Continuous Growth:** Powered by curiosity, .NET logic, and persistent practice.

---

<p align="center">
  🎀 <i>Thanks for visiting this pink corner of my backend engineering portfolio!</i> 🌸
</p>
