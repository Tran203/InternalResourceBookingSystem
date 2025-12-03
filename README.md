# Internal Resource Booking System

A web application for managing company resources and bookings, designed for the City of Johannesburg. Built with ASP.NET Core MVC, Entity Framework Core.

## Requirements
- .NET 8.0 SDK
- SQL Server (LocalDB or Express)
- Visual Studio 2022 or VS Code
- Git

## Setup Instructions
1. **Clone the Repository**:
   ```bash
   git clone <https://github.com/Tran203/InternalResourceBookingSystem>
   cd InternalResourceBookingSystem
   ```
   
2. **Configure the Database**:
   - Update the connection string in `appsettings.json`:
     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=InternalResourceBookingDB;Trusted_Connection=True;MultipleActiveResultSets=true"
     }
     ```
3. **Run the Application**:
   ```bash
   dotnet run
   ```
