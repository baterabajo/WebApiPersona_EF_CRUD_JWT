
using Microsoft.AspNetCore.Mvc;
using MyDemoAPI.Entities;
using MyDemoAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace MyDemoAPI.Controllers
{

    [Route("[controller]")]
    public class PersonaController : ControllerBase
    {

        private readonly DataContext _context;

        public PersonaController(DataContext context)
        {
            _context = context;
        }

        

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Persona persona)
        {
            if (id != persona.Id)
            {
                return BadRequest("Los ids no coinciden");
            }

            var personaExistente = await _context.Personas.FirstOrDefaultAsync(p => p.Id == id);

            if (personaExistente == null)
            {
                return NotFound("La persona no existe");
            }

            personaExistente.Nombre = persona.Nombre;
            personaExistente.Apellido = persona.Apellido;
            personaExistente.Edad = persona.Edad;
            
            try
            {
                _context.Update(personaExistente);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(personaExistente);
       }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var persona = await _context.Personas.FirstOrDefaultAsync(p => p.Id == id);

            if (persona == null)
            {
                return NotFound("La persona no existe");
            }

            try
            {
                _context.Remove(persona);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(persona);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Persona persona)
        {
            try
            {
                _context.Add(persona);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(persona);
        }

        [HttpGet]
        public async Task <IActionResult> Get()
        {
            var personas = await _context.Personas.ToListAsync();
            return Ok(personas);
        }

        [HttpGet("{id}")]
        public async Task <IActionResult> Get(int id)
        {
            var persona = await _context.Personas.FirstOrDefaultAsync(p => p.Id == id);
            return Ok(persona);
        }

        private IActionResult GetPersonas(int id)
        {
            var personas = _context.Personas.FirstOrDefault(p => p.Id == id);
            if (personas == null)
            {
                return NotFound($"La persona con el id {id} no fue encontrada");
            }
            return Ok(personas);
        }



    }
}