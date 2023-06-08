using OVB.Demos.Transports.CompanyContext.Infrascructure;
using OVB.Demos.Transports.CompanyContext.WebGrpc.Services;

namespace OVB.Demos.Transports.CompanyContext.WebGrpc;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddGrpc();

        #region Infrascructure Configuration
        builder.Services.AddMicrosservicesCompanyContextInfrascructureDependenciesConfiguration();
        #endregion

        var app = builder.Build();
        app.MapGrpcService<GreeterService>();
        app.Run();
    }
}