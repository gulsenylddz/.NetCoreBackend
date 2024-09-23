using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        //Loosely coupled --> Gevşek Bağlılık(Bağımlılık soyut sınıfa olunca oluşur.)
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]

        public IActionResult Get() 
        {
            //Dependency chain-->Bağımlılık zinciri

            var result = _productService.GetAll();

            if (result.Success==true)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpGet("getbyid")]

        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);  
        }

        [HttpPost("add")]
        public IActionResult Post(Product product)
        {
            var result = _productService.Add(product);

            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }

}
