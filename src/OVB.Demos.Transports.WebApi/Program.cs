
using OVB.Demos.Transports.Domain;
using OVB.Demos.Transports.Infrascructure;

namespace OVB.Demos.Transports.WebApi;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        #region Domain Configuration

        builder.Services.AddDomainDependenciesConfiguration();

        #endregion

        #region Infrascructure Configuration

        builder.Services.AddInfrascructureDependenciesConfiguration(builder.Configuration["ConnectionString"]);

        #endregion

        builder.Services.AddControllers();

        var app = builder.Build();

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}