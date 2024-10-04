using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaShopController.models;



namespace PizzaShopController
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        public PizzaController() { }
        [HttpGet]
        public ActionResult<List<Pizza>> Get() => PizzaService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Pizza> Get(int id)
        {
            var pizza = PizzaService.Get(id);

            if (pizza == null)
                return NotFound();
            

            return pizza;
        }
        [Authorize]
        [HttpPost]
        public ActionResult Post(Pizza pizza)
        {
            if (pizza == null) return BadRequest();
            if (PizzaService.FindSameName(pizza)) return BadRequest();
            PizzaService.Add(pizza);
            return Ok();
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if(!PizzaService.Delete(id)) return BadRequest();
            return Ok();
        }
        [HttpPut]
        public ActionResult Put(Pizza pizza)
        {
            if(pizza == null) { return BadRequest(); }
            if (!PizzaService.Update(pizza)) { return BadRequest(); }
            return Ok();
        }
    }

}
