using Microsoft.Extensions.DependencyInjection;
using OVB.Demos.Transports.Application.Services.OutOfBusiness.DeveloperContext;
using OVB.Demos.Transports.Application.Services.OutOfBusiness.DeveloperContext.Interfaces;
using OVB.Demos.Transports.Application.Services.OutOfBusiness.FileContext;
using OVB.Demos.Transports.Application.UseCases.CompanyContext.ImportBatchCompanies;
using OVB.Demos.Transports.Application.UseCases.CompanyContext.ImportBatchCompanies.Inputs;
using OVB.Demos.Transports.Application.UseCases.CompanyContext.ImportBatchCompanies.Outputs;
using OVB.Demos.Transports.Application.UseCases.Interfaces;
using OVB.Demos.Transports.Domain.Results.Interfaces;

namespace OVB.Demos.Transports.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationDependenciesConfiguration(this IServiceCollection serviceCollection)
    {
        #region Services Configuration

        serviceCollection.AddSingleton<IFileService, FileService>();
        serviceCollection.AddSingleton<IAuthorizationService, AuthorizationService>();

        #endregion

        #region Use Cases Configuration

        serviceCollection.AddScoped<IUseCase<ImportBatchCompaniesUseCaseInput, ICommandResult<ImportBatchCompaniesUseCaseSuccessfullResponse>>,
            ImportBatchCompaniesUseCase>();

        #endregion


        return serviceCollection;
    }
}
