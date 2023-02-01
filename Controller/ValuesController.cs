using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using WebApplication.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ValuesController : Controller
    {
        DataContext dataContext;
        public ValuesController(DataContext dataContext) 
        {
            this.dataContext = dataContext;
        }
        
        [HttpGet]
        [Route("GetProduit")]
        public IActionResult GetProduit()
        {
            var produit = dataContext.Produits.ToList();

            //var produit = new Produit () { Nom = "vintest", PrixUnitaire = "50" };
            return Json(produit);
        }

        /*// GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
