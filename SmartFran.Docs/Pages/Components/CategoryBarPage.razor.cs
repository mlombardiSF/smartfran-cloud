using SmartFran.Components.Models;
using SmartFran.Docs.Shared;

namespace SmartFran.Docs.Pages.Components;

public partial class CategoryBarPage
{
    private string _activeCategory  = "Helados";
    private string _activeCategory2 = "Helados";

    public static readonly List<CategoryModel> MainCategories = new()
    {
        new() { Name="Todos",   Icon="apps",         Group="Principal" },
        new() { Name="Helados", Icon="icecream",      Group="Principal" },
        new() { Name="Palitos", Icon="kebab_dining",  Group="Principal" },
        new() { Name="Sundaes", Icon="local_cafe",    Group="Principal" },
    };

    public static readonly List<CategoryModel> ExtraCategories = new()
    {
        new() { Name="Tortas",    Icon="cake",          Group="Especiales" },
        new() { Name="Bombones",  Icon="redeem",        Group="Especiales" },
        new() { Name="Kilos",     Icon="scale",         Group="Granel"     },
        new() { Name="Medios kg", Icon="balance",       Group="Granel"     },
    };

    public static readonly string FullCode =
@"<CategoryBar CategoriesMain=""@_main""
             CategoriesExtra=""@_extra""
             CategoryActive=""@_active""
             OnCategorySelect=""cat => _active = cat"" />

@code {
    private string _active = ""Helados"";

    private List<CategoryModel> _main = new() {
        new() { Name=""Todos"",   Icon=""apps"" },
        new() { Name=""Helados"", Icon=""icecream"" },
        new() { Name=""Palitos"", Icon=""kebab_dining"" },
    };

    private List<CategoryModel> _extra = new() {
        new() { Name=""Tortas"",   Icon=""cake"",   Group=""Especiales"" },
        new() { Name=""Bombones"", Icon=""redeem"", Group=""Especiales"" },
    };
}";

    public static readonly string MainOnlyCode =
@"<CategoryBar CategoriesMain=""@_main""
             CategoryActive=""@_active""
             OnCategorySelect=""cat => _active = cat"" />";

    public static readonly string CategoryModelCode =
@"public class CategoryModel
{
    public string Name  { get; set; } = string.Empty;
    public string Icon  { get; set; } = string.Empty;  // Material Symbols
    public string Group { get; set; } = string.Empty;  // Agrupar en dropdown
}";

    public static readonly List<PropEntry> Props = new()
    {
        new("CategoriesMain",  "List<CategoryModel>",   "new()", "Categorías que se muestran como chips directos"),
        new("CategoriesExtra", "List<CategoryModel>",   "new()", "Categorías en el dropdown del botón Más. Agrupadas por CategoryModel.Group"),
        new("CategoryActive",  "string",                "\"\"",  "Nombre de la categoría actualmente seleccionada"),
        new("OnCategorySelect","EventCallback<string>", "",      "Disparado al seleccionar cualquier categoría. Emite el nombre"),
    };
}
