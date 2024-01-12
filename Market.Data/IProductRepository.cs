using Market.Products;

namespace Market.Data
{
    public interface IProductRepository
    {
        Product GetProductByName(string name);
        List<Product> GetAllProducts();
        void CreateProduct(int id, string name, int quantity, decimal price);
        void DeleteProductById(int id);
    }
}
