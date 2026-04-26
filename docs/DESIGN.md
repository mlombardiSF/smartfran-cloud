# Design System Document

## 1. Overview & Creative North Star
The Creative North Star for this design system is **"The Luminous Ledger."** 

In the high-velocity world of Cloud POS, efficiency is often mistaken for austerity. This design system rejects that notion, transforming a functional utility into a premium, editorial experience. By moving away from the rigid, "boxed-in" grid of traditional SaaS, we embrace a sense of depth and atmospheric light. We utilize the contrast between the deep, authoritative **Navy (#0f0035)** and the electric **Vibrant Purple (#ae00ff)** to create a layout that feels both grounded and futuristic. 

The aesthetic is characterized by **intentional asymmetry**, where high-contrast typography scales and overlapping surface layers break the "template" look. This is not just a POS; it is a sophisticated digital workspace designed for clarity, tactile joy, and professional prestige.

---

## 2. Colors
Our palette is a sophisticated interplay of deep space and neon energy. 

### The Palette
*   **Primary Core:** `primary` (#8a00cb) and `primary_container` (#ae00ff). These drive action and represent the pulse of the brand.
*   **The Foundation:** `background` (#fdf7ff) and `surface` (#fdf7ff). A slightly tinted off-white that prevents eye fatigue.
*   **The Deep Navy:** `on_background` (#1f1144) and `inverse_surface` (#35285b). Used for high-contrast headers and grounded navigation.

### The "No-Line" Rule
To achieve a high-end editorial feel, **1px solid borders for sectioning are strictly prohibited.** We do not define boundaries with lines; we define them with light. Sectioning must be achieved through background shifts—for example, a `surface_container_low` card resting on a `surface` background.

### Surface Hierarchy & Nesting
Treat the UI as a physical stack of frosted glass. Use the `surface_container` tiers to create depth:
*   **Lowest:** Base background or deep-set containers.
*   **Highest:** Active interactive elements or prioritized modal content.
*   **The Glass & Gradient Rule:** For floating headers or action bars, use Glassmorphism. Apply `surface` colors at 80% opacity with a `backdrop-blur` (20px-40px). 
*   **Signature Textures:** Main CTAs should use a subtle linear gradient from `primary` (#8a00cb) to `primary_container` (#ae00ff) at a 135-degree angle to provide a "lit-from-within" soul.

---

## 3. Typography
The typography uses a dual-font strategy to balance character with extreme readability.

*   **Display & Headlines (Plus Jakarta Sans):** Used for large data points and page titles. The wide aperture of Plus Jakarta Sans provides a modern, tech-forward vibe that feels premium.
*   **Body & Titles (Manrope):** Chosen for its geometric precision and high legibility at small sizes. 
*   **The Editorial Scale:** We use a high-contrast scale. A `display-lg` (3.5rem) title might sit near a `label-md` (0.75rem) descriptor to create a clear visual hierarchy that feels like a high-end magazine layout rather than a database table.

---

## 4. Elevation & Depth
Elevation is achieved through **Tonal Layering** rather than structural shadows.

*   **The Layering Principle:** Stacking is the primary tool for hierarchy. A `surface_container_lowest` card placed on a `surface_container_low` background creates a natural, soft lift.
*   **Ambient Shadows:** When a component must "float" (like a mobile FAB or a dropdown), use an extra-diffused shadow. 
    *   *Shadow Specs:* Blur: 40px, Spread: -5px, Color: `on_surface` (#1f1144) at 6% opacity. This mimics natural ambient light.
*   **The "Ghost Border" Fallback:** If accessibility requires a stroke, use the `outline_variant` token at 15% opacity. Never use 100% opaque borders.
*   **Glassmorphism:** Use semi-transparent layers for the POS sidebar to allow the background gradients to bleed through, softening the interface's edges.

---

## 5. Components
All components prioritize "The Large Touch": generous targets for fast-paced retail environments.

### Buttons
*   **Primary:** Rounded `full` (9999px), using the Signature Gradient. Padding: `3.5` (1.2rem) vertical, `6` (2rem) horizontal.
*   **Secondary:** Glass-style. Background: `primary_container` at 10% opacity. Text color: `primary`.
*   **States:** On `hover` or `pressed`, increase the surface brightness using `primary_fixed_dim` (#e6b4ff).

### Cards & Lists
*   **The Card:** Use `md` (1.5rem) or `lg` (2rem) corner radius. 
*   **No Dividers:** Forbid the use of line dividers between list items. Use vertical white space `3` (1rem) or subtle background alternating shifts between `surface_container_low` and `surface_container_lowest`.

### Input Fields
*   **Styling:** Large `DEFAULT` (1rem) radius. Background: `surface_container_high`. No borders.
*   **Focus State:** A 2px glow using `secondary_fixed` (#e8ddff) rather than a solid stroke.

### Specialized POS Components
*   **Numerical Keypad:** Large, circular buttons with `surface_container_highest` backgrounds. Use `display-sm` for numbers to ensure zero-error input.
*   **Status Badges:** Use the `tertiary` (#006267) teal for "Success/Open" states, styled as pills with `full` roundedness and 10% opacity backgrounds.

---

## 6. Do's and Don'ts

### Do
*   **Do** use generous white space. Use the `spacing-8` (2.75rem) or `spacing-10` (3.5rem) tokens to let the UI breathe.
*   **Do** lean into the large corner radii (`lg` and `xl`). It makes the tech feel approachable and ergonomic for touch.
*   **Do** use the `tertiary` teal (#f2cced7) sparingly for data visualization to provide a cool contrast to the warm purples.

### Don't
*   **Don't** use pure black (#000000) for shadows or text. Always use the `on_surface` (#1f1144) or `inverse_surface` (#35285b) to maintain tonal depth.
*   **Don't** use 90-degree corners. This system is fluid and "cloud-tech"; sharp corners feel dated and aggressive.
*   **Don't** cram information. If a screen feels full, use a "layered" approach with a horizontal scroll or a "sheet" that slides up from the bottom.

---
**Director’s Note:** Remember, we are not building a form; we are building a flow. Every interaction should feel like light moving through glass. Use the tokens not as limits, but as the DNA of a premium experience.