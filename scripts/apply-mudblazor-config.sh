#!/bin/bash
# =============================================================================
# apply-mudblazor-config.sh
# Aplica los archivos de configuración de MudBlazor al proyecto generado.
# El nombre del proyecto y namespace se detectan automáticamente.
# =============================================================================
set -e

# ── Detectar nombre del proyecto automáticamente ─────────────────────────────
CSPROJ=$(find . -maxdepth 2 -name "*.csproj" | head -1)

if [ -z "$CSPROJ" ]; then
  echo "❌ No se encontró ningún .csproj. Ejecutá setup.sh primero."
  exit 1
fi

# APP  = carpeta del proyecto (ej: mudblazor-wasm-docker)
APP=$(dirname "$CSPROJ" | sed 's|^\./||')
# NAMESPACE = .NET convierte guiones a guión_bajo en namespaces automáticamente
NAMESPACE=$(basename "$CSPROJ" .csproj | tr '-' '_')

echo "→ Proyecto detectado : $APP"
echo "→ Namespace C#       : $NAMESPACE"

# ── 1. wwwroot/index.html ────────────────────────────────────────────────────
echo "→ Actualizando index.html..."
cat > "$APP/wwwroot/index.html" << HTML
<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>MudBlazor App</title>
    <base href="/" />

    <!-- MudBlazor CSS -->
    <link href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700&display=swap" rel="stylesheet" />
    <link href="_content/MudBlazor/MudBlazor.min.css" rel="stylesheet" />

    <!-- Blazor CSS (nombre dinámico del proyecto) -->
    <link href="${APP}.styles.css" rel="stylesheet" />
</head>
<body>
    <div id="app">
        <div style="display:flex;justify-content:center;align-items:center;height:100vh;font-family:Roboto,sans-serif;color:#666;">
            <div style="text-align:center">
                <div style="font-size:2rem;margin-bottom:1rem">⏳</div>
                <p>Cargando aplicación...</p>
            </div>
        </div>
    </div>

    <div id="blazor-error-ui">
        Un error inesperado ocurrió.
        <a href="" class="reload">Recargar</a>
        <a class="dismiss">🗙</a>
    </div>

    <!-- MudBlazor JS -->
    <script src="_content/MudBlazor/MudBlazor.min.js"></script>
    <!-- Blazor WASM runtime -->
    <script src="_framework/blazor.webassembly.js"></script>
</body>
</html>
HTML

# ── 2. Program.cs ────────────────────────────────────────────────────────────
echo "→ Actualizando Program.cs..."
cat > "$APP/Program.cs" << CS
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using ${NAMESPACE};

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});

// Registrar servicios de MudBlazor
builder.Services.AddMudServices();

await builder.Build().RunAsync();
CS

# ── 3. _Imports.razor ────────────────────────────────────────────────────────
echo "→ Actualizando _Imports.razor..."
cat > "$APP/_Imports.razor" << RAZOR
@using System.Net.Http
@using System.Net.Http.Json
@using Microsoft.AspNetCore.Components.Forms
@using Microsoft.AspNetCore.Components.Routing
@using Microsoft.AspNetCore.Components.Web
@using static Microsoft.AspNetCore.Components.Web.RenderMode
@using Microsoft.AspNetCore.Components.WebAssembly.Http
@using Microsoft.JSInterop
@using ${NAMESPACE}
@using MudBlazor
RAZOR

# ── 4. Layout/MainLayout.razor ───────────────────────────────────────────────
echo "→ Actualizando MainLayout.razor..."
cat > "$APP/Layout/MainLayout.razor" << 'RAZOR'
@inherits LayoutComponentBase

<MudThemeProvider />
<MudDialogProvider />
<MudSnackbarProvider />

<MudLayout>
    <MudAppBar Elevation="1">
        <MudIconButton Icon="@Icons.Material.Filled.Menu"
                       Color="Color.Inherit"
                       Edge="Edge.Start"
                       OnClick="@ToggleDrawer" />
        <MudText Typo="Typo.h6" Class="ml-3">Mi App MudBlazor</MudText>
        <MudSpacer />
    </MudAppBar>

    <MudDrawer @bind-Open="_drawerOpen" ClipMode="DrawerClipMode.Always" Elevation="2">
        <MudDrawerHeader>
            <MudText Typo="Typo.h6">Navegación</MudText>
        </MudDrawerHeader>
        <NavMenu />
    </MudDrawer>

    <MudMainContent>
        <MudContainer MaxWidth="MaxWidth.Large" Class="mt-4">
            @Body
        </MudContainer>
    </MudMainContent>
</MudLayout>

@code {
    private bool _drawerOpen = true;
    private void ToggleDrawer() => _drawerOpen = !_drawerOpen;
}
RAZOR

# ── 5. Layout/NavMenu.razor ──────────────────────────────────────────────────
echo "→ Actualizando NavMenu.razor..."
cat > "$APP/Layout/NavMenu.razor" << 'RAZOR'
<MudNavMenu>
    <MudNavLink Href="/" Match="NavLinkMatch.All"
                Icon="@Icons.Material.Filled.Home">
        Inicio
    </MudNavLink>
    <MudNavLink Href="/counter"
                Icon="@Icons.Material.Filled.Add">
        Contador
    </MudNavLink>
    <MudNavLink Href="/weather"
                Icon="@Icons.Material.Filled.WbSunny">
        Clima
    </MudNavLink>
</MudNavMenu>
RAZOR

# ── 6. Pages/Home.razor ──────────────────────────────────────────────────────
echo "→ Actualizando Home.razor..."
cat > "$APP/Pages/Home.razor" << 'RAZOR'
@page "/"

<PageTitle>Inicio</PageTitle>

<MudText Typo="Typo.h4" GutterBottom="true">¡Bienvenido a MudBlazor! 🎉</MudText>
<MudText Class="mb-8" Color="Color.Secondary">
    Plantilla base con Blazor WASM + MudBlazor corriendo en Docker.
</MudText>

<MudGrid>
    <MudItem xs="12" sm="6" md="4">
        <MudCard>
            <MudCardHeader>
                <CardHeaderContent>
                    <MudText Typo="Typo.h6">🚀 Blazor WASM</MudText>
                </CardHeaderContent>
            </MudCardHeader>
            <MudCardContent>
                <MudText>Corre completamente en el navegador via WebAssembly.</MudText>
            </MudCardContent>
        </MudCard>
    </MudItem>

    <MudItem xs="12" sm="6" md="4">
        <MudCard>
            <MudCardHeader>
                <CardHeaderContent>
                    <MudText Typo="Typo.h6">🎨 MudBlazor</MudText>
                </CardHeaderContent>
            </MudCardHeader>
            <MudCardContent>
                <MudText>Más de 100 componentes Material Design listos para usar.</MudText>
            </MudCardContent>
        </MudCard>
    </MudItem>

    <MudItem xs="12" sm="6" md="4">
        <MudCard>
            <MudCardHeader>
                <CardHeaderContent>
                    <MudText Typo="Typo.h6">🐳 Docker</MudText>
                </CardHeaderContent>
            </MudCardHeader>
            <MudCardContent>
                <MudText>Sin instalar nada en tu PC. El SDK corre dentro del contenedor.</MudText>
            </MudCardContent>
        </MudCard>
    </MudItem>
</MudGrid>

<MudDivider Class="my-6" />

<MudAlert Severity="Severity.Info">
    Editá los archivos en <strong>Pages/</strong> y verás los cambios al refrescar.
</MudAlert>
RAZOR

# ── 7. Pages/Counter.razor ───────────────────────────────────────────────────
echo "→ Actualizando Counter.razor..."
cat > "$APP/Pages/Counter.razor" << 'RAZOR'
@page "/counter"

<PageTitle>Contador</PageTitle>

<MudText Typo="Typo.h4" GutterBottom="true">Contador</MudText>
<MudText Class="mb-4">Valor actual: <strong>@_count</strong></MudText>

<MudStack Row="true" Spacing="2">
    <MudButton Variant="Variant.Filled" Color="Color.Primary" OnClick="Incrementar">
        + Incrementar
    </MudButton>
    <MudButton Variant="Variant.Outlined" Color="Color.Secondary" OnClick="Resetear">
        Resetear
    </MudButton>
</MudStack>

@code {
    private int _count = 0;
    private void Incrementar() => _count++;
    private void Resetear() => _count = 0;
}
RAZOR

echo ""
echo "✅ Configuración de MudBlazor aplicada correctamente."
