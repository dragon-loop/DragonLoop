# Dragon Loop

## Setup
1. Download [Postgres](https://www.postgresql.org/)
2. Clone this repo to your local machine
3. Run the scripts located in the `Postgres` directory to set up your local Postgres database
4. Use the [Dotnet Secret Manager](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-2.2&tabs=windows) to set `PgConnectionString` in the `DragonLoopAPI` project
5. Run `DragonLoopAPI` in Visual Studio and use your browser to hit the endpoints
