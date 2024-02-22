# Use the official Microsoft ASP.NET Core runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use the official Microsoft .NET SDK image to build the project files
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the csproj file and restore any dependencies (via NUGET)
COPY ["src/Oakell.HttpApi.Host/Oakell.HttpApi.Host.csproj", "Oakell.HttpApi.Host/"]
RUN ls
RUN dotnet restore "Oakell.HttpApi.Host/Oakell.HttpApi.Host.csproj"

# Copy the project files and build the release
COPY ./ ./
WORKDIR "src/Oakell.HttpApi.Host"
RUN dotnet build "Oakell.HttpApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Oakell.HttpApi.Host.csproj" -c Release -o /app/publish

# Final stage/image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Oakell.HttpApi.Host.dll"]
