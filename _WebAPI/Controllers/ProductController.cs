using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        //Loosely coupled --> Gevşek Bağlılık(Bağımlılık soyut sınıfa olunca oluşur.)
        IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]

        public List<Product> Get()
        {
            //Dependency chain-->Bağımlılık zinciri

            var result = _productService.GetAll(); 
            return result.Data; 
        }
    }
}
