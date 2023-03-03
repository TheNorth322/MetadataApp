namespace MetadataApp.Domain.Interfaces;

public interface IAutentificator
{
    UserInfo LogIn(string login, string password);
}