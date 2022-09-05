using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Stock.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsStockController : ControllerBase
    {
        private readonly IProductStockService _productStockService;

        public ProductsStockController(IProductStockService productStockService)
        {
            _productStockService = productStockService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            ProductStockGetDto productStockGet = await _productStockService.GetAsync(id);
            return Ok(productStockGet);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Add(ProductStockPostDto postDto)
        {
            await _productStockService.AddAsync(postDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productStockService.RemoveAsync(id);
            return NoContent();
        }


    }
}
