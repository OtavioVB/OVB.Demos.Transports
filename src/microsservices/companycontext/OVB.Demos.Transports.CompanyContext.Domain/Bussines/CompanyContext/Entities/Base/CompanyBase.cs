using OVB.Demos.Transports.CompanyContext.Domain.Bussines.CompanyContext.DataTransferObject;
using static OVB.Demos.Transports.CompanyContext.Domain.Bussines.CompanyContext.ValueObjects.CompanyValueObjects;
using static OVB.Demos.Libraries.Domain.DomainBase;
using OVB.Demos.Libraries.Cryptography;

namespace OVB.Demos.Transports.CompanyContext.Domain.Bussines.CompanyContext.Entities.Base;

public abstract class CompanyBase : All
{
    #region Properties

    protected Name Name { get; set; }
    protected PlatformName PlatformName { get; set; }
    protected PrivateKey CryptographyPrivateKey { get; set; }

    protected Company? Company { get; set; }

    #endregion

    #region Constructors

    #endregion

    #region Bussiness Methods

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    #endregion
}
