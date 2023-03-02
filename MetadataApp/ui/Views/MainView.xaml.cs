using System.ComponentModel;
using System.Windows;
using MetadataApp.ui.ViewModels;

namespace MetadataApp.ui.Views;

public partial class MainView : Window
{
    public MainView()
    {
        InitializeComponent();
    }

    public MainView(MainViewModel vm)
    {
        DataContext = vm;
        Closing += OnClose;
        (DataContext as ViewModelBase).MessageBoxRequest +=
            ViewMessageBoxRequest;
        InitializeComponent();
    }

    private void ViewMessageBoxRequest(object sender, MessageBoxEventArgs e)
    {
        e.Show();
    }

    private void OnClose(object sender, CancelEventArgs e)
    {
        Closing -= OnClose;
        (DataContext as ViewModelBase).MessageBoxRequest -= ViewMessageBoxRequest;
    }
}