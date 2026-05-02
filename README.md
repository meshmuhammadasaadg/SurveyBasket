# 📊 SurveyBasket API

<div align="center">

![.NET](https://img.shields.io/badge/.NET%209-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework%20Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)
![JWT](https://img.shields.io/badge/JWT-000000?style=for-the-badge&logo=jsonwebtokens&logoColor=white)
![Swagger](https://img.shields.io/badge/Swagger-85EA2D?style=for-the-badge&logo=swagger&logoColor=black)

A production-ready **REST API** for managing surveys, questions, and votes — built with clean architecture principles and modern .NET 9 practices.

</div>

---

## 📌 Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Tech Stack](#tech-stack)
- [Project Structure](#project-structure)
- [Getting Started](#getting-started)
- [API Modules](#api-modules)
- [Authentication & Authorization](#authentication--authorization)
- [Configuration](#configuration)
- [Course Reference](#course-reference)

---

## Overview

**SurveyBasket** is a full-featured survey management system built as a RESTful API with .NET 9. It allows administrators to create polls with questions, manage users and roles, and collect and analyze votes — all secured with JWT-based authentication, refresh tokens, and fine-grained role/permission-based authorization.

---

## ✨ Features

### 🔐 Authentication & Security

- JWT Authentication with configurable expiry
- Refresh Token support with revocation
- Role-based & Permission-based Authorization
- ASP.NET Core Identity integration
- User lockout & account management
- Email confirmation with verification codes

### 📋 Surveys & Voting

- Full CRUD for Polls (with toggle status)
- Questions management per poll
- Voting system with duplicate prevention
- Results & analytics (votes per day, votes per question)

### 👥 User Management

- User registration with email verification
- Profile management & password change
- Admin user management (create, update, lock/unlock)
- Role & permissions management with seeded defaults

### 🛠 Developer Experience

- Global error handling with Problem Details (RFC 7807)
- Custom `Result<T>` pattern for clean error propagation
- FluentValidation for all request models
- Mapster for fast object mapping
- Structured logging with Serilog (console + DB sinks)
- Audit logging (CreatedBy, UpdatedAt, etc.)
- Cancellation Token support on all async endpoints

### ⚡ Performance & Reliability

- In-Memory Cache, Distributed Cache (Redis-ready), Output Cache & Hybrid Cache
- Response Caching
- Hangfire background jobs (fire-and-forget + recurring)
- Rate Limiting (Fixed Window, Sliding Window, Token Bucket, Concurrency, IP & User-based)
- Health Checks (DB, Hangfire, external URIs, custom checks)

### 🌐 API Design

- CORS with multi-policy support
- API Versioning (URL segment, header, query string)
- Pagination, Filtering & Sorting
- OpenAPI / Swagger documentation with Scalar UI
- UUID v7 for entity IDs

---

## 🧰 Tech Stack

| Layer           | Technology                                     |
| --------------- | ---------------------------------------------- |
| Framework       | ASP.NET Core 9 Web API                         |
| ORM             | Entity Framework Core                          |
| Database        | SQL Server                                     |
| Authentication  | ASP.NET Core Identity + JWT Bearer             |
| Mapping         | Mapster                                        |
| Validation      | FluentValidation                               |
| Logging         | Serilog                                        |
| Background Jobs | Hangfire                                       |
| Caching         | IMemoryCache / IDistributedCache / HybridCache |
| API Docs        | Swagger (Swashbuckle) + OpenAPI + Scalar       |
| Versioning      | Asp.Versioning.Http                            |

---

## 📁 Project Structure

```
SurveyBasket/
├── SurveyBasket.Api/
│   ├── Controllers/          # API controllers per module
│   ├── Contracts/            # Request & Response DTOs
│   ├── Entities/             # Domain models (Poll, Question, Vote, etc.)
│   ├── Services/             # Business logic & service interfaces
│   ├── Persistence/          # DbContext, EF configurations, migrations
│   ├── Authentication/       # JWT provider, token validation
│   ├── Errors/               # Custom error types & Result pattern
│   ├── Mapping/              # Mapster profiles
│   ├── Middleware/           # Exception handling middleware
│   ├── Extensions/           # Service registration & helper extensions
│   └── Program.cs            # Application entry point
└── SurveyBasket.slnx
```

---

## 🚀 Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server)
- [Visual Studio 2026+](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

### Setup

1. **Clone the repository**

   ```bash
   git clone https://github.com/meshmuhammadasaadg/SurveyBasket.git
   cd SurveyBasket
   ```

2. **Configure your connection string and secrets**

   Update `appsettings.json` or use User Secrets:

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=.;Database=SurveyBasketDb;Trusted_Connection=True;"
     },
     "JwtSettings": {
       "Key": "your-super-secret-key",
       "Issuer": "SurveyBasketApp",
       "Audience": "SurveyBasketUsers",
       "ExpiryMinutes": 30
     },
     "MailSettings": {
       "Host": "smtp.example.com",
       "Port": 587,
       "Mail": "noreply@example.com",
       "DisplayName": "SurveyBasket",
       "Password": "your-password"
     }
   }
   ```

3. **Apply database migrations**

   ```bash
   dotnet ef database update
   ```

4. **Run the API**

   ```bash
   dotnet run --project SurveyBasket.Api
   ```

5. **Open Scalar UI**

   Navigate to `https://localhost:{port}/scalar` to explore the API.

---

## 📦 API Modules

### 🗳 Polls

| Method   | Endpoint                       | Description               |
| -------- | ------------------------------ | ------------------------- |
| `GET`    | `/api/polls`                   | Get all polls (paginated) |
| `GET`    | `/api/polls/{id}`              | Get poll by ID            |
| `POST`   | `/api/polls`                   | Create new poll           |
| `PUT`    | `/api/polls/{id}`              | Update poll               |
| `DELETE` | `/api/polls/{id}`              | Delete poll               |
| `PUT`    | `/api/polls/{id}/toggleStatus` | Toggle poll status        |

### ❓ Questions

| Method | Endpoint                                          | Description            |
| ------ | ------------------------------------------------- | ---------------------- |
| `GET`  | `/api/polls/{pollId}/questions`                   | Get all questions      |
| `POST` | `/api/polls/{pollId}/questions`                   | Add question           |
| `PUT`  | `/api/polls/{pollId}/questions/{id}`              | Update question        |
| `PUT`  | `/api/polls/{pollId}/questions/{id}/toggleStatus` | Toggle question status |

### 🗃 Votes

| Method | Endpoint                    | Description                    |
| ------ | --------------------------- | ------------------------------ |
| `GET`  | `/api/polls/current`        | Get available polls for voting |
| `POST` | `/api/polls/{pollId}/votes` | Submit vote                    |

### 📈 Results

| Method | Endpoint                                 | Description               |
| ------ | ---------------------------------------- | ------------------------- |
| `GET`  | `/api/polls/{pollId}/votes/results`      | Poll vote results         |
| `GET`  | `/api/polls/{pollId}/votes/per-day`      | Votes grouped by day      |
| `GET`  | `/api/polls/{pollId}/votes/per-question` | Votes grouped by question |

### 🔑 Auth

| Method | Endpoint                              | Description              |
| ------ | ------------------------------------- | ------------------------ |
| `POST` | `/api/auth/register`                  | Register new user        |
| `POST` | `/api/auth/confirm-email`             | Confirm email address    |
| `POST` | `/api/auth/resend-confirmation-email` | Resend verification code |
| `POST` | `/api/auth/login`                     | Login and get JWT        |
| `POST` | `/api/auth/refresh`                   | Refresh access token     |
| `POST` | `/api/auth/revoke-refresh-token`      | Revoke refresh token     |

### 👤 Account

| Method | Endpoint                       | Description              |
| ------ | ------------------------------ | ------------------------ |
| `GET`  | `/api/account/profile`         | Get current user profile |
| `PUT`  | `/api/account/profile`         | Update profile           |
| `PUT`  | `/api/account/change-password` | Change password          |
| `POST` | `/api/account/forget-password` | Request password reset   |
| `POST` | `/api/account/reset-password`  | Reset password           |

### 👥 Users Management _(Admin)_

| Method | Endpoint                       | Description      |
| ------ | ------------------------------ | ---------------- |
| `GET`  | `/api/users`                   | List all users   |
| `POST` | `/api/users`                   | Create user      |
| `PUT`  | `/api/users/{id}`              | Update user      |
| `PUT`  | `/api/users/{id}/toggleStatus` | Lock/unlock user |
| `PUT`  | `/api/users/{id}/unlock`       | Unlock user      |

### 🏷 Roles Management _(Admin)_

| Method | Endpoint                       | Description                    |
| ------ | ------------------------------ | ------------------------------ |
| `GET`  | `/api/roles`                   | Get all roles                  |
| `GET`  | `/api/roles/{id}`              | Get role details & permissions |
| `POST` | `/api/roles`                   | Create new role                |
| `PUT`  | `/api/roles/{id}`              | Update role                    |
| `PUT`  | `/api/roles/{id}/toggleStatus` | Toggle role status             |

---

## 🔐 Authentication & Authorization

The API uses **JWT Bearer tokens** with an **Options Pattern** for configuration. Tokens include embedded roles and permissions claims.

- Default roles and permissions are **seeded automatically** on startup
- New registered users are assigned a default role
- Protected endpoints use `[Authorize]` with policy-based permission checks
- The **Hangfire dashboard** is protected and requires admin access

---

## ⚙️ Configuration

| Section             | Description                         |
| ------------------- | ----------------------------------- |
| `JwtSettings`       | Token key, issuer, audience, expiry |
| `MailSettings`      | SMTP config for email verification  |
| `ConnectionStrings` | SQL Server connection               |
| `HangfireSettings`  | Background job dashboard            |
| `AllowedOrigins`    | CORS allowed origins                |

> 💡 Sensitive values like JWT keys and email passwords should be stored using **User Secrets** in development and **environment variables** in production.

---

## 📚 Course Reference

This project was built as part of the **"Building REST APIs with .NET"** course by **Muhammad ElHelaly** on [DevCreed](https://devcreed.net/courses/details/dotnet-rest-api).

The course covers 35 sections and 37+ hours of content including HTTP fundamentals, EF Core, JWT auth, background jobs, caching, rate limiting, versioning, OpenAPI, deployment, and more.

---

## 📄 License

This project is intended for educational purposes as part of the DevCreed course curriculum.

---

## 👨‍💻 Author

<div align="center">

Built with 💙 by **Muhammad Asaad**

[![GitHub](https://img.shields.io/badge/GitHub-meshmuhammadasaadg-181717?style=for-the-badge&logo=github&logoColor=white)](https://github.com/meshmuhammadasaadg)

_"Code is like humor. When you have to explain it, it's bad."_

</div>
