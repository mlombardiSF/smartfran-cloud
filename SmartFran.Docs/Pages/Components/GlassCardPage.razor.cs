using SmartFran.Docs.Shared;

namespace SmartFran.Docs.Pages.Components;

public partial class GlassCardPage
{
    public static readonly string VariantCode =
@"<GlassCard Variant=""GlassCard.GlassVariant.Subtle"">
    contenido
</GlassCard>

<GlassCard Variant=""GlassCard.GlassVariant.Medium"">
    contenido
</GlassCard>

<GlassCard Variant=""GlassCard.GlassVariant.Strong"">
    contenido
</GlassCard>";

    public static readonly string RadiusCode =
@"<GlassCard Radius=""GlassCard.GlassRadius.Default"">contenido</GlassCard>
<GlassCard Radius=""GlassCard.GlassRadius.Lg"">contenido</GlassCard>
<GlassCard Radius=""GlassCard.GlassRadius.Xl"">contenido</GlassCard>";

    public static readonly string RealCode =
@"<GlassCard Variant=""GlassCard.GlassVariant.Medium""
           Radius=""GlassCard.GlassRadius.Xl""
           Style=""padding:2rem; max-width:360px;"">

    <SfInput Label=""Email""
             Icon=""alternate_email""
             @bind-Value=""_email"" />

    <SfInput Label=""Contraseña""
             Icon=""lock""
             Type=""password""
             ShowToggle=""true""
             @bind-Value=""_pass"" />

    <SfButton OnClick=""HandleLogin"">
        Ingresar
    </SfButton>

</GlassCard>";

    public static readonly List<PropEntry> Props = new()
    {
        new("ChildContent",    "RenderFragment?", "",        "Contenido renderizado dentro de la card"),
        new("Variant",         "GlassVariant",    "Subtle",  "Intensidad del efecto glass: Subtle | Medium | Strong"),
        new("Radius",          "GlassRadius",     "Lg",      "Radio de borde: Default | Lg | Xl"),
        new("Style",           "string?",         "null",    "Estilos inline adicionales (padding, width, etc.)"),
        new("AdditionalClass", "string?",         "null",    "Clases CSS adicionales para el elemento raíz"),
    };
}
