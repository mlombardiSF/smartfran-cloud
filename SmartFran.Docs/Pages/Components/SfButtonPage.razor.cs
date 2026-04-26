using SmartFran.Docs.Shared;

namespace SmartFran.Docs.Pages.Components;

public partial class SfButtonPage
{
    private bool _loading = false;

    private async Task SimulateLoad()
    {
        _loading = true;
        await Task.Delay(2000);
        _loading = false;
    }

    public static readonly string VariantCode =
@"<SfButton Variant=""SfButton.SfButtonVariant.Primary"">
    Confirmar
</SfButton>

<SfButton Variant=""SfButton.SfButtonVariant.Secondary"" TrailingIcon="""">
    Cancelar
</SfButton>

<SfButton Variant=""SfButton.SfButtonVariant.Ghost"" TrailingIcon="""">
    Ver más
</SfButton>";

    public static readonly string LoadingCode =
@"<SfButton IsLoading=""@_loading"" OnClick=""HandleClick"">
    Iniciar sesión
</SfButton>

@code {
    private bool _loading = false;

    private async Task HandleClick() {
        _loading = true;
        await Task.Delay(2000); // llamada a API
        _loading = false;
    }
}";

    public static readonly string DisabledCode =
@"<SfButton Disabled=""true"">
    Acción bloqueada
</SfButton>

<SfButton Variant=""SfButton.SfButtonVariant.Secondary""
          TrailingIcon=""""
          Disabled=""true"">
    También bloqueada
</SfButton>";

    public static readonly string HrefCode =
@"<!-- Renderiza un <a> con el mismo estilo visual -->
<SfButton Href=""/mi-ruta"">
    Ir a página
</SfButton>";

    public static readonly List<PropEntry> Props = new()
    {
        new("ChildContent",  "RenderFragment?",    "",                    "Contenido del botón (texto, íconos, etc.)"),
        new("Variant",       "SfButtonVariant",    "Primary",             "Estilo visual: Primary | Secondary | Ghost"),
        new("IsLoading",     "bool",               "false",               "Muestra spinner y deshabilita el botón"),
        new("Disabled",      "bool",               "false",               "Bloquea la interacción sin estado de carga"),
        new("Type",          "string",             "\"button\"",          "Atributo HTML type del elemento button"),
        new("Href",          "string?",            "null",                "Si se define, renderiza un tag <a> en vez de <button>"),
        new("TrailingIcon",  "string?",            "\"arrow_forward\"",   "Ícono Material Symbols al final. Pasar \"\" para ocultarlo"),
        new("OnClick",       "EventCallback",      "",                    "Callback al hacer click (solo cuando no usa Href)"),
    };
}
