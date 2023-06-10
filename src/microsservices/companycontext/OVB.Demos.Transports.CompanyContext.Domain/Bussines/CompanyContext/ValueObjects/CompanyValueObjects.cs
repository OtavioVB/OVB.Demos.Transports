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

        public static int MaxLength = 255;
        public static int MinLength = 5;

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

    public readonly struct Document
    {
        private string Content { get; init; }
        private string Type { get; init; }

        public Document(string type, string content)
        {
            Type = type;
            Content = content;
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public bool IsSetted()
        {
            return Type != string.Empty && Content != string.Empty;
        }

        public string GetDocumentContent()
        {
            return Content;
        }

        public string GetDocumentType()
        {
            return Type;
        }
    }
}
