# Restore and Build
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
ARG APP_ENV
WORKDIR /app
COPY . .
RUN dotnet restore "BFF/BFF.csproj"
RUN dotnet publish "BFF/BFF.csproj" -c ${APP_ENV} -o out

# Run Env
FROM mcr.microsoft.com/dotnet/aspnet:5.0
ARG APP_ENV
WORKDIR /app
RUN ln -sf /usr/share/zoneinfo/Asia/Taipei /etc/localtime

COPY --from=build /app/out ./
COPY service_account.json ./
COPY identity_private.key ./

ENV GOV_IDENTITY_PRIVATE_KEY=/app/identity_private.key
ENV GOOGLE_APPLICATION_CREDENTIALS=/app/service_account.json
ENV ASPNETCORE_ENVIRONMENT=${APP_ENV}
ENV URLS=http://*:80/;

ENTRYPOINT ["dotnet", "BFF.dll"]
