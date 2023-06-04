namespace OVB.Demos.Transports.CompanyContext.Domain.Bussines.CompanyContext.ValueObjects;

public static class CompanyValueObjects
{
    public readonly struct Name
    {
        private string Value { get; init; }

        public Name(string value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }

        public bool IsSetted()
        {
            return Value != string.Empty;
        }
    }

    public readonly struct PlatformName
    {
        private string Value { get; init; }

        public PlatformName(string value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }

        public bool IsSetted()
        {
            return Value != string.Empty;
        }
    }
}
