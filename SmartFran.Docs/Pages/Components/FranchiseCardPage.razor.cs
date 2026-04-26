using SmartFran.Components.Models;
using SmartFran.Docs.Shared;

namespace SmartFran.Docs.Pages.Components;

public partial class FranchiseCardPage
{
    private int _selectedId = 0;

    public static readonly Franchise FranchiseA = new()
    {
        Id = 1, Name = "SmartFran Centro", Address = "Av. Corrientes 1234, CABA",
        Code = "SF-001", Active = true
    };

    public static readonly Franchise FranchiseInactive = new()
    {
        Id = 99, Name = "SmartFran Norte", Address = "Av. Cabildo 890, CABA",
        Code = "SF-099", Active = false
    };

    public static readonly List<Franchise> SampleFranchises = new()
    {
        new() { Id=1, Name="SmartFran Centro",  Address="Av. Corrientes 1234, CABA", Code="SF-001", Active=true  },
        new() { Id=2, Name="SmartFran Palermo",  Address="Thames 678, CABA",          Code="SF-002", Active=true  },
        new() { Id=3, Name="SmartFran Belgrano", Address="Cabildo 890, CABA",         Code="SF-003", Active=true  },
    };

    public static readonly string StatesCode =
@"@* No seleccionada *@
<FranchiseCard Franchise=""@_franchise"" IsSelected=""false"" />

@* Seleccionada *@
<FranchiseCard Franchise=""@_franchise"" IsSelected=""true"" />

@* Franquicia inactiva *@
<FranchiseCard Franchise=""@_inactiveFranchise"" IsSelected=""false"" />";

    public static readonly string SelectableCode =
@"@foreach (var f in _franchises) {
    var franchise = f;
    <FranchiseCard Franchise=""@franchise""
                   IsSelected=""@(_selectedId == franchise.Id)""
                   OnSelect=""id => _selectedId = id"" />
}

@code {
    private int _selectedId = 0;
    private List<Franchise> _franchises = new() { /* ... */ };
}";

    public static readonly string FranchiseModelCode =
@"public class Franchise
{
    public int    Id      { get; set; }
    public string Name    { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Code    { get; set; } = string.Empty;
    public bool   Active  { get; set; }
}";

    public static readonly List<PropEntry> Props = new()
    {
        new("Franchise",  "Franchise",       "new Franchise()", "Objeto con los datos de la franquicia"),
        new("IsSelected", "bool",            "false",           "Activa el ícono check y el borde de selección"),
        new("OnSelect",   "EventCallback<int>", "",             "Se dispara al hacer click. Emite el Id de la franquicia"),
    };
}
