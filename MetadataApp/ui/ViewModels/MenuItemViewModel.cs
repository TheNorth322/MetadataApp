using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace MetadataApp.ui.ViewModels;

public class MenuItemViewModel
{
    private readonly ICommand _command;
    public ObservableCollection<MenuItemViewModel> MenuItems { get; set; }
    public bool AvailabilityStatus { get; set; }
    public bool VisibilityStatus { get; set; }
    public string Header { get; set; }
    
    public MenuItemViewModel()
    {
        _command = new RelayCommand(_execute => Execute(),
            _canExecute => true);
    }

    public MenuItemViewModel(string header, bool visibilityStatus, bool availabilityStatus)
    {
        Header = header;
        VisibilityStatus = visibilityStatus;
        AvailabilityStatus = availabilityStatus;
        _command = new RelayCommand(_execute => Execute(),
            _canExecute => true);
    }
    public ICommand Command
    {
        get { return _command; }
    }

    private void Execute()
    {
        MessageBox.Show("Clicked at " + Header);
    }
}