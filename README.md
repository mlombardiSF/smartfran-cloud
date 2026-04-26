# 🚀 SmartFran: Proyecto Blazor WASM con Librería de Componentes

Proyecto integral de **Blazor WebAssembly** (.NET 8) con **MudBlazor** que integra:
- **SmartFranCloudApp**: Aplicación interactiva principal (maqueta POS)
- **SmartFran.Components**: Librería RCL compartida con 19 componentes reutilizables
- **SmartFran.Docs**: Sitio de documentación con demos en vivo de todos los componentes

Todo corre en **Docker** — no necesitas instalar .NET en tu PC.

---

## 🎯 Arquitectura

```
SmartFran (monorepo)
│
├── 📦 SmartFran.Components (Razor Class Library)
│   ├── 19 componentes reutilizables (button, input, cards, panels, etc.)
│   ├── Themes & Design tokens (glassmorphism, colores, tipografía)
│   └── Services (CartService para estado compartido)
│
├── 🎨 SmartFranCloudApp (Blazor WASM)
│   └── Maqueta interactiva del POS — consume SmartFran.Components
│
└── 📚 SmartFran.Docs (Blazor WASM)
    ├── Página de inicio con grid de componentes
    ├── 19 páginas de documentación (1 por componente)
    ├── Demos en vivo interactivas
    ├── Código copiable (Prism.js)
    └── Props tables para cada componente
```

### Ventajas de esta estructura

| Aspecto | Beneficio |
|---|---|
| **RCL Compartida** | Los componentes están en un solo lugar, importables en cualquier proyecto .NET |
| **Docs integrada** | Documentación viva con demos + código → developers entienden cómo usar cada componente |
| **Dev uniforme** | Todo junto en Docker con hot reload → cambios se ven al guardar |
| **Prod escalable** | Cada app en su propio container → podés actualizar/escalar de forma independiente |
| **Monorepo** | Un solo repo, un solo build, versionado junto |

---

## ⚡ Inicio rápido

### 1️⃣ Desarrollo (hot reload para los 3 proyectos)

```bash
# Levantar los 3 apps juntos
docker compose --profile dev up --build

# Esperar el mensaje: "Starting application..."
# Luego abrir en el navegador:
#   http://localhost:5000  ← SmartFranCloudApp (maqueta POS)
#   http://localhost:5001  ← SmartFran.Docs (documentación)
```

Los cambios en cualquier archivo `.razor` se ven al refrescar el navegador.

### 2️⃣ Producción (nginx optimizado, cada app en su propio container)

```bash
# Construir e iniciar en modo producción
docker compose --profile prod up --build

# Acceder:
#   http://localhost:8080  ← SmartFranCloudApp (maqueta POS)
#   http://localhost:8081  ← SmartFran.Docs (documentación)
```

En producción:
- Cada app corre en **nginx alpine** (ligero y seguro)
- Archivos `.wasm` comprimidos con gzip
- Cache agresivo de assets (1 año)
- Fallback SPA: todas las rutas sirven `index.html`

---

## 📁 Estructura del proyecto

```
mudblazor-wasm-docker/
│
├── 📄 docker-compose.yml          ← Orquestación (dev + prod)
├── 📄 Dockerfile                  ← Build prod SmartFranCloudApp
├── 📄 Dockerfile.dev              ← Dev SmartFranCloudApp (hot reload)
├── 📄 Dockerfile.docs             ← Build prod SmartFran.Docs
├── 📄 Dockerfile.docs.dev         ← Dev SmartFran.Docs (hot reload)
├── 📄 nginx.conf                  ← Config nginx (SPA + .wasm)
├── 📄 README.md                   ← Este archivo
│
├── 📂 SmartFran.Components/       ← RCL: 19 componentes reutilizables
│   ├── 📄 SmartFran.Components.csproj
│   ├── 📂 Components/             ← Componentes .razor
│   ├── 📂 Models/                 ← DTOs (Product, CartItem, Socio, etc.)
│   ├── 📂 Services/               ← CartService (estado compartido)
│   ├── 📂 Themes/                 ← SfTheme (design tokens)
│   └── 📂 wwwroot/css/            ← smartfran.css (glassmorphism)
│
├── 📂 SmartFranCloudApp/               ← Blazor WASM: Maqueta POS
│   ├── 📄 Program.cs              ← Servicios + MudBlazor config
│   ├── 📂 Pages/
│   ├── 📂 Layout/
│   └── 📂 wwwroot/
│
└── 📂 SmartFran.Docs/             ← Blazor WASM: Documentación
    ├── 📄 Program.cs
    ├── 📂 Pages/Components/       ← 19 páginas de docs
    ├── 📂 Shared/                 ← ComponentPreview, CodeBlock, PropsTable
    └── 📂 wwwroot/
```

---

## 🛠️ Comandos útiles

### Desarrollo

```bash
# Levantar todos (SmartFranCloudApp + SmartFran.Docs)
docker compose --profile dev up --build

# Levantar solo un servicio
docker compose --profile dev up mudblazor-dev --build
docker compose --profile dev up smartfran-docs-dev --build

# Ver logs en tiempo real
docker logs -f mudblazor-dev
docker logs -f smartfran-docs-dev

# Parar sin borrar volúmenes
docker compose --profile dev stop

# Parar y borrar todo (limpia caché de NuGet)
docker compose --profile dev down -v
```

### Producción

```bash
# Levantar en prod
docker compose --profile prod up --build -d

# Ver estado
docker compose --profile prod ps

# Ver logs
docker logs mudblazor-prod
docker logs smartfran-docs-prod

# Parar en prod
docker compose --profile prod down
```

### Reconstruir sin caché

```bash
# Si algo roto no se soluciona con rebuild normal
docker compose --profile dev down -v
docker compose --profile dev up --build
```

---

## 🧪 Cómo desarrollar

### 1. Editar componentes en SmartFran.Components

```
SmartFran.Components/Components/SfButton.razor
SmartFran.Components/Components/SfButton.razor.css
```

- El cambio se detecta automáticamente
- Refreshear el navegador → ves los cambios
- **Impacta**: SmartFranCloudApp + SmartFran.Docs (porque ambos usan la librería)

### 2. Editar páginas de documentación en SmartFran.Docs

```
SmartFran.Docs/Pages/Components/SfButtonPage.razor
SmartFran.Docs/Pages/Components/SfButtonPage.razor.cs
```

- Guardar → refresh en http://localhost:5001 → ves cambios inmediatos
- No necesita rebuild de SmartFran.Components

### 3. Editar SmartFranCloudApp (maqueta POS)

```
SmartFranCloudApp/Pages/SomeFeature.razor
```

- Cambios visibles en http://localhost:5000 al refrescar

### ⚙️ Agregar un nuevo componente

1. **Crear en SmartFran.Components:**
   ```
   SmartFran.Components/Components/MyNewComponent.razor
   SmartFran.Components/Components/MyNewComponent.razor.css
   ```

2. **Crear documentación en SmartFran.Docs:**
   ```
   SmartFran.Docs/Pages/Components/MyNewComponentPage.razor
   SmartFran.Docs/Pages/Components/MyNewComponentPage.razor.cs
   ```

3. **Registrar en DocsLayout:**
   ```xml
   <!-- SmartFran.Docs/Layout/DocsLayout.razor -->
   <MudNavLink Href="/components/mynewcomponent">MyNewComponent</MudNavLink>
   ```

4. **Refreshear los navegadores** → cambios aparecen en dev automáticamente

---

## 🏗️ Buenas prácticas: Por qué esta arquitectura es correcta

### 1. **RCL para componentes compartidos** ✅
- Los componentes viven en un lugar centralizador
- Ambas apps (SmartFranCloudApp + SmartFran.Docs) consumen la misma versión
- Cambios en un componente se reflejan en ambas automáticamente
- No hay duplicación de código

### 2. **Docs site como Blazor WASM** ✅
- Demos en vivo: interactuar con componentes mientras lees la docs
- Código copiable: Prism.js con syntax highlighting
- Props tables: documenta cada parámetro automáticamente
- SPA: rápido, sin latencia servidor

### 3. **Docker con profiles** ✅
- Un único `docker-compose.yml` para dev y prod
- Profiles (`--profile dev`, `--profile prod`) separan lógicamente
- En dev: hot reload, volúmenes montados, NuGet caché compartido
- En prod: imágenes optimizadas, nginx, sin volúmenes, containers independientes

### 4. **Cada app en su propio container (prod)** ✅
- **Escalabilidad**: podés lanzar 2 instancias de docs, 1 de app
- **Independencia**: actualizar docs sin tocar SmartFranCloudApp
- **Monitoreo**: logs y métricas por container separadas
- **Deployments**: CI/CD puede pushear cada imagen de forma independiente

### 5. **Monorepo** ✅
- Un solo repositorio → versionado junto
- Cambios atómicos: si modificas un componente, documentación y maqueta se actualizan en el mismo commit
- Fácil: single source of truth

---

## 🚢 Deployment a producción

### Opción 1: Docker Compose (simple)

```bash
# En tu servidor:
git clone <repo>
cd mudblazor-wasm-docker

docker compose --profile prod up -d

# Verificar:
docker compose ps
```

### Opción 2: CI/CD (profesional)

**GitHub Actions** ejemplo:

```yaml
name: Build & Push Docker Images

on: [push]

jobs:
  build:
    runs-on: ubuntu-latest
    steps:
      - uses: actions/checkout@v3
      
      - name: Build SmartFranCloudApp
        run: docker build -t myregistry/mudblazor-app:${{ github.sha }} -f Dockerfile .
      
      - name: Build SmartFran.Docs
        run: docker build -t myregistry/smartfran-docs:${{ github.sha }} -f Dockerfile.docs .
      
      - name: Push to registry
        run: |
          docker push myregistry/mudblazor-app:${{ github.sha }}
          docker push myregistry/smartfran-docs:${{ github.sha }}
```

Luego en tu servidor:

```bash
docker pull myregistry/mudblazor-app:latest
docker pull myregistry/smartfran-docs:latest

docker compose --profile prod down
docker compose --profile prod up -d
```

### Opción 3: Kubernetes (enterprise)

```yaml
# deployment.yaml
apiVersion: apps/v1
kind: Deployment
metadata:
  name: mudblazor-app
spec:
  replicas: 2
  template:
    spec:
      containers:
      - name: app
        image: myregistry/mudblazor-app:latest
        ports:
        - containerPort: 80
---
apiVersion: apps/v1
kind: Deployment
metadata:
  name: smartfran-docs
spec:
  replicas: 1
  template:
    spec:
      containers:
      - name: docs
        image: myregistry/smartfran-docs:latest
        ports:
        - containerPort: 80
```

---

## 🐛 Troubleshooting

### "No se ven los cambios en el navegador"

1. Verificar que los contenedores estén corriendo:
   ```bash
   docker compose --profile dev ps
   ```
   
2. Chequear los logs:
   ```bash
   docker logs smartfran-docs-dev
   ```
   
3. Probar con `Ctrl+Shift+R` (hard refresh) en el navegador

4. Si persiste, reconstruir sin caché:
   ```bash
   docker compose --profile dev down -v
   docker compose --profile dev up --build
   ```

### "El contenedor se cae apenas inicia"

```bash
# Ver el error en los logs
docker logs smartfran-docs-dev

# Generalmente es:
# - Error en Program.cs (servicios mal registrados)
# - Error en _Imports.razor (using incorrecto)
# - Error de compilación de C# en los componentes
```

### "Puerto 5000/5001 ya está en uso"

```bash
# Ver qué está usando el puerto
lsof -i :5000

# O cambiar el puerto en docker-compose.yml:
# ports:
#   - "5002:5000"  ← cambiar 5002 por lo que quieras
```

### "SmartFran.Components no se actualiza en las apps"

La librería es un proyecto referenciado. Después de cambios importantes:

```bash
# Rebuild completo
docker compose --profile dev down -v
docker compose --profile dev up --build
```

---

## 📊 Componentes disponibles (19 totales)

### Design System (4)
- **SfButton** — Botón con variantes Primary/Secondary/Ghost + loading
- **SfInput** — Input con ícono, toggle password, validación
- **GlassCard** — Contenedor glassmorphism (Subtle/Medium/Strong)
- **PageBackground** — Fondo animado con blobs y patrón SVG

### Loading (2)
- **LoadingProgressBar** — Barra de progreso con glow
- **LoadingStepItem** — Steps wizard (Pending/Active/Completed)

### Navegación (4)
- **TopNavBar** — Header con usuario, hora, notificaciones
- **SideNavBar** — Drawer lateral colapsable
- **BottomBar** — Footer con versión y sync
- **PosNavBar** — Header POS con buscador de productos

### POS (9)
- **ProductCard** — Tarjeta producto con imagen, precio, agregar
- **CartPanel** — Panel lateral: socio, items, totales, checkout
- **CategoryBar** — Chips de categorías + dropdown "Más"
- **SocioPanelSlide** — Perfil socio: puntos, descuento, canjes
- **OrdersButton** — Botón pedidos con badge y pulso
- **FranchiseCard** — Selección de franquicia
- **CounterRow** — Fila de mostrador (abierto/cerrado)
- **ShiftModal** — Modal confirmación apertura turno
- **ToastNotification** — Notificación toast con progreso

---

## 📚 Recursos

- [MudBlazor Documentation](https://mudblazor.com)
- [Blazor WebAssembly Docs](https://docs.microsoft.com/en-us/aspnet/core/blazor)
- [Docker Compose](https://docs.docker.com/compose/)
- [Razor Class Libraries](https://docs.microsoft.com/en-us/aspnet/core/razor-pages/ui-class)

---

## 📝 Licencia

Este proyecto es de uso interno de SmartFran.

---

**Última actualización**: Abril 2026 | **.NET 8** | **MudBlazor 9.2.0** | **Docker Compose**
