
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using web_api_es.DLAC;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComprasController:ControllerBase
    {
       [HttpGet("")]
        public async Task<IActionResult> getCompras()
        {
            return Ok(await Task.Run(() => new comprasDLAC().listaCompras()));
        }

        [HttpGet("{Id:int}")]
        public async Task<IActionResult> getComprasId(int id)
        {
            return Ok(await Task.Run(() => new comprasDLAC().ComprasPorId(id)));
        }

        [HttpPost("nuevo")]
        public async Task<IActionResult> PostCompras(compras compras)
        {
            await Task.Run(() => new comprasDLAC().guardarCompra(compras));
            return Ok(await Task.Run(() => new comprasDLAC().idUltimaCompra()));
        }
        [HttpPut("actualizar")]
        public async Task<IActionResult> PutCompra(compras compras)
        {
            return Ok(await Task.Run(() => new comprasDLAC().actualizarCompra(compras)));
        }

        [HttpDelete("eliminar/{id:int}")]
        public async Task<IActionResult> DeleteCompra(int id)
        {
            return Ok(await Task.Run(() => new comprasDLAC().eliminarCompra(id)));
        }

    }    

}
