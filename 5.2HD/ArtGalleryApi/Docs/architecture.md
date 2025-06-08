# 🎨 Art Gallery API - System Architecture

## Overview

This backend system manages data for an Aboriginal Art Gallery, enabling CRUD operations on Artists and Artifacts stored in MongoDB. It is built using ASP.NET Core Web API, following a clean architecture with clear separation of concerns.

---

## Technologies Used

| Layer           | Tool/Technology                      |
|----------------|--------------------------------------|
| Backend API     | ASP.NET Core Web API                 |
| Database        | MongoDB (NoSQL)                      |
| ORM/Driver      | MongoDB C# Driver                    |
| Documentation   | Swagger + Markdown                  |
| Testing         | xUnit                                |
| Authentication  | OAuth/OIDC (planned via Auth0)       |

---

## Architecture Diagram

```plaintext
+------------------+        +----------------------+
|  React Frontend  | <----> |  REST API Controllers |
+------------------+        +----------------------+
                                  |
                                  v
                         +---------------------+
                         |   Services Layer    |
                         +---------------------+
                                  |
                                  v
                         +---------------------+
                         | MongoDbContext.cs   |
                         | (MongoDB Integration)|
                         +---------------------+
                                  |
                                  v
                         +---------------------+
                         |     MongoDB         |
                         | (Artists, Artifacts)|
                         +---------------------+
```

---

## Design Patterns & Principles

- **Controller-Service-Model** separation
- **Dependency Injection** for services and context
- **Single Responsibility Principle**: Each class handles one responsibility
- **Swagger UI** for auto-generated API docs
- **Markdown + xUnit** for dev-friendly docs and tests
