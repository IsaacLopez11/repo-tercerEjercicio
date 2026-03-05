# Imagen base
FROM mcr.microsoft.com/dotnet/runtime:8.0

# Carpeta de trabajo
WORKDIR /app

# Copiar archivos
COPY bin/Release/net8.0/publish/ .

# Ejecutar app
ENTRYPOINT ["dotnet", "cargaExcel.dll"]