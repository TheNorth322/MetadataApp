using System;
using System.IO;

namespace MetadataApp.Domain;

public class UserInfo
{
    public string Login { get; }
    public string PasswordHash { get; }
    public Stream ConfigStream { get; }

    public UserInfo(string login, string passwordHash, Stream configStream)
    {
        if (String.IsNullOrEmpty(login)) throw new ArgumentException(nameof(login));
        Login = login;
        
        if (String.IsNullOrEmpty(passwordHash)) throw new ArgumentException(nameof(passwordHash));
        PasswordHash = passwordHash;
        
        if (configStream == null) throw new ArgumentNullException(nameof(configStream));
        ConfigStream = configStream;
    }
}