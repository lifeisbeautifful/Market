using Z.Dapper.Plus;
using Market.Products;
using Microsoft.Data.SqlClient;


namespace Market.Data
{
    public class Helper
    {
        string connectionString = "Data source=DESKTOP-2G9K46F\\SQLEXPRESS;Initial Catalog=Products;Integrated Security=true;Encrypt=false;";

        public void BulkInsertProducts()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var products = new List<Product>()
                {
                    new()
                    {
                        Id = 1,Name = "Banana", Quantity = 400, Price = 45
                    },

                    new()
                    {
                        Id = 2, Name = "Apple", Quantity = 250, Price = 10
                    }
                };

                connection.BulkInsert(products);
            }
        }
    }
}
