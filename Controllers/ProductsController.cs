using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BurnRed.Data;
using BurnRed.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BurnRed.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Produces("application/json")]
    
    public class ProductsController : ControllerBase
    {
        private readonly IRedRepository _repository;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IRedRepository repository, ILogger<ProductsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<Product>> Get()
        {
            try 
            {
                return Ok(_repository.GetAllProducts());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to return products: {ex}");
                return BadRequest("Failed to return products");

            }
        }




       
    }
}
