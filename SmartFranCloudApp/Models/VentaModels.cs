namespace SmartFranCloudApp.Models;

// ── Producto del catálogo ──────────────────────────────────────────────────
public class Product
{
    public string  Id         { get; set; } = Guid.NewGuid().ToString("N")[..8];
    public string  Name     { get; set; } = string.Empty;
    public string  Category  { get; set; } = string.Empty;
    public decimal Price     { get; set; }
    public string  ImageUrl  { get; set; } = string.Empty;
    public bool    IsFavorite { get; set; }
}

// ── Item del carrito ───────────────────────────────────────────────────────
public class CartItemModel
{
    public string  Id        { get; set; } = string.Empty;
    public string  Name    { get; set; } = string.Empty;
    public decimal Price    { get; set; }
    public string  ImageUrl { get; set; } = string.Empty;
    public int     Quantity  { get; set; } = 1;
    public bool    IsRedemption   { get; set; }
    public int     RedemptionPoints { get; set; }

    public decimal Total => Price * Quantity;
}

// ── Socio del club ─────────────────────────────────────────────────────────
public class SocioModel
{
    public string Name       { get; set; } = string.Empty;
    public string Dni          { get; set; } = string.Empty;
    public int    Points       { get; set; }
    public string Level        { get; set; } = string.Empty;
    public int    Discount    { get; set; }
    public int    Progress     { get; set; }
    public string Favorite     { get; set; } = string.Empty;
    public string Birthday     { get; set; } = string.Empty;
    public string Loyalty      { get; set; } = string.Empty;
}

// ── Canje disponible ───────────────────────────────────────────────────────
public class RedemptionModel
{
    public string  Name  { get; set; } = string.Empty;
    public int     Points  { get; set; }
    public decimal Money  { get; set; }
}

// ── Categoría del catálogo ─────────────────────────────────────────────────
public class CategoryModel
{
    public string Name    { get; set; } = string.Empty;
    public string Icon     { get; set; } = string.Empty;
    public bool   IsMore   { get; set; }    // aparece en dropdown "Más"
    public string Group     { get; set; } = string.Empty; // para agrupar en "Más"
}

// ── Config de nivel del socio ──────────────────────────────────────────────
public class NivelConfig
{
    public string Color { get; set; } = "#6e59ee";
    public string Bg    { get; set; } = "#ebe8ff";
    public string Icon { get; set; } = "workspace_premium";

    public static NivelConfig Get(string nivel) => nivel switch
    {
        "Bronce"   => new() { Color="#b45309", Bg="#fef3c7", Icon="stars"              },
        "Silver"   => new() { Color="#475569", Bg="#f1f5f9", Icon="workspace_premium"  },
        "Gold"     => new() { Color="#d97706", Bg="#fffbeb", Icon="emoji_events"       },
        "Platinum" => new() { Color="#7c3aed", Bg="#f5f3ff", Icon="diamond"            },
        _          => new() { Color="#6e59ee", Bg="#ebe8ff", Icon="workspace_premium"  },
    };
}
