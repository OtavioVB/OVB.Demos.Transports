using System.Security.Cryptography;

namespace OVB.Demos.Libraries.Cryptography;

public readonly struct PrivateKey
{
    private byte[] Value { get; init; }

    public PrivateKey()
    {
        var aes = Aes.Create();
        aes.GenerateKey();
        Value = aes.Key;
    }

    public PrivateKey(byte[] value)
    {
        Value = value;
    }

    public byte[] GetValue()
    {
        return Value;
    }

}
