using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
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

        EventManager.RegisterClassHandler(typeof(Window), KeyDownEvent, new KeyEventHandler(MainKeyDown));
        languageText.Text = "Язык раскладки: " + Language.GetEquivalentCulture().DisplayName;
        capsLockPressed.Text = "Клавиша Caps Lock нажата";
        bool isCapsLockToggled = Keyboard.IsKeyToggled(Key.CapsLock);
        if (isCapsLockToggled)
            capsLockPressed.Text = "Клавиша Caps Lock нажата";
        else
            capsLockPressed.Text = "";
        InputLanguageManager.Current.InputLanguageChanged +=
               new InputLanguageEventHandler((sender, e) =>
               {
                   languageText.Text = "Язык раскладки: " + e.NewLanguage.DisplayName;
               });
    }

    private void ViewMessageBoxRequest(object sender, MessageBoxEventArgs e)
    {
        e.Show();
    }

    private void MainKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.CapsLock)
        {
            bool isCapsLockToggled = Keyboard.IsKeyToggled(Key.CapsLock);
            if (isCapsLockToggled)
                capsLockPressed.Text = "Клавиша Caps Lock нажата";
            else
                capsLockPressed.Text = "";
        }
    }

    private void OnClose(object sender, CancelEventArgs e)
    {
        Closing -= OnClose;
        (DataContext as ViewModelBase).MessageBoxRequest -= ViewMessageBoxRequest;
    } 
}