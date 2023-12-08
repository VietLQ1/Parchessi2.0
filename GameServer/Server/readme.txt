HOW TO INSTALL AND RUN THESE

    Download .NET Framework 8.0 from Microsoft
        https://dotnet.microsoft.com/en-us/download/dotnet
    
    After installed, you can run the following command to install the Entity Framework Core Tools: 
        dotnet add package Microsoft.EntityFrameworkCore.Design
    
    Database Migrations, run the following command in the terminal:
    
        cd .\Server
        
        This will create the initial migration
            dotnet ef migrations add InitialCreate   
    
        This will create the database and apply the migration
            dotnet ef database update
    
    
    In this project, we are using the following NuGet packages:
        Microsoft.EntityFrameworkCore
        Microsoft.EntityFrameworkCore.Tools
        Microsoft.EntityFrameworkCore.Design
        MySql.Data.EntityFrameworkCore
        MySqlConnector
        Newtonsoft.Json
