# JWT Authentication API

This API provides user authentication and authorization using JSON Web Tokens (JWT). It uses the Identity Framework for password hashing and user management.

## Features
- User registration with password hashing
- User login with JWT generation
- Protected routes requiring JWT authorization
- Role-based access control (optional)
- Password management
- Smart lock system integration (optional)

## Technologies Used
- .NET 6 or later
- ASP.NET Core Web API
- Entity Framework Core
- Identity Framework
- JWT (JSON Web Token)
- SQL Server (or your preferred database)
  
## Installation

1. **Clone the repository**:
    ```bash
    git clone https://github.com/your-username/your-repo-name.git
    ```

2. **Navigate to the project directory**:
    ```bash
    cd your-repo-name
    ```

3. **Install dependencies**:
    Make sure you have the required .NET SDK installed. Then, run:
    ```bash
    dotnet restore
    ```

4. **Set up your database**:
    Ensure that your `appsettings.json` has the correct connection string for your database. Then, run the following command to apply migrations and create the database:
    ```bash
    dotnet ef database update
    ```

5. **Run the API**:
    ```bash
    dotnet run
    ```

## API Endpoints

### Authentication

#### Register a User
```http
POST /api/auth/register
