using System;

namespace ConfigLineValidatorLib;

public class ConfigLineValidator
{
    private readonly int arrLength = 4;
    private int _previousHierarchyLevel;
    private bool _handlerExists;

    public ConfigLineValidator()
    {
        _previousHierarchyLevel = 0;
        _handlerExists = true;
    }
    public bool Validate(string[] configData)
    {
        CheckNull(configData);
        CheckLength(configData.Length);
        
        _previousHierarchyLevel = GetHierarchyLevel(configData[0]);
        
        CheckItemName(configData[1]);
        GetVisibilityStatus(configData[2]);

        _handlerExists = configData[3] == "" ? false : true;
        
        return true;
    }

    private int GetVisibilityStatus(string visibilityStatus)
    {
        int parsedValue;
        if (!int.TryParse(visibilityStatus, out parsedValue))
            throw new ArgumentException("Failed to parse visibility status value");
        if (parsedValue < 0 && parsedValue > 2)
            throw new ArgumentException("Bad visibility status value");
        return parsedValue;
    }

    private void CheckItemName(string itemName)
    {
        if (itemName == "")
            throw new ArgumentException("Bad item name");
    }

    private void CheckNull(string[] configData)
    {
        foreach (string i in configData)
            if (i == null)
                throw new ArgumentNullException(nameof(configData));
    }
    
    private void CheckLength(int currentLength)
    {
        if (currentLength != arrLength)
            throw new ArgumentException($"Configuration file length isn't equal to {arrLength}");
    }
    
    private int GetHierarchyLevel(string hierarchyLevel)
    {
        int parsedValue;
        if (!int.TryParse(hierarchyLevel, out parsedValue))
            throw new ArgumentException("Failed to parse hierarchy level value");
        if (!(_handlerExists && parsedValue <= _previousHierarchyLevel ||
              !_handlerExists && parsedValue - _previousHierarchyLevel == 1))
            throw new ArgumentException("Bad hierarchy level");

        return parsedValue;
    }
}