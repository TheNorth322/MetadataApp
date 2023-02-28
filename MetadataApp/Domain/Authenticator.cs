using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Security.Authentication;

namespace MetadataApp.Domain;

public class Authenticator
{
    private IDBConnection _dbConnection;

    public Authenticator(IDBConnection dbConnection)
    {
        _dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
    }

    public UserInfo LogIn(string login, string password)
    {
        UserInfo userInfo = _dbConnection.FindUserInfo(login);
        PasswordHash passwordHash = new PasswordHash();

        if (passwordHash.Verify(password, userInfo.PasswordHash))
            return userInfo; 
        
        throw new ApplicationException("Wrong login/password");
    }
}