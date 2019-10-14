FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src/DragonLoopAPI
EXPOSE 55495
COPY ./DragonLoopAPI/DragonLoopAPI.csproj .
RUN dotnet restore "DragonLoopAPI.csproj"
COPY ./DragonLoopAPI .
COPY ./DragonLoopModels/ ../DragonLoopModels
COPY ./DragonLoopViewModels ../DragonLoopViewModels
RUN dotnet build "DragonLoopAPI.csproj" -c Debug -o /app/build
RUN dotnet user-secrets set "PgConnectionString" "Server=db"
ENTRYPOINT [ "dotnet", "run" ]
