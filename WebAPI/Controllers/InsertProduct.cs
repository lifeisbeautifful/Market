using Market;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class InsertProduct
    {
        private readonly IProductService _productService;

        public InsertProduct(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost()]
        public void AddProduct([FromBody] ProductDTO product)
        {
            _productService.InsertProduct(product.Id, product.Name, product.Quantity,
                product.Price);
        }
    }
}
