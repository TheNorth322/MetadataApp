﻿using System;
using System.IO;
using System.Windows;
using MetadataApp.Domain;
using MetadataApp.ui.Views;

namespace MetadataApp.ui.ViewModels;

public class LogInViewModel : ViewModelBase , ICloseWindow
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

    private void LogIn()
    {
        try
        {
            Authenticator authenticator = new Authenticator();
            StreamReader streamReader = authenticator.LogIn(Login, Password);
            ConfigurationParser configurationParser = new ConfigurationParser();
            OpenNewView(new MainView(new MainViewModel(configurationParser.Parse(streamReader))));
            
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

    public Action Close { get; set; }
}