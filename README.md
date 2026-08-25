# 🎓 Student Management System – ASP.NET Core Web API

A complete **Student Management System** built using **ASP.NET Core Web API**, **Entity Framework Core**, **SQL Server**, and **Swagger/OpenAPI**.

This project demonstrates how to build a RESTful CRUD API for managing student records and how to consume that API from an **ASP.NET Core MVC application** using `HttpClient`.

---

## 🚀 Project Overview

The project is divided into two applications:

### 1. StudentAPI

A RESTful **ASP.NET Core Web API** responsible for:

* Creating student records
* Retrieving all students
* Retrieving a student by ID
* Updating student records
* Deleting student records
* Communicating with SQL Server through Entity Framework Core
* Providing API documentation/testing through Swagger

### 2. RestulAPiCRUD

An **ASP.NET Core MVC client application** that consumes the Student Web API using `HttpClient`.

It provides a user interface for:

* Viewing students
* Adding students
* Editing students
* Viewing student details
* Deleting students

---

# 🏗️ Architecture

The basic architecture of the project is:

```text
                ┌──────────────────────┐
                │      User / Client   │
                └──────────┬───────────┘
                           │
                           ▼
                ┌──────────────────────┐
                │   ASP.NET Core MVC   │
                │   RestulAPiCRUD      │
                └──────────┬───────────┘
                           │
                     HttpClient
                           │
                           ▼
                ┌──────────────────────┐
                │   ASP.NET Core API   │
                │      StudentAPI      │
                └──────────┬───────────┘
                           │
                    Entity Framework
                           │
                           ▼
                ┌──────────────────────┐
                │      SQL Server      │
                │      StudentDB       │
                └──────────────────────┘
```

---

# 🛠️ Technologies Used

| Technology            | Purpose                            |
| --------------------- | ---------------------------------- |
| C#                    | Programming Language               |
| ASP.NET Core Web API  | RESTful API development            |
| ASP.NET Core MVC      | Frontend/client application        |
| Entity Framework Core | Database access                    |
| SQL Server            | Database                           |
| Swagger / OpenAPI     | API documentation and testing      |
| HttpClient            | Consuming API from MVC             |
| Newtonsoft.Json       | JSON serialization/deserialization |
| Bootstrap             | UI styling                         |
| Visual Studio         | Development Environment            |

---

# 📁 Project Structure

```text
WEBAPI
│
├── StudentAPI
│   │
│   ├── Controllers
│   │   └── StudentAPIController.cs
│   │
│   ├── Data
│   │   └── AppDbContext.cs
│   │
│   ├── Models
│   │   └── TblStudent.cs
│   │
│   ├── Program.cs
│   ├── appsettings.json
│   ├── StudentAPI.csproj
│   └── StudentAPI.http
│
│
└── RestulAPiCRUD
    │
    ├── Controllers
    │   └── StudentController.cs
    │
    ├── Models
    │   └── Student.cs
    │
    ├── Views
    │   ├── Student
    │   │   ├── Index.cshtml
    │   │   ├── Create.cshtml
    │   │   ├── Edit.cshtml
    │   │   ├── Details.cshtml
    │   │   └── Delete.cshtml
    │   │
    │   └── Shared
    │
    ├── Program.cs
    └── RestulAPiCRUD.csproj
```

---

# 🔥 API Features

The Student API provides complete CRUD functionality.

### CRUD means:

```text
C → Create
R → Read
U → Update
D → Delete
```

The API supports the following operations:

| HTTP Method | Endpoint               | Description        |
| ----------- | ---------------------- | ------------------ |
| GET         | `/api/StudentAPI`      | Get all students   |
| GET         | `/api/StudentAPI/{id}` | Get student by ID  |
| POST        | `/api/StudentAPI`      | Create new student |
| PUT         | `/api/StudentAPI/{id}` | Update student     |
| DELETE      | `/api/StudentAPI/{id}` | Delete student     |

---

# 📌 Student Model

The student entity contains the following properties:

```csharp
public class TblStudent
{
    public int Id { get; set; }

    public string? SName { get; set; }

    public int? SAge { get; set; }

    public string? SGender { get; set; }

    public string? SFatherName { get; set; }

    public string? SClass { get; set; }
}
```

### Student Fields

| Property    | Type   | Description               |
| ----------- | ------ | ------------------------- |
| Id          | int    | Student unique identifier |
| SName       | string | Student name              |
| SAge        | int    | Student age               |
| SGender     | string | Student gender            |
| SFatherName | string | Father's name             |
| SClass      | string | Student class             |

---

# 🗄️ Database

The project uses:

```text
SQL Server
```

Database:

```text
StudentDB
```

The API communicates with SQL Server through:

```text
Entity Framework Core
```

The database context is:

```csharp
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<TblStudent> Tbl_student { get; set; }
}
```

---

# 🔌 Connection String

The connection string is configured inside:

```text
appsettings.json
```

Example:

```json
"ConnectionStrings": {
  "conStrings": "Server=YOUR_SERVER;Database=StudentDB;Trusted_Connection=true;TrustServerCertificate=True;"
}
```

> ⚠️ Do not commit your personal/local SQL Server connection string to a public repository. Replace it with your own server name or use User Secrets/environment variables.

---

# ⚙️ API Configuration

The API registers Entity Framework Core with SQL Server in `Program.cs`:

```csharp
var con = builder.Configuration.GetConnectionString("conStrings");

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(con)
);
```

Controllers are registered using:

```csharp
builder.Services.AddControllers();
```

Swagger is configured using:

```csharp
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
```

---

# 📖 Swagger / OpenAPI

This project includes **Swagger**, which provides an interactive interface for testing the API.

When the application is running in Development mode, open:

```text
/swagger
```

Swagger allows you to:

* View available endpoints
* View HTTP methods
* View request parameters
* Send GET requests
* Send POST requests
* Send PUT requests
* Send DELETE requests
* Inspect API responses

Example:

```text
GET     /api/StudentAPI
GET     /api/StudentAPI/{id}
POST    /api/StudentAPI
PUT     /api/StudentAPI/{id}
DELETE  /api/StudentAPI/{id}
```

---

# 🧪 API Examples

## 1. Get All Students

### Request

```http
GET /api/StudentAPI
```

### Example Response

```json
[
  {
    "id": 1,
    "sName": "Ali",
    "sAge": 20,
    "sGender": "Male",
    "sFatherName": "Ahmed",
    "sClass": "BSCS"
  }
]
```

---

# 2. Get Student By ID

### Request

```http
GET /api/StudentAPI/1
```

### Example Response

```json
{
  "id": 1,
  "sName": "Ali",
  "sAge": 20,
  "sGender": "Male",
  "sFatherName": "Ahmed",
  "sClass": "BSCS"
}
```

---

# 3. Create Student

### Request

```http
POST /api/StudentAPI
```

### Request Body

```json
{
  "sName": "Ali Khan",
  "sAge": 21,
  "sGender": "Male",
  "sFatherName": "Muhammad Khan",
  "sClass": "BSCS"
}
```

---

# 4. Update Student

### Request

```http
PUT /api/StudentAPI/1
```

### Request Body

```json
{
  "id": 1,
  "sName": "Ali Khan Updated",
  "sAge": 22,
  "sGender": "Male",
  "sFatherName": "Muhammad Khan",
  "sClass": "BSCS"
}
```

---

# 5. Delete Student

### Request

```http
DELETE /api/StudentAPI/1
```

A successful request removes the student from the database.

---

# 🌐 MVC Client Application

The `RestulAPiCRUD` project consumes the Web API using:

```csharp
HttpClient
```

The MVC application communicates with the API through HTTP requests.

For example:

```csharp
HttpResponseMessage response = client.GetAsync(Url).Result;
```

The response is then converted from JSON into C# objects using:

```csharp
JsonConvert.DeserializeObject<List<Student>>(result);
```

---

# 🔄 MVC → API Communication

The communication flow is:

```text
MVC Controller
      │
      │ HttpClient
      ▼
Student Web API
      │
      │ Entity Framework Core
      ▼
SQL Server
      │
      │ Data
      ▼
Student Web API
      │
      │ JSON Response
      ▼
MVC Controller
      │
      ▼
Razor View
```

---

# 📌 MVC CRUD Operations

The MVC application provides the following actions:

### Index

Retrieves all students from the API.

```text
GET /api/StudentAPI
```

### Create

Sends a new student to the API.

```text
POST /api/StudentAPI
```

### Edit

Retrieves an existing student and updates it.

```text
GET /api/StudentAPI/{id}
PUT /api/StudentAPI/{id}
```

### Details

Retrieves a single student.

```text
GET /api/StudentAPI/{id}
```

### Delete

Deletes the selected student.

```text
DELETE /api/StudentAPI/{id}
```

---

# 📦 NuGet Packages

The API uses the following important packages:

```text
Microsoft.AspNetCore.OpenApi
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.Design
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
Swashbuckle.AspNetCore
```

The MVC application also uses:

```text
Newtonsoft.Json
```

for JSON serialization and deserialization.

---

# 💻 Requirements

Before running the project, make sure you have:

* Visual Studio 2022 or later
* .NET 10 SDK
* SQL Server
* SQL Server Management Studio (SSMS) — recommended
* Git — optional

---

# 🚀 How to Run the Project

## Step 1 — Clone the Repository

```bash
git clone https://github.com/Habibkhalqi/WEBAPI.git
```

Go to the project directory:

```bash
cd WEBAPI
```

---

## Step 2 — Configure SQL Server

Open:

```text
StudentAPI/appsettings.json
```

Update the connection string according to your SQL Server instance.

Example:

```json
"ConnectionStrings": {
  "conStrings": "Server=YOUR_SERVER;Database=StudentDB;Trusted_Connection=true;TrustServerCertificate=True;"
}
```

---

## Step 3 — Create / Update Database

Open the Package Manager Console in Visual Studio.

Run:

```powershell
Update-Database
```

If migrations are not available yet, create one:

```powershell
Add-Migration InitialCreate
```

Then:

```powershell
Update-Database
```

---

## Step 4 — Run StudentAPI

Open the `StudentAPI` project and run it.

You should see the API running on a local HTTPS address.

Then open Swagger:

```text
https://localhost:<port>/swagger
```

---

## Step 5 — Run MVC Application

Run the:

```text
RestulAPiCRUD
```

project.

Make sure the API URL inside:

```text
RestulAPiCRUD/Controllers/StudentController.cs
```

matches the actual StudentAPI HTTPS URL.

Example:

```csharp
private string Url =
    "https://localhost:7246/api/StudentAPI/";
```

If the API uses a different port on your machine, update this URL accordingly.

---

# 🧪 Testing

You can test the API using:

* Swagger UI
* Postman
* `.http` files
* MVC Client Application

Swagger is recommended for quickly testing all CRUD endpoints.

---

# 🔐 Important Security Note

The repository should **not** contain sensitive information such as:

* Database passwords
* API keys
* Authentication secrets
* Production connection strings
* Private certificates

For local development, use:

```text
User Secrets
```

or environment variables for sensitive configuration.

---

# 📚 What I Learned From This Project

This project demonstrates practical understanding of:

* ASP.NET Core Web API
* REST API architecture
* HTTP methods
* CRUD operations
* Entity Framework Core
* DbContext
* DbSet
* SQL Server
* Dependency Injection
* API Controllers
* Routing
* HTTP status responses
* JSON serialization/deserialization
* HttpClient
* Swagger / OpenAPI
* MVC and Web API communication
* Connecting frontend/client applications with APIs

---

# 🎯 Learning Flow

The project follows this learning flow:

```text
ASP.NET Core
     ↓
Web API
     ↓
Controllers
     ↓
HTTP Methods
     ↓
Entity Framework Core
     ↓
SQL Server
     ↓
CRUD Operations
     ↓
Swagger
     ↓
HttpClient
     ↓
ASP.NET Core MVC
     ↓
API Consumption
```

---

# 📌 Future Improvements

The project can be further improved by adding:

* DTOs
* Repository Pattern
* Service Layer
* Dependency Injection improvements
* Proper validation
* Global exception handling
* Proper HTTP status codes
* Async `HttpClient` methods
* Authentication & Authorization
* JWT Authentication
* Pagination
* Searching and filtering
* Sorting
* Logging
* Unit Testing
* Integration Testing
* API versioning
* Production-ready configuration

---

# 🤝 Contributing

Contributions are welcome.

If you want to improve this project:

1. Fork the repository
2. Create a new branch

```bash
git checkout -b feature/new-feature
```

3. Make your changes
4. Commit your changes

```bash
git commit -m "Add new feature"
```

5. Push your branch

```bash
git push origin feature/new-feature
```

6. Open a Pull Request

---

# 👨‍💻 Author

**Habibullah**

.NET Developer | ASP.NET Core | C# | Web API | MVC | Entity Framework Core | SQL Server

---

# ⭐ Support

If you found this project useful for learning ASP.NET Core Web API and CRUD operations, consider giving the repository a ⭐ on GitHub.

---

## 📄 License

This project is created for learning and educational purposes.


