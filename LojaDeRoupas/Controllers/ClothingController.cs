using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaDeRoupas.Data;
using LojaDeRoupas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            return await _context.Clothings.ToListAsync();
        }

        // GET: api/Clothing/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<Clothing>> Get(int id)
        {
            try
            {
                var clothing = await _context.Clothings
                    .Include(c => c.ClothingColors)
                    .ThenInclude(cc => cc.Color)
                    .FirstOrDefaultAsync(c => c.Id == id);

                if (clothing == null)
                {
                    return NotFound();
                }

                return Ok(clothing);
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
                // Adicione as cores à peça de roupa antes de salvá-la
                foreach (var clothingColor in clothing.ClothingColors)
                {
                    clothingColor.Color = await _context.Colors.FindAsync(clothingColor.ColorId);
                }
                
                _context.Clothings.Add(clothing);
                await _context.SaveChangesAsync();

                return CreatedAtAction("Get", new { id = clothing.Id }, clothing);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        // PUT: api/Clothing/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Clothing>> Put(int id, [FromBody] Clothing clothing)
        {
            try
            {
                var clothings = await _context.Clothings.FindAsync(id);
                if (clothings == null)
                {
                    return NotFound("Não existe esse ID");
                }

                _context.Entry(clothings).CurrentValues.SetValues(clothing);
                await _context.SaveChangesAsync();
                return Ok(clothings);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        // DELETE: api/Clothing/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Clothing>> Delete(int id)
        {
            var clothing = await _context.Clothings.FindAsync(id);
            if (clothing == null)
            {
                return NotFound("não existe esse ID");
            }

            _context.Clothings.Remove(clothing);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}