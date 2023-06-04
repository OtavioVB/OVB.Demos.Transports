using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OVB.Demos.Transports.Gateway.WebApi.Controllers.CompanyContext.Payloads;
using System.Net.Mime;

namespace OVB.Demos.Transports.Gateway.WebApi.Controllers.CompanyContext;

[ApiVersion("1")]
[Route("api/gateway/v{version:apiVersion}/management/[controller]")]
[ApiController]
public sealed class CompanyController : ControllerBase
{
    [HttpPost]
    [Route("Create")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
    [AllowAnonymous]
    public async Task<IActionResult> CreateAsync(
        CancellationToken cancellationToken)
    {
        throw new Exception();
    }

    [HttpPost]
    [Route("BatchImport")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
    [AllowAnonymous]
    public async Task<IActionResult> BatchImportCompaniesAsync(
        [FromHeader] string sourcePlatform,
        [FromBody] BatchImportCompaniesPayloadInput input,   
        CancellationToken cancellationToken)
    {
        throw new Exception();
    }
}
