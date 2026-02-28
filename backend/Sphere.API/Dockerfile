# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY *.sln .
COPY Sphere.Api/*.csproj Sphere.Api/
COPY Sphere.Application/*.csproj Sphere.Application/
COPY Sphere.Domain/*.csproj Sphere.Domain/
COPY Sphere.Infrastructure/*.csproj Sphere.Infrastructure/

RUN dotnet restore

COPY . .
RUN dotnet publish Sphere.Api/Sphere.Api.csproj -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5000

ENTRYPOINT [ "dotnet", "Sphere.Api.dll" ]