namespace OVB.Demos.Transports.CompanyContext.Domain.Bussines.BaseContext;

public static class BaseValueObjects
{
    public readonly struct Country
    {
        private string Value { get; init; }

        public Country(string value)
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

    public readonly struct Language
    {
        private string Value { get; init; }

        public Language(string value)
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
