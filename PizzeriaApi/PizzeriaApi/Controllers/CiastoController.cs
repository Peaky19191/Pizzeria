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
    }
}