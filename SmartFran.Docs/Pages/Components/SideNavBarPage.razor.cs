using SmartFran.Docs.Shared;

namespace SmartFran.Docs.Pages.Components;

public partial class SideNavBarPage
{
    private bool _open = false;

    public static readonly string ToggleCode =
@"<SideNavBar IsOpen=""@_open"" OnClose=""() => _open = false"" />

<button @onclick=""() => _open = true"">Abrir SideNavBar</button>

@code {
    private bool _open = false;
}";

    public static readonly List<PropEntry> Props = new()
    {
        new("IsOpen",  "bool",            "false", "Controla si el drawer está visible. Al abrir, muestra overlay de cierre"),
        new("OnClose", "EventCallback",   "",      "Se dispara al presionar el botón X o al hacer click en el overlay"),
    };
}
