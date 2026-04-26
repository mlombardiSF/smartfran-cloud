using SmartFran.Docs.Shared;

namespace SmartFran.Docs.Pages.Components;

public partial class SfInputPage
{
    private string _email  = string.Empty;
    private string _nombre = string.Empty;
    private string _pass   = string.Empty;

    public static readonly string BasicCode =
@"<SfInput Label=""Email""
         Icon=""alternate_email""
         Placeholder=""usuario@empresa.com""
         @bind-Value=""_email"" />

<SfInput Label=""Nombre""
         Icon=""person""
         Placeholder=""Tu nombre completo""
         @bind-Value=""_nombre"" />

@code {
    private string _email  = string.Empty;
    private string _nombre = string.Empty;
}";

    public static readonly string PasswordCode =
@"<SfInput Label=""Contraseña""
         Icon=""lock""
         Type=""password""
         ShowToggle=""true""
         Placeholder=""Ingresá tu contraseña""
         @bind-Value=""_pass"" />

@code {
    private string _pass = string.Empty;
}";

    public static readonly string ErrorCode =
@"<SfInput Label=""Email""
         Icon=""alternate_email""
         HasError=""@_hasError""
         ErrorText=""El formato del email no es válido.""
         @bind-Value=""_email"" />

@code {
    private bool   _hasError = true;
    private string _email    = string.Empty;
}";

    public static readonly List<PropEntry> Props = new()
    {
        new("Value",        "string",               "\"\"",     "Valor del campo. Usar con @bind-Value para two-way binding"),
        new("ValueChanged", "EventCallback<string>","",         "Callback cuando cambia el valor"),
        new("Label",        "string",               "\"\"",     "Etiqueta visible sobre el campo"),
        new("Icon",         "string",               "\"\"",     "Ícono Material Symbols a la izquierda. Vacío para omitir"),
        new("Type",         "string",               "\"text\"", "Tipo HTML del input: text | password | email | number, etc."),
        new("Placeholder",  "string",               "\"\"",     "Texto placeholder"),
        new("AutoComplete", "string",               "\"off\"",  "Atributo HTML autocomplete"),
        new("ShowToggle",   "bool",                 "false",    "Botón ojo para alternar visibilidad (contraseñas)"),
        new("HasError",     "bool",                 "false",    "Activa el estado de error con borde rojo"),
        new("ErrorText",    "string",               "\"\"",     "Mensaje de error visible cuando HasError es true"),
        new("Disabled",     "bool",                 "false",    "Deshabilita el campo"),
    };
}
