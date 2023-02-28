using System.Windows;
using MetadataApp.ui.ViewModels;

namespace MetadataApp;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class LogInView : Window
{
    public LogInView()
    {
        InitializeComponent();
        Loaded += ViewLoaded;
        DataContext = new LogInViewModel();
        (DataContext as LogInViewModel).MessageBoxRequest +=
            ViewMessageBoxRequest;
    }

    private void ViewMessageBoxRequest(object sender, MessageBoxEventArgs e)
    {
        e.Show();
    }

    private void ViewLoaded(object sender, RoutedEventArgs e)
    {
        if (DataContext is ICloseWindow vm) vm.Close += () => { Close(); };
    }
}