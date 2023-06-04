using OVB.Demos.Libraries.Domain;
using OVB.Demos.Transports.CompanyContext.Domain.Bussines.CompanyContext.DataTransferObject;
using static OVB.Demos.Transports.CompanyContext.Domain.Bussines.CompanyContext.ValueObjects.CompanyValueObjects;

namespace OVB.Demos.Transports.CompanyContext.Domain.Bussines.CompanyContext.Entities.Base;

public abstract class CompanyBase : DomainBase.All
{
    #region Properties

    protected Name Name { get; set; }
    protected PlatformName PlatformName { get; set; }

    protected Company Company { get; set; }

    #endregion

    #region Constructors

    protected CompanyBase()
    {
        Company = Company.Empty;
    }

    #endregion

    #region Bussiness Methods

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    #endregion
}
