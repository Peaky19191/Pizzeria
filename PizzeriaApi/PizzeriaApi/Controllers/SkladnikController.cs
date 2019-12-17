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
    public class SkladnikController : ControllerBase
    {
        private s15509Context _context;
        public SkladnikController(s15509Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetSkladnik()
        {
            return Ok(_context.Skladnik.ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetSkladnik(int id)
        {
            var skladnik = _context.Skladnik.FirstOrDefault(e => e.IdSkladnik == id);
            if (skladnik == null)
            {
                return NotFound();
            }
            return Ok(skladnik);
        }

        [HttpPost]
        public IActionResult Create(Skladnik newSkladnik)
        {
            _context.Skladnik.Add(newSkladnik);
            _context.SaveChanges();

            return StatusCode(201, newSkladnik); //201, 202
        }

        [HttpPut]
        public IActionResult Update(Skladnik updatedSkladnik)
        {
            if (_context.Skladnik.Count(e => e.IdSkladnik == updatedSkladnik.IdSkladnik) == 0)
            {
                return NotFound();
            }

            _context.Skladnik.Attach(updatedSkladnik);
            _context.Entry(updatedSkladnik).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedSkladnik);
        }

        [HttpDelete("{idskladnik:int}")]
        public IActionResult Delete(int idSkladnik)
        {
            var skladnik = _context.Skladnik.FirstOrDefault(e => e.IdSkladnik == idSkladnik);

            if (skladnik == null)
            {
                return NotFound();
            }

            _context.Skladnik.Remove(skladnik);
            _context.SaveChanges();
            return Ok(skladnik);
        }
    }
}