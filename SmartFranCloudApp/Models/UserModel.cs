namespace SmartFranCloudApp.Models;

public record UserModel(string Email, string FullName, string? AvatarImage)
{
    public string FirstName  => FullName.Split(' ')[0];
    public string AvatarPath => AvatarImage is not null
        ? $"assets/images/profiles/{AvatarImage}"
        : "assets/images/profiles/perfil-user.png";
}
