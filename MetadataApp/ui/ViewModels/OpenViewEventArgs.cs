using System.Windows;

namespace MetadataApp.ui.ViewModels;

public class OpenViewEventArgs
{
    private readonly Window _view;

    public OpenViewEventArgs(Window view)
    {
        _view = view;
    }

    public void Show()
    {
        _view.Show();
    }
}