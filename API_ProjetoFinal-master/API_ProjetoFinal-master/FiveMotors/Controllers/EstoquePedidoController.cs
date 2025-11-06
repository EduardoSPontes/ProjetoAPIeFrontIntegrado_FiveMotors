using FiveMotors.Data;
using FiveMotors.Mappers;
using FiveMotors.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FiveMotors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoquePedidoController : ControllerBase
    {
        private readonly FiveMotorsContext _context;

        public EstoquePedidoController(FiveMotorsContext context)
        {
            _context = context;
        }

        // GET: api/EstoquePedido
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstoquePedido>>> GetAll()
        {
            var estoques = await _context.estoquePedidos.ToListAsync();
            return Ok(estoques);
        }

        // GET: api/EstoquePedido/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<EstoquePedido>> GetById(Guid id)
        {
            var estoque = await _context.estoquePedidos.FindAsync(id);
            if (estoque == null)
                return NotFound();

            return Ok(estoque);
        }

        // GET: api/EstoquePedido/veiculo/{veiculoId}
        [HttpGet("veiculo/{veiculoId}")]
        public async Task<ActionResult<EstoquePedido>> GetByVeiculoId(Guid veiculoId)
        {
            var estoque = await _context.estoquePedidos.FirstOrDefaultAsync(e => e.VeiculoId == veiculoId);
            if (estoque == null)
                return NotFound();

            return Ok(estoque);
        }

        // POST: api/EstoquePedido/{veiculoId}?quantidade=1
        [HttpPost("{veiculoId}")]
        public async Task<ActionResult> Post(Guid veiculoId, [FromQuery] int quantidade)
        {
            var veiculo = await _context.veiculos.FindAsync(veiculoId);
            if (veiculo == null)
                return BadRequest("Veículo não encontrado.");

            var estoque = new EstoquePedido
            {
                EstoquePedidoId = Guid.NewGuid(),
                VeiculoId = veiculo.VeiculoId,
                Modelo = veiculo.Modelo,
                Ano = veiculo.Ano,
                QuantidadeDisponivel = quantidade,
                StatusPedido = quantidade > 0 ? "Em estoque" : "Esgotado"
            };

            _context.estoquePedidos.Add(estoque);
            await _context.SaveChangesAsync();

            return Ok(estoque);
        }

        // PUT: api/EstoquePedido/{id}?novaQuantidade=10
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromQuery] int novaQuantidade)
        {
            var estoque = await _context.estoquePedidos.FindAsync(id);
            if (estoque == null)
                return NotFound();

            estoque.QuantidadeDisponivel = novaQuantidade;
            estoque.StatusPedido = novaQuantidade > 0 ? "Em estoque" : "Esgotado";

            _context.Entry(estoque).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/EstoquePedido/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var estoque = await _context.estoquePedidos.FindAsync(id);
            if (estoque == null)
                return NotFound();

            _context.estoquePedidos.Remove(estoque);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
