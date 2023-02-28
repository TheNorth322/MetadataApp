using System;
using System.Formats.Asn1;

namespace MetadataApp.ui.ViewModels;

public struct Handler
{
    public string Tag { get; set; }
    public Action<string> Func;
    
    public Handler(string tag, Action<string> func)
    {
        Tag = tag;
        Func = func;
    }
}