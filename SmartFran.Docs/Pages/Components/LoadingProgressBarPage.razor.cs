using SmartFran.Docs.Shared;

namespace SmartFran.Docs.Pages.Components;

public partial class LoadingProgressBarPage
{
    private int _pct = 65;

    public static readonly string StaticCode =
@"<LoadingProgressBar Percentage=""0"" />
<LoadingProgressBar Percentage=""45"" />
<LoadingProgressBar Percentage=""100"" />";

    public static readonly string InteractiveCode =
@"<LoadingProgressBar Percentage=""@_pct"" />

<input type=""range"" min=""0"" max=""100""
       @bind=""_pct"" @bind:event=""oninput"" />

@code {
    private int _pct = 65;
}";

    public static readonly List<PropEntry> Props = new()
    {
        new("Percentage", "int", "0", "Porcentaje completado (0–100). Controla el ancho del fill y el texto visible"),
    };
}
