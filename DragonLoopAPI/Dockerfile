FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src/DragonLoopAPI
COPY ./DragonLoopModels ../DragonLoopModels
COPY DragonLoopAPI/DragonLoopAPI.csproj ./
RUN dotnet restore "DragonLoopAPI.csproj"
COPY ./DragonLoopAPI .


FROM build as dev
RUN dotnet build "DragonLoopAPI.csproj" -c Development -o /app/build
ENTRYPOINT [ "dotnet", "watch", "run"]

FROM build AS publish
RUN dotnet publish "DragonLoopAPI.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DragonLoopAPI.dll"]
