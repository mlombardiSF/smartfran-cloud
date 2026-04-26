# ── Stage 1: Build ──────────────────────────────────────────────────────────
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Instalar la plantilla de Blazor WASM (si no existe el proyecto)
COPY . .

# Restaurar dependencias
RUN dotnet restore "SmartFranCloudApp/SmartFranCloudApp.csproj"

# Build en modo Release
RUN dotnet publish "SmartFranCloudApp/SmartFranCloudApp.csproj" \
    -c Release \
    -o /app/publish \
    --nologo

# Patch base href: /smartfran-cloud/ → / (GitHub Pages usa el source; Docker sirve desde raíz)
RUN sed -i 's|<base href="/smartfran-cloud/"|<base href="/"|g' /app/publish/wwwroot/index.html

# ── Stage 2: Serve con Nginx ─────────────────────────────────────────────────
FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html

# Copiar los archivos publicados de Blazor WASM
COPY --from=build /app/publish/wwwroot .

# Copiar configuración de Nginx para SPA (Single Page Application)
COPY nginx.conf /etc/nginx/nginx.conf

EXPOSE 80
