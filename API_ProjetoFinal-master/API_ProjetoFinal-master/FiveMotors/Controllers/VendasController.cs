using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FiveMotors.Data;
using FiveMotors.Models;
using FiveMotors.Mappers;
using FiveMotors.InputModels;
using FiveMotors.ViewModels;

namespace FiveMotors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendasController : ControllerBase
    {
        private readonly FiveMotorsContext _context;

        public VendasController(FiveMotorsContext context)
        {
            _context = context;
        }

        // GET: api/Vendas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VendaView>>> Getvendas()
        {
            var vendas = await _context.vendas
                 .Include(a => a.Cliente)
                 .Include(a => a.FormaDePagamamento)
                 .Include(a => a.Veiculo)
                  .ToListAsync();




            var venda = vendas.Select(VendaMepper.ToDto).ToList();

            return Ok(venda);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VendaView>> GetVendaById(Guid id)
        {
            var venda = await _context.vendas
                .Include(a => a.Cliente)
                .Include(a => a.FormaDePagamamento)
                .Include(a => a.Veiculo)
                .FirstOrDefaultAsync(a => a.VendaId == id);

            if (venda == null)
                return NotFound();

            var vendaView = VendaMepper.ToDto(venda);

            return Ok(vendaView);
        }


        // PUT: api/Vendas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVenda(Guid id, [FromBody] VendaInput vendainput)
        {
            var vendas = await _context.vendas.FindAsync(id);
            if (vendas == null)
                return NotFound();

            VendaMepper.Update(vendas, vendainput);

            _context.Entry(vendainput).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Vendas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] VendaInput vendainput)
        {
            if(!await _context.clientes.AnyAsync(c => c.ClienteId == vendainput.ClienteId))
                      return BadRequest("Cliente Não Encontrado");

            if (!await _context.veiculos.AnyAsync(v => v.VeiculoId == vendainput.VeiculoId))
                return BadRequest("Veículo Não Encontrado");

            if (!await _context.formaDePagamamentos.AnyAsync(f => f.FormaDePagamentoId == vendainput.FormaDePagamentoId))
                return BadRequest("Forma de Pagamento Não Encontrada");
            var vendas = VendaMepper.ToEntity(vendainput);

            _context.vendas.Add(vendas);
            _context.SaveChanges();

            var result = VendaMepper.ToDto(vendas);
            return CreatedAtAction(nameof(Getvendas), new { id = vendas.VendaId }, result);
        }

        // DELETE: api/Vendas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenda(Guid id)
        {
            var venda = await _context.vendas.FindAsync(id);
            if (venda == null)
            {
                return NotFound();
            }

            _context.vendas.Remove(venda);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VendaExists(Guid id)
        {
            return _context.vendas.Any(e => e.VendaId == id);
        }
    }
}
