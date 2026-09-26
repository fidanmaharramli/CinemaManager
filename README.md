<div align="center">

<img src="https://vercel.app" width="100%"/>

# 🎬 Cinema Manager CLI System 🍿

### `Robust Backend & Database System Built with C# and .NET 10`

<img src="https://demolab.com" alt="Typing SVG"/>

<br>

<img src="https://shields.io"/>
<img src="https://shields.io"/>
<img src="https://shields.io"/>
<img src="https://shields.io"/>

</div>

---

<div align="center">

## 🎀 ABOUT THE PROJECT

</div>

**Cinema Manager** is a high-performance backend Console Relationship Management (CRM) prototype designed for movie theaters. It effortlessly handles movie catalogs, tracks custom audiences, manages live ticket purchases, and implements strict business logic validations (such as duration limits and secure ID processing).

### 🌸 Key Features:
- 🎬 **Comprehensive Movie Registry:** Full CRUD operations categorized by structural genres.
- 👥 **Customer Relationship Management:** Database tracking of custom profiles and metadata.
- 🎟️ **Advanced Ticket Transaction Engine:** Multi-entity table relationships mapping customers directly to live movie screenings.
- 🔒 **Data Integrity & Validations:** Safe numeric parsing (`int.TryParse`), input checks, and zero-crash exception handling.

---

<div align="center">

## 🧠 SYSTEM ARCHITECTURE

This project follows a strict **N-Tier Layered Architecture** to ensure clean separation of concerns and maintainable code:

</div>

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

<div align="center">

## 🛠️ TECHNOLOGIES USED

### Languages & Frameworks
<img src="https://skillicons.dev"/>

### Database & Data Access
<img src="https://skillicons.dev"/>

### Development Tools
<img src="https://skillicons.dev"/>

</div>

---

<div align="center">

## 🗄️ DATABASE DATA MATRIX

</div>

| System Entity | Properties & Fields Managed | Relational Status |
|---|---|---|
| **Movie** | `Id`, `Title`, `Genre` (Enum), `Duration` (min), `AgeLimit` | Core Catalog |
| **Customer** | `Id`, `Name`, `Age` | User Directory |
| **Ticket** | `Id`, `MovieId` (FK), `CustomerId` (FK), `SeatNumber`, `Price` | Transactional Mapping |

---

<div align="center">

## 🎨 PROJECT PREVIEW

</div>

The application comes bundled with a beautifully customized **Magenta & Soft Pink Console UI Layer**, optimized with native `UTF-8` character encoding for seamless rendering of smooth modern UI borders and responsive menu flows:

```text
╔══════════════════════════════════════════════════╗
║               CINEMA MANAGER                     ║
╠══════════════════════════════════════════════════╣
║                                                  ║
║     FILMLER                                      ║
║   1.  Film elave et                              ║
║   2.  Butun filmleri goster                      ║
...
║     BILETLER                                     ║
║   8.  Bilet al                                   ║
║   9.  Butun biletleri goster                     ║
╚══════════════════════════════════════════════════╝
```

---

<div align="center">

## 📊 GITHUB PROFILE STATS

<img src="https://vercel.app" />
<img src="https://vercel.app" />

<br><br>

<img src="https://demolab.com" />

</div>

---

<div align="center">

## 🌸 CORE DESIGN PRINCIPLES
> *"Clean code always looks like it was written by someone who cares."*

- **Progress Over Perfection:** Constantly refactoring code and learning advanced database features.
- **Graceful Debugging:** Conquered the trickiest Entity Framework `IDENTITY_INSERT` bugs like a real engineer! 💻
- **Continuous Growth:** Powered by curiosity, .NET logic, and persistent practice.

---

🎀 *Thanks for visiting this pink corner of my backend engineering portfolio!* 🌸

</div>
