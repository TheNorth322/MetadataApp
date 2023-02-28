using System;
using MetadataApp.Domain.Interfaces;

namespace MetadataApp.Domain;

public class Authentificator : IAutentificator
{
    private readonly IDBConnection _dbConnection;

    public Authentificator(IDBConnection dbConnection)
    {
        _dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
    }

    public UserInfo LogIn(string login, string password)
    {
        var userInfo = _dbConnection.FindUserInfo(login);
        var passwordHash = new PasswordHash();

        if (passwordHash.Verify(password, userInfo.PasswordHash))
            return userInfo;

        throw new ApplicationException("Wrong login/password");
    }
}