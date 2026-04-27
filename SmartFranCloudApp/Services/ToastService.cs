namespace SmartFranCloudApp.Services;

public class ToastService
{
    public record ToastEntry(
        Guid   Id,
        string Icon,
        string Title,
        string Subtitle,
        string AccentGradient,
        string PulseColor,
        int    DurationMs);

    private readonly List<ToastEntry> _items = new();
    public IReadOnlyList<ToastEntry> Items => _items.AsReadOnly();

    public event Action? OnChanged;

    public void Show(string type, string? subtitle = null)
    {
        var entry = type switch
        {
            "venta"       => new ToastEntry(Guid.NewGuid(), "point_of_sale",  "Venta procesada",            "La venta fue registrada correctamente en el sistema.", "linear-gradient(135deg,#6e59ee,#9080f5)", "#9080f5", 4000),
            "ticket"      => new ToastEntry(Guid.NewGuid(), "receipt",         "Ticket impreso",              "El ticket de venta fue enviado a la impresora.",        "linear-gradient(135deg,#006267,#009da4)", "#009da4", 4500),
            "comprobante" => new ToastEntry(Guid.NewGuid(), "mark_email_read", "Comprobante electrónico",     "El comprobante fue generado y enviado al cliente.",      "linear-gradient(135deg,#4b3e73,#63568c)", "#63568c", 5000),
            "turno"       => new ToastEntry(Guid.NewGuid(), "schedule",        "Turno aperturado",            "El turno fue iniciado correctamente.",                   "linear-gradient(135deg,#1a6b3a,#2ea855)", "#2ea855", 4600),
            _             => null
        };
        if (entry is null) return;
        if (subtitle is not null) entry = entry with { Subtitle = subtitle };
        _items.Add(entry);
        OnChanged?.Invoke();
        _ = Task.Delay(entry.DurationMs).ContinueWith(_ => Dismiss(entry.Id));
    }

    public void Dismiss(Guid id)
    {
        _items.RemoveAll(t => t.Id == id);
        OnChanged?.Invoke();
    }
}
