using OVB.Demos.Transports.Application.Services.Business.CompanyContext.Inputs;
using OVB.Demos.Transports.Application.Services.Business.CompanyContext.Interfaces;
using OVB.Demos.Transports.Application.Services.Business.CompanyContext.Outputs;
using OVB.Demos.Transports.Domain.Results;
using OVB.Demos.Transports.Domain.Results.Interfaces;

namespace OVB.Demos.Transports.Application.Services.Business.CompanyContext;

public sealed class CompanyService : ICompanyService
{
    public async Task<ICommandResult<IReadOnlyCollection<CompanyBaseModel>>> ConvertFileToCompanyBaseModelServiceAsync(
        ConvertFileToCompanyBaseModelServiceInput input, CancellationToken cancellationToken)
    {
        var response = new CommandResult<IReadOnlyCollection<CompanyBaseModel>>();

        using var fileStream = File.Create(input.Path);
        await input.File.CopyToAsync(fileStream);
        await fileStream.FlushAsync(cancellationToken);

        var companies = new List<CompanyBaseModel>();

        var lines = await File.ReadAllLinesAsync(input.Path, cancellationToken);
        foreach (var line in lines)
        {
            var lineInformationSplitted = line.Split(input.SeparatorCharacter);
            companies.Add(new CompanyBaseModel(lineInformationSplitted[0], lineInformationSplitted[1], lineInformationSplitted[2]));
        }
            
        return response;
    }
}
