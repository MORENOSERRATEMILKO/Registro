using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Registro.Data;
using Registro.Models;

namespace Registro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIEstudiantes1Controller : ControllerBase
    {
        private readonly DataDbContext _context;

        public APIEstudiantes1Controller(DataDbContext context)
        {
            _context = context;
        }

        // GET: api/APIEstudiantes1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estudiante>>> GetCliente()
        {
            return await _context.Cliente.ToListAsync();
        }

        // GET: api/APIEstudiantes1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estudiante>> GetEstudiante(int id)
        {
            var estudiante = await _context.Cliente.FindAsync(id);

            if (estudiante == null)
            {
                return NotFound();
            }

            return estudiante;
        }

        // PUT: api/APIEstudiantes1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstudiante(int id, Estudiante estudiante)
        {
            if (id != estudiante.EstudianteId)
            {
                return BadRequest();
            }

            _context.Entry(estudiante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstudianteExists(id))
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

        // POST: api/APIEstudiantes1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Estudiante>> PostEstudiante(Estudiante estudiante)
        {
            _context.Cliente.Add(estudiante);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstudiante", new { id = estudiante.EstudianteId }, estudiante);
        }

        // DELETE: api/APIEstudiantes1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstudiante(int id)
        {
            var estudiante = await _context.Cliente.FindAsync(id);
            if (estudiante == null)
            {
                return NotFound();
            }

            _context.Cliente.Remove(estudiante);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstudianteExists(int id)
        {
            return _context.Cliente.Any(e => e.EstudianteId == id);
        }

        public class Parametros
        {
            public int Inicial { get; set; }
            public int Final { get; set; }
        }
        public class Respuesta
        {
            public int aleatorio { get; set; }
        }

        public class RespuestaLetra
        {
            public char letraAleatoria { get; set; }
        }
        [HttpGet]
        [Route("Random")]
        public Respuesta Aleatorio()
        {
            Respuesta respuesta = new Respuesta();
            Random numeroAleatorio = new Random();
            respuesta.aleatorio = numeroAleatorio.Next(0, 101);
            return respuesta;
        }

        [HttpPost]
        [Route("Randomconparametros")]
        public Respuesta AleatoriotConRago([FromBody] Parametros numeros)
        {

            Respuesta respuesta = new Respuesta();
            Random r = new Random();
            respuesta.aleatorio = (r.Next(numeros.Inicial, (numeros.Final + 1)));

            return respuesta;
        }

        [HttpGet]
        [Route("Randomletras")]
        public RespuestaLetra letra()
        {
            RespuestaLetra respuesta = new RespuestaLetra();
            Random r = new Random();
            int numero = r.Next(26);
            char letraGenerada = (char)(((int)'A') + numero);
            respuesta.letraAleatoria = letraGenerada;
            return respuesta;
        }
    }
}
