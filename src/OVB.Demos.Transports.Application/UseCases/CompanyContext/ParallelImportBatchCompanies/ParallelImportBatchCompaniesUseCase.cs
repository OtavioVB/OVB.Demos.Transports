using OVB.Demos.Transports.Application.Services.Business.CompanyContext.Inputs;
using OVB.Demos.Transports.Application.Services.Business.CompanyContext.Interfaces;
using OVB.Demos.Transports.Application.Services.OutOfBusiness.DeveloperContext.Interfaces;
using OVB.Demos.Transports.Application.Services.OutOfBusiness.FileContext;
using OVB.Demos.Transports.Application.UseCases.CompanyContext.ImportBatchCompanies.Outputs;
using OVB.Demos.Transports.Application.UseCases.CompanyContext.ParallelImportBatchCompanies.Inputs;
using OVB.Demos.Transports.Application.UseCases.CompanyContext.ParallelImportBatchCompanies.Outputs;
using OVB.Demos.Transports.Application.UseCases.Interfaces;
using OVB.Demos.Transports.Domain.CompanyContext.ENUMs;
using OVB.Demos.Transports.Domain.Results;
using OVB.Demos.Transports.Domain.Results.ErrorResults;
using OVB.Demos.Transports.Domain.Results.Interfaces;
using OVB.Demos.Transports.Infrascructure.EntityFrameworkCore.UnitOfWork.Interfaces;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Text;

namespace OVB.Demos.Transports.Application.UseCases.CompanyContext.ParallelImportBatchCompanies;

public sealed class ParallelImportBatchCompaniesUseCase : IUseCase<ParallelImportBatchCompaniesUseCaseInput,
    ICommandCompleteResult<ParallelImportBatchCompaniesUseCaseSuccessfullResponse, ParallelImportBatchCompaniesUseCaseErrorfullResponse>>
{
    private readonly IFileService _fileService;
    private readonly IAuthorizationService _authorizationService;
    private readonly ICompanyService _companyService;
    private readonly IUnitOfWork _unitOfWork;

    public ParallelImportBatchCompaniesUseCase(
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

    public Task<ICommandCompleteResult<ParallelImportBatchCompaniesUseCaseSuccessfullResponse, ParallelImportBatchCompaniesUseCaseErrorfullResponse>> ExecuteUseCaseAsync(
        ParallelImportBatchCompaniesUseCaseInput input, CancellationToken cancellationToken)
    {
        return _unitOfWork.ExecuteUnitOfWorkAsync<ICommandCompleteResult<ParallelImportBatchCompaniesUseCaseSuccessfullResponse, ParallelImportBatchCompaniesUseCaseErrorfullResponse>>(
            handler: async (cancellationToken) =>
        {
            var response = new CommandCompleteResult<ParallelImportBatchCompaniesUseCaseSuccessfullResponse, ParallelImportBatchCompaniesUseCaseErrorfullResponse>();
            var messages = new List<NotificationMessage>();

            var authorizationServiceResponse = await _authorizationService.DeveloperAuthorizeToMakeChanges(
                authorizationCode: input.DeveloperAuthorizationCode,
                cancellationToken: cancellationToken);
            if (authorizationServiceResponse.GetResultState() == StateResult.ErrorResult)
            {
                response.AddErrorResponse(
                    notificationMessages: new ParallelImportBatchCompaniesUseCaseErrorfullResponse(
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
                response.AddErrorResponse(notificationMessages: new ParallelImportBatchCompaniesUseCaseErrorfullResponse(
                        companiesError: null,
                        generalNotificationMessages: (IReadOnlyCollection<NotificationMessage>)fileServiceResponse.GetErrorCommandResult()));
                return (false, response);
            }
            messages.AddRange(fileServiceResponse.GetSuccessfullCommandResult());


            var archiveName = $"{Guid.NewGuid().ToString("N")}.csv";
            using (var fileStream = File.Create(Path.Combine(Environment.CurrentDirectory, "archives_temp", archiveName)))
            {
                await input.File.CopyToAsync(fileStream);
                await fileStream.FlushAsync(cancellationToken);
            }

            var hasAnyInvalid = false;
            var companiesError = new ConcurrentBag<ParallelCompanyBatchInformation>();
            var companiesSuccessfullInformation = new ConcurrentBag<ValidCompanyInformation>();

            Parallel.ForEach(File.ReadLines(Path.Combine(Environment.CurrentDirectory, "archives_temp", archiveName)), (line) =>
            {
                var splittedLine = line.Split(",");
                var companyServiceResponse = _companyService.CreateCompanyValidationServiceAsync(
                    input: new CreateCompanyServiceInput(splittedLine[0], splittedLine[1], splittedLine[2], TypeCompany.Standard));

                if (companyServiceResponse.GetResultState() == StateResult.ErrorResult)
                {
                    hasAnyInvalid = true;
                    companiesError.Add(new ParallelCompanyBatchInformation(
                        cnpj: splittedLine[2],
                        notifications: (IReadOnlyCollection<NotificationMessage>)companyServiceResponse.GetErrorCommandResult()));
                }
                else if (companyServiceResponse.GetResultState() == StateResult.SuccessfullResult && hasAnyInvalid == false)
                {
                    companiesSuccessfullInformation.Add(
                        item: new ValidCompanyInformation(
                            splittedLine[0],
                            splittedLine[1],
                            splittedLine[2]));
                }
            });

            if (hasAnyInvalid == true)
            {
                response.AddErrorResponse(new ParallelImportBatchCompaniesUseCaseErrorfullResponse(
                    companiesError: companiesError,
                    generalNotificationMessages: messages));
                return (false, response);
            }


            var companiesSuccessfullCreation = new Collection<ParallelImportBatchCompaniesCompanyInformationUseCaseSuccessfullResponse>();
            foreach (var company in companiesSuccessfullInformation)
            {
                var companyCreateServiceResponse = await _companyService.CreateCompanyServiceWithoutDomainValidationAsync(
                    input: new CreateCompanyServiceInput(company.RealName, company.PlatformName, company.Cnpj, TypeCompany.Standard),
                    cancellationToken: cancellationToken);

                if (companyCreateServiceResponse.GetResultState() == StateResult.ErrorResult)
                {
                    companiesError.Add(
                        item: new ParallelCompanyBatchInformation(
                            company.Cnpj,
                            (IReadOnlyCollection<NotificationMessage>)companyCreateServiceResponse.GetErrorCommandResult()));

                    response.AddErrorResponse(
                        notificationMessages: new ParallelImportBatchCompaniesUseCaseErrorfullResponse(
                            companiesError: companiesError,
                            generalNotificationMessages: messages));
                    return (false, response);
                }
                else
                {
                    var companySuccessfullCreationResponse = companyCreateServiceResponse.GetSuccessfullCommandResult();
                    companiesSuccessfullCreation.Add(
                        item: new ParallelImportBatchCompaniesCompanyInformationUseCaseSuccessfullResponse(
                            identifier: companySuccessfullCreationResponse.Identifier,
                            cnpj: companySuccessfullCreationResponse.Cnpj,
                            createdAt: companySuccessfullCreationResponse.CreatedAt,
                            notifications: companySuccessfullCreationResponse.Notifications));
                }
            }

            response.AddSuccessfullResponse(
                entity: new ParallelImportBatchCompaniesUseCaseSuccessfullResponse(
                    companiesInformation: companiesSuccessfullCreation,
                    notifications: messages));
            return (true, response);
        }, cancellationToken: cancellationToken);
    }

    public readonly struct ValidCompanyInformation
    {
        public ValidCompanyInformation(string realName, string platformName, string cnpj)
        {
            RealName = realName;
            PlatformName = platformName;
            Cnpj = cnpj;
        }

        public string RealName { get; init; }
        public string PlatformName { get; init; }
        public string Cnpj { get; init; }
    }
}
