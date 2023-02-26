using System;

namespace MetadataApp.ui.ViewModels;

public interface IOpenNewWindow
{
    event EventHandler<MessageBoxEventArgs> OpenNewWindow;
}