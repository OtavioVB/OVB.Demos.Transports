using static OVB.Demos.Transports.Domain.CompanyContext.ValueObjects.CompanyValueObjects;

namespace OVB.Demos.Transports.Domain.CompanyContext.ValueObjects;

public static class CompanyValueObjects
{
    public readonly struct PlatformName
    {
        private string Value { get; init; }

        public PlatformName(string value)
        {
            Value = value;
        }

        public static int MaxLength = 32;
        public static int MinLength = 3;
        public static bool IsFixedLength = false;
        public static string DatabaseColumnType = "VARCHAR";


        public override string ToString()
            => Value;

        public static PlatformName Build(string platformName)
            => new PlatformName(platformName);
    }

    public readonly struct Name
    {
        private string Value { get; init; }

        public Name(string value)
        {
            Value = value;
        }

        public static int MaxLength = 255;
        public static int MinLength = 3;
        public static bool IsFixedLength = false;
        public static string DatabaseColumnType = "VARCHAR";

        public override string ToString()
            => Value;

        public static Name Build(string name)
            => new Name(name);
    }

    public readonly struct Cnpj
    {
        private string Value { get; init; }

        public Cnpj(string value)
        {
            Value = value;
        }

        public static int UniqueLength = 14;
        public static string DatabaseColumnType = "CHAR";
        public static bool IsFixedLength = true;

        public override string ToString()
        => Value;

        public static Cnpj Build(string cnpj)
            => new Cnpj(cnpj);
    }
}
