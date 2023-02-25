using System;
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
        string hash = BitConverter.ToString(new PasswordHash(password).Hash);
        
        string line; 
        while ((line = streamReader.ReadLine()) != null)
        {
            string[] userData = line.Split(' ');
            if (login == userData[0] && hash == userData[1]) 
                return new StreamReader(new FileStream(userData[2], FileMode.Open));
        }

        throw new ApplicationException("User isn't found!");
    }
}