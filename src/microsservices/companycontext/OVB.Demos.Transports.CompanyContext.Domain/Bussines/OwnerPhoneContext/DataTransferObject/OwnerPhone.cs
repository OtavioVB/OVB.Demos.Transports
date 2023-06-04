using OVB.Demos.Libraries.Domain;

namespace OVB.Demos.Transports.CompanyContext.Domain.Bussines.OwnerPhoneContext.DataTransferObject;

public sealed class OwnerPhone : DataTransferObjectBase.Default
{
    public OwnerPhone(Guid identifier, string ddi, string dd, string number) : base(identifier)
    {
        Ddi = ddi;
        Dd = dd;
        Number = number;
    }

    public string Ddi { get; set; }
    public string Dd { get; set; }
    public string Number { get; init; }
}
