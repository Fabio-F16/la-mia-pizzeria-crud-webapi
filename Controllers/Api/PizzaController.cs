using la_mia_pizzeria_static.Database;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static.Controllers.Api
{
    [Route("api/pizze")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        [HttpGet]
        [Route("get")]
        public IActionResult Get()
        {
            PizzaContext context = new PizzaContext();

            IQueryable<Pizza> listaPizze = context.Pizze.Include(p => p.Categoria);

            return Ok(listaPizze);
        }
    }
}
