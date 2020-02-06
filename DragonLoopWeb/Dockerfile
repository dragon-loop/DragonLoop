FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src/DragonLoopWeb
COPY ./DragonLoopModels ../DragonLoopModels
COPY ./DragonLoopViewModels ../DragonLoopViewModels
COPY DragonLoopWeb/DragonLoopWeb.csproj .
RUN dotnet restore "DragonLoopWeb.csproj"
COPY ./DragonLoopWeb/ .

FROM build as dev
RUN dotnet build "DragonLoopWeb.csproj" -c Development -o /app/build
ENTRYPOINT [ "dotnet", "watch", "run"]

FROM build AS publish
RUN dotnet publish "DragonLoopWeb.csproj" -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/DragonLoopWeb/dist .
COPY ./DragonLoopWeb/nginx.conf /etc/nginx/nginx.conf
