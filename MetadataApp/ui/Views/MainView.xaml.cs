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
        InitializeComponent();
        (DataContext as MainViewModel).MessageBoxRequest +=
            ViewMessageBoxRequest;
    }

    private void ViewMessageBoxRequest(object sender, MessageBoxEventArgs e)
    {
        e.Show();
    }
}