using Microsoft.Extensions.DependencyInjection;
using OVB.Demos.Libraries.Domain.Validations.Interfaces;
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

        serviceCollection.AddSingleton((serviceProvider) =>
        {
            var managementMessages = new ManagementMessages<Country>();
            var messageCode = nameof(Country).ToUpper().Substring(0, 3);

            managementMessages.AddMessage($"{messageCode}01", Languages.BrazilPortuguese, TypeMessage.Error, "O país de origem precisa ser informado conforme o código apresentado pelo ISO-3.");

            return managementMessages;
        });

        #endregion

        #region Validations

        serviceCollection.AddSingleton<IValidation<Country>, CountryValidation>();

        #endregion

        return serviceCollection;
    }
}
