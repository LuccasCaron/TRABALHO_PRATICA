
# Use the SDK image for building and restoring
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
EXPOSE 80
WORKDIR /app

# Copy csproj and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY ../ ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "PROJETO_ADVOCACIA.dll"]
