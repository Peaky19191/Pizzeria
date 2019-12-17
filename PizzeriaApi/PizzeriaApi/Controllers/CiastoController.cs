using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzeriaApi.Models;

namespace PizzeriaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CiastoController : ControllerBase
    {
        private s15509Context _context;
        public CiastoController(s15509Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCiasto()
        {
            return Ok(_context.Ciasto.ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetCiasto(int id)
        {
            var ciasto = _context.Ciasto.FirstOrDefault(e => e.IdCiasta == id);
            if (ciasto == null)
            {
                return NotFound();
            }
            return Ok(ciasto);
        }

        [HttpPost]
        public IActionResult Create(Ciasto newCiasto)
        {
            _context.Ciasto.Add(newCiasto);
            _context.SaveChanges();

            return StatusCode(201, newCiasto); //201, 202
        }

        [HttpPut]
        public IActionResult Update(Ciasto updatedCiasto)
        {
            if (_context.Ciasto.Count(e => e.IdCiasta == updatedCiasto.IdCiasta) == 0)
            {
                return NotFound();
            }

            _context.Ciasto.Attach(updatedCiasto);
            _context.Entry(updatedCiasto).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedCiasto);
        }

        [HttpDelete("{idciasta:int}")]
        public IActionResult Delete(int idCiasta)
        {
            var ciasto = _context.Ciasto.FirstOrDefault(e => e.IdCiasta == idCiasta);

            if (ciasto == null)
            {
                return NotFound();
            }

            _context.Ciasto.Remove(ciasto);
            _context.SaveChanges();
            return Ok(ciasto);
        }
    }
}