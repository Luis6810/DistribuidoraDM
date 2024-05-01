using DistribuidoraDM.Data;
using Microsoft.AspNetCore.Mvc;

namespace DistribuidoraDM.Controllers
{
    [ApiController]
    [Route("Proveedor")]
    public class ProvedorController : ControllerBase
    {
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var respuesta = DataProveedor.ObtenerTodosProductosProveedor();
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
