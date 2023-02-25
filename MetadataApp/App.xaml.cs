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
        MainWindow.Show();
        base.OnStartup(e);
    }
}