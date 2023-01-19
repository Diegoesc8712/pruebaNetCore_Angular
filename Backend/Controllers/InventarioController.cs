
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
    public class InventarioController:ControllerBase
    {
       [HttpGet("")]
        public async Task<IActionResult> getInventario()
        {
            return Ok(await Task.Run(() => new inventarioDLAC().listainventario()));
            //return Ok(await Task.Run(() => new solicitudDLAC().listado()));
        }
        [HttpGet("lista")]
        public async Task<IActionResult> getInventarioExistentes()
        {
            return Ok(await Task.Run(() => new inventarioDLAC().listainventarioExistentes()));
            //    //return Ok(await Task.Run(() => new solicitudDLAC().listado()));
        }

        [HttpGet("{Id:int}")]
        public async Task<IActionResult> getInventarioId(int id)
        {
            return Ok(await Task.Run(() => new inventarioDLAC().inventarioPorId(id)));
            //    //return Ok(await Task.Run(() => new solicitudDLAC().listado()));
        }

        [HttpPost("nuevo")]
        public async Task<IActionResult> PostInventario(inventario inventario)
        {
            return Ok(await Task.Run(() => new inventarioDLAC().guardarinventario(inventario)));
        }
        [HttpPut("actualizar")]
        public async Task<IActionResult> PutActualizarInventario(inventario inventario)
        {
            return Ok(await Task.Run(() => new inventarioDLAC().actualizarinventario(inventario)));
        }

        [HttpDelete("eliminar/{id:int}")]
        public async Task<IActionResult> DeleteInventario(int id)
        {
            return Ok(await Task.Run(() => new inventarioDLAC().eliminarInventario(id)));
        }

    }    

}
