using Market;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class GetProductsInfo :ControllerBase
    {
        private readonly IProductService _productService;

        public GetProductsInfo(IProductService productService)
        {
            _productService = productService;    
        }

        [HttpGet("name")]
        public ProductDTO GetProductByName(string name)
        {
            return _productService.GetProductByName(name);
        }

        [HttpGet(Name = "GetAllProducts")]
        public List<ProductDTO> GetAllProducts()
        {
            return _productService.GetAllProducts();
        }
    }
}
