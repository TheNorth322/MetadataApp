using System;
using System.Security.Cryptography;
using System.Text;

namespace PasswordHashLib;

public sealed class PasswordHash
{
    private readonly string _salt = "3yYQv8xx5MjR63RFwWxLxaXR";
    public string _hash;

    public void Hash(string password)
    {
        UnicodeEncoding ue = new UnicodeEncoding();
        byte[] messageBytes = ue.GetBytes(password + _salt);
        SHA256 shHash = SHA256.Create();
        _hash = BitConverter.ToString(shHash.ComputeHash(messageBytes));
    }

    public bool Verify(string password, string savedHash)
    {
        Hash(password);
        return _hash == savedHash;
    }
}