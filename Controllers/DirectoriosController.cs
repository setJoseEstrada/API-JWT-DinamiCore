using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DynamiCore.Models;
using Microsoft.AspNetCore.Authorization;

namespace DynamiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class DirectoriosController : ControllerBase
    {
        private readonly DynamicoreContext _context;

        public DirectoriosController(DynamicoreContext context)
        {
            _context = context;
        }

        // GET: api/Directorios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Directorio>>> GetDirectorios()
        {
            var muestro = await _context.Directorios.Select(datos => new{

                datos.Id,
                datos.IdUsuario,
                datos.IdContacto,
                NombreUsuario = datos.IdUsuarioNavigation.Nombre,
                NombreContacto = datos.IdContactoNavigation.Nombre,
                Correo = datos.IdContactoNavigation.Correo

            }).ToListAsync();


            return Ok(muestro);
        }

        // GET: api/Directorios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Directorio>> GetDirectorio(int id)
        {
            //var directorio = await _context.Directorios.FindAsync(id);
            var muestro = await _context.Directorios.Select(datos => new {

                datos.Id,
                datos.IdUsuario,
                datos.IdContacto,
                NombreUsuario = datos.IdUsuarioNavigation.Nombre,
                NombreContacto = datos.IdContactoNavigation.Nombre,
                Correo = datos.IdContactoNavigation.Correo

            }).FirstOrDefaultAsync(x=>x.Id==id);


            

            if (muestro == null)
            {
                return NotFound();
            }

            return Ok(muestro);
        }

        // PUT: api/Directorios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDirectorio(int id, Directorio directorio)
        {
            if (id != directorio.Id)
            {
                return BadRequest();
            }

            _context.Entry(directorio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DirectorioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Directorios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Directorio>> PostDirectorio(Directorio directorio)
        {
            _context.Directorios.Add(directorio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDirectorio", new { id = directorio.Id }, directorio);
        }

        // DELETE: api/Directorios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDirectorio(int id)
        {
            var directorio = await _context.Directorios.FindAsync(id);
            if (directorio == null)
            {
                return NotFound();
            }

            _context.Directorios.Remove(directorio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DirectorioExists(int id)
        {
            return _context.Directorios.Any(e => e.Id == id);
        }
    }
}
