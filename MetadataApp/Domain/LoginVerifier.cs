using System;

namespace MetadataApp.Domain;

public class LoginVerifier
{
    public void Verify(byte[] hashBytes, string password)
    {
        PasswordHash hash = new PasswordHash(hashBytes);
        if (!hash.Verify(password))
            throw new UnauthorizedAccessException("Неверный пароль");
    }
}