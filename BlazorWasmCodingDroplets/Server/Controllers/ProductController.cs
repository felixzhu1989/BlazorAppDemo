using BlazorWasmCodingDroplets.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWasmCodingDroplets.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _service;
        public ProductController(ProductService service)
        {
            _service = service;
        }
        [HttpGet("All")]
        public ActionResult<List<Product>> GetProducts()
        {
           return _service.GetProducts();
        }

        [HttpGet]
        public ActionResult<Product> GetProduct(string productCode)
        {
            return _service.GetProduct(productCode);
        }

        [HttpPost]
        public ActionResult AddProduct([FromBody] Product product)
        {
            _service.AddProduct(product);
            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteProduct(string productCode)
        {
            _service.DeleteProduct(productCode);
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateProduct([FromBody]Product product)
        {
            _service.UpdateProduct(product);
            return Ok();
        }
    }
}
