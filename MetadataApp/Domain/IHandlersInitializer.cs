using HandlerLib;
using MetadataApp.ui.ViewModels;

namespace MetadataApp.Domain.Interfaces;

public interface IHandlersInitializer
{
    Handler[] Initialize();
}