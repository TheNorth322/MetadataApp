using System.IO;

namespace MetadataApp.Domain;

public interface IStreamInitializer
{
    StreamReader Initialize();
}