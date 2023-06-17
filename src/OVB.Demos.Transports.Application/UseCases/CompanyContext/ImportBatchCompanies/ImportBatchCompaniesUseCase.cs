using OVB.Demos.Transports.Application.Services.Business.CompanyContext.Inputs;
using OVB.Demos.Transports.Application.Services.Business.CompanyContext.Interfaces;
using OVB.Demos.Transports.Application.Services.OutOfBusiness.DeveloperContext.Interfaces;
using OVB.Demos.Transports.Application.Services.OutOfBusiness.FileContext;
using OVB.Demos.Transports.Application.UseCases.CompanyContext.ImportBatchCompanies.Inputs;
using OVB.Demos.Transports.Application.UseCases.CompanyContext.ImportBatchCompanies.Outputs;
using OVB.Demos.Transports.Application.UseCases.Interfaces;
using OVB.Demos.Transports.Domain.CompanyContext.ENUMs;
using OVB.Demos.Transports.Domain.Results;
using OVB.Demos.Transports.Domain.Results.ErrorResults;
using OVB.Demos.Transports.Domain.Results.Interfaces;
using OVB.Demos.Transports.Infrascructure.EntityFrameworkCore.UnitOfWork.Interfaces;

namespace OVB.Demos.Transports.Application.UseCases.CompanyContext.ImportBatchCompanies;

public sealed class ImportBatchCompaniesUseCase : IUseCase<ImportBatchCompaniesUseCaseInput, 
    ICommandCompleteResult<ImportBatchCompaniesUseCaseSuccessfullResponse, ImportBatchCompaniesUseCaseErrorfullResponse>>
{
    private readonly IFileService _fileService;
    private readonly IAuthorizationService _authorizationService;
    private readonly ICompanyService _companyService;
    private readonly IUnitOfWork _unitOfWork;

    public ImportBatchCompaniesUseCase(
        IFileService fileService,
        IAuthorizationService authorizationService, 
        ICompanyService companyService,
        IUnitOfWork unitOfWork)
    {
        _fileService = fileService;
        _authorizationService = authorizationService;
        _companyService = companyService;
        _unitOfWork = unitOfWork;
    }

    public Task<ICommandCompleteResult<ImportBatchCompaniesUseCaseSuccessfullResponse, ImportBatchCompaniesUseCaseErrorfullResponse>> ExecuteUseCaseAsync(
        ImportBatchCompaniesUseCaseInput input, CancellationToken cancellationToken)
    {
        return _unitOfWork.ExecuteUnitOfWorkAsync<ICommandCompleteResult<ImportBatchCompaniesUseCaseSuccessfullResponse, ImportBatchCompaniesUseCaseErrorfullResponse>>(
            handler: async (cancellationToken) =>
        {
            var response = new CommandCompleteResult<ImportBatchCompaniesUseCaseSuccessfullResponse, ImportBatchCompaniesUseCaseErrorfullResponse>();
            var messages = new List<NotificationMessage>();

            var authorizationServiceResponse = await _authorizationService.DeveloperAuthorizeToMakeChanges(
                authorizationCode: input.Authorization, 
                cancellationToken: cancellationToken);
            if (authorizationServiceResponse.GetResultState() == StateResult.ErrorResult)
            {
                response.AddErrorResponse(
                    notificationMessages: new ImportBatchCompaniesUseCaseErrorfullResponse(
                        companiesError: null,
                        generalNotificationMessages: (IReadOnlyCollection<NotificationMessage>)authorizationServiceResponse.GetErrorCommandResult()));
                return (false, response);
            }
            messages.AddRange(authorizationServiceResponse.GetSuccessfullCommandResult());

            var fileServiceResponse = await _fileService.ValidateIsCsvFileServiceAsync(
                input: input.File, 
                cancellationToken: cancellationToken);
            if (fileServiceResponse.GetResultState() == StateResult.ErrorResult)
            {
                response.AddErrorResponse(notificationMessages: new ImportBatchCompaniesUseCaseErrorfullResponse(
                        companiesError: null,
                        generalNotificationMessages: (IReadOnlyCollection<NotificationMessage>)fileServiceResponse.GetErrorCommandResult()));
                return (false, response);
            }
            messages.AddRange(fileServiceResponse.GetSuccessfullCommandResult());

            var fileDecomposeServiceResponse = await _companyService.ConvertFileToCompanyBaseModelServiceAsync(
                input: new ConvertFileToCompanyBaseModelServiceInput(input.File, ',', Path.Combine(Environment.CurrentDirectory, "archives_temp", $"{Guid.NewGuid().ToString("N")}.csv")),
                cancellationToken: cancellationToken);
            if (fileDecomposeServiceResponse.GetResultState() == StateResult.ErrorResult)
            {
                response.AddErrorResponse(notificationMessages: new ImportBatchCompaniesUseCaseErrorfullResponse(
                        companiesError: null,
                        generalNotificationMessages: (IReadOnlyCollection<NotificationMessage>)fileDecomposeServiceResponse.GetErrorCommandResult()));
                return (false, response);
            }

            var hasAnyInvalid = false;
            var companiesError = new List<CompanyBatchInformation>();
            var companiesSuccessfullInformation = new List<ImportBatchCompaniesCompanyInformationUseCaseSuccessfullResponse>();

            foreach (var company in fileDecomposeServiceResponse.GetSuccessfullCommandResult())
            {
                var createCompanyServiceResponse = await _companyService.CreateCompanyServiceAsync(
                    input: new CreateCompanyServiceInput(
                        realName: company.RealName,
                        platformName: company.PlatformName,
                        cnpj: company.Cnpj,
                        typeCompany: TypeCompany.Standard),
                    cancellationToken: cancellationToken);

                if (createCompanyServiceResponse.GetResultState() == StateResult.ErrorResult)
                {
                    hasAnyInvalid = true;
                    companiesError.Add(
                        item: new CompanyBatchInformation(
                            cnpj: company.Cnpj,
                            notifications: (IReadOnlyCollection<NotificationMessage>)createCompanyServiceResponse.GetErrorCommandResult()));
                }
                else if (createCompanyServiceResponse.GetResultState() == StateResult.SuccessfullResult && hasAnyInvalid == false)
                {
                    var createCompanyServiceSuccessfullResponse = createCompanyServiceResponse.GetSuccessfullCommandResult();
                    companiesSuccessfullInformation.Add(
                        item: new ImportBatchCompaniesCompanyInformationUseCaseSuccessfullResponse(
                            identifier: createCompanyServiceSuccessfullResponse.Identifier,
                            cnpj: createCompanyServiceSuccessfullResponse.Cnpj,
                            createdAt: createCompanyServiceSuccessfullResponse.CreatedAt,
                            notifications: createCompanyServiceSuccessfullResponse.Notifications));
                }
            }

            if (hasAnyInvalid == true)
            {
                response.AddErrorResponse(new ImportBatchCompaniesUseCaseErrorfullResponse(
                    companiesError: companiesError,
                    generalNotificationMessages: messages));
                return (false, response);
            }

            response.AddSuccessfullResponse(
                new ImportBatchCompaniesUseCaseSuccessfullResponse(
                    companiesInformation: companiesSuccessfullInformation,
                    notifications: messages));
            return (true, response);
        }, cancellationToken: cancellationToken);
    }
}
