# HR Application

## Project Title
**HR Application**

## Tech Stack
- **Backend**: ASP.NET Core
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
### Features
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

### Development Environment
This project was developed using Azure Studio within a Docker container, providing a consistent and isolated development environment.

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
3. **Access the application**: Open your browser and navigate to http://localhost:8080.

### Configuration
Database Connection: Update the connection string in appsettings.json to point to your SQL Server instance.
Azure Deployment: Follow Azure's documentation to deploy the Docker container to Azure App Service.
Usage
Employee Registration: Register new employees and manage their details.
Salary Management: Add, modify, and delete salary records for employees.
Authorization: 
Contributions are welcome! Please fork the repository and submit a pull request.
