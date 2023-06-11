using static OVB.Demos.Transports.CompanyContext.Domain.Bussines.CompanyContext.ValueObjects.CompanyValueObjects;
using static OVB.Demos.Libraries.Domain.DomainBase;
using OVB.Demos.Libraries.Domain;
using OVB.Demos.Transports.Responses;
using OVB.Demos.Transports.CompanyContext.Domain.Bussines.CompanyContext.Responses;
using OVB.Demos.Transports.CompanyContext.Domain.Bussines.CompanyContext.ENUMs;
using OVB.Demos.Transports.CompanyContext.Domain.Bussines.CompanyContext.DataTransferObject;

namespace OVB.Demos.Transports.CompanyContext.Domain.Bussines.CompanyContext.Entities.Base;

public abstract class CompanyBase : All
{
    #region Properties

    protected Name Name { get; set; }
    protected PlatformName PlatformName { get; set; }
    protected Document Document { get; set; }

    protected State State { get; set; }
    protected TypeCompany Type { get; init; }

    protected Company Company { get; set; }

    #endregion

    #region Constructors
    protected CompanyBase(
        TypeCompany typeCompany)
    {
        Type = typeCompany;
        State = State.Unavailable;
        Company = Company.Empty;
    }
    #endregion

    #region Bussiness Methods

    public ResponseBase<CreateCompanyDomainSuccessfullResponse> CreateCompany()
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    #endregion
}
