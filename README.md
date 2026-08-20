# Appointment & Service Booking Platform

An appointment and service booking platform built with **ASP.NET Core MVC**.

The application is intended to allow customers to book services with available employees, while administrators and employees can manage services, availability, and appointments.

---

## Project Status

**Current Phase:** Initial Project Setup & Architecture

The project currently contains the foundational solution structure and project dependencies. Application features will be implemented incrementally.

---

## Tech Stack

- **Backend:** ASP.NET Core MVC
- **Language:** C#
- **ORM:** Entity Framework Core
- **Database:** SQL Server
- **Authentication:** ASP.NET Core Identity
- **Frontend:** Razor Views + Bootstrap
- **JavaScript:** JavaScript + jQuery
- **UI Components & Charts:** DevExtreme
- **Architecture:** Clean Architecture

---

## Solution Structure

```text
BookingSystem/
│
├── BookingSystem.Web.sln
│
├── Web/
│   └── BookingSystem.Web
│       ├── Controllers/
│       ├── Views/
│       ├── wwwroot/
│       └── Program.cs
│
├── Application/
│   └── BookingSystem.Application
│       ├── DTOs/
│       ├── Interfaces/
│       └── ...
│
├── Domain/
│   └── BookingSystem.Domain
│       ├── Entities/
│       ├── Enums/
│       └── ...
│
└── Infrastructure/
    └── BookingSystem.Infrastructure
        ├── Data/
        ├── Repositories/
        └── ...
```
# Architecture

The solution is organized into separate projects according to their responsibilities.

# Domain

Contains the core business/domain layer.

# Responsibilities:

Domain entities
Enums
Domain-related rules
Core abstractions

The Domain project should remain independent of the other application layers.

# Application

Contains application-level logic and abstractions.

# Responsibilities:

DTOs
Application interfaces
Use-case logic
Application-specific abstractions
Infrastructure

Contains implementations that interact with external systems.

# Responsibilities:

Entity Framework Core
Database configuration
DbContext
Data access
External service implementations
Web

Contains the ASP.NET Core MVC presentation layer.

# Responsibilities:

Controllers
Views
ViewModels
Web configuration
User interaction

# Current Setup

The following setup has been completed:

 Solution created
 Web project created
 Domain project created
 Application project created
 Infrastructure project created
 Project references configured
 Solution build verified
 .gitignore added
 Initial README added
 Git repository initialized

# Planned Features

The following features are planned for future development:

# Authentication & Authorization
User registration and login
Customer, Employee, and Admin roles
Role-based authorization

# Service Management
Create services
Update services
Delete services
View available services

# Employee Management
Manage employees
Assign services to employees
Configure employee availability

# Appointment Booking
Select service
Select employee
Select date
View available time slots
Create appointment
Prevent double booking

# Appointment Management
View upcoming appointments
View past appointments
Confirm appointments
Complete appointments
Cancel appointments

# Administration
Manage services
Manage employees
Manage appointments
Dashboard statistics

# Development Approach

Features will be developed incrementally using Git feature branches.

Example:

main
 │
 ├── feature/identity-authentication
 │
 ├── feature/service-management
 │
 ├── feature/employee-management
 │
 ├── feature/availability-management
 │
 └── feature/appointment-booking

Each feature will be developed on its own branch and merged into main through a Pull Request.

## Getting Started
# Prerequisites
.NET 8 SDK
Visual Studio 2022 or VS Code
SQL Server / LocalDB

# Clone the Repository
git clone <https://github.com/Basant948/AppointmentBookingSystem>
cd AppointmentBookingSystem

# Restore Dependencies
dotnet restore

# Build the Solution
dotnet build

# Run the Application
dotnet run --project Web

# Project Goals

The main goals of this project are:

- Build a realistic appointment booking application
- Practice ASP.NET Core MVC development
- Apply Clean Architecture principles
- Work with Entity Framework Core
- Implement authentication and authorization
- Handle real-world booking and availability scenarios
- Maintain a professional Git workflow

# License

This project is created for educational and portfolio purposes.

## 👨‍💻 Author

Basant Ritu Rajbanshi