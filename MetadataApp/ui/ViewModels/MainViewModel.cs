using System;
using System.Collections.ObjectModel;
using MetadataApp.ui.Views;

namespace MetadataApp.ui.ViewModels;

public class MainViewModel : ViewModelBase
{
    public ObservableCollection<MenuItemViewModel> MenuItems { get; set; }
    
    public MainViewModel(ObservableCollection<MenuItemViewModel> menuItemViewModels)
    {
        MenuItems = menuItemViewModels;
        /*foreach (MenuItemViewModel vm in menuItemViewModels)
        {
            vm.MessageBoxRequest += InvokeMessageBoxRequest;
        }*/
    }

    /*private void InvokeMessageBoxRequest(object sender, MessageBoxEventArgs e)
    {
        MessageBox_Show();
    }*/
}