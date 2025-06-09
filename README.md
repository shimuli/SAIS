
# 🧾 Social Assistance Blazor App

This project is a Blazor Server application for digitizing a **Social Assistance Application Form**. It leverages **ASP.NET Core**, **Entity Framework Core**, **SQL Server**, and **Bootstrap** to allow users to submit applications, and administrators to manage applicant data.

---

## 🚀 Project Setup Instructions

### 1. 🛠️ Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Visual Studio 2022+](https://visualstudio.microsoft.com/)
- Git

---

### 2. 📥 Clone the Repository

```bash
git clone https://github.com/shimuli/SAIS.git
cd SAIS
```

---

### 3. ⚙️ Update Connection String

Edit the `appsettings.json` file and update the `DefaultConnection`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=SAISDB;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

---

### 4. 📦 Run Migrations & Create Database

In Visual Studio **Package Manager Console**:

```bash
Update-Database
```

> This creates all the required tables.

---

## 🌱 Seeding Reference Data

You can insert some baseline reference data (Gender, Marital Status, Programme) by calling a custom `SeedReferenceData()` method from a class like `SeedData.cs`.

---

## 📄 Manual Data Insertion for County Hierarchy

Use this SQL script to populate the county hierarchy directly in **SQL Server**:

```sql
-- ================================
-- Counties
-- ================================
INSERT INTO Counties (CountyId, Name) VALUES 
(1, 'Uasin Gishu'),
(2, 'Kakamega'),
(3, 'Kisumu');

-- ================================
-- SubCounties
-- ================================
INSERT INTO SubCounties (SubCountyId, Name, CountyId) VALUES 
(1, 'Eldoret East', 1),
(2, 'Eldoret West', 1),
(3, 'Lugari', 2),
(4, 'Likuyani', 2),
(5, 'Kisumu East', 3),
(6, 'Kisumu West', 3);

-- ================================
-- Locations
-- ================================
INSERT INTO Locations (LocationId, Name, SubCountyId) VALUES 
(1, 'Kapsoya', 1),
(2, 'Langas', 2),
(3, 'Mautuma', 3),
(4, 'Sinoko', 4),
(5, 'Nyalenda', 5),
(6, 'Obunga', 6);

-- ================================
-- SubLocations
-- ================================
INSERT INTO SubLocations (SubLocationId, Name, LocationId) VALUES 
(1, 'Kipkaren', 1),
(2, 'Kamukunji', 2),
(3, 'Lwandeti', 3),
(4, 'Sango', 4),
(5, 'Kilo', 5),
(6, 'Bandani', 6);

-- ================================
-- Villages
-- ================================
INSERT INTO Villages (VillageId, Name, SubLocationId) VALUES 
(1, 'Cheplaskei', 1),
(2, 'Kapchorua', 2),
(3, 'Makutano', 3),
(4, 'Stendikisa', 4),
(5, 'Kachok', 5),
(6, 'Nyamasaria', 6);
```

> You can paste and run this in **SQL Server Management Studio (SSMS)**.

---



## 📌 Credits

This system is part of the **Senior Systems Developer Practical Test – Development Pathways**, June 2025.

---

