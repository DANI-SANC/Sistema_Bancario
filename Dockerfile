# Etapa 1: Construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar la solución y restaurar dependencias
COPY Sistema_Bancario.sln .
COPY Sistema_Bancario.Dominio/*.csproj Sistema_Bancario.Dominio/
COPY Sistema_Bancario.Application/*.csproj Sistema_Bancario.Application/
COPY Sistema_Bancario.Infrastructure/*.csproj Sistema_Bancario.Infrastructure/
COPY Sistema_Bancario.Presentacion/*.csproj Sistema_Bancario.Presentacion/

RUN dotnet restore

# Copiar el código fuente y compilar
COPY . /app
WORKDIR /app/Sistema_Bancario.Presentacion
RUN dotnet publish -c Release -o /publish

# Etapa 2: Ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /publish .

# Configurar la conexión a la base de datos
ENV ConnectionStrings__SQL="Server=sqlserver;Database=Sistema_Bancario_QA;User Id=sa;Password=Sql@Server2024;TrustServerCertificate=True;"

# Exponer el puerto
ENV ASPNETCORE_URLS=http://+:8081
EXPOSE 8081

ENTRYPOINT ["dotnet", "Sistema_Bancario.Presentacion.dll"]
