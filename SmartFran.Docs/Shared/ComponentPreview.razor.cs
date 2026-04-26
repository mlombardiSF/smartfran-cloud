using Microsoft.AspNetCore.Components;

namespace SmartFran.Docs.Shared;

public partial class ComponentPreview
{
    [Parameter] public string           Title           { get; set; } = string.Empty;
    [Parameter] public string           Description     { get; set; } = string.Empty;
    [Parameter] public string           Code            { get; set; } = string.Empty;
    [Parameter] public RenderFragment?  Preview         { get; set; }
    [Parameter] public bool             DarkBackground  { get; set; } = false;

    private string _tab = "preview";
}
