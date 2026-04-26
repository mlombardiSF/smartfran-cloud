namespace SmartFranCloudApp.Models;

public class Franchise
{
    public int    Id        { get; set; }
    public string Name      { get; set; } = string.Empty;
    public string Address   { get; set; } = string.Empty;
    public string Code      { get; set; } = string.Empty;
    public bool   Active    { get; set; }
}

public class Terminal
{
    public string  Id           { get; set; } = string.Empty;
    public string  Name         { get; set; } = string.Empty;
    public string  Description  { get; set; } = string.Empty;
    public bool    Open         { get; set; }
    public string? Since        { get; set; }
    public int     FranchiseId  { get; set; }
}
