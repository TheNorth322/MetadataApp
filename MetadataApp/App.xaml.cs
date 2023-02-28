using System.Windows;
using MetadataApp.ui.ViewModels;

namespace MetadataApp;

/// <summary>
///     Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        MainWindow = new LogInView();
        (MainWindow.DataContext as ViewModelBase).OpenNewWindow += OpenNewView;
        MainWindow.Show();
        base.OnStartup(e);
    }

    private void OpenNewView(object sender, OpenViewEventArgs e)
    {
        e.Show();
    }
}