using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using webapi.DAL;
using webapi.Model;

namespace webapi.Controllers
{
  
    [Route("api/product")]
    public class ProductsController : Controller
    {
        private readonly IProductRepository productRepository;

     
        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            return productRepository.List();
        }
        

        [HttpHead("{id}")]
        public IActionResult Head(int id)
        {
            var product = productRepository.GetById(id);

            if (product == null) return NotFound();

            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = productRepository.GetById(id);

            if (product == null) return NotFound();

            return Ok(product);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {

            if (productRepository.List()
                                 .Any(p => p
                                          .Name
                                          .ToLower() == product.Name.ToLower())) return Conflict($"A '{product.Name}' nevű termék már létezik.");

            productRepository.Add(product);

            return CreatedAtAction(nameof(Get), new { id = product.ID }, product); ;
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            var existingProduct = productRepository.GetById(id);
            if (existingProduct == null) return NotFound();
            productRepository.Update(id, product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool delete = productRepository.Delete(id);
            if (delete) return NoContent(); 
            else return NotFound();
        }
        [HttpGet("-/count")]
        public ActionResult<CountResult> GetCount()
        {
            var productCount = productRepository.List().Count;

            var result = new CountResult
            {
                Count = productCount
            };

            return Ok(result);
        }
    }
}