using Microsoft.AspNetCore.Mvc;
using TiendaMicroservicio.Models;
using TiendaMicroservicio.Persistencia;
using System.Linq;

namespace TiendaMicroservicio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly ContextoTienda _contexto;

        public ProductoController(ContextoTienda contexto)
        {
            _contexto = contexto;
        }

        // GET /api/producto
        [HttpGet]
        public IActionResult GetProductos()
        {
            var productos = _contexto.Productos.ToList();
            return Ok(productos);
        }

        // POST /api/producto
        [HttpPost]
        public IActionResult AgregarProducto(Producto producto)
        {
            _contexto.Productos.Add(producto);
            _contexto.SaveChanges();
            return CreatedAtAction(nameof(GetProductos), new { id = producto.Id }, producto);
        }

        // PUT /api/producto/{id}
        [HttpPut("{id}")]
        public IActionResult ActualizarProducto(int id, Producto productoActualizado)
        {
            var producto = _contexto.Productos.FirstOrDefault(p => p.Id == id);
            if (producto == null)
            {
                return NotFound();
            }

            producto.Nombre = productoActualizado.Nombre;
            producto.Precio = productoActualizado.Precio;
            producto.Stock = productoActualizado.Stock;
            _contexto.SaveChanges();
            return NoContent();
        }

        // DELETE /api/producto/{id}
        [HttpDelete("{id}")]
        public IActionResult EliminarProducto(int id)
        {
            var producto = _contexto.Productos.FirstOrDefault(p => p.Id == id);
            if (producto == null)
            {
                return NotFound();
            }

            _contexto.Productos.Remove(producto);
            _contexto.SaveChanges();
            return NoContent();
        }
    }
}
