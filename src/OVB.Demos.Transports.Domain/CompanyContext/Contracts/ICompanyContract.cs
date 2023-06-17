using OVB.Demos.Transports.Domain.CompanyContext.DataTransferObject;
using OVB.Demos.Transports.Domain.Results.ErrorResults;
using OVB.Demos.Transports.Domain.Results.Interfaces;

namespace OVB.Demos.Transports.Domain.CompanyContext.Contracts;

public interface ICompanyContract
{
    public ICommandResult<IEnumerable<NotificationMessage>> CreateCompany(string platformName, string realName, string cnpj);
    public Company GetCompanyDataTransferObject();
}
