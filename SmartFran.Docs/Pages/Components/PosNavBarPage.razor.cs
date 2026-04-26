using SmartFran.Components.Models;
using SmartFran.Docs.Shared;

namespace SmartFran.Docs.Pages.Components;

public partial class PosNavBarPage
{
    public static readonly List<Product> SampleProducts = new()
    {
        new() { Id="p1", Name="Cucurucho",       Category="Helados", Price=950,  ImageUrl="/assets/images/products/cucurucho.png"      },
        new() { Id="p2", Name="Palito Bombón",    Category="Palitos", Price=680,  ImageUrl="/assets/images/products/palito-bombon.png"  },
        new() { Id="p3", Name="Sundae Frutal",    Category="Sundaes", Price=1200, ImageUrl="/assets/images/products/sundae-frutal.png"  },
        new() { Id="p4", Name="Tacita 2 Bochas",  Category="Helados", Price=1100, ImageUrl="/assets/images/products/tacita-2b.png"      },
        new() { Id="p5", Name="Gigante 3 Bochas", Category="Helados", Price=1650, ImageUrl="/assets/images/products/gigante-3b.png"     },
        new() { Id="p6", Name="Crocantino",       Category="Palitos", Price=720,  ImageUrl="/assets/images/products/crocantino.png"     },
    };

    public static readonly string WithProductsCode =
@"<PosNavBar UserName=""Matías L.""
           Terminal=""002""
           Shift=""0045""
           Products=""@_products""
           OnProductSelect=""HandleSelect"" />

@code {
    private List<Product> _products = new() { /* ... */ };

    private void HandleSelect(Product p)
        => CartService.AddProduct(p);
}";

    public static readonly string EmptyCode =
@"<PosNavBar UserName=""Carlos F."" Terminal=""001"" Shift=""0001"" />";

    public static readonly List<PropEntry> Props = new()
    {
        new("UserName",        "string",                "\"Usuario\"", "Nombre del operador. Visible en la info del POS y en el avatar"),
        new("Terminal",        "string",                "\"001\"",     "Número o ID del terminal POS activo"),
        new("Shift",           "string",                "\"0001\"",    "Número de turno en curso"),
        new("Products",        "List<Product>",         "new()",       "Lista de productos para el buscador con debounce (280ms)"),
        new("OnMenuToggle",    "EventCallback",         "",            "Disparado al presionar el botón hamburguesa"),
        new("OnSoundConfig",   "EventCallback",         "",            "Disparado al presionar el botón de notificaciones de sonido"),
        new("OnProductSelect", "EventCallback<Product>","",            "Disparado cuando el usuario selecciona un resultado del buscador"),
    };
}
