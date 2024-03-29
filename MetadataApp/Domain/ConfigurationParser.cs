﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using ConfigLineValidatorLib;
using MetadataApp.Domain.Interfaces;
using MetadataApp.ui.ViewModels;
using HandlerLib;
using StreamCollectionLib;

namespace MetadataApp.Domain;

public class ConfigurationParser : IConfigurationParser
{
    private StreamCollection _streams;
    public ConfigurationParser(StreamCollection streams)
    {
        _streams = streams;
    }
    public ObservableCollection<MenuItemViewModel> Parse(Stream stream)
    {
        _streams.Add(stream);
        StreamReader streamReader = new StreamReader(stream);
        ObservableCollection<MenuItemViewModel> menuItemsCollection = new ObservableCollection<MenuItemViewModel>();
        Handler[] handlers = new HandlersInitializer().Initialize();

        ConfigLineValidator configLineValidator = new ConfigLineValidator();
        while (streamReader.ReadLine() is { } line)
        {
            bool visility = true, availability = true;
            string[] configData = line.Split(' ');
            
            configLineValidator.Validate(configData);
            ObservableCollection<MenuItemViewModel> localCollection = menuItemsCollection;

            GetCollection(ref localCollection, Convert.ToInt32(configData[0]));
            ChangeStatus(Convert.ToInt32(configData[2]), ref availability, ref visility);

            localCollection.Add(new MenuItemViewModel(configData[1], visility, availability));

            if (configData[3] == "")
            {
                localCollection[localCollection.Count - 1].MenuItems = new ObservableCollection<MenuItemViewModel>();
            }
            else
            {
                Handler handler = GetHandler(handlers, configData[3]);
                localCollection[localCollection.Count - 1].Handler = handler;
            }
        }

        stream.Close();
        return menuItemsCollection;
    }

    private Handler GetHandler(Handler[] handlers, string tag)
    {
        foreach (Handler handler in handlers)
            if (handler.Tag == tag)
                return handler;

        throw new ApplicationException("No handlers were found");
    }

    private void GetCollection(ref ObservableCollection<MenuItemViewModel> collection, int hierarchyLevel)
    {
        for (int i = 0; i < hierarchyLevel; i++) 
            collection = collection[collection.Count - 1].MenuItems;
    }

    private void ChangeStatus(int flag, ref bool availability, ref bool visility)
    {
        if (flag == 1)
            availability = false;
        else if (flag == 2)
            visility = false;
    }
}