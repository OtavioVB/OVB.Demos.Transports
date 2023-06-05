using OVB.Demos.Libraries.Domain;
using OVB.Demos.Transports.CompanyContext.Domain.Bussines.OwnerContext.DataTransferObject;

namespace OVB.Demos.Transports.CompanyContext.Domain.Bussines.OwnerPhoneContext.DataTransferObject;

public sealed class OwnerPhone : DataTransferObjectBase.Default
{
    public OwnerPhone(Guid identifier, string ddi, string dd, string number) : base(identifier)
    {
        Ddi = ddi;
        Dd = dd;
        Number = number;
    }

    #region Properties

    public string Ddi { get; set; }
    public string Dd { get; set; }
    public string Number { get; set; }

    #endregion

    #region Relationships

    public Guid? OwnerIdentifier { get; set; }
    public Owner? Owner { get; set; }

    #endregion
}
