using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}