Run the following scripts:

dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore

dotnet add package Microsoft.AspNetCore.Identity.UI

dotnet add package Microsoft.Data.Sqlite.Core

dotnet add package Microsoft.EntityFrameworkCore.Sqlite

dotnet add package Microsoft.EntityFrameworkCore.SqlServer

dotnet add package Microsoft.EntityFrameworkCore.Design

dotnet add package Microsoft.EntityFrameworkCore.Tools

<!-- dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design -->
	
Once all packages areRun the following:
dotnet ef migrations add InitialCreate
dotnet ef database update