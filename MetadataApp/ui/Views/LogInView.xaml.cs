using System.ComponentModel;
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
        
        Closing += OnClose;
        DataContext = new LogInViewModel();
        (DataContext as ViewModelBase).Close += () => { Close(); };
        (DataContext as ViewModelBase).MessageBoxRequest +=
            ViewMessageBoxRequest;
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