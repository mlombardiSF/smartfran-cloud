using Microsoft.AspNetCore.Components;

namespace SmartFran.Docs.Shared;

public partial class PropsTable
{
    [Parameter] public List<PropEntry> Props { get; set; } = new();
}

public record PropEntry(
    string Name,
    string Type,
    string Default,
    string Description
);
