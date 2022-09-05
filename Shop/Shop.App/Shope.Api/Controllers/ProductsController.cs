using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Shope.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            ProductGetDto data = await _productService.GetByIdAsync(id);
          return Ok(data);
        }
       



        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
         => Ok(await _productService.GetAll());



        [HttpPost("Create")]
        public async Task<IActionResult> Create(ProductPostDto postDto)
        {

            await _productService.AddAsync(postDto);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductPostDto postDto)
        {
            await _productService.UpdateAsync(id, postDto);
            return NoContent();
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteAsync(id);
            return NoContent();
        }



    }
}
