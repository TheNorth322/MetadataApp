using System;
using System.IO;
using System.Linq;
using System.Text;
using MetadataApp.Domain.Interfaces;

namespace MetadataApp.Domain;

public class FileDBConnection : IDBConnection
{
    private readonly string path = "database_path.txt";
    private StreamCollection _streams;
    public FileDBConnection(StreamCollection streams)
    {
        _streams = streams;
    }
    public UserInfo FindUserInfo(string login)
    {
        FileStream fileStream = InitializeDatabase();
        StreamReader streamReader = new StreamReader(fileStream, Encoding.UTF8);
        UserInfoValidator userInfoValidator = new UserInfoValidator();

        while (streamReader.ReadLine() is { } line)
        {
            string[] userData = line.Split(' ');
            userInfoValidator.Validate(userData);
            
            if (login != userData[0])
                continue;

            if (!File.Exists(userData[2]))
                throw new FileNotFoundException($"File {userData[2]} isn't found");

            FileStream configStream = new FileStream(userData[2], FileMode.Open);
            _streams.Add(configStream);
            fileStream.Close();
            return new UserInfo(userData[0], userData[1], configStream);
        }

        fileStream.Close();
        throw new ApplicationException("Wrong login/password");
    }

    private FileStream InitializeDatabase()
    {
        string _path = File.ReadLines(path).First();
        FileStream databaseStream = new FileStream(_path, FileMode.Open);
        
        _streams.Add(databaseStream);
        
        return databaseStream;
    }
}