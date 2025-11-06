using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FiveMotors.Data;
using FiveMotors.Models;
using FiveMotors.InputModels;
using FiveMotors.Mappers;
using FiveMotors.ViewModels;

namespace FiveMotors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentosController : ControllerBase
    {
        private readonly FiveMotorsContext _context;

        public AgendamentosController(FiveMotorsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgendamentoView>>> GetAllAgendamento()
        {
            //var agendamentos = await _context.agendamentos.ToListAsync();

            var agendamentos = await _context.agendamentos
                 .Include(a => a.Cliente)
                 .Include(a => a.Veiculo)
                  .ToListAsync();
            
            var agendamento = agendamentos.Select(AgendamentoMapper.ToDto).ToList();

            return Ok(agendamento);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AgendamentoView>> GetAgendamentoById(Guid id)
        {
            var agendamento = await _context.agendamentos
                .Include(a => a.Cliente)
                .Include(a => a.Veiculo)
                .FirstOrDefaultAsync(a => a.AgendamentoId == id);

            if (agendamento == null)
                return NotFound();

            var agendamentoView = AgendamentoMapper.ToDto(agendamento);

            return Ok(agendamentoView);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]AgendamentoInput input)
        {
            if (!await _context.clientes.AnyAsync(c => c.ClienteId == input.ClienteId))
                return BadRequest("Cliente Não Encontrado");

            if (!await _context.veiculos.AnyAsync(v => v.VeiculoId == input.VeiculoId))
                return BadRequest("Veículo Não Encontrado");

            var agendamento = AgendamentoMapper.ToEntity(input);

            _context.agendamentos.Add(agendamento);
            _context.SaveChanges();

            var result = AgendamentoMapper.ToDto(agendamento);
            return CreatedAtAction(nameof(GetAllAgendamento), new { id = agendamento.AgendamentoId }, result);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] AgendamentoInput input)
        {

            var agendamento = await _context.agendamentos.FindAsync(id);
            if (agendamento == null)
                return NotFound();

            AgendamentoMapper.Update(agendamento, input);

            _context.Entry(agendamento).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();

        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var agendamento = _context.clientes.Find(id);
            if (agendamento == null) return;

            _context.clientes.Remove(agendamento);
            _context.SaveChanges();
        }
    }
}
