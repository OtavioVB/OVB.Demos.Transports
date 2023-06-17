using OVB.Demos.Transports.Application.Services.Business.CompanyContext.Inputs;
using OVB.Demos.Transports.Application.Services.Business.CompanyContext.Interfaces;
using OVB.Demos.Transports.Application.Services.Business.CompanyContext.Outputs;
using OVB.Demos.Transports.Domain.CompanyContext.Builders.Interfaces;
using OVB.Demos.Transports.Domain.CompanyContext.DataTransferObject;
using OVB.Demos.Transports.Domain.Results;
using OVB.Demos.Transports.Domain.Results.ErrorResults;
using OVB.Demos.Transports.Domain.Results.Interfaces;
using OVB.Demos.Transports.Infrascructure.EntityFrameworkCore.Repositories.Base.Interfaces;
using OVB.Demos.Transports.Infrascructure.EntityFrameworkCore.Repositories.Extensions;
using OVB.Demos.Transports.Infrascructure.EntityFrameworkCore.UnitOfWork.Interfaces;

namespace OVB.Demos.Transports.Application.Services.Business.CompanyContext;

public sealed class CompanyService : ICompanyService
{
    private readonly IBuilderCompany _builderCompany;
    private readonly IBaseRepository<Company> _companyBaseRepository;
    private readonly IExtensionCompanyRepository _extensionCompanyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CompanyService(
        IBuilderCompany builderCompany, 
        IBaseRepository<Company> companyBaseRepository, 
        IExtensionCompanyRepository extensionCompanyRepository, 
        IUnitOfWork unitOfWork)
    {
        _builderCompany = builderCompany;
        _companyBaseRepository = companyBaseRepository;
        _extensionCompanyRepository = extensionCompanyRepository;
        _unitOfWork = unitOfWork;
    }

    public static NotificationMessage CompanyExists =
        new NotificationMessage("COM01", "The company exists registered in our database.", TypeMessage.Information);


    public async Task<ICommandResult<IReadOnlyCollection<CompanyBaseModel>>> ConvertFileToCompanyBaseModelServiceAsync(
        ConvertFileToCompanyBaseModelServiceInput input, CancellationToken cancellationToken)
    {
        var response = new CommandResult<IReadOnlyCollection<CompanyBaseModel>>();

        using (var fileStream = File.Create(input.Path))
        {
            await input.File.CopyToAsync(fileStream);
            await fileStream.FlushAsync(cancellationToken);
        }

        var companies = new List<CompanyBaseModel>();

        var lines = await File.ReadAllLinesAsync(input.Path, cancellationToken);
        foreach (var line in lines)
        {
            var lineInformationSplitted = line.Split(input.SeparatorCharacter);
            companies.Add(new CompanyBaseModel(lineInformationSplitted[0], lineInformationSplitted[1], lineInformationSplitted[2]));
        }

        File.Delete(input.Path));
        response.AddSuccessfullResponse(companies);
        return response;
    }

    /// <summary>
    /// Create Unique Company Service
    /// </summary>
    public async Task<ICommandResult<CreateCompanyServiceSuccessfullResponse>> CreateCompanyServiceAsync(
        CreateCompanyServiceInput input, CancellationToken cancellationToken)
    {
        var response = new CommandResult<CreateCompanyServiceSuccessfullResponse>();
        var messages = new List<NotificationMessage>();

        var companyDomain = _builderCompany.BuildCompanyContractAccordingToHisType(input.TypeCompany);
        var createCompanyDomainCommandResult = companyDomain.CreateCompany(input.PlatformName, input.RealName, input.Cnpj);
        if (createCompanyDomainCommandResult.GetResultState() == StateResult.ErrorResult)
        {
            response.AddErrorResponse(createCompanyDomainCommandResult.GetErrorCommandResult());
            return response;
        }

        var existsInDatabase = await _extensionCompanyRepository.VerifyEntityExistsByCnpjAsync(input.Cnpj, cancellationToken);
        if (existsInDatabase == true)
        {
            messages.Add(CompanyExists);
            response.AddErrorResponse(messages);
            return response;
        }

        var companyDataTransferObject = companyDomain.GetCompanyDataTransferObject();
        await _companyBaseRepository.AddAsync(companyDataTransferObject, cancellationToken);
        await _unitOfWork.AddChangesToTransaction(cancellationToken);

        response.AddSuccessfullResponse(
            entity: new CreateCompanyServiceSuccessfullResponse(
                notifications: messages,
                identifier: companyDataTransferObject.Identifier,
                cnpj: companyDataTransferObject.Cnpj,
                createdAt: companyDataTransferObject.CreatedAt));
        return response;
    }
}
