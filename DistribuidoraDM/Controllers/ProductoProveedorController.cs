using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DistribuidoraDM.Data;
using DistribuidoraDM.Models;

namespace DistribuidoraDM.Controllers
{
    [Route("ProductoProv")]
    [ApiController]
    public class ProductoProveedorController : ControllerBase
    {
        [HttpGet("Get/{id}")]
        public IActionResult Get(int id)
        {
            var respuesta = DataProductoProveedor.ObtenerProductoProveedor(id);
            if (respuesta.Ok)
            {
                return Ok(respuesta.resultado);
            }
            else
            {
                return StatusCode(500, respuesta.Mensaje);
            }

        }

        [HttpPost("Actualizar")]
        public IActionResult Update([FromBody] ProductoProveedor productoProveedor)
        {
            var respuesta = DataProductoProveedor.ActualizarProductoProveedor(productoProveedor);
            if (respuesta.Ok)
            {
                return Ok();
            }
            else
            {
                return StatusCode(500, respuesta.Mensaje);
            }

        }
        [HttpPost("Insertar")]
        public IActionResult Insertar([FromBody] ProductoProveedor productoProveedor)
        {
            var respuesta = DataProductoProveedor.InsertarProductoProveedor(productoProveedor);
            if (respuesta.Ok)
            {
                return Ok();
            }
            else
            {
                return StatusCode(500, respuesta.Mensaje);
            }

        }
    }
}
