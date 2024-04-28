using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DistribuidoraDM.Data;

namespace DistribuidoraDM.Controllers
{
    [ApiController]
    [Route("ProductoProvedor")]
    public class ProductProveedorController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAll()
        {
            var respuesta = DataProductoProveedor.ObtenerTodosProductosProveedor();
            if (respuesta.Ok)
            {
                return Ok(respuesta.resultado);
            }
            else
            {
                return StatusCode(500, respuesta.Mensaje);
            }

        }

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

        [HttpGet("GetByName/{nombre}")]
        public IActionResult GetByName(string nombre)
        {
            var respuesta = DataProductoProveedor.ObtenerProductoProveedorPorNombre(nombre);
            if (respuesta.Ok)
            {
                return Ok(respuesta.resultado);
            }
            else
            {
                return StatusCode(500, respuesta.Mensaje);
            }

        }

        [HttpGet("GetByKey/{key}")]
        public IActionResult GetByKey(string key)
        {
            var respuesta = DataProductoProveedor.ObtenerProductoProveedorPorClave(key);
            if (respuesta.Ok)
            {
                return Ok(respuesta.resultado);
            }
            else
            {
                return StatusCode(500, respuesta.Mensaje);
            }

        }

    }
}
