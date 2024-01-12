using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Market.Data
{
    public class DatabaseContext
    {
        private readonly IConfiguration _configuration;

        public DatabaseContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection CreateMasterConnection()
            => new SqlConnection(_configuration.GetConnectionString("Master"));

        public IDbConnection CreateProductConnection()
            => new SqlConnection(_configuration.GetConnectionString("Products"));
    }
}
