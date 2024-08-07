# HR Application

## Project Title
**HR Application**

## Tech Stack
- **Backend**: ASP.NET Core , MVC architecture
- **Frontend**: Razor Pages, Bootstrap, jQuery
- **Database**: SQL Server
- **Containerization**: Docker
- **Cloud Platform**: Azure

## Libraries Installed
- **Backend**:
  - **Microsoft.EntityFrameworkCore**: 5.0.0
  - **Microsoft.EntityFrameworkCore.SqlServer**: 5.0.0
  - **Microsoft.AspNetCore.Identity**: 5.0.0
  - **Microsoft.AspNetCore.Authentication.JwtBearer**: 5.0.0
  - **Swashbuckle.AspNetCore**: 5.6.3 (for Swagger API documentation)
- **Frontend**:
  - **Bootstrap**: 4.5.2
  - **jQuery**: 3.5.1

## Properties Implemented
### Features of HR Application
- **Login Management and Registration Management**:
  - **User Registration**: Register new users.
  - **User Login**: Authenticate users and provide access to the application.
- **Salary Management**:
  - **Addition**: Add new salary records for employees.
  - **Modification**: Update existing salary records.
  - **Deletion**: Remove salary records.
- **Employee Management**:
  - **Addition**: Add new Employee records.
  - **Modification**: Update existing employee records.
  - **Deletion**: Remove employee records.
- **Department Management**:
  - **Addition**: Add new Department records.
  - **Modification**: Update existing Deparment records.
  - **Deletion**: Remove Department records.

### Use Case
The HR Application can be used by an organization to store and manage employee records on a device. It includes features for employee registration and salary management. Additionally, it has implemented authorization features to ensure secure access to the application.

## Getting Started
### Prerequisites
- Docker installed on your machine
- Azure account for deployment

### Installation
1. **Clone the repository**:
   ```sh
   git clone https://github.com/your-repo/hr-application.git
   cd hr-application
**Commands to Install Dependencies**:

**Microsoft.AspNetCore.Authentication.Cookies**:
```sh
dotnet add package Microsoft.AspNetCore.Authentication.Cookies --version 2.2.0
```

**Microsoft.AspNetCore.Authorization**:
```sh
dotnet add package Microsoft.AspNetCore.Authorization --version 8.0.7
```

**Microsoft.EntityFrameworkCore**:
```sh

dotnet add package Microsoft.EntityFrameworkCore --version 8.0.7
```

**Microsoft.EntityFrameworkCore.Design**:
```sh
dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.7
```
**Microsoft.EntityFrameworkCore.SqlServer**:
```sh

dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 8.0.7
```

**Microsoft.EntityFrameworkCore.Tools**:
```sh

dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.0.7
```
**Build the project**:
```sh
dotnet build
```
**Run the project**:
```
dotnet run
```
**Build and run the Docker container**:
  ```sh
  git clone https://github.com/your-repo/hr-application.git
  cd hr-application
  ```
3. **Access the application**: Open the application on the web browser.

### Configuration
Database Connection: Update the connection string in appsettings.json to point to your SQL Server instance.
Azure Deployment: Follow Azure's documentation to deploy the Docker container to Azure App Service.


If you are setting the Application for the first time you have to Register and then login with  your username and password.
To have intial set up of your Database use the following command to enter some values into your database.

```sh

INSERT INTO Departments (DepartmentID, DepartmentName)
VALUES (1, 'DepartmentNamePlaceholder');
SELECT * FROM Employee;
follow the same sql qurey with salary and Department to set up your initial database 

```

Create SQL migrations from models:
```sh
dotnet ef migrations add "Initial Migration"
```

Apply migrations to database tables:
```sh
dotnet ef database update "Initial Migration"
```

After these you are all set to go.

I have also posted the video for reference on how the application would like!
Also refer for MVC Diagram 

https://drive.google.com/file/d/12IUpSX5yFTREF1qpJV1EzOZnwQcynqZU/view?usp=drive_link
https://drive.google.com/file/d/13xV6CuGvRMPX9qV_k0wZxVdzd2SpkhBT/view?usp=sharing


Contributions are welcome! Please fork the repository and submit a pull request.


