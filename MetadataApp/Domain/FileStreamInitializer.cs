using System.IO;
using System.Linq;
using System.Text;

namespace MetadataApp.Domain;

public class FileStreamInitializer : IStreamInitializer
{
    public StreamReader Initialize()
    {
        string path = File.ReadLines("database_path.txt").First();
        return new StreamReader(new FileStream(path, FileMode.Open), Encoding.UTF8);
    }
}
