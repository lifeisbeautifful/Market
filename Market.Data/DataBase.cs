using Dapper;
using Market.Products;
using System.Data;

namespace Market.Data
{
    public class DataBase 
    {
        private readonly DatabaseContext _context;

        public DataBase(DatabaseContext context)
        {
            _context = context;
        }

        public void CreateDatabase(string dbName)
        {
            var query = "SELECT * FROM sys.databases WHERE name = @name";
            var parameters = new DynamicParameters();
            parameters.Add("name", dbName);

            using (var connection = _context.CreateMasterConnection())
            {
                var records = connection.Query(query, parameters);
                if (!records.Any())
                {
                    connection.Execute($"CREATE DATABASE {dbName}");
                }
            }
        }
    }
}
