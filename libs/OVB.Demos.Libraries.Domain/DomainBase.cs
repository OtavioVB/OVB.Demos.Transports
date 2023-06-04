using static OVB.Demos.Libraries.Domain.ValueObjectBase;

namespace OVB.Demos.Libraries.Domain;

public static class DomainBase
{
    public abstract class All
    {
        protected Guid Identifier { get; set; }
        protected Guid CorrelationIdentifier { get; set; }
        protected SourcePlatform SourcePlatform { get; set; }
        protected DateTime CreatedAt { get; set; }
        protected DateTime UpdatedAt { get; set; }
    }
}
