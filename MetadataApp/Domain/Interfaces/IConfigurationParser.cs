using System.Collections.ObjectModel;
using System.IO;
using MetadataApp.ui.ViewModels;

namespace MetadataApp.Domain.Interfaces;

public interface IConfigurationParser
{
    ObservableCollection<MenuItemViewModel> Parse(Stream stream);
}