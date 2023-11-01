# Employee Management System - .NET Core API

This Employee Management System is a .NET Core API project that allows you to manage employee data using a SQL Server database. It provides a RESTful API for basic CRUD (Create, Read, Update, Delete) operations for employee records, and it's designed to be used as the backend for an employee management application.

## Features

- Create, Read, Update, and Delete employees.
- Retrieve a list of all employees.
- Retrieve employee details by employee ID.
- Support for department information with DepartmentID as a foreign key.

## Technologies Used

- .NET Core: The project is built using .NET Core, a cross-platform, open-source framework for building modern, cloud-based, and internet-connected applications.

- Entity Framework Core: Entity Framework Core is used to interact with the SQL Server database. It provides data access, data modeling, and database migrations.

- SQL Server: The database used to store and manage employee information.

## Getting Started

To get started with this project, follow these steps:

1. **Prerequisites:**
   - Install .NET Core: [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download)
   - Install SQL Server: [https://www.microsoft.com/en-us/sql-server/sql-server-downloads](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

2. **Clone the Repository:**
   ```bash
   git clone https://github.com/ani21das/employee-management-system.git
   ```

3. **Database Setup:**
   - Open `appsettings.json` and update the connection string to your SQL Server instance.
   - Run the following commands to create and apply database migrations:
     ```bash
     dotnet ef database update
     ```

4. **Run the Application:**
   - Navigate to the project directory and run:
     ```bash
     dotnet run
     ```

5. **API Endpoints:**
   - The API is accessible at `http://localhost:5000` by default.

6. **Swagger Documentation:**
   - You can access API documentation using Swagger UI at `http://localhost:5000/swagger/index.html`.

## API Endpoints

- `GET /api/employees`: Retrieve a list of all employees.
- `GET /api/employees/{id}`: Retrieve employee details by ID.
- `POST /api/employees`: Create a new employee.
- `PUT /api/employees/{id}`: Update an existing employee.
- `DELETE /api/employees/{id}`: Delete an employee.
