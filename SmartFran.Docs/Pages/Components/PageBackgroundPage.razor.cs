using SmartFran.Docs.Shared;

namespace SmartFran.Docs.Pages.Components;

public partial class PageBackgroundPage
{
    public static readonly string DefaultCode =
@"<PageBackground>
    <!-- contenido de la página -->
</PageBackground>";

    public static readonly string MinimalCode =
@"<PageBackground ShowPattern=""false"" ShowShapes=""false"">
    <!-- contenido de la página -->
</PageBackground>";

    public static readonly string CustomBlobCode =
@"<PageBackground BlobTopRight=""#00c3ff"" BlobBottomLeft=""#0055aa"">
    <!-- contenido de la página -->
</PageBackground>";

    public static readonly List<PropEntry> Props = new()
    {
        new("ChildContent",    "RenderFragment?", "null",      "Contenido renderizado sobre el fondo"),
        new("ShowPattern",     "bool",            "true",      "Muestra el patrón SVG de cuadrícula sutil"),
        new("ShowShapes",      "bool",            "true",      "Muestra las figuras geométricas flotantes"),
        new("BlobTopRight",    "string",          "\"#ae00ff\"","Color CSS del blob en esquina superior derecha"),
        new("BlobBottomLeft",  "string",          "\"#6200a0\"","Color CSS del blob en esquina inferior izquierda"),
    };
}
