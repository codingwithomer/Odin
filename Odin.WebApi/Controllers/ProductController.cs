using Microsoft.AspNetCore.Mvc;
using Odin.BLL.Services;
using Odin.Models;
using System.Collections.Generic;


namespace Odin.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        { 
            _productService = productService;
        }

        [HttpGet]
        public IEnumerable<ProductDTO> Get()
        {
            return _productService.GetProducts();
        }

        [HttpGet("{id}")]
        public ProductDTO Get(int id)
        {
            return _productService.GetProductById(id);
        }

        [HttpPost]
        public void Post([FromBody] ProductDTO productDTO)
        {
            _productService.CreateProduct(productDTO);
        }

        [HttpPut]
        public void Put([FromBody] ProductDTO productDTO)
        {
            _productService.Update(productDTO);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _productService.Delete(id);
        }
    }
}
