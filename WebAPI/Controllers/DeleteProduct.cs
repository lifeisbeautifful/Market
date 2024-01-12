using Market;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class DeleteProduct
    {
        private readonly IProductService _productService;

        public DeleteProduct(IProductService productService)
        {
            _productService = productService;
        }

        [HttpDelete("id")]
        public void DeleteProductById(int id)
        {
            _productService.DeleteProduct(id);
        }
    }
}
