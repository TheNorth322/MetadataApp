using System;
using System.IO;
using System.Linq;
using System.Text;

namespace MetadataApp.Domain;

public class FileDBConnection : IDBConnection
{
    private readonly string path = "database_path.txt";

    private FileStream InitializeDatabase()
    {
        string path = File.ReadLines("database_path.txt").First();
        return new FileStream(path, FileMode.Open);
    }

    public UserInfo FindUserInfo(string login)
    {
        FileStream fileStream = InitializeDatabase();
        StreamReader streamReader = new StreamReader(fileStream, Encoding.UTF8);

        while (streamReader.ReadLine() is { } line)
        {
            string[] userData = line.Split(' ');
            if (login != userData[0]) continue;

            if (!File.Exists(userData[2]))
                throw new FileNotFoundException($"File {userData[2]} isn't found");

            FileStream configStream = new FileStream(userData[2], FileMode.Open);
            
            fileStream.Close();
            return new UserInfo(userData[0], userData[1], configStream);
        }

        fileStream.Close();
        throw new ApplicationException("Wrong login/password");
    }
}