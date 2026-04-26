using SmartFran.Components.Models;
using SmartFran.Components.Services;
using SmartFran.Docs.Shared;
using Microsoft.AspNetCore.Components;

namespace SmartFran.Docs.Pages.Components;

public partial class CartPanelPage
{
    [Inject] private CartService CartService { get; set; } = default!;

    public static readonly List<Product> DemoProducts = new()
    {
        new() { Id="p1", Name="Cucurucho",      Category="Helados", Price=950,  ImageUrl="/assets/images/products/cucurucho.png"     },
        new() { Id="p2", Name="Palito Bombón",  Category="Palitos", Price=680,  ImageUrl="/assets/images/products/palito-bombon.png" },
        new() { Id="p3", Name="Sundae Frutal",  Category="Sundaes", Price=1200, ImageUrl="/assets/images/products/sundae-frutal.png" },
        new() { Id="p4", Name="Gigante 2B",     Category="Helados", Price=1850, ImageUrl="/assets/images/products/gigante-2b.png"    },
    };

    public static readonly string BasicCode =
@"@inject CartService Cart

<CartPanel OnConfirmPayment=""HandlePayment""
           OnOpenSocioPanel=""() => _socioOpen = true""
           OnSocioCleared=""HandleSocioCleared"" />

@code {
    private bool _socioOpen = false;

    private void HandlePayment() {
        // procesar pago
    }

    private void HandleSocioCleared() {
        _socioOpen = false;
    }
}";

    public static readonly List<PropEntry> Props = new()
    {
        new("OnConfirmPayment", "EventCallback", "", "Disparado al presionar CONFIRMAR PAGO (solo habilitado si hay items)"),
        new("OnOpenSocioPanel", "EventCallback", "", "Disparado al hacer click en el área del socio cargado"),
        new("OnSocioCleared",   "EventCallback", "", "Disparado cuando el operador quita al socio activo del carrito"),
        new("CartService (DI)", "CartService",   "", "Singleton inyectado automáticamente. Registrar en Program.cs: builder.Services.AddSingleton<CartService>()"),
    };
}
