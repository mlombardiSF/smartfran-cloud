using SmartFran.Components.POS.Venta;
using SmartFran.Docs.Shared;

namespace SmartFran.Docs.Pages.Components;

public partial class OrdersButtonPage
{
    private OrdersButton? _ordersBtn;
    private int _pendingCount = 2;

    private void SimulateNewOrder()
    {
        _pendingCount++;
        _ordersBtn?.NotifyNewOrders();
    }

    public static readonly string BadgeCode =
@"<OrdersButton PendingOrders=""0"" />
<OrdersButton PendingOrders=""3"" />
<OrdersButton PendingOrders=""12"" />";

    public static readonly string NotifyCode =
@"<OrdersButton @ref=""_btn"" PendingOrders=""@_count"" OnClick=""HandleOrdersClick"" />

@code {
    private OrdersButton? _btn;
    private int _count = 0;

    // Llamar cuando llegue un pedido nuevo (ej: SignalR)
    private void OnNewOrderReceived() {
        _count++;
        _btn?.NotifyNewOrders();  // activa pulso por 700ms
    }

    private void HandleOrdersClick() {
        // abrir panel de pedidos
    }
}";

    public static readonly List<PropEntry> Props = new()
    {
        new("PendingOrders",    "int",           "0",  "Número de pedidos pendientes. Se muestra en el badge"),
        new("OnClick",          "EventCallback", "",   "Disparado al hacer click en el botón"),
        new("NotifyNewOrders()", "—",            "—",  "Método público. Activa la animación de pulso por 700ms. Llamar via @ref"),
    };
}
