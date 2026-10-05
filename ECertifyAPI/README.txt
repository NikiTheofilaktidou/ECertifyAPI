### Database Configuration

1. Make sure SQL Server is installed and running.
2. Run `Infrastructure/init.sql` in SQL Server Management Studio (SSMS).
   This creates the `ECertify` database and its tables.
3. Configure the connection string in `appsettings.Development.json`:

"ConnectionStrings": {
    "DbContext": "Server=(localdb)\\MSSQLLocalDB;Database=ECertify;Trusted_Connection=True;TrustServerCertificate=True;"
}

Adjust the `Server` value according to your SQL Server instance's name.
4. Run the application.
5.To test API endpoints, you can use Swagger UI at `https://localhost:<port>/swagger`