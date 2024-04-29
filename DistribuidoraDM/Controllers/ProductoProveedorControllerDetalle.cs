using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DistribuidoraDM.Data;

namespace DistribuidoraDM.Controllers
{
    [ApiController]
    [Route("ProductoProvedor")]
    public class ProductoProveedorDetalle : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAll()
        {
            var respuesta = DataProductoProveedorDetalle.ObtenerTodosProductosProveedor();
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
            var respuesta = DataProductoProveedorDetalle.ObtenerProductoProveedor(id);
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
            var respuesta = DataProductoProveedorDetalle.ObtenerProductoProveedorPorNombre(nombre);
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
            var respuesta = DataProductoProveedorDetalle.ObtenerProductoProveedorPorClave(key);
            if (respuesta.Ok)
            {
                return Ok(respuesta.resultado);
            }
            else
            {
                return StatusCode(500, respuesta.Mensaje);
            }

        }

        [HttpGet("GetSearch/{key},{idTipoProducto}")]
        public IActionResult GetSearch(string key, int idTipoProducto)
        {
            var respuesta = DataProductoProveedorDetalle.ObtenerProductoProveedorBusqueda(key, idTipoProducto);
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
