using Market.Data;

namespace Market
{
    public class ProductService : IProductService
    {
        public readonly IProductRepository productRepos;

        public ProductService(IProductRepository repository)
        {
            productRepos = repository;
        }

        public ProductDTO GetProductByName(string name)
        {
            var product = productRepos.GetProductByName(name);

            //use automaper for this
            var productDto = new ProductDTO()
            {
                Name = product.Name,
                Quantity = product.Quantity,
                Price = product.Price
            };

            return productDto;
        }

        public List<ProductDTO> GetAllProducts()
        {
            var products = productRepos.GetAllProducts();

            var productsDto = new List<ProductDTO>();
            products.ForEach(x => productsDto.Add(new ProductDTO()
            {
                Name = x.Name,
                Price = x.Price,
                Quantity = x.Quantity
            }));
            return productsDto;
        }

        public void InsertProduct(int id, string name, int quantity, decimal price)
        {
            productRepos.CreateProduct(id, name, quantity, price);
        }

        public void DeleteProduct(int id)
        {
            productRepos.DeleteProductById(id);
        }
    }
}
