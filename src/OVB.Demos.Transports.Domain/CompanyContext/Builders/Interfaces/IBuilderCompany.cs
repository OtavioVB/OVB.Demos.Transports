using OVB.Demos.Transports.Domain.CompanyContext.Contracts;
using OVB.Demos.Transports.Domain.CompanyContext.Entities.Base;
using OVB.Demos.Transports.Domain.CompanyContext.ENUMs;

namespace OVB.Demos.Transports.Domain.CompanyContext.Builders.Interfaces;

public interface IBuilderCompany
{
    public CompanyBase BuildCompanyAccordingToHisType(TypeCompany typeCompany);
    public ICompanyContract BuildCompanyContractAccordingToHisType(TypeCompany typeCompany);
}
