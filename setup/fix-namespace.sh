#!/bin/bash
# =============================================================================
# fix-namespace.sh
# Corrige el namespace en proyectos ya generados donde los archivos
# todavía referencian "SmartFranCloudApp" en lugar del nombre real del proyecto.
# =============================================================================
set -e

# Detectar proyecto
CSPROJ=$(find . -maxdepth 2 -name "*.csproj" | head -1)
if [ -z "$CSPROJ" ]; then
  echo "❌ No se encontró ningún .csproj."
  exit 1
fi

APP=$(dirname "$CSPROJ" | sed 's|^\./||')
NAMESPACE=$(basename "$CSPROJ" .csproj | tr '-' '_')

echo "→ Proyecto : $APP"
echo "→ Namespace: $NAMESPACE"
echo ""

# Fix Program.cs
echo "→ Corrigiendo Program.cs..."
sed -i "s/using SmartFranCloudApp;/using ${NAMESPACE};/" "$APP/Program.cs"

# Fix _Imports.razor
echo "→ Corrigiendo _Imports.razor..."
sed -i "s/@using SmartFranCloudApp/@using ${NAMESPACE}/" "$APP/_Imports.razor"

# Fix index.html (el .styles.css debe usar el nombre de carpeta, no SmartFranCloudApp)
echo "→ Corrigiendo index.html..."
sed -i "s/SmartFranCloudApp\.styles\.css/${APP}.styles.css/" "$APP/wwwroot/index.html"

echo ""
echo "✅ Namespace corregido. Reiniciá el contenedor:"
echo "   docker compose --profile dev down"
echo "   docker compose --profile dev up"
