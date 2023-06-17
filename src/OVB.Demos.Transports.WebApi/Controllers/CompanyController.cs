using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OVB.Demos.Transports.Application.UseCases.CompanyContext.ImportBatchCompanies.Inputs;
using OVB.Demos.Transports.Application.UseCases.CompanyContext.ImportBatchCompanies.Outputs;
using OVB.Demos.Transports.Application.UseCases.Interfaces;
using OVB.Demos.Transports.Domain.Results;
using OVB.Demos.Transports.Domain.Results.Interfaces;

namespace OVB.Demos.Transports.WebApi.Controllers;

[ApiController]
[Route("api/v1/companies")]
public class CompanyController : ControllerBase
{
    [HttpPost]
    [Consumes("multipart/form-data")]
    [RequestSizeLimit(104_858)] // 100kb
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
    [Route("BatchImport")]
    [AllowAnonymous]
    public async Task<IActionResult> ImportBatchCompaniesAsync(
        [FromHeader] string authorizationCode,
        [FromServices] IUseCase<ImportBatchCompaniesUseCaseInput, ICommandCompleteResult<ImportBatchCompaniesUseCaseSuccessfullResponse, 
            ImportBatchCompaniesUseCaseErrorfullResponse>> useCase,
        [FromForm] IFormFile file,
        CancellationToken cancellationToken)
    {
        if (ModelState.IsValid == false)
            return StatusCode(StatusCodes.Status422UnprocessableEntity, "The state of model to request is not valid.");

        var useCaseResponse = await useCase.ExecuteUseCaseAsync(
            input: new ImportBatchCompaniesUseCaseInput(
                authorization: authorizationCode,
                file: file),
            cancellationToken: cancellationToken);

        if (useCaseResponse.GetResultState() == StateResult.SuccessfullResult)
            return StatusCode(StatusCodes.Status201Created, useCaseResponse.GetSuccessfullCommandResult());
        else
            return StatusCode(StatusCodes.Status400BadRequest, useCaseResponse.GetErrorCommandResult());
    }
}