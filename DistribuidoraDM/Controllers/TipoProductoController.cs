using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DistribuidoraDM.Data;

namespace DistribuidoraDM.Controllers
{
    [ApiController]
    [Route("TipoProductos")]

    public class TipoProductoController : ControllerBase
    {
        [HttpGet]
                public IActionResult GetAll()
        {
            var respuesta = DataTipoProductos.ObtenerTodosTiposProductos();
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
