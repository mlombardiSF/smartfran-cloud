using SmartFranCloudApp.Models;

namespace SmartFranCloudApp.Services;

public class UserService
{
    private static readonly Dictionary<string, (string FullName, string AvatarImage, string Password)> _registry = new()
    {
        ["mariob@smartfran.com"]   = ("Mario Bernasconi", "mariob-user.webp",   "1234"),
        ["matiasl@smartfran.com"]  = ("Matias Lombardi",  "matiasl-user.webp",  "1234"),
        ["gonzalop@smartfran.com"] = ("Gonzalo Paez",     "gonzalop-user.webp", "1234"),
        ["fernandaz@smartfran.com"] = ("Fernanda Zaniboni", "fernandaz-user.webp", "1234"),
        ["pablom@smartfran.com"] = ("Pablo Marinangeli", "pablom-user.webp", "1234"),
        ["macarenag@smartfran.com"] = ("Macarena Gonzales", "macarenag-user.webp", "1234"),
        ["leonardoo@smartfran.com"] = ("Leonardo Ortigoza", "leonardoo-user.webp", "1234"),
    };

    public static readonly UserModel Guest = new("", "Usuario Invitado", null);

    public UserModel CurrentUser { get; private set; } = Guest;

    public event Action? OnChanged;

    public void Login(string email, string password)
    {
        var key = email.Trim().ToLower();
        CurrentUser = _registry.TryGetValue(key, out var data) && data.Password == password
            ? new UserModel(email, data.FullName, data.AvatarImage)
            : Guest;
        OnChanged?.Invoke();
    }

    public void Logout()
    {
        CurrentUser = Guest;
        OnChanged?.Invoke();
    }
}
