using System.Collections.ObjectModel;

namespace MetadataApp.ui.ViewModels;

public class MenuItemViewModel : ViewModelBase
{
    private readonly RelayCommand _command;

    public MenuItemViewModel(string header, bool visibilityStatus, bool availabilityStatus)
    {
        Header = header;
        VisibilityStatus = visibilityStatus;
        AvailabilityStatus = availabilityStatus;
    }

    public MenuItemViewModel(string header, bool visibilityStatus, bool availabilityStatus, Handler handler)
        : this(header, visibilityStatus, availabilityStatus)
    {
        Handler = handler;
        _command = new RelayCommand(_execute => Handler.Func(Handler.Tag),
            _canExecute => true);
    }

    public ObservableCollection<MenuItemViewModel> MenuItems { get; set; }
    public bool AvailabilityStatus { get; set; }
    public bool VisibilityStatus { get; set; }
    public string Header { get; set; }

    public Handler Handler { get; set; }

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