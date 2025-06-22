# Etapa 1: build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar los proyectos
COPY . .

# Restaurar dependencias
RUN dotnet restore UI/CentroEventos.UI.csproj

# Publicar el proyecto en modo Release
RUN dotnet publish UI/CentroEventos.UI.csproj -c Release -o /app/publish

# Etapa 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Exponer el puerto (opcional, 5000 o el que uses en tu app)
EXPOSE 5000

# Comando de arranque
ENTRYPOINT ["dotnet", "CentroEventos.UI.dll"]
