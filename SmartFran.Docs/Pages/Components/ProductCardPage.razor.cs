using SmartFran.Components.Models;
using SmartFran.Docs.Shared;

namespace SmartFran.Docs.Pages.Components;

public partial class ProductCardPage
{
    private Product? _lastAdded = null;

    private void HandleAdd(Product p)
    {
        _lastAdded = p;
        StateHasChanged();
        Task.Delay(2500).ContinueWith(_ => InvokeAsync(() =>
        {
            _lastAdded = null;
            StateHasChanged();
        }));
    }

    public static readonly Product SampleProduct = new()
    {
        Id       = "p001",
        Name     = "Gigante 2 Bochas",
        Category = "Helados",
        Price    = 1850,
        ImageUrl = "/assets/images/products/gigante-2b.png",
    };

    public static readonly List<Product> GridProducts = new()
    {
        new() { Id="p1", Name="Cucurucho",       Category="Helados",  Price=950,  ImageUrl="/assets/images/products/cucurucho.png"      },
        new() { Id="p2", Name="Palito Bombón",    Category="Palitos",  Price=680,  ImageUrl="/assets/images/products/palito-bombon.png"  },
        new() { Id="p3", Name="Sundae Frutal",    Category="Sundaes",  Price=1200, ImageUrl="/assets/images/products/sundae-frutal.png"  },
        new() { Id="p4", Name="Tacita 2 Bochas",  Category="Helados",  Price=1100, ImageUrl="/assets/images/products/tacita-2b.png"      },
        new() { Id="p5", Name="Gigante 3 Bochas", Category="Helados",  Price=1650, ImageUrl="/assets/images/products/gigante-3b.png"     },
        new() { Id="p6", Name="Crocantino",       Category="Palitos",  Price=720,  ImageUrl="/assets/images/products/crocantino.png"     },
    };

    public static readonly string SingleCode =
@"<ProductCard Product=""@_product"" OnAdd=""HandleAdd"" />

@code {
    private Product _product = new() {
        Id       = ""p001"",
        Name     = ""Gigante 2 Bochas"",
        Category = ""Helados"",
        Price    = 1850,
        ImageUrl = ""/assets/images/gigante.png"",
    };

    private void HandleAdd(Product p) {
        // agregar al carrito, mostrar feedback, etc.
    }
}";

    public static readonly string GridCode =
@"<div style=""display:grid;
            grid-template-columns:repeat(auto-fill,minmax(160px,1fr));
            gap:1rem;"">
    @foreach (var product in _products) {
        var p = product;
        <ProductCard Product=""@p"" OnAdd=""HandleAdd"" />
    }
</div>

@code {
    private List<Product> _products = new() { /* ... */ };

    private void HandleAdd(Product p)
        => CartService.AddProduct(p);
}";

    public static readonly string ProductModelCode =
@"public class Product
{
    public string  Id        { get; set; } = Guid.NewGuid().ToString(""N"")[..8];
    public string  Name      { get; set; } = string.Empty;
    public string  Category  { get; set; } = string.Empty;
    public decimal Price     { get; set; }
    public string  ImageUrl  { get; set; } = string.Empty;
    public bool    IsFavorite { get; set; }
}";

    public static readonly List<PropEntry> Props = new()
    {
        new("Product", "Product",               "new Product()", "Objeto con los datos del producto a mostrar"),
        new("OnAdd",   "EventCallback<Product>","",              "Se dispara cuando el usuario hace click en + o en la tarjeta"),
    };
}
