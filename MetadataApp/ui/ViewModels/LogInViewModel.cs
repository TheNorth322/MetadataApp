using System;
using System.Windows;
using MetadataApp.Domain;
using MetadataApp.ui.Views;

namespace MetadataApp.ui.ViewModels;

public class LogInViewModel : ViewModelBase, ICloseWindow
{
    private string _login;

    private RelayCommand _logInCommand;
    private string _password;

    public string Login
    {
        get => _login;
        set
        {
            _login = value;
            OnPropertyChange(nameof(Login));
        }
    }

    public string Password
    {
        get => _password;
        set
        {
            _password = value;
            OnPropertyChange(nameof(Password));
        }
    }

    public RelayCommand LogInCommand
    {
        get
        {
            return _logInCommand ?? (_logInCommand = new RelayCommand(
                _execute => LogIn(),
                _canExecute => ValidateData()
            ));
        }
    }

    public Action Close { get; set; }

    private void LogIn()
    {
        try
        {
            Authentificator authentificator = new Authentificator(new FileDBConnection());
            UserInfo userInfo = authentificator.LogIn(Login, Password);
            ConfigurationParser configurationParser = new ConfigurationParser();

            OpenNewView(new MainView(new MainViewModel(configurationParser.Parse(userInfo.ConfigStream))));
            Close?.Invoke();
        }
        catch (Exception ex)
        {
            MessageBox_Show(null, ex.Message, "Возникла ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private bool ValidateData()
    {
        return true;
    }
}