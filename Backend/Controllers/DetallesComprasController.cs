using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.DataContext;
using Service.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallesComprasController : ControllerBase
    {
        private readonly TiendaContext _context;

        public DetallesComprasController(TiendaContext context)
        {
            _context = context;
        }

        // GET: api/DetallesCompras?filtro=valor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleCompra>>> GetDetallesCompras([FromQuery] string? filtro)
        {
            var query = _context.DetallesCompra
                .Include(d => d.Producto)
                .Include(d => d.Compra)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                query = query.Where(d => d.Producto != null && d.Producto.Nombre.Contains(filtro));
            }

            return await query.ToListAsync();
        }

        // GET: api/DetalleCompras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleCompra>> GetDetalleCompra(int id)
        {
            var detalleCompra = await _context.DetallesCompra.FindAsync(id);

            if (detalleCompra == null)
            {
                return NotFound();
            }

            return detalleCompra;
        }

        // PUT: api/DetalleCompras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleCompra(int id, DetalleCompra detalleCompra)
        {
            if (id != detalleCompra.Id)
            {
                return BadRequest();
            }

            _context.Entry(detalleCompra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleCompraExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DetalleCompras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetalleCompra>> PostDetalleCompra(DetalleCompra detalleCompra)
        {
            // Adjuntar Producto y Compra para evitar su inserción duplicada
            if (detalleCompra.Producto != null)
            {
                _context.Attach(detalleCompra.Producto);
            }
            if (detalleCompra.Compra != null)
            {
                _context.Attach(detalleCompra.Compra);
            }

            _context.DetallesCompra.Add(detalleCompra);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalleCompra", new { id = detalleCompra.Id }, detalleCompra);
        }

        // DELETE: api/DetalleCompras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleCompra(int id)
        {
            var detalleCompra = await _context.DetallesCompra.FindAsync(id);
            if (detalleCompra == null)
            {
                return NotFound();
            }

            _context.DetallesCompra.Remove(detalleCompra);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetalleCompraExists(int id)
        {
            return _context.DetallesCompra.Any(e => e.Id == id);
        }
    }
}
