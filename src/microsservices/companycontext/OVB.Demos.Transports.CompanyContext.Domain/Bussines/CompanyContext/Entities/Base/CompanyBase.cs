using OVB.Demos.Transports.CompanyContext.Domain.Bussines.CompanyContext.DataTransferObject;
using static OVB.Demos.Transports.CompanyContext.Domain.Bussines.CompanyContext.ValueObjects.CompanyValueObjects;
using static OVB.Demos.Libraries.Domain.DomainBase;
using OVB.Demos.Libraries.Cryptography;
using OVB.Demos.Libraries.Domain;
using static OVB.Demos.Transports.CompanyContext.Domain.Bussines.BaseContext.BaseValueObjects;
using OVB.Demos.Transports.Responses;
using OVB.Demos.Transports.CompanyContext.Domain.Bussines.CompanyContext.Responses;

namespace OVB.Demos.Transports.CompanyContext.Domain.Bussines.CompanyContext.Entities.Base;

public abstract class CompanyBase : All
{
    #region Properties

    protected Name Name { get; set; }
    protected PlatformName PlatformName { get; set; }
    protected Document Document { get; set; }
    protected Language Language { get; set; }
    protected Country Country { get; set; }

    protected State State { get; set; }

    protected Company Company { get; set; }

    #endregion

    #region Constructors
    protected CompanyBase()
    {
        State = State.Unavailable;
        Company = Company.Empty;
    }
    #endregion

    #region Bussiness Methods

    public ResponseBase<CreateCompanyDomainSuccessfullResponse> CreateCompany()
    {
        var response = new ResponseBase<CreateCompanyDomainSuccessfullResponse>();
        bool hasAnyInvalid = false;
        var messages = new List<ErrorMessage>();

        throw new NotImplementedException();
    }

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    #endregion
}
