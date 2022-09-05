using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Service.Abstractions.Services.Category;

namespace Shope.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">return category</response>
        /// <response code="404"> item not Found</response>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        => Ok(await _categoryService.GetByIdAsync(id));


        /// <summary>
        /// </summary>
        /// <response code="200">return category</response>
        /// <returns></returns>
        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _categoryService.GetAll());
        }
       


        /// <summary>
        /// 
        /// </summary>
        /// <response code="201">category created</response>
        /// <response code="409">category name alrady exsist</response>
        /// <param name="postDto"></param>
        /// <returns></returns>

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CategoryPostDto postDto)
        {
            await _categoryService.AddAsync(postDto);
            return StatusCode(201);
        }
        /// <summary>
        /// 
        /// </summary>
        ///      /// <response code="200">category created</response>
        /// <response code="409">category name alrady exsist</response>
        /// <response code="404">category  not found</response>
        /// <param name="id"></param>
        /// <param name="postDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CategoryPostDto postDto)
        {
            await _categoryService.UpdateAsync(id, postDto);
            return NoContent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <response code="404">category  not found</response>
        ///
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteAsync(id);
            return NoContent();
        }
    }
}
