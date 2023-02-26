using System;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Security.Authentication;

namespace MetadataApp.Domain;

public class Authenticator
{
    public StreamReader LogIn(string login, string password)
    {
        IStreamInitializer streamInitializer = new FileStreamInitializer();
        StreamReader streamReader = streamInitializer.Initialize();
        PasswordHash passwordHash = new PasswordHash();

        while (streamReader.ReadLine() is { } line)
        {
            string[] userData = line.Split(' ');
            if (login == userData[0] && passwordHash.Verify(password, userData[1]))
            {
                if (!File.Exists(userData[2]))
                    throw new FileNotFoundException($"File {userData[2]} isn't found");
                return new StreamReader(new FileStream(userData[2], FileMode.Open));
            }
        }

        throw new ApplicationException("Wrong login/password");
    }
}