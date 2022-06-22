using Microsoft.AspNetCore.Mvc;
using pizza_mama.Data;
using pizza_mama.Models;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace pizza_mama.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiController : Controller
    {
        DataContext dataContext;
        public ApiController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        // GET: api/<ApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        // GET: api/<ApiController>
        [HttpGet]
        [Route("GetPizzas")]
        public IActionResult GetPizzas()
        {
            /*
            var pizza = new Pizza()
            { nom = " Pizzatest", prix = 8, vegetarienne = false,
                ingredients = "Tomate, ognons, oeuf" };
            */
           var pizza =  dataContext.Pizzas.ToList();

            return Json(pizza);
        }

    }
}
