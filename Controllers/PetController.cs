using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimuladoVeterinaria.Data;
using SimuladoVeterinaria.Models;

namespace SimuladoVeterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PetController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PetDto>>> GetPets(int id)
        {
            return await _context.pets.Select(p => new PetDto
            {
                Nome = p.Nome,
                Id = p.Id,
                Raca = p.Raca,
                Descricao = p.Descricao,
            }).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PetDto>> GetPet(int id)
        {
            var pet = await _context.pets.FindAsync(id);

            if (pet == null)
            {
                return NotFound();
            }
            return new PetDto
            {
                Nome = pet.Nome,
                Raca = pet.Raca,
                Descricao = pet.Descricao,
                Id = pet.Id,
             
            };

        }

        [HttpPost]
        public async Task<ActionResult<PetDto>> CreatePet(PetDto petDto)
        {
            var pet = new Pet
            {
                Nome = petDto.Nome,
                Raca = petDto.Raca,
                Descricao = petDto.Descricao,
                TutorId = petDto.TutorId
            };

            _context.pets.Add(pet);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPet), new { id = pet.Id }, petDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePet(int id, PetDto petDto)
        {
            var aluno = await _context.pets.FindAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }
            petDto.Nome = petDto.Nome;
            petDto.Raca = petDto.Raca;
            petDto.Descricao = petDto.Descricao;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
