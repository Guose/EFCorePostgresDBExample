using LinqToDB.Configuration;

namespace NinjaDomain.Data.Data
{
    internal partial class DataProvider : NinjaContext
    {
        public DataProvider(LinqToDBConnectionOptions<NinjaContext> options) : base(options)
        {
        }
    }
}
