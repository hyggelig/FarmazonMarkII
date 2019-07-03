using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Farmazon.DAL;
using Farmazon.DAL.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace FarmazonMarkII.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        Logger logger = LogManager.GetCurrentClassLogger();
        private readonly IDataRepository<Products> _dataRepository;

        public ProductsController(IDataRepository<Products> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/Products
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<Products> products = _dataRepository.GetAll();
                return Ok(products);
            }
            catch (Exception ex)
            {
                logger.Error("An Error Occured During Processing Products Get Method." + ex.Message);
                return NoContent();
            }
        }

        // GET: api/Products/5
        [HttpGet("GetProduct/{id}", Name = "GetProduct")]
        public IActionResult Get(long id)
        {
            try
            {
                Products product = _dataRepository.Get(id);

                if (product == null)
                {
                    return NotFound("The Product record couldn't be found.");
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                logger.Error("An Error Occured During Processing GetUser Method." + ex.Message);
                return new ObjectResult("Something Went Wrong During Processing Getting Product Via Id") { StatusCode = 500 };
            }
        }

        // GET : api/products/getproductsbyowner/1/enes/ecer
        [HttpGet("GetProductsByOwner/{ownerID}/{ownerName}/{ownerLastName}", Name = "GetProductsByOwner")]
        public IActionResult GetProductsByOwner(long ownerID, string ownerName, string ownerLastName)
        {
            try
            {
                IEnumerable<Products> products = _dataRepository.GetUsersProducts(ownerID, ownerName, ownerLastName);

                if (products == null)
                {
                    return NotFound("No products were found belongs to this user");
                }

                return Ok(products);
            }
            catch (Exception ex)
            {
                logger.Error("An Error Occured During Processing GetProductsByOwner Method." + ex.Message);
                return NoContent();
            }

        }

        // POST: api/Products
        [HttpPost]
        public IActionResult Post([FromBody] Products product)
        {
            if (product == null)
            {
                return BadRequest("Product is null.");
            }

            try
            {
                _dataRepository.Create(product);
                return CreatedAtRoute(
                      "Get",
                      new { Id = product.productId },
                      product);
            }
            catch (Exception ex)
            {
                logger.Error("An Error Occured During Processing Products Post Method." + ex.Message);
                return new ObjectResult("Something Went Wrong During Processing Products Post Method") { StatusCode = 500 };
            }
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Products product)
        {
            if (product == null)
            {
                return BadRequest("Product is null.");
            }

            try
            {
                Products productToUpdate = _dataRepository.Get(id);
                if (productToUpdate == null)
                {
                    return NotFound("The Product record couldn't be found.");
                }

                _dataRepository.Update(productToUpdate, product);
                return NoContent();
            }
            catch (Exception ex)
            {
                logger.Error("An Error Occured During Processing Products Put(ID) Method." + ex.Message);
                return NoContent();
            }
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            try
            {
                Products product = _dataRepository.Get(id);
                if (product == null)
                {
                    return NotFound("The Product record couldn't be found.");
                }

                _dataRepository.Delete(product);
                return NoContent();
            }
            catch (Exception ex)
            {
                logger.Error("An Error Occured During Processing Products Delete Method." + ex.Message);
                return NoContent();
            }
        }
    }
}