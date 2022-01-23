using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using Web2.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        [ProducesResponseType(200)]
        public IEnumerable<Product> GetList()
        {
            return new Product[] { new Product { Id = 1, Name = "Console Nintendo Switch", Description = "Dernière génération des consoles de la marque Nintedo." } };
        }

        /// <summary>
        /// Retourner le produit en fonction du ID.
        /// </summary>
        /// <param name="id">Identifiant unique du produit</param>
        /// <returns></returns>
        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public ActionResult<Product> Get(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            return Ok(new Product { Id = 1, Name = "Console Nintendo Switch", Description = "Dernière génération des consoles de la marque Nintedo." });
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] string product)
        {
            var newProduct = new Product { Id = 1, Name = "Console Nintendo Switch", Description = "Dernière génération des consoles de la marque Nintedo." };
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}
