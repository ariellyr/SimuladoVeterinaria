using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimuladoVeterinaria.Data;
using SimuladoVeterinaria.Models;

namespace SimuladoVeterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TutorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TutorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tutor>>> GetTutores()
        {
            return await _context.Tutores.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TutorDto>> GetTutor(int id)
        {
            var tutor = await _context.Tutores.FindAsync(id);


            if (tutor == null)
            {
                return NotFound();
            }


            return new TutorDto
            {
                Nome = tutor.Nome,
                Telefone = tutor.Telefone,
            };
        }

        [HttpPost]
        public async Task<ActionResult<Tutor>> CreateTutor(TutorDto TutorDto)
        {
            var tutor = new Tutor
            {
               
                Nome = TutorDto.Nome,
                Cpf = TutorDto.Cpf,
                Telefone = TutorDto.Telefone,
            };


            _context.Tutores.Add(tutor);
            await _context.SaveChangesAsync();


            return CreatedAtAction(nameof(GetTutor), new { id = tutor.Id }, tutor);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTutor(int id, TutorDto tutorDto)
        {
            var tutor = await _context.Tutores.FindAsync(id);
            if (tutor == null)
            {
                return NotFound();
            }
            tutor.Nome = tutorDto.Nome;
            tutor.Telefone = tutorDto.Telefone;


            await _context.SaveChangesAsync();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTutor(int id)
        {
            var tutor = await _context.Tutores.FindAsync(id);
            if (tutor == null)
            {
                return NotFound();
            }
            _context.Tutores.Remove(tutor);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}