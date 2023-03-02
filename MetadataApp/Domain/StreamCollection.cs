using System.Collections.Generic;
using System.IO;
using System.Windows.Media;

namespace MetadataApp.Domain;

public class StreamCollection
{
    private List<Stream> Streams;

    public StreamCollection()
    {
        Streams = new List<Stream>();
    }

    public void Close()
    {
        foreach (Stream stream in Streams)
            if (stream != null)
                stream.Close();
    }

    public void Add(Stream stream)
    {
        Streams.Add(stream);
    }

    public void Delete(Stream stream)
    {
        if (stream != null)
            Streams.Remove(stream);
    }
}