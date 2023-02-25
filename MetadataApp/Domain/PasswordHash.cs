using System;
using System.Security.Cryptography;

namespace MetadataApp.Domain;

public sealed class PasswordHash
{
    private const int SaltSize = 16, HashSize = 20, HashIter = 10000;
    private readonly byte[] _salt, _hash;

    public PasswordHash(string password)
    {
        new RNGCryptoServiceProvider().GetBytes(_salt = new byte[SaltSize]);
        _hash = new Rfc2898DeriveBytes(password, _salt, HashIter).GetBytes(HashSize);
    }

    public PasswordHash(byte[] hashBytes)
    {
        Array.Copy(hashBytes, 0, _salt = new byte[SaltSize], 0, SaltSize);
        Array.Copy(hashBytes, SaltSize, _hash = new byte[HashSize], 0, HashSize);
    }

    public byte[] Salt => (byte[])_salt.Clone();
    public byte[] Hash => (byte[])_hash.Clone();

    public byte[] ToArray()
    {
        var hashBytes = new byte[SaltSize + HashSize];
        Array.Copy(_salt, 0, hashBytes, 0, SaltSize);
        Array.Copy(_hash, 0, hashBytes, SaltSize, HashSize);
        return hashBytes;
    }

    public bool Verify(string password)
    {
        var test = new Rfc2898DeriveBytes(password, _salt, HashIter).GetBytes(HashSize);
        for (var i = 0; i < HashSize; i++)
            if (test[i] != _hash[i])
                return false;
        return true;
    }
}