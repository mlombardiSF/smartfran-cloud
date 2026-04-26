using SmartFran.Docs.Shared;

namespace SmartFran.Docs.Pages.Components;

public partial class ShiftModalPage
{
    private bool   _visible = false;
    private string _result  = string.Empty;

    private void HandleConfirmDemo()
    {
        _visible = false;
        _result  = "Turno aperturado en Mostrador 2";
    }

    public static readonly string BasicCode =
@"<SfButton OnClick=""() => _visible = true"">Abrir Modal</SfButton>

<ShiftModal IsVisible=""@_visible""
            CounterName=""Mostrador 2""
            OnCancel=""() => _visible = false""
            OnConfirm=""HandleConfirm"" />

@code {
    private bool _visible = false;

    private void HandleConfirm() {
        _visible = false;
        // lógica de apertura de turno
    }
}";

    public static readonly List<PropEntry> Props = new()
    {
        new("IsVisible",   "bool",          "false", "Controla si el modal y su overlay son visibles"),
        new("CounterName", "string",        "\"\"",  "Nombre del mostrador que se mostrará en el mensaje de confirmación"),
        new("OnCancel",    "EventCallback", "",      "Disparado al presionar Cancelar o al hacer click en el overlay"),
        new("OnConfirm",   "EventCallback", "",      "Disparado al presionar el botón Aperturar Turno"),
    };
}
