using SmartFran.Docs.Shared;

namespace SmartFran.Docs.Pages.Components;

public partial class TopNavBarPage
{
    public static readonly string DefaultCode =
@"<TopNavBar />";

    public static readonly string UserCode =
@"<TopNavBar UserName=""Marina Rossi"" />";

    public static readonly List<PropEntry> Props = new()
    {
        new("UserName", "string", "\"Usuario\"", "Nombre del usuario autenticado. Se muestra en el header y como inicial del avatar"),
    };
}
