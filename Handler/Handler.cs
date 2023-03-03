using System;

namespace HandlerLib;

public struct Handler
{
    public string Tag { get; }
    public Action<string> Func;

    public Handler(string tag, Action<string> func)
    {
        Tag = tag;
        Func = func;
    }
}