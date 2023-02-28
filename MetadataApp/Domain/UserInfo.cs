using System;
using System.IO;

namespace MetadataApp.Domain;

public class UserInfo
{
    public UserInfo(string login, string passwordHash, Stream configStream)
    {
        if (string.IsNullOrEmpty(login)) throw new ArgumentException(nameof(login));
        Login = login;

        if (string.IsNullOrEmpty(passwordHash)) throw new ArgumentException(nameof(passwordHash));
        PasswordHash = passwordHash;

        if (configStream == null) throw new ArgumentNullException(nameof(configStream));
        ConfigStream = configStream;
    }

    public string Login { get; }
    public string PasswordHash { get; }
    public Stream ConfigStream { get; }
}