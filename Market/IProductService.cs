namespace Market
{
    public interface IProductService
    {
        ProductDTO GetProductByName(string name);
        List<ProductDTO> GetAllProducts();
        void InsertProduct(int id, string name, int quantity, decimal price);
        void DeleteProduct(int id);
    }
}
