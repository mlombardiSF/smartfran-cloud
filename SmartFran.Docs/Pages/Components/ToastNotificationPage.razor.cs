using SmartFran.Docs.Shared;

namespace SmartFran.Docs.Pages.Components;

public partial class ToastNotificationPage
{
    private bool   _toastVisible  = false;
    private string _toastTitle    = string.Empty;
    private string _toastSubtitle = string.Empty;

    private void ShowNewOrder()
    {
        _toastTitle    = "Nuevo Pedido Recibido";
        _toastSubtitle = "Pedido #1042 — delivery — $2.350";
        _toastVisible  = true;
        StateHasChanged();
        Task.Delay(5000).ContinueWith(_ => InvokeAsync(() =>
        {
            _toastVisible = false;
            StateHasChanged();
        }));
    }

    private void ShowSync()
    {
        _toastTitle    = "Sincronización completada";
        _toastSubtitle = "Catálogo actualizado · 3 productos nuevos";
        _toastVisible  = true;
        StateHasChanged();
        Task.Delay(5000).ContinueWith(_ => InvokeAsync(() =>
        {
            _toastVisible = false;
            StateHasChanged();
        }));
    }

    public static readonly string BasicCode =
@"<ToastNotification IsVisible=""@_show""
                   Title=""Nuevo Pedido Recibido""
                   Subtitle=""Pedido #1042 — delivery — $2.350""
                   OnClose=""() => _show = false"" />

@code {
    private bool _show = false;

    private void NotifyNewOrder() {
        _show = true;
        // auto-hide a los 5 segundos
        Task.Delay(5000).ContinueWith(_ => InvokeAsync(() => {
            _show = false;
            StateHasChanged();
        }));
    }
}";

    public static readonly List<PropEntry> Props = new()
    {
        new("IsVisible", "bool",          "false", "Muestra el toast y activa la animación de la barra de progreso"),
        new("Title",     "string",        "\"\"",  "Título principal del toast"),
        new("Subtitle",  "string",        "\"\"",  "Texto secundario con detalle adicional"),
        new("OnClose",   "EventCallback", "",      "Disparado al presionar el botón X del toast"),
    };
}
