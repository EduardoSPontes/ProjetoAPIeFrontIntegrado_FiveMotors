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
    public class VeiculosController : ControllerBase
    {
        private readonly FiveMotorsContext _context;

        public VeiculosController(FiveMotorsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VeiculoView>>> GetAllVeiculos()
        {
            var veiculos = await _context.veiculos.ToListAsync();

            var veiculo = veiculos.Select(VeiculoMapper.ToDto).ToList();

            return Ok(veiculo);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<IEnumerable<VeiculoView>>> GetAllClientbyId(Guid Id)
        {
            var veiculos = await _context.veiculos.FindAsync(Id);

            if (veiculos == null)
                return NotFound();
            
            var veiculo = VeiculoMapper.ToDto(veiculos);
            return Ok(veiculo);
        }

        [HttpPost]
        public async Task Post(VeiculoInput input)
        {
            var veiculos = VeiculoMapper.ToEntity(input);

            _context.veiculos.Add(veiculos);
           await _context.SaveChangesAsync();

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] VeiculoInput input)
        {

            var veiculo = await _context.veiculos.FindAsync(id);
            if (veiculo == null)
                return NotFound();

            VeiculoMapper.Update(veiculo, input);

            _context.Entry(veiculo).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();

        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var veiculo = _context.veiculos.Find(id);
            if (veiculo == null) return;

            _context.veiculos.Remove(veiculo);
            _context.SaveChanges();
        }
    }
}
