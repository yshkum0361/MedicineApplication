📘 .NET 8 Medicines Management App

A complete .NET 8 Razor Pages + MSSQL + Google SSO application for managing medicines with full CRUD operations, pagination, sorting, filtering, user authentication, and a post-login dashboard.

📑 Table of Contents

🚀 Project Overview

🏗️ Architecture

🧰 Tech Stack

📦 Features

📁 Folder Structure

🗄️ Database Schema

🔐 Authentication (Google SSO)

⚙️ Installation & Setup

🧪 Running the Application

🧭 Application Screens

📝 API/CRUD Behaviour

☁️ Deployment Guide (Azure)

🛠️ Troubleshooting

📜 License

🚀 Project Overview

---
This is a fully functional medicine management system built using modern .NET technologies.

Users authenticate using Google Single Sign-On (OpenID Connect), and once logged in they can:

View their personalized dashboard

Manage a full list of medicines

Add/Edit/Delete medicines

Filter, sort, and paginate medicine data

The main purpose of this project is to demonstrate expertise in:

✔ .NET 8
✔ MSSQL
✔ Razor Pages
✔ Entity Framework Core
✔ Identity + Google OAuth
✔ CRUD operations
✔ Pagination / Sorting / Filtering



---
```
🏗️ **Architecture**

┌────────────────────────┐
│ Browser │
│ Razor Pages Frontend │
└────────────┬───────────┘
│ HTTPS / Auth Cookies
┌────────────▼───────────┐
│ ASP.NET Core 8 │
│ Razor Pages + Identity│
└────────────┬───────────┘
│ EF Core
┌────────────▼───────────┐
│ Application DB │
│ (SQL Server / MSSQL) │
└─────────────────────────┘




```

---

🧰 **Tech Stack**

**Backend**
- .NET 8
- ASP.NET Core Razor Pages
- Entity Framework Core 8
- ASP.NET Identity
- Google OAuth / OpenID Connect

**Database**
- Microsoft SQL Server (LocalDB in development)

**Frontend**
- Razor Pages (CSHTML)
- Bootstrap 5
- Layout-based UI

**Tools**
- EF Core Migrations
- Secret Manager for OAuth keys

---
Google SSO login

Persistent user profile (Identity)

Dashboard with user info

Medicines CRUD (Create, Read, Update, Delete)

SQL-backed data storage

🔍 Medicine Listing Features

Pagination

Sorting (ASC/DESC)

Filtering/Search

Bootstrap table styling

💎 Optional Enhancements Included

Responsive layout

Authorization enforcement

Developer exception filters

Manage Account page via Identity

---
```
📁 Folder Structure
DotNet8MedicinesApp/
├── Data/
│   └── ApplicationDbContext.cs
├── Models/
│   ├── Medicine.cs
│   └── ApplicationUser.cs
├── Pages/
│   ├── Index.cshtml (+ .cs)
│   ├── Medicines/
│   │   ├── Index.cshtml (+ .cs)
│   │   ├── Create.cshtml (+ .cs)
│   │   ├── Edit.cshtml (+ .cs)
│   │   ├── Delete.cshtml (+ .cs)
│   │   └── Details.cshtml (+ .cs)
│   ├── Shared/
│   │   └── _Layout.cshtml
│   └── Error.cshtml
├── appsettings.json
├── Program.cs
└── README.md
```

---
🗄️ Database Schema
ApplicationUser table

(Provided by Identity)

Column	Type	Notes
Id	string	Primary Key
UserName	string	Login name
Email	string	Email address
PasswordHash	string	Authentication
...	...	Identity defaults
Medicine table
Column	Type	Notes
MedicineId	int (PK)	Identity
Name	nvarchar(100)	Required
Company	nvarchar(100)	Required
Price	decimal(18,2)	Required
ExpiryDate	date	Required
Stock	int	Required
CreatedOn	datetime	Set automatically

---
🔐 Authentication (Google SSO)
1️⃣ Google Cloud Console

Create a new OAuth Client ID:

Authorized redirect URI:

https://localhost:7001/signin-google

2️⃣ Set secrets securely
dotnet user-secrets set "Authentication:Google:ClientId" "YOUR_ID"
dotnet user-secrets set "Authentication:Google:ClientSecret" "YOUR_SECRET"


Identity automatically displays a Sign in with Google button.

---
⚙️ Installation & Setup
Clone the repository
git clone https://github.com/yshkum0361/MedicineApplication.git

cd MedicineApplication

Install dependencies
dotnet restore

Run EF Core migrations
dotnet ef migrations add InitialSetup

dotnet ef database update


Run the project
dotnet run


🧪 Running the Application

Default endpoints:

Page	URL

Login	/Identity/Account/Login\

Dashboard	/

Medicine List	/Medicines

Create Medicine	/Medicines/Create

---
🧭 Application Screens
📌 Dashboard

Shows:

Username

Email

Login Provider

Manage Account button

📌 Medicine List

Includes:

Search by name/company

Sorting by: Name, Price, Expiry

Pagination (Prev/Next + pages)

Edit/Delete buttons

📌 CRUD Screens

Bootstrap UI

Server validation

Model binding

Automatic redirect after save

📝 API/CRUD Behaviour
Action	HTTP Method	Page
List medicines	GET	/Medicines/Index
Create medicine	POST	/Medicines/Create
Edit medicine	POST	/Medicines/Edit/{id}
Delete medicine	POST	/Medicines/Delete/{id}

All actions require an authenticated user.

```
Feature,Status,Details
Authentication,✅ Implemented,SSO via Google (OpenID Connect/OAuth 2.0 flow) using Microsoft.AspNetCore.Authentication.Google.
User Persistence,✅ Implemented,"Uses ApplicationUser (extends IdentityUser) to store login details (name, email, provider, timestamp) in the DB."
CRUD Operations,✅ Implemented,"Full CRUD functionality for the Medicine entity via scaffolded Razor Pages (/Medicines/Create, /Edit, /Delete)."
Database Schema,✅ Implemented,MSSQL database (Medicines and Identity tables) managed by EF Core.
Post-Login Dashboard,✅ Implemented,"Displays logged-in user details (Username, Email, Login Provider)."
Front-End/UI,✅ Implemented,Responsive UI using Bootstrap 5.
```

```
Feature,Status,Details
Search/Filter/Sort,✅ Implemented,"The Medicine List page includes filtering by Name/Company and supports sorting on Name, Price, and Expiry Date."
Pagination,✅ Implemented,The Medicine List page implements server-side pagination (10 items per page).
Logging/Error Handling,✅ Implemented,Standard ASP.NET Core logging and the Developer Exception Page middleware are configured.
Deployment,(Optional),The solution is deployable to Azure App Services.

```

---
🤖 List of AI / Tools Used
The following AI tools were utilized to assist in the assignment structure, guidance, and code generation.

Google Gemini (Flash 2.5) / CHAT GPT / Perplexity : Used for initial project structure guidance, generating EF Core model boilerplate, and refining the Razor Pages logic for sorting and pagination in the Medicines/Index.cshtml.cs file, used for google sign in, and Azure Deployment.
---
