using OVB.Demos.Transports.CompanyContext.Application.Services.Internal.CompanyContext.Inputs;
using OVB.Demos.Transports.CompanyContext.Application.Services.Internal.CompanyContext.Interfaces;
using OVB.Demos.Transports.CompanyContext.Application.Services.Internal.CompanyContext.Outputs;
using OVB.Demos.Transports.CompanyContext.Domain.Bussines.CompanyContext.DataTransferObject;
using OVB.Demos.Transports.CompanyContext.Infrascructure.EntityFrameworkCore.Repositories.Base.Interfaces;
using OVB.Demos.Transports.CompanyContext.Infrascructure.UnitOfWork.Interfaces;
using OVB.Demos.Transports.Responses;
using OVB.Demos.Transports.Responses.ManagementMessages;

namespace OVB.Demos.Transports.CompanyContext.Application.Services.Internal.CompanyContext;

public sealed class CompanyService : ICompanyService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBaseRepository<Company> _companyBaseRepository;
    private readonly IExtensionCompanyRepository _extensionCompanyRepository;
    private readonly ManagementMessages<CompanyService> _managementMessages;

    public Task<ResponseBase<CreateCompanyServiceSuccessfullResponse>> CreateCompanyServiceAsync(CreateCompanyServiceInput input, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
