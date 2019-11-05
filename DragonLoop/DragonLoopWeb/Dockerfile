FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src/DragonLoopWeb
EXPOSE 55495
COPY DragonLoopWeb/*.csproj ./
RUN dotnet restore
#RUN dotnet restore "DragonLoopWeb.csproj"
COPY ./DragonLoopWeb .
COPY ./DragonLoopModels/ ../DragonLoopModels
COPY ./DragonLoopViewModels ../DragonLoopViewModels
RUN dotnet build "DragonLoopWeb.csproj" -c Debug -o /app/build
ENTRYPOINT [ "dotnet", "watch", "run"]

FROM build AS publish
RUN dotnet publish "DragonLoopWeb.csproj" --self-contained -c Release -o /app/publish
#ENTRYPOINT [ "bash" ]

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#ENTRYPOINT [ "bash" ]
ENTRYPOINT ["dotnet", "DragonLoopWeb.dll"]

