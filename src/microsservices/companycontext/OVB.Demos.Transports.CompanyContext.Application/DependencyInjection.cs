using Microsoft.Extensions.DependencyInjection;
using OVB.Demos.Transports.CompanyContext.Application.Services.Internal.CompanyContext;
using OVB.Demos.Transports.Responses;
using OVB.Demos.Transports.Responses.ManagementMessages;

namespace OVB.Demos.Transports.CompanyContext.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddMicrosservicesCompanyContextApplicationDependenciesConfiguration(this IServiceCollection serviceCollection)
    {
        #region Management Error Messages

        serviceCollection.AddSingleton((serviceProvider) =>
        {
            var managementMessages = new ManagementMessages<CompanyService>();

            managementMessages.AddMessage("COM01", "pt-br", TypeMessage.Error, "A companhia já possui um cadastramento no nosso sistema com as informações fornecidas.");

            return managementMessages;
        });

        #endregion

        return serviceCollection;
    }
}
