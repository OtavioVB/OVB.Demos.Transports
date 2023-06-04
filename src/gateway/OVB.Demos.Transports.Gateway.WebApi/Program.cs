
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace OVB.Demos.Transports.Gateway.WebApi;

public static class Program
{
    public static void Main()
    {
        var builder = WebApplication.CreateBuilder();

        #region Internal ASP. NET Core 7 Configuration
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        #endregion

        #region API Versioning Configuration

        builder.Services.AddApiVersioning(opt =>
        {
            opt.DefaultApiVersion = new ApiVersion(1, 0);
            opt.AssumeDefaultVersionWhenUnspecified = true;
            opt.ReportApiVersions = true;
        });

        #endregion

        #region Authentication Jwt Configuration

        builder.Services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Gateway:Application:Authentication:Bearer:Token"] ?? string.Empty)),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });

        #endregion

        var app = builder.Build();

        #region Application Configuration

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();

        #endregion
    }
}