using System;
using System.Collections.ObjectModel;
using System.IO;
using MetadataApp.ui.ViewModels;

namespace MetadataApp.Domain;

public class ConfigurationParser
{
    public ObservableCollection<MenuItemViewModel> Parse(StreamReader streamReader)
    {
        ObservableCollection<MenuItemViewModel> MenuItemsCollection = new ObservableCollection<MenuItemViewModel>();

        while (streamReader.ReadLine() is { } line)
        {
            bool visility = true, availability = true;
            string[] configData = line.Split(' ');

            ObservableCollection<MenuItemViewModel> localCollection = MenuItemsCollection;

            GetCollection(Convert.ToInt32(configData[0]), ref localCollection);
            ChangeStatus(Convert.ToInt32(configData[2]), ref availability, ref visility);        

            localCollection.Add(new MenuItemViewModel(configData[1], visility, availability));

            if (configData[3] == "")
                localCollection[localCollection.Count - 1].MenuItems = new ObservableCollection<MenuItemViewModel>();
            else
            {
                // СЮДА АБРАБОЧЕК В ПОСЛЕДНИЙ ЭЛЕМЕНТ ЛОКАЛ КОЛЕКШЕН
            }
        }

        return MenuItemsCollection;
    }

    private void GetCollection(int hierarchyLevel, ref ObservableCollection<MenuItemViewModel> collection)
    {
        for (int i = 0; i < hierarchyLevel; i++)
        {
            collection = collection[collection.Count - 1].MenuItems;
        }
    }

    private void ChangeStatus(int flag, ref bool availability, ref bool visility)
    {
        if (flag == 1)
            availability = false;
        else if (flag == 2)
            visility = false;
    }
}