namespace OVB.Demos.Transports.CompanyContext.Domain.Bussines.OwnerPhoneContext.DataTransferObject;

public sealed class OwnerPhone
{
    public OwnerPhone(Guid identifier, string ddi, string dd, string number)
    {
        Identifier = identifier;
        Ddi = ddi;
        Dd = dd;
        Number = number;
    }

    public Guid Identifier { get; init; }
    public string Ddi { get; set; }
    public string Dd { get; set; }
    public string Number { get; init; }
}
