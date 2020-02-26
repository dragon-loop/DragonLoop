# Dragon Loop

![ASP .NET Core CI](https://github.com/dragon-loop/DragonLoop/workflows/ASP%20.NET%20Core%20CI/badge.svg)
![Build images and redeploy](https://github.com/dragon-loop/DragonLoop/workflows/Build%20images%20and%20redeploy/badge.svg)
## Setup
1. Download [Postgres](https://www.postgresql.org/)
2. Clone this repo to your local machine
3. Run the scripts located in the `DragonLoopDatabase` repository to set up your local Postgres database
   * routes.sql
   * buses.sql
   * stops.sql
   * schedules.sql
   * route_segments.sql
4. Use the [Dotnet Secret Manager](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-2.2&tabs=windows) to set `PgConnectionString` in the `DragonLoopAPI` project
   * `cd DragonLoopAPI`
   * `dotnet user-secrets set "PgConnectionString" "Server=127.0.0.1;Port=5432;User Id=postgres;Password=password;Database=postgres;"`
5. Run `DragonLoopAPI` and `DragonLoopApp.Android`/`DragonLoopApp.iOS`/`DragonLoopWeb` in Visual Studio
