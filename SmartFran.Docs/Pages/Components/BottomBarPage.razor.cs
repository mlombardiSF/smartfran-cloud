using SmartFran.Docs.Shared;

namespace SmartFran.Docs.Pages.Components;

public partial class BottomBarPage
{
    public static readonly string BasicCode =
@"<BottomBar />";

    public static readonly List<PropEntry> Props = new()
    {
        new("—", "—", "—", "Componente sin parámetros. El contenido (versión, sync, botones) es estático"),
    };
}
