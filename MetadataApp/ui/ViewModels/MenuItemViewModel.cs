using System.Collections.ObjectModel;
using HandlerLib;
namespace MetadataApp.ui.ViewModels;

public class MenuItemViewModel : ViewModelBase
{
    private readonly RelayCommand _command;
    public ObservableCollection<MenuItemViewModel> MenuItems { get; set; }
    public bool AvailabilityStatus { get; set; }
    public bool VisibilityStatus { get; set; }
    public string Header { get; set; }

    public Handler Handler { get; set; }

    public MenuItemViewModel(string header, bool visibilityStatus, bool availabilityStatus)
    {
        Header = header;
        VisibilityStatus = visibilityStatus;
        AvailabilityStatus = availabilityStatus;
    }

    public RelayCommand Command
    {
        get
        {
            return _command ?? new RelayCommand(
                _execute => Handler.Func(Handler.Tag),
                _canExecute => true
            );
        }
    }
}