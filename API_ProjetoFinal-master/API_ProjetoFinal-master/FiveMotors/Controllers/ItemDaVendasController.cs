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
    public class ItemDaVendasController : ControllerBase
    {
        private readonly FiveMotorsContext _context;

        public ItemDaVendasController(FiveMotorsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDaVendaView>>> GetItemVenda()
        {
            var itens = await _context.itemDaVendas
                .Include(i => i.Venda)
                .ThenInclude(v => v.Cliente)
                .Include(i => i.Veiculo)
                .ToListAsync();

            var views = itens.Select(ItemDaVendaMepper.ToDto).ToList();
            return Ok(views);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDaVendaView>> GetItemVendaById(Guid id)
        {
            var itemVenda = await _context.itemDaVendas
                .Include(i => i.Venda)
                .ThenInclude(v => v.Cliente)
                .Include(i => i.Veiculo)
                .FirstOrDefaultAsync(i => i.ItemDaVendaId == id);

            if (itemVenda == null)
                return NotFound();

            var itemView = ItemDaVendaMepper.ToDto(itemVenda);
            return Ok(itemView);
        }

        [HttpGet("por-venda/{vendaId}")]
        public async Task<ActionResult<IEnumerable<ItemDaVendaView>>> GetItensPorVenda(Guid vendaId)
        {
            var itens = await _context.itemDaVendas
                .Include(i => i.Venda)
                .ThenInclude(v => v.Cliente)
                .Include(i => i.Veiculo)
                .Where(i => i.VendaId == vendaId)
                .ToListAsync();

            var views = itens.Select(ItemDaVendaMepper.ToDto).ToList();
            return Ok(views);
        }

        [HttpPost]
        public async Task<ActionResult<ItemDaVendaView>> PostItemVenda([FromBody] ItemDaVendaInput input)
        {
            if (!await _context.vendas.AnyAsync(v => v.VendaId == input.VendaId))
                return BadRequest("Venda não encontrada");

            if (!await _context.veiculos.AnyAsync(v => v.VeiculoId == input.VeiculoId))
                return BadRequest("Veículo não encontrado");

            var item = ItemDaVendaMepper.ToEntity(input);
            _context.itemDaVendas.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetItemVendaById), new { id = item.ItemDaVendaId }, ItemDaVendaMepper.ToDto(item));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemVenda(Guid id, [FromBody] ItemDaVendaInput input)
        {
            var item = await _context.itemDaVendas.FindAsync(id);
            if (item == null)
                return NotFound();

            if (!await _context.vendas.AnyAsync(v => v.VendaId == input.VendaId))
                return BadRequest("Venda não encontrada");

            if (!await _context.veiculos.AnyAsync(v => v.VeiculoId == input.VeiculoId))
                return BadRequest("Veículo não encontrado");

            ItemDaVendaMepper.Update(item, input);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemVenda(Guid id)
        {
            var item = await _context.itemDaVendas.FindAsync(id);
            if (item == null)
                return NotFound();

            _context.itemDaVendas.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}