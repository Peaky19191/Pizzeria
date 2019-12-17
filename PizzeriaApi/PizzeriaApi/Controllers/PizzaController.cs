using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzeriaApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace PizzeriaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private s15509Context _context;
        public PizzaController(s15509Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetPizza()
        {
            return Ok(_context.Pizza.ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetPizza(int id)
        {
            var pizza = _context.Pizza.FirstOrDefault(e => e.IdPizza == id);
            if (pizza == null)
            {
                return NotFound();
            }
            return Ok(pizza);
        }
  
        [HttpPost]
        public IActionResult Create(Pizza newPizza)
        {
            _context.Pizza.Add(newPizza);
            _context.SaveChanges();

            return StatusCode(201, newPizza); //201, 202
        }

        [HttpPut]
        public IActionResult Update(Pizza updatedPizza)
        {
            if (_context.Pizza.Count(e => e.IdPizza == updatedPizza.IdPizza) == 0)
            {
                return NotFound();
            }

            _context.Pizza.Attach(updatedPizza);
            _context.Entry(updatedPizza).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedPizza);
        }

        [HttpDelete("{idpizza:int}")]
        public IActionResult Delete(int idPizza)
        {
            var pizza = _context.Pizza.FirstOrDefault(e => e.IdPizza == idPizza);

            if (pizza == null)
            {
                return NotFound();
            }

            _context.Pizza.Remove(pizza);
            _context.SaveChanges();
            return Ok(pizza);
        }
    }
}