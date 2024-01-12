using Dapper;
using Market.Products;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Market.Data
{
    public class ProductRepository : IProductRepository
    {
        private string connectionString =
            @"Data source=DESKTOP-2G9K46F\SQLEXPRESS;Initial Catalog=Products;Integrated Security=true;Encrypt=false;";
        private readonly DatabaseContext _context;

        public ProductRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Product GetProductByName(string name)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                DynamicParameters prName = new DynamicParameters();
                prName.Add("ProductName", name);

                return connection.Query<Product>("GetProductByName", param: prName, commandType: CommandType.StoredProcedure).FirstOrDefault();

            }
        }

        public List<Product> GetAllProducts()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Product>("GetAllProducts",
                    commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public void CreateProduct(int id, string name, int quantity, decimal price)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                DynamicParameters paramet = new DynamicParameters();
                paramet.Add("Id", id);
                paramet.Add("Name", name);
                paramet.Add("Quantity", quantity);
                paramet.Add("Price", price);

                var inserTedProduct = connection.Query("InsertProduct", param: paramet,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteProductById(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                DynamicParameters paramet = new DynamicParameters();
                paramet.Add("Id", id);

                connection.Query("DeleteProductById", param: paramet,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
