using OVB.Demos.Transports.Application.Services.Business.CompanyContext.Inputs;
using OVB.Demos.Transports.Application.Services.Business.CompanyContext.Interfaces;
using OVB.Demos.Transports.Application.Services.Business.CompanyContext.Outputs;
using OVB.Demos.Transports.Domain.Results;
using OVB.Demos.Transports.Domain.Results.Interfaces;

namespace OVB.Demos.Transports.Application.Services.Business.CompanyContext;

public sealed class CompanyService : ICompanyService
{
    public async Task<ICommandResult<IEnumerable<CompanyBaseModel>>> ConvertFileToCompanyBaseModelServiceAsync(
        ConvertFileToCompanyBaseModelServiceInput input, CancellationToken cancellationToken)
    {
        var response = new CommandResult<IEnumerable<CompanyBaseModel>>();

        var path = Path.Combine(Environment.CurrentDirectory, "archives_temp", input.File.FileName);
        using var fileStream = File.Create(path);
        await input.File.CopyToAsync(fileStream);
        await fileStream.FlushAsync(cancellationToken);

        var companies = new List<CompanyBaseModel>();

        var lines = await File.ReadAllLinesAsync(path, cancellationToken);
        foreach (var line in lines)
        {
            var lineInformationSplitted = line.Split(",");
            companies.Add(new CompanyBaseModel(lineInformationSplitted[0], lineInformationSplitted[1], lineInformationSplitted[2]));
        }
            
        
        return response;
    }
}
