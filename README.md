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
Build and run the Docker container:

Access the application: Open your browser and navigate to http://localhost:8080.

Configuration
Database Connection: Update the connection string in appsettings.json to point to your SQL Server instance.
Azure Deployment: Follow Azure's documentation to deploy the Docker container to Azure App Service.
Usage
Employee Registration: Register new employees and manage their details.
Salary Management: Add, modify, and delete salary records for employees.
Authorization: Secure access to the application using JWT authentication.
Contributing
Contributions are welcome! Please fork the repository and submit a pull request.
