FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 5233

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["VIVA-WEBAPP-MVC//VIVA-WEBAPP-MVC.csproj", "VIVA-WEBAPP-MVC/"]
RUN dotnet restore "VIVA-WEBAPP-MVC/VIVA-WEBAPP-MVC.csproj"
COPY . .
WORKDIR "/src/VIVA-WEBAPP-MVC"
RUN dotnet build --no-restore -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "VIVA-WEBAPP-MVC.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
ENV ASPNETCORE_ENVIRONMENT="Development"
ENV ASPNETCORE_HTTP_PORTS=5233
ENV ASPNETCORE_URLS=http://+:5233
RUN useradd -m vivauser
WORKDIR /app
COPY --from=publish /app/publish .
USER vivauser
EXPOSE 5233
ENTRYPOINT ["dotnet", "VIVA-WEBAPP-MVC.dll"]
