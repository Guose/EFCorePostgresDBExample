using LinqToDB.Common;
using LinqToDB.Configuration;

namespace NinjaDomain.WebApi.Helpers
{
    public class ConnectionHelper : ILinqToDBSettings
    {
        public IEnumerable<IDataProviderSettings> DataProviders => Enumerable.Empty<IDataProviderSettings>();

        public string? DefaultConfiguration => 
            "User ID=adminUser;" +
            "Password=adminUser;" +
            "Server=localhost;" +
            "Port=5432;" +
            "Database=NinjaDomain;" +
            "Integrated Security=true;" +
            "Pooling=true;";

        public string? DefaultDataProvider => throw new NotImplementedException();

        public IEnumerable<IConnectionStringSettings> ConnectionStrings => throw new NotImplementedException();
    }
}
