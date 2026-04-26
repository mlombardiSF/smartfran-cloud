# Color System Migration: SmartFran Cloud Brand Update

## Summary

The primary color palette was migrated from **Magenta-Purple** (`#8a00cb`) to **Blue-Violet** (`#6e59ee`) — the official SmartFran Cloud project brand color. This document records the rationale, the full palette mapping, and the scope of changes applied.

---

## Rationale

| | Previous | New |
|---|---|---|
| **Context** | SmartFran corporate brand | SmartFran **Cloud** project brand |
| **Color** | `#8a00cb` (Magenta-Purple, Hue ~285°) | `#6e59ee` (Blue-Violet, Hue ~248°) |
| **Issue** | Color failed marketing quality review: too magenta, does not represent the Cloud product identity |

The new primary `#6e59ee` is the official brand color for the **SmartFran Cloud** project, distinct from the broader SmartFran corporate identity.

---

## Design Principles Maintained (from DESIGN.md)

- **"The Luminous Ledger"** aesthetic preserved: depth, atmospheric light, premium editorial feel.
- **No-Line Rule** intact: sectioning through surface shifts, not borders.
- **Surface Hierarchy** (Tonal Layering): all container levels maintained with the new hue.
- **Signature Gradient**: updated to `linear-gradient(135deg, #6e59ee 0%, #9080f5 100%)`.
- **Glassmorphism**: dark surface values updated to complement the new blue-navy foundation.
- **Tertiary (teal `#006267`)**: unchanged — complementary to both old and new primary by spectral symmetry.

---

## Complete Color Palette Mapping

### Primary Cluster

| Token | Before | After |
|---|---|---|
| `Primary` / `--sf-primary` | `#8a00cb` | **`#6e59ee`** |
| `PrimaryDarken` | `#7000a6` | **`#5444d4`** |
| `PrimaryLighten` / `--sf-primary-container` | `#ae00ff` | **`#9080f5`** |
| `--sf-primary-fixed` | `#f5d9ff` | **`#ebe8ff`** |
| `--sf-primary-fixed-dim` / `DrawerIcon` | `#e6b4ff` | **`#c5bbff`** |
| `--sf-on-primary-fixed` | `#30004a` | **`#1a0060`** |
| `--sf-inverse-primary` | `#e6b4ff` | **`#c5bbff`** |

### Secondary Cluster

| Token | Before | After |
|---|---|---|
| `Secondary` / `--sf-secondary` | `#63568c` | **`#6558a0`** |
| `SecondaryDarken` | `#4b3e73` | **`#4d4188`** |
| `SecondaryLighten` / `--sf-secondary-fixed-dim` | `#cebefb` | **`#c8bef8`** |
| `--sf-secondary-container` | `#d0c0fe` | **`#cec8ff`** |
| `--sf-secondary-fixed` | `#e8ddff` | **`#e5e0ff`** |

### Foundation Dark Colors (Navy)

The navy values shift hue from ~285° (purple-navy) to ~248° (blue-navy) to maintain tonal coherence with the new primary.

| Token | Before | After | Note |
|---|---|---|---|
| Deep dark (SideNav bg) | `#0f0035` | **`#0b0935`** | Hue shift ~285° → ~248° |
| `TextPrimary` / `--sf-on-background` | `#1f1144` | **`#19124a`** | Dark blue-navy text |
| `DrawerBackground` / `--sf-inverse-surface` | `#35285b` | **`#2c2458`** | Dark blue-violet drawer |
| `TextSecondary` / `--sf-on-surface-variant` | `#4f4255` | **`#4c4568`** | Muted blue-grey |

### Surface & Background Tokens

| Token | Before | After |
|---|---|---|
| `Background` / `Surface` / `--sf-background` | `#fdf7ff` | **`#f9f8ff`** |
| `--sf-surface-container-low` | `#f8f1ff` | **`#f3f1ff`** |
| `--sf-surface-container` | `#f3eaff` | **`#edeaff`** |
| `--sf-surface-container-high` | `#ede4ff` | **`#e7e3ff`** |
| `--sf-surface-container-highest` / `--sf-surface-variant` | `#e8ddff` | **`#e2dcff`** |
| `--sf-surface-dim` | `#e0d4ff` | **`#d8d3ff`** |

### Shadow RGBA Values

| Context | Before | After |
|---|---|---|
| Neutral shadow (dark navy base) | `rgba(31, 17, 68, x)` | **`rgba(25, 18, 74, x)`** |
| Primary colored shadow | `rgba(138, 0, 203, x)` | **`rgba(110, 89, 238, x)`** |
| PrimaryLighten colored shadow | `rgba(174, 0, 255, x)` | **`rgba(144, 128, 245, x)`** |
| Deep dark shadow | `rgba(15, 0, 53, x)` | **`rgba(11, 9, 53, x)`** |
| Glassmorphism dark surface | `rgba(53, 40, 91, x)` | **`rgba(44, 36, 88, x)`** |
| Light tint (old `--sf-secondary-fixed`) | `rgba(232, 221, 255, x)` | **`rgba(226, 220, 255, x)`** |

---

## Files Modified

### Core System Files
1. `SmartFranCloudApp/Themes/SfTheme.cs` — MudBlazor theme (Palette + Shadows)
2. `SmartFranCloudApp/wwwroot/css/smartfran.css` — CSS design tokens + global utilities

### Page CSS
3. `SmartFranCloudApp/Pages/Login.razor.css`
4. `SmartFranCloudApp/Pages/ForgotPassword.razor.css`
5. `SmartFranCloudApp/Pages/InitialLoad.razor.css`
6. `SmartFranCloudApp/Pages/SelectionFranchise.razor.css`
7. `SmartFranCloudApp/Pages/NotFound.razor.css`

### Component CSS
8. `SmartFranCloudApp/Shared/POS/Venta/CartPanel.razor.css`
9. `SmartFranCloudApp/Shared/POS/Venta/SocioPanelSlide.razor.css`
10. `SmartFranCloudApp/Shared/POS/Venta/CategoryBar.razor.css`
11. `SmartFranCloudApp/Shared/POS/Venta/ProductCard.razor.css`
12. `SmartFranCloudApp/Shared/POS/Venta/OrdersButton.razor.css`
13. `SmartFranCloudApp/Shared/Nav/PosNavBar.razor.css`
14. `SmartFranCloudApp/Shared/Nav/SideNavBar.razor.css`
15. `SmartFranCloudApp/Shared/Loading/LoadingStepItem.razor.css`
16. `SmartFranCloudApp/Shared/Loading/LoadingProgressBar.razor.css`

---

## Tertiary & Error Colors (Unchanged)

- `Tertiary`: `#006267` (teal) — universal complement, works with both primary hues.
- `Error`: `#ba1a1a` — semantic, hue-independent.

---

*Applied: 2026-04-25 | Approved by: Marketing/Brand QA*
