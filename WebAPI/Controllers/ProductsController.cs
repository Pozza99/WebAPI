using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebAPI.Models;
using WebAppAPI;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")] //richiamo i metodi qui dentro che uso nella pagina 
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _productsRepository;
        public ProductsController(IConfiguration configuration , IProductsRepository productsRepository) //aggiungo
        {
            _productsRepository = productsRepository;
        }

        public IEnumerable<ProductModel> Get()
        {
            return _productsRepository.Get().Select(p => new ProductModel(p.Id, p.Code, p.Name)); //per ogni prodotto crea un nuovo Product Model
        }

        /*[HttpGet("{id}")] //per recuperare l'id dal url   [HttpGet("{id}/{code}")] recupero anche il code
        public ProductModel Get(int id)
        {
            return new ProductModel(id, $"ABC {id}", $"Prodotto {id}"); //mi stampa il prodotto con l'id recuperato
        }*/

            [HttpGet("{id}")]
        public ActionResult<ProductModel> Get(int id) //per utilizzare gli status code questo metodo
        {
            var product = _productsRepository.GetById(id);
            if (product == null) //controllo se esiste
                return NotFound();

            return Ok(new ProductModel(product.Id, product.Code, product.Name));
        }

        [HttpGet("search")] // api/products/search?filterText=abc //lo cerca in query string perche non è tra le parentesi
        public IEnumerable<ProductModel> Search(string filterText)
        {
            return null;
        }

        [HttpPost]
        public ActionResult Post(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public ActionResult Put (int id, ProductModel model)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete (int id)
        {
            return Ok();
        }

    }
}