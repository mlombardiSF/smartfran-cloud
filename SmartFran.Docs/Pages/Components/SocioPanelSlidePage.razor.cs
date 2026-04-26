using SmartFran.Components.Services;
using SmartFran.Docs.Shared;
using Microsoft.AspNetCore.Components;

namespace SmartFran.Docs.Pages.Components;

public partial class SocioPanelSlidePage
{
    [Inject] private CartService CartService { get; set; } = default!;

    private bool _open = false;

    public static readonly string BasicCode =
@"@inject CartService Cart

<SocioPanelSlide IsOpen=""@_open"" OnClose=""() => _open = false"" />

@code {
    private bool _open = false;

    // Abrirlo al hacer click en el socio del CartPanel:
    // OnOpenSocioPanel=""() => _open = true""
}";

    public static readonly List<PropEntry> Props = new()
    {
        new("IsOpen",          "bool",          "false", "Controla si el panel está visible (slide-in desde la derecha)"),
        new("OnClose",         "EventCallback", "",      "Disparado al presionar el botón X del panel"),
        new("CartService (DI)","CartService",   "",      "Singleton inyectado. Provee SocioActive, canjes disponibles y AvailablePoints"),
    };
}
