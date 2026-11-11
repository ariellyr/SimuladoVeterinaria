using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimuladoVeterinaria.Data;
using SimuladoVeterinaria.Models;

namespace SimuladoVeterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AgendamentoController(AppDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<ActionResult<Agendamento>> CreateAgendamentos(AgendamentoDto agendamentoDto)
        {
            var agendamento = new Agendamento
            {
                Id = agendamentoDto.Id,
                Data = agendamentoDto.Data,
                Motivo = agendamentoDto.Motivo,
                Gravidade = agendamentoDto.Gravidade,
                TutorId = agendamentoDto.TutorId,
                PetId = agendamentoDto.PetId

            };

            _context.agendamentos.Add(agendamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(CreateAgendamentos), new { id = agendamento.Id }, agendamento);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgendamentoDto>>> GetAgendamentos()
        {
            var agendamentos = await _context.agendamentos
                .Select(C => new Agendamento
                {
                    Id = C.Id,
                    Data = C.Data, 
                    Motivo = C.Motivo,
                    Gravidade = C.Gravidade,
                    PetId = C.PetId,
                    TutorId = C.TutorId,
                    Pet = C.Pet, 
                    Tutor = C.Tutor
                })
                .ToListAsync();

            return Ok(agendamentos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AgendamentoDto>> GetAgendamento(int id)
        {
            var agendamento = await _context.agendamentos

            .Select(t => new AgendamentoDto
            {
                Data = t.Data,
                Gravidade = t.Gravidade,
                Motivo = t.Motivo,
                PetId = t.PetId,
                TutorId = t.TutorId,
              
            })
            .ToListAsync();

            return Ok(agendamento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAgendamento(int id, AgendamentoDto agendamentoDto)
        {
            var agendamentos = await _context.agendamentos.FindAsync(id);
            if (agendamentos == null)
            {
                return NotFound();
            }
            agendamentos.Data = agendamentoDto.Data;
            agendamentos.PetId = agendamentoDto.PetId;
            agendamentos.TutorId = agendamentoDto.TutorId;
           
            await _context.SaveChangesAsync();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgendamentos(int id)
        {
            var agendamentos = await _context.agendamentos.FindAsync(id);
            if (agendamentos == null)
            {
                return NotFound();
            }
            _context.agendamentos.Remove(agendamentos);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}