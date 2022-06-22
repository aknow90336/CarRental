# Restore and Build
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
ARG APP_ENV
WORKDIR /app
COPY . .
RUN dotnet restore "CarRental.Frontend/CarRental.Frontend.csproj"
RUN dotnet publish "CarRental.Frontend/CarRental.Frontend.csproj" -o out

# Run Env
FROM mcr.microsoft.com/dotnet/aspnet:5.0
ARG APP_ENV
WORKDIR /app
RUN ln -sf /usr/share/zoneinfo/Asia/Taipei /etc/localtime

COPY --from=build /app/out ./
COPY ./CarRental.Frontend/Config ./Config
COPY service_account.json ./


ENV GOOGLE_APPLICATION_CREDENTIALS=/app/service_account.json
ENV ASPNETCORE_ENVIRONMENT=${APP_ENV}
ENV URLS=http://*:80/;

ENTRYPOINT ["dotnet", "CarRental.Frontend.dll"]
