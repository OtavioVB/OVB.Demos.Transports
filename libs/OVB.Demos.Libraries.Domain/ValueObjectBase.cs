namespace OVB.Demos.Libraries.Domain;

public static class ValueObjectBase
{
    public readonly struct SourcePlatform
    {
        private string Value { get; init; }

        public SourcePlatform(string value)
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
