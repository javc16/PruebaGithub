using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LuckyStore.Context;
using LuckyStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace LuckyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly FacturaContext _context;

        public FacturaController(FacturaContext context) 
        {
            _context = context;
            if (_context.Factura.Count() == 0) 
            {
                _context.Factura.Add(new Factura { Name = "Juan", Address = "Florida", Date = DateTime.Now });
                _context.Detalle.Add(new Detalle {IdFactura=1,Item="Monitor",Quantity=1,Price=1000,Date=DateTime.Now });
                _context.Detalle.Add(new Detalle {IdFactura = 1, Item = "Teclado", Quantity = 2, Price = 500, Date = DateTime.Now });
                _context.SaveChanges();
            }
        }

        [HttpGet("factura")]
        public async Task<ActionResult<IEnumerable<Factura>>> GetFacturas() 
        {
            return await _context.Factura.ToListAsync();
        }

        [HttpGet("detail")]
        public async Task<ActionResult<IEnumerable<Detalle>>> GetDetalleFactura()
        {
            return await _context.Detalle.ToListAsync();
        }

        [HttpGet("get-factura-by-id/{id}")]
        public async Task<ActionResult<Factura>> GetFacturaById(int id)
        {
            var factura = await _context.Factura.FirstOrDefaultAsync(x => x.Id == id);
            if (factura == null) 
            {
                return NotFound();
            }
            return factura;
        }

        [HttpPost("factura")]
        public async Task<ActionResult<Factura>> PostFactura(Factura item)
        {
            _context.Factura.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFacturaById), new {id =item.Id }, item);
        }

        [HttpPut("factura/{id}")]
        public async Task<ActionResult> PutFactura(int id, Factura item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("factura/{id}")]
        public async Task<ActionResult> DeleteFactura(long id) 
        {
            var factura = await _context.Factura.FindAsync(id);
            if (factura == null) 
            {
                return NotFound();
            }
            _context.Factura.Remove(factura);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
