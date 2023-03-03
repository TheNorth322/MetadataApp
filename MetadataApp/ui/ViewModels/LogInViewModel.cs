using System;
using System.Reflection;
using System.Windows;
using MetadataApp.Domain;
using MetadataApp.ui.Views;
using StreamCollectionLib;

namespace MetadataApp.ui.ViewModels;

public class LogInViewModel : ViewModelBase
{
    private string _login;

    private RelayCommand _logInCommand;
    private string _password;

    private StreamCollection _streams;

    public LogInViewModel()
    {
        if (Assembly.Load("Authentification") == null)
            throw new DllNotFoundException("Authentification dll isn't found.");

        _streams = new StreamCollection();
    }

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

    private void LogIn()
    {
        try
        {
            Authentificator authentificator = new Authentificator(new FileDBConnection(_streams));
            UserInfo userInfo = authentificator.LogIn(Login, Password);
            ConfigurationParser configurationParser = new ConfigurationParser(_streams);

            OpenNewView(new MainView(new MainViewModel(configurationParser.Parse(userInfo.ConfigStream))));
            Close?.Invoke();
        }
        catch (Exception ex)
        {
            _streams.Close();
            MessageBox_Show(null, ex.Message, "Возникла ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private bool ValidateData()
    {
        //return !(String.IsNullOrEmpty(Login) || String.IsNullOrEmpty(Password));
        return true;
    }
}