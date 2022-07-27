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
        public IActionResult Get(string? search)
        {
            PizzaContext context = new PizzaContext();
            IQueryable<Pizza> listaPizze = context.Pizze.Include(p => p.Categoria);

            if (search != null && search !="")
            {
                listaPizze = listaPizze.Where(p => p.Name.ToLower().Contains(search)).Include(p => p.Categoria);
            }

            return Ok(listaPizze.ToList());
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using (PizzaContext context = new PizzaContext())
            {
                Pizza current = context.Pizze.Where(pizza => pizza.ID == id).Include(p => p.Categoria).Include(p => p.ListaIngredienti).FirstOrDefault();
                
                if (current == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(current);
                }
            }

        }
    }
}

