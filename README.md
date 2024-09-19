# Employee Management API
![Screenshot 2024-09-19 150845](https://github.com/user-attachments/assets/0d00639f-9d81-4dcf-9ecb-0fd3f8ea42b0)

## Overview
This project is a simple CRUD API built using .NET Core to manage employees in an organization.

## Prerequisites
- .NET 6 or higher
- PostgreSQL
- Visual Studio or any preferred IDE

## Getting Started

### 1. Clone the Repository
Clone the repository to your local machine using the following command:
```bash
git clone https://github.com/shady78/EmployeeManagement.API.git
```

### 2. Navigate to the Project Directory
Change your directory to the project folder:
```bash
cd yourrepository
```
3. Setup the Database
Install PostgreSQL: If you don't have PostgreSQL installed, download and install it from PostgreSQL [Official Site](https://www.postgresql.org/download/).

- Create a Database: 

Open the PostgreSQL command line or pgAdmin.
Create a new database using the following SQL command:
```bash
CREATE DATABASE EmployeeDB;
```
Run the SQL Script:

Execute the SQL script to create the Employees table. You can run the following command in your SQL environment:
```bash
CREATE TABLE Employees (
    "EmployeeID" SERIAL PRIMARY KEY,
    "Name" VARCHAR(100) NOT NULL,
    "Department" VARCHAR(100) NOT NULL,
    "Salary" DECIMAL NOT NULL CHECK ("Salary" > 0)
);
```
4. Configure Connection String
Open appsettings.json file in the API project and update the connection string to point to your PostgreSQL database:
```bash
"ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=EmployeeDB;Username=yourusername;Password=yourpassword"
}
```
5. Build the Project
Open the solution in Visual Studio and build the project to restore dependencies.
6. Run Migrations
Open the Package Manager Console in Visual Studio and run:
```bash
Update-Database
```
This command will apply any pending migrations to the database.

7. Run the Application
You can run the application using Visual Studio by pressing F5 or using the following command in the terminal:
```bash
dotnet run --project API
```
8. Testing the API
You can test the API using tools like Postman or Swagger. The following endpoints are available:

- GET /Employees: Retrieve all employees. 
- POST /Employees: Add a new employee.
- PUT /Employees/{id}: Update an existing employee.
- DELETE /Employees/{id}: Delete an employee.

Unit Tests
To run unit tests:

Ensure you have the test project included in your solution.
Open the Test Explorer in Visual Studio and run all tests.

# Employee Management API Documentation

## Overview
The Employee Management API provides a simple way to manage employee records in an organization. This API supports CRUD (Create, Read, Update, Delete) operations to facilitate employee management.

## API Endpoints

### 1. Get All Employees
- **Method**: `GET`
- **Endpoint**: `/Employees`
- **Description**: Retrieves a list of all employees.
- **Response**:
  - **200 OK**: Returns an array of employee objects.
  
### 2. Add a New Employee
- **Method**: `POST`
- **Endpoint**: `/Employees`
- **Description**: Adds a new employee to the database.
- **Request Body**:
  ```json
  {
      "Name": "Employee Name",
      "Department": "Employee Department",
      "Salary": 5000
  }
  
### 3. Update an Existing Employee
- **Method**: `PUT`
- **Endpoint**: `/Employees/{id}`
- **Description**: Updates the details of an existing employee.
- **Request Body**:
    ```json
    {
    "Name": "Updated Name",
    "Department": "Updated Department",
    "Salary": 6000
   }
   
- **Response**:
- **200 OK**: Returns the updated employee object.
- **404 Not Found**: If the employee does not exist.

### 4. Delete an Employee
- **Method**: `DELETE`
- **Endpoint**: /Employees/{id}
- **Description**: Deletes an employee from the database.
- **Response**:
- **204 No Content**: Employee deleted successfully.
- **404 Not Found**: If the employee does not exist.

