using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OVB.Demos.Transports.WebApi.Controllers;

[ApiController]
[Route("api/v1/companies")]
public class CompanyController : ControllerBase
{
    [HttpPost]
    [Consumes("multipart/form-data")]
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
        [FromForm] IFormFile file,
        CancellationToken cancellationToken)
    {
        return await Task.FromResult(StatusCode(StatusCodes.Status503ServiceUnavailable));
    }
}