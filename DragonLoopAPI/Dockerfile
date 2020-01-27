FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ./DragonLoopAPI/DragonLoopAPI.csproj DragonLoopAPI/
RUN dotnet restore "DragonLoopAPI/DragonLoopAPI.csproj"
COPY . .
WORKDIR "/src/DragonLoopAPI"
RUN dotnet build "DragonLoopAPI.csproj" -c Release -o /app/build
RUN dotnet user-secrets set "PgConnectionString" "Server=db;Port=5432;User Id=postgres;Password=password;Database=postgres;"
ENTRYPOINT [ "dotnet", "watch", "run"]

FROM build AS publish
RUN dotnet publish "DragonLoopAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DragonLoopAPI.dll"]