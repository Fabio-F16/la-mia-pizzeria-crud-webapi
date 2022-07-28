using la_mia_pizzeria_static.Database;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static.Controllers.Api
{
    [Route("api/message")]
    [ApiController]
    public class MessageController : ControllerBase
    {

        [HttpPost]
      public IActionResult Post( Message message)
        {

            try
            {
                using (PizzaContext context = new PizzaContext())
                {
                    context.Messages.Add(message);
                    context.SaveChanges();
                }
                return Ok(new {Status = "ok", Message = "Dati corretti"});
            }
            catch (Exception)
            {

                return BadRequest();
            }
           
        }
       
    }
}

