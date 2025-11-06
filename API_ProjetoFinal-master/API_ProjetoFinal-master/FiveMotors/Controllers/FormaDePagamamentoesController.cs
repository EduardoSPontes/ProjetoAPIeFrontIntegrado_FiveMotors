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
    public class FormaDePagamamentoesController : ControllerBase
    {
        private readonly FiveMotorsContext _context;

        public FormaDePagamamentoesController(FiveMotorsContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteView>>> GetAllFormaPagamento()
        {
            var pagamentos = await _context.formaDePagamamentos.ToListAsync();

            var pagamento = pagamentos.Select(FormaDePagamentoMapper.ToDto).ToList();

            return Ok(pagamento);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<IEnumerable<FormaDePagamentoView>>> GetAllFormaPagamentobyId(Guid Id)
        {
            var pagamentos = await _context.formaDePagamamentos.FindAsync(Id);

            if (pagamentos == null)
                return NotFound();

            var pagamento = FormaDePagamentoMapper.ToDto(pagamentos);
            return Ok(pagamento);
        }


        [HttpPost]
        public async void Post(FormaDePagamentoInput input)
        {
            var pagamento = FormaDePagamentoMapper.ToEntity(input);

            _context.formaDePagamamentos.Add(pagamento);
            _context.SaveChanges();

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] FormaDePagamentoInput input)
        {

            var pagamento = await _context.formaDePagamamentos.FindAsync(id);
            if (pagamento == null)
                return NotFound();

            FormaDePagamentoMapper.Update(pagamento, input);

            _context.Entry(pagamento).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();

        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var pagamento = _context.clientes.Find(id);
            if (pagamento == null) return;

            _context.clientes.Remove(pagamento);
            _context.SaveChanges();
        }
    }
}
