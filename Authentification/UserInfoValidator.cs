using System;

namespace MetadataApp.Domain.Interfaces;

public class UserInfoValidator
{
    private readonly int _arrLength = 3;
    public bool Validate(string[] userInfo)
    {
        foreach (string i in userInfo)
        {
            CheckNull(i);
            CheckEmpty(i);
        }
        CheckLength(userInfo.Length);
        return true;
    }
    
    private void CheckLength(int currentLength)
    {
        if (currentLength != _arrLength)
            throw new ArgumentException($"User info length length isn't equal to {_arrLength}");
    }

    private void CheckEmpty(string str)
    {
        if (str == "")
            throw new ArgumentException("User information element must not be empty");
    }

    private void CheckNull(string str)
     {
         if (str == null)
             throw new ArgumentNullException(nameof(str));
     }
}