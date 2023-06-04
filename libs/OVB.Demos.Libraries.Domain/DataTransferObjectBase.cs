namespace OVB.Demos.Libraries.Domain;

public static class DataTransferObjectBase
{
    public abstract class Default
    {
        protected Default(Guid identifier)
        {
            Identifier = identifier;
        }

        public Guid Identifier { get; set; }
    }

    public abstract class Time
    {
        protected Time(DateTime createdAt, DateTime updatedAt)
        {
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public abstract class MicrosservicesInfo
    {
        protected MicrosservicesInfo(Guid correlationIdentifier, string sourcePlatform)
        {
            CorrelationIdentifier = correlationIdentifier;
            SourcePlatform = sourcePlatform;
        }

        public Guid CorrelationIdentifier { get; set; }
        public string SourcePlatform { get; set; }
    }

    public abstract class All
    {
        protected All(Guid identifier, Guid correlationIdentifier, string sourcePlatform, DateTime createdAt, DateTime updatedAt)
        {
            Identifier = identifier;
            CorrelationIdentifier = correlationIdentifier;
            SourcePlatform = sourcePlatform;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public Guid Identifier { get; set; }
        public Guid CorrelationIdentifier { get; set; }
        public string SourcePlatform { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
