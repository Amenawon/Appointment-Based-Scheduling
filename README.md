# 🗓️ Appointment Booking System Backend

This is the **backend API** for the Appointment Scheduling System, designed to manage user authentication, appointment scheduling, and role-based access control.  
Built with **ASP.NET Core 6**, it provides endpoints for integration with a React frontend.

<img width="1757" height="857" alt="image" src="https://github.com/user-attachments/assets/6e34e8be-d612-4f47-85a2-9c00e199a4eb" />


---

## 🚀 Features

- 🔐 **User Authentication & Authorization** using **ASP.NET Core Identity** and **JWT tokens**
- 👥 **Role-based access control** – supports `Admin`, `User`, and `Attendee` roles
- 📅 **Appointment management** – create and view appointments
- 👤 **User management** – register new users, assign roles, and retrieve user details
- 🧩 **Entity Framework Core integration** with **SQL Server** for data persistence
- 🧾 **Swagger API documentation** for easy testing and exploration

---

## 🧰 Technologies Used

- **C#**, **ASP.NET Core 6**
- **Entity Framework Core**
- **ASP.NET Core Identity**
- **JWT (JSON Web Token)** Authentication
- **SQL Server**
- **Swagger / Swashbuckle** for API documentation

---

## ⚙️ Setup Instructions

### 1️. Clone the repository

### 2. Configure the database

Update the appsettings.json file with your SQL Server connection string.

### 3. Configure JWT

In appsettings.json, set your JWT settings.

### 4. Apply migrations

```bash
dotnet ef database update
```

### 5. Run the application

```bash
dotnet run
```
