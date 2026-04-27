namespace SmartFranCloudApp.Models;

// ── Producto del catálogo ──────────────────────────────────────────────────
public class Product
{
    public string       Id         { get; set; } = Guid.NewGuid().ToString("N")[..8];
    public string       Name       { get; set; } = string.Empty;
    public string       Category   { get; set; } = string.Empty;
    public decimal      Price      { get; set; }
    public string       ImageUrl   { get; set; } = string.Empty;
    public bool         IsFavorite { get; set; }
    public List<string> Tags       { get; set; } = new();
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

// ── Kanban de pedidos ──────────────────────────────────────────────────────
public enum KanbanOrderStatus { Nuevo, Preparacion, Listo, Finalizado }

public class KanbanOrder
{
    public string Key          { get; set; } = Guid.NewGuid().ToString("N")[..6];
    public string Id           { get; set; } = "";
    public string Platform     { get; set; } = "";
    public string ClientName   { get; set; } = "";
    public string ClientPhone  { get; set; } = "";
    public KanbanOrderStatus Status { get; set; }
    public string? TimerLabel  { get; set; }
    public bool   TimerPulse   { get; set; }
    public string DeliveryType { get; set; } = "";
    public string DeliveryIcon { get; set; } = "delivery_dining";
    public string Address      { get; set; } = "";
    public string? Note        { get; set; }
    public List<KanbanOrderItem> Items { get; set; } = new();
    public decimal Discount    { get; set; }
    public decimal Shipping    { get; set; }

    public decimal Subtotal => Items.Sum(i => i.Price * i.Qty);
    public decimal Total    => Subtotal - Discount + Shipping;
}

public class KanbanOrderItem
{
    public int     Qty   { get; set; }
    public string  Name  { get; set; } = "";
    public decimal Price { get; set; }
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
