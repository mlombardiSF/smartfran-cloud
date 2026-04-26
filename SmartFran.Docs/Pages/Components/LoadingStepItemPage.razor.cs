using SmartFran.Docs.Shared;

namespace SmartFran.Docs.Pages.Components;

public partial class LoadingStepItemPage
{
    public static readonly string StatesCode =
@"<LoadingStepItem Label=""Conectando con el servidor""     State=""LoadingStepItem.StepState.Pending"" />
<LoadingStepItem Label=""Cargando catálogo de productos"" State=""LoadingStepItem.StepState.Active"" />
<LoadingStepItem Label=""Verificando credenciales""       State=""LoadingStepItem.StepState.Completed"" />";

    public static readonly string SequenceCode =
@"<LoadingStepItem Label=""Verificando credenciales""       State=""LoadingStepItem.StepState.Completed"" />
<LoadingStepItem Label=""Conectando con SmartFran Cloud"" State=""LoadingStepItem.StepState.Completed"" />
<LoadingStepItem Label=""Cargando catálogo de productos"" State=""LoadingStepItem.StepState.Active"" />
<LoadingStepItem Label=""Sincronizando inventario""       State=""LoadingStepItem.StepState.Pending"" />
<LoadingStepItem Label=""Iniciando módulo de ventas""     State=""LoadingStepItem.StepState.Pending"" />

@code {
    // Actualizar el State de cada item según el avance real
}";

    public static readonly string EnumCode =
@"public enum StepState
{
    Pending,    // Paso aún no iniciado
    Active,     // Paso en curso (shimmer + dots animados)
    Completed   // Paso finalizado (ícono check teal + badge Listo)
}";

    public static readonly List<PropEntry> Props = new()
    {
        new("Label", "string", "\"\"",                       "Texto descriptivo del paso"),
        new("State", "StepState", "StepState.Pending",       "Estado visual: Pending | Active | Completed"),
    };
}
