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
    using FiveMotors.ViewModels;
    using FiveMotors.Mappers;
    using NuGet.Protocol.Core.Types;

    namespace FiveMotors.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class ClientesController : ControllerBase
        {
            private readonly FiveMotorsContext _context;

            public ClientesController(FiveMotorsContext context)
            {
                _context = context;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<ClienteView>>> GetAllClients()
            {
                var clientes = await _context.clientes.ToListAsync(); 

                var cliente = clientes.Select(ClienteMapper.ToDto).ToList(); 

                return Ok(cliente);
            }

            [HttpGet("{Id}")]
            public async Task<ActionResult<IEnumerable<ClienteView>>> GetAllClientbyId(Guid Id)
            {
                var clientes = await _context.clientes.FindAsync(Id);

                if (clientes == null)
                    return NotFound();

               var cliente = ClienteMapper.ToDto(clientes);
                return Ok(cliente);
            }

            [HttpGet("usuario/{userId}")]
            public async Task<IActionResult> GetByUserId(string userId)
            {
                var cliente = await _context. clientes
                    .FirstOrDefaultAsync(c => c.UserId == userId);

                if (cliente == null)
                    return NotFound();

                return Ok(cliente);
            }


            [HttpPost]
            public async Task<IActionResult> Post([FromBody] ClienteInput input)
            {
                var cliente = ClienteMapper.ToEntity(input);
                _context.clientes.Add(cliente);
                await _context.SaveChangesAsync();
                return Ok(cliente);
            }

            [HttpPut("{id}")]
            public async Task<ActionResult> Put(Guid id, [FromBody] ClienteInput input)
            {
            
                var cliente = await _context.clientes.FindAsync(id);
                if (cliente == null)
                    return NotFound();

                ClienteMapper.Update(cliente, input);

                _context.Entry(cliente).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return NoContent(); 

            }

            [HttpDelete("{id}")]
            public void Delete(Guid id)
            {
                var cliente = _context.clientes.Find(id);
                if (cliente == null) return;

                _context.clientes.Remove(cliente);
                _context.SaveChanges();
            }
        }
    }
