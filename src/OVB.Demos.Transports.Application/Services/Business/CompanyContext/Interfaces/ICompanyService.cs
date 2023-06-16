using OVB.Demos.Transports.Application.Services.Business.CompanyContext.Inputs;
using OVB.Demos.Transports.Application.Services.Business.CompanyContext.Outputs;
using OVB.Demos.Transports.Domain.Results.Interfaces;

namespace OVB.Demos.Transports.Application.Services.Business.CompanyContext.Interfaces;

public interface ICompanyService
{
    public Task<ICommandResult<IEnumerable<CompanyBaseModel>>> ConvertFileToCompanyBaseModelServiceAsync(
        ConvertFileToCompanyBaseModelServiceInput input, CancellationToken cancellationToken);
}
