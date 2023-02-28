using System.Collections.ObjectModel;

namespace MetadataApp.ui.ViewModels;

public class MainViewModel : ViewModelBase
{
    public MainViewModel(ObservableCollection<MenuItemViewModel> menuItemViewModels)
    {
        MenuItems = menuItemViewModels;
    }

    public ObservableCollection<MenuItemViewModel> MenuItems { get; }
}