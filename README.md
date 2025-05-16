# CORE

This folder contains the **infrastructure-level and reusable components** of the RentACar project. It provides **base functionality** that can be used across different layers of the application, and even reused in other projects without any modification.

## 🧱 Purpose

The `Core` layer is designed based on the **Clean Architecture** and **Onion Architecture** principles. Its main purpose is to:
- Isolate reusable components from business logic.
- Handle cross-cutting concerns (e.g. logging, validation, exception handling).
- Provide foundational interfaces and utility classes.
- Increase code maintainability and testability.

---

## 📁 Folder Structure

Core/
│
├── CrossCuttingConcerns/ # Concerns like caching, logging, validation, etc.
├── Entities/ # Base entities (IEntity, IDto, User, OperationClaim, etc.)
├── Extensions/ # Extension methods for claims, strings, etc.
├── Utilities/
│ ├── Business/ # Business rule engine helpers
│ ├── Interceptors/ # Method interceptors for AOP (Aspect-Oriented Programming)
│ ├── Results/ # Result wrappers: SuccessResult, ErrorResult, etc.
│ └── Security/
│ ├── Encryption/ # Helper classes for encryption and hashing
│ └── Jwt/ # JWT token helper classes


---

## ✨ Key Components

### 🔐 `Security` (Encryption & JWT)
Provides helpers to:
- Hash passwords (SHA512, HMAC)
- Create and validate JWT tokens
- Bind and configure token options from `appsettings.json`

### 🧩 `Entities`
Includes base interfaces and models:
- `IEntity`: Marker interface for all entities
- `IDto`: Marker interface for all Data Transfer Objects
- `User`, `OperationClaim`, `UserOperationClaim`: Concrete entities used in authentication & authorization

### 🔁 `Interceptors`
Implements method-level AOP using Castle DynamicProxy:
- Enables cross-cutting concerns like validation, caching, logging to be applied declaratively via attributes

### ✅ `Results`
Standardizes method return types:
- `IResult`, `IDataResult<T>` interfaces
- Implementations: `SuccessResult`, `ErrorDataResult<T>`, etc.

### ⚙️ `BusinessRules`
Utility to run multiple business rules in a chain and return first failure:
```csharp
var result = BusinessRules.Run(rule1, rule2);
if (result != null)
    return result; 
```
### 🧪 Reusability
This layer is designed to be domain-agnostic, meaning:

It doesn’t depend on any project-specific logic.

It can be copied and reused in other enterprise-grade applications.

### 📌 Dependencies
.NET 6/7/8 compatible

Uses Microsoft.Extensions.Configuration for binding

Uses System.IdentityModel.Tokens.Jwt for token handling

### 📄 Related Files to Review
File	Purpose
JwtHelper.cs	Generates JWT tokens based on user & claims
ClaimExtensions.cs	Adds custom claims for identity handling
BusinessRules.cs	Simplifies handling multiple rule checks
IResult.cs, IDataResult<T>.cs	Standard return pattern for methods

