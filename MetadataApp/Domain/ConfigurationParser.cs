using System;
using System.Collections.ObjectModel;
using System.IO;
using MetadataApp.Domain.Interfaces;
using MetadataApp.ui.ViewModels;

namespace MetadataApp.Domain;

public class ConfigurationParser : IConfigurationParser
{
    public ObservableCollection<MenuItemViewModel> Parse(Stream stream)
    {
        var streamReader = new StreamReader(stream);
        var menuItemsCollection = new ObservableCollection<MenuItemViewModel>();
        var handlers = new HandlersInitializer().Initialize();

        while (streamReader.ReadLine() is { } line)
        {
            bool visility = true, availability = true;
            var configData = line.Split(' ');

            var localCollection = menuItemsCollection;

            GetCollection(ref localCollection, Convert.ToInt32(configData[0]));
            ChangeStatus(Convert.ToInt32(configData[2]), ref availability, ref visility);

            localCollection.Add(new MenuItemViewModel(configData[1], visility, availability));

            if (configData[3] == "")
            {
                localCollection[localCollection.Count - 1].MenuItems = new ObservableCollection<MenuItemViewModel>();
            }
            else
            {
                var handler = GetHandler(handlers, configData[3]);
                localCollection[localCollection.Count - 1].Handler = handler;
            }
        }

        stream.Close();
        return menuItemsCollection;
    }

    private Handler GetHandler(Handler[] handlers, string tag)
    {
        foreach (var handler in handlers)
            if (handler.Tag == tag)
                return handler;

        throw new ApplicationException("No handlers were found");
    }

    private void GetCollection(ref ObservableCollection<MenuItemViewModel> collection, int hierarchyLevel)
    {
        for (var i = 0; i < hierarchyLevel; i++) collection = collection[collection.Count - 1].MenuItems;
    }

    private void ChangeStatus(int flag, ref bool availability, ref bool visility)
    {
        if (flag == 1)
            availability = false;
        else if (flag == 2)
            visility = false;
    }
}