using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using OVB.Demos.Transports.Domain.CompanyContext.Builders;
using OVB.Demos.Transports.Domain.CompanyContext.Builders.Interfaces;
using OVB.Demos.Transports.Domain.CompanyContext.Validators;
using OVB.Demos.Transports.Domain.CompanyContext.ValueObjects;

namespace OVB.Demos.Transports.Domain;

public static class DependencyInjection
{
    public static IServiceCollection AddDomainDependenciesConfiguration(this IServiceCollection serviceCollection)
    {
        #region Validators
        serviceCollection.AddSingleton<AbstractValidator<CompanyValueObjects.Name>, CompanyValidators.NameValidator>();
        serviceCollection.AddSingleton<AbstractValidator<CompanyValueObjects.PlatformName>, CompanyValidators.PlatformNameValidator>();
        serviceCollection.AddSingleton<AbstractValidator<CompanyValueObjects.Cnpj>, CompanyValidators.CnpjValidator>();
        #endregion

        #region Builders
        serviceCollection.AddSingleton<IBuilderCompany, BuilderCompany>();
        #endregion

        return serviceCollection;
    }
}
