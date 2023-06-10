using Microsoft.Extensions.DependencyInjection;
using OVB.Demos.Libraries.Domain.Validations.Interfaces;
using OVB.Demos.Transports.CompanyContext.Domain.Bussines.CompanyContext.ValueObjects;
using OVB.Demos.Transports.Domain;
using OVB.Demos.Transports.Responses;
using OVB.Demos.Transports.Responses.ManagementMessages;
using static OVB.Demos.Transports.CompanyContext.Domain.Bussines.BaseContext.BaseValueObjects;
using static OVB.Demos.Transports.CompanyContext.Domain.Bussines.BaseContext.Validations.BaseValidations;

namespace OVB.Demos.Transports.CompanyContext.Domain;

public static class DependencyInjection
{
    public static IServiceCollection AddMicrosservicesCompanyContextDomainDependenciesConfiguration(this IServiceCollection serviceCollection)
    {
        #region Management Error Messages

        serviceCollection.AddSingleton<ManagementMessages<Country>>((serviceProvider) =>
        {
            var managementMessages = new ManagementMessages<Country>();
            var messageCode = nameof(Country).ToUpper().Substring(0, 3);

            managementMessages.AddMessage($"{messageCode}01", Languages.BrazilPortuguese, TypeMessage.Error, "O país de origem precisa ser informado conforme o código apresentado pelo ISO-3.");

            return managementMessages;
        });

        serviceCollection.AddSingleton<ManagementMessages<Language>>((serviceProvider) =>
        {
            var managementMessages = new ManagementMessages<Language>();
            var messageCode = nameof(Language).ToUpper().Substring(0, 3);

            managementMessages.AddMessage($"{messageCode}01", Languages.BrazilPortuguese, TypeMessage.Error, "A língua precisa estar em conformidade com as aceitas pelo software.");

            return managementMessages;
        });

        serviceCollection.AddSingleton<ManagementMessages<CompanyValueObjects.Name>>((serviceProvider) =>
        {
            var managementMessages = new ManagementMessages<CompanyValueObjects.Name>();
            var messageCode = nameof(CompanyValueObjects.Name).ToUpper().Substring(0, 3);

            managementMessages.AddMessage($"{messageCode}01", Languages.BrazilPortuguese, TypeMessage.Error, 
                $"É necessário que o nome real da companhia possua menos que {CompanyValueObjects.Name.MaxLength} caracteres.");
            managementMessages.AddMessage($"{messageCode}02", Languages.BrazilPortuguese, TypeMessage.Error,
                $"É necessário que o nome real da companhia possua mais que {CompanyValueObjects.Name.MinLength} caracteres.");

            return managementMessages;
        });


        #endregion

        #region Validations

        serviceCollection.AddSingleton<IValidation<Country>, CountryValidation>();
        serviceCollection.AddSingleton<IValidation<Language>, LanguageValidation>();

        #endregion

        return serviceCollection;
    }
}
