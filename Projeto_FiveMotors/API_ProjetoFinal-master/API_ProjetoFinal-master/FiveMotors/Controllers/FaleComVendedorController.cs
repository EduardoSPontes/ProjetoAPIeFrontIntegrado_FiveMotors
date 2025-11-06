using FiveMotors.Data;
using FiveMotors.InputModels;
using FiveMotors.Mappers;
using FiveMotors.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FiveMotors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaleComVendedorController : ControllerBase
    {
        private readonly FiveMotorsContext _context;

        public FaleComVendedorController(FiveMotorsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FaleComVendedorView>>> GetAll()
        {
            var mensagens = await _context.faleComVendedors.ToListAsync();
            var mensagensDto = mensagens.Select(FaleComVendedorMapper.ToDto).ToList();

            return Ok(mensagensDto);
        }

        // GET: api/FaleComVendedor/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<FaleComVendedorView>> GetById(Guid id)
        {
            var mensagem = await _context.faleComVendedors.FindAsync(id);

            if (mensagem == null)
                return NotFound();

            var dto = FaleComVendedorMapper.ToDto(mensagem);
            return Ok(dto);
        }

        // POST: api/FaleComVendedor
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] FaleComVendedorInput input)
        {
            var mensagem = FaleComVendedorMapper.ToEntity(input);

            _context.faleComVendedors.Add(mensagem);
            await _context.SaveChangesAsync();

            return Ok(mensagem);
        }

        // PUT: api/FaleComVendedor/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] FaleComVendedorInput input)
        {
            var mensagem = await _context.faleComVendedors.FindAsync(id);
            if (mensagem == null)
                return NotFound();

            FaleComVendedorMapper.Update(mensagem, input);
            _context.Entry(mensagem).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/FaleComVendedor/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var mensagem = await _context.faleComVendedors.FindAsync(id);
            if (mensagem == null)
                return NotFound();

            _context.faleComVendedors.Remove(mensagem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

