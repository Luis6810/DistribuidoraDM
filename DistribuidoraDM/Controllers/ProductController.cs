using Microsoft.AspNetCore.Mvc;
using DistribuidoraDM.Data;

namespace DistribuidoraDM.Controllers
{
    [ApiController]
    [Route("Producto")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var respuesta = DataProduct.ObtenerTodosProductosProveedor();
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
