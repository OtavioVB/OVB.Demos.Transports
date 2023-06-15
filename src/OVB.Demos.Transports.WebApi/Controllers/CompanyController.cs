using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace OVB.Demos.Transports.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CompanyController : ControllerBase
{
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
    [AllowAnonymous]
    public async Task<IActionResult> ImportBatchCompaniesAsync(
        CancellationToken cancellationToken)
    {
        return await Task.FromResult(StatusCode(StatusCodes.Status503ServiceUnavailable));
    }
}