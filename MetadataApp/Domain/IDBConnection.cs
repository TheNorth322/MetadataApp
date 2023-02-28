namespace MetadataApp.Domain;

public interface IDBConnection
{
    UserInfo FindUserInfo(string login);
}