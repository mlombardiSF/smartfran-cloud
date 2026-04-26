#!/bin/bash
# =============================================================================
# setup.sh — Crea el proyecto MudBlazor WASM dentro de Docker
# Ejecutar UNA SOLA VEZ para inicializar el proyecto
# =============================================================================
set -e

echo ""
echo "╔══════════════════════════════════════════════════════╗"
echo "║     MudBlazor WASM — Setup inicial con Docker        ║"
echo "╚══════════════════════════════════════════════════════╝"
echo ""

# Verifica que Docker esté corriendo
echo "🔍 Verificando Docker..."

if ! command -v docker &> /dev/null; then
  echo "❌ El comando 'docker' no se encontró en el PATH."
  echo "   Asegurate de que Docker Desktop esté instalado."
  exit 1
fi

# Intentar conectar con el daemon (sin requerir sudo)
DOCKER_OK=false
if docker ps > /dev/null 2>&1; then
  DOCKER_OK=true
elif docker -H unix:///var/run/docker.sock ps > /dev/null 2>&1; then
  DOCKER_OK=true
fi

if [ "$DOCKER_OK" = false ]; then
  echo ""
  echo "⚠️  Docker está instalado pero no responde. Posibles causas:"
  echo ""
  echo "   En Windows (WSL2):"
  echo "   → Abrí Docker Desktop y esperá a que el ícono deje de girar."
  echo "   → En Docker Desktop > Settings > Resources > WSL Integration:"
  echo "     habilitá tu distro de WSL (ej: Ubuntu)."
  echo ""
  echo "   En Linux:"
  echo "   → Corré:  sudo systemctl start docker"
  echo "   → O agregá tu usuario al grupo docker:"
  echo "     sudo usermod -aG docker \$USER   (luego cerrá y abrí sesión)"
  echo ""
  echo "   En Mac:"
  echo "   → Abrí Docker Desktop desde Aplicaciones."
  echo ""
  echo "   Si Docker Desktop YA está corriendo, probá ejecutar:"
  echo "   docker ps"
  echo "   Y si funciona, volvé a correr este script."
  echo ""
  exit 1
fi

echo "✅ Docker activo y respondiendo."

# Si ya existe el proyecto, no lo sobreescribir
if [ -d "SmartFranCloudApp" ]; then
  echo "ℹ️  La carpeta 'SmartFranCloudApp' ya existe. Saltando creación."
else
  echo "📦 Creando proyecto Blazor WASM con MudBlazor..."

  docker run --rm \
    -v "$(pwd):/workspace" \
    -w /workspace \
    mcr.microsoft.com/dotnet/sdk:8.0 \
    bash -c "
      set -e

      echo '→ Instalando plantilla Blazor WASM...'
      dotnet new blazorwasm -n SmartFranCloudApp --framework net8.0

      echo '→ Agregando MudBlazor...'
      cd SmartFranCloudApp
      dotnet add package MudBlazor

      echo '→ Proyecto creado correctamente ✓'
    "

  echo ""
  echo "✅ Proyecto creado en ./SmartFranCloudApp"
fi

echo ""
echo "🔧 Aplicando configuración de MudBlazor..."
bash apply-mudblazor-config.sh

echo ""
echo "╔══════════════════════════════════════════════════════╗"
echo "║  ✅ Setup completo. Ahora podés levantar el proyecto  ║"
echo "║                                                       ║"
echo "║  Desarrollo (hot reload):                            ║"
echo "║    docker compose --profile dev up --build           ║"
echo "║    → http://localhost:5000                            ║"
echo "║                                                       ║"
echo "║  Producción:                                         ║"
echo "║    docker compose --profile prod up --build          ║"
echo "║    → http://localhost:8080                            ║"
echo "╚══════════════════════════════════════════════════════╝"
echo ""
