using MongoDB.Driver;

namespace OVB.Demos.Libraries.MongoDb.Base.Connection;

public sealed class MongoDbConnection
{
    private string ConnectionString { get; init; }

    public MongoDbConnection(string connectionString)
    {
        ConnectionString = connectionString;
    }
}
