using SmartFran.Components.Models;
using SmartFran.Docs.Shared;

namespace SmartFran.Docs.Pages.Components;

public partial class CounterRowPage
{
    private string _selectedId = string.Empty;

    public static readonly Terminal TerminalOpen = new()
    {
        Id = "T001", Name = "Mostrador 1", Description = "Caja principal",
        Open = true, Since = "08:30", FranchiseId = 1
    };

    public static readonly Terminal TerminalClosed = new()
    {
        Id = "T002", Name = "Mostrador 2", Description = "Caja secundaria",
        Open = false, FranchiseId = 1
    };

    public static readonly List<Terminal> SampleTerminals = new()
    {
        new() { Id="T001", Name="Mostrador 1", Description="Caja principal",   Open=true,  Since="08:30", FranchiseId=1 },
        new() { Id="T002", Name="Mostrador 2", Description="Caja secundaria",  Open=true,  Since="09:15", FranchiseId=1 },
        new() { Id="T003", Name="Mostrador 3", Description="Caja de apoyo",    Open=false, FranchiseId=1 },
    };

    public static readonly string StatesCode =
@"@* Abierto *@
<CounterRow Terminal=""@_terminal"" IsSelected=""false"" />

@* Seleccionado *@
<CounterRow Terminal=""@_terminal"" IsSelected=""true"" />

@* Cerrado *@
<CounterRow Terminal=""@_closedTerminal"" IsSelected=""false"" />";

    public static readonly string SelectableCode =
@"@foreach (var t in _terminals) {
    var term = t;
    <CounterRow Terminal=""@term""
                IsSelected=""@(_selected?.Id == term.Id)""
                OnClick=""t2 => _selected = t2"" />
}

@code {
    private Terminal? _selected;
    private List<Terminal> _terminals = new() { /* ... */ };
}";

    public static readonly string TerminalModelCode =
@"public class Terminal
{
    public string  Id          { get; set; } = string.Empty;
    public string  Name        { get; set; } = string.Empty;
    public string  Description { get; set; } = string.Empty;
    public bool    Open        { get; set; }
    public string? Since       { get; set; }   // Hora de apertura
    public int     FranchiseId { get; set; }
}";

    public static readonly List<PropEntry> Props = new()
    {
        new("Terminal",   "Terminal",            "new Terminal()", "Objeto con los datos del mostrador"),
        new("IsSelected", "bool",                "false",          "Muestra el borde de selección activo"),
        new("OnClick",    "EventCallback<Terminal>", "",           "Se dispara al hacer click. Emite el objeto Terminal completo"),
    };
}
