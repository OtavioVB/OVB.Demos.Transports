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

        serviceCollection.AddSingleton<ManagementMessages<CompanyService>>((serviceProvider) =>
        {
            var managementMessages = new ManagementMessages<CompanyService>();

            managementMessages.AddMessage("COM01", "PT-BR", TypeMessage.Error, "A companhia já possui um cadastramento no nosso sistema com as informações fornecidas.");
            managementMessages.AddMessage("COM01", "EN-US", TypeMessage.Error, "The company has registration in our system with the information provided.");
            managementMessages.AddMessage("COM01", "ES-ES", TypeMessage.Error, "La empresa ya cuenta con un registro en nuestro sistema con la información brindada");

            return managementMessages;
        });

        #endregion

        return serviceCollection;
    }
}
