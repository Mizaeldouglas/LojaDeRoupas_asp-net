using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaDeRoupas.Data;
using LojaDeRoupas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaDeRoupas.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClothingController : ControllerBase
    {

        private readonly AppDbContext _context;

        public ClothingController(AppDbContext context)
        {
            _context = context;
        }


        // GET: api/Clothing
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clothing>>> Get()
        {
            var clothings = await _context.Clothings.FindAsync();
            try
            {
                return Ok(clothings);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        // GET: api/Clothing/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<Clothing>> Get(int id)
        {
            try
            {
                var clothings = await _context.Clothings.FindAsync(id);

                if (clothings == null)
                {
                    return NotFound();
                }

                return Ok(clothings);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        // POST: api/Clothing
        [HttpPost]
        public async Task<ActionResult<Clothing>> Post([FromBody] Clothing clothing)
        {
            try
            {
                var clothings = await _context.Clothings.AddAsync(clothing);
                await _context.SaveChangesAsync();
                return Ok(clothings);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        // PUT: api/Clothing/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Clothing/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
