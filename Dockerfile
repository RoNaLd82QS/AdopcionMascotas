# Etapa 1: Compilación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar archivo del proyecto y restaurar dependencias
COPY *.csproj ./
RUN dotnet restore

# Copiar el resto de archivos y compilar
COPY . ./
RUN dotnet publish -c Release -o /out

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copiar salida del build
COPY --from=build /out .

# Render usa esta variable para asignar el puerto
ENV ASPNETCORE_URLS=http://+:10000
ENV PORT=10000

ENTRYPOINT ["dotnet", "SistemaAdopcionMascotas.dll"]
