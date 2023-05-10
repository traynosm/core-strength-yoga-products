Run the following scripts.

dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design

dotnet tool install -g dotnet-aspnet-codegenerator

dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore

dotnet add package Microsoft.AspNetCore.Identity.UI

dotnet aspnet-codegenerator identity -dbProvider sqlite