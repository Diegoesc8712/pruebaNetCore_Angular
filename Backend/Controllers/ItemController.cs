
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
    public class ItemController:ControllerBase
    {
       [HttpGet("")]
        public async Task<IActionResult> getItems()
        {
            return Ok(await Task.Run(() => new itemDLAC().listaItem()));
        }

        [HttpGet("{Id:int}")]
        public async Task<IActionResult> getItemId(int id)
        {
            return Ok(await Task.Run(() => new itemDLAC().ItemPorId(id)));
        }

        [HttpPost("nuevo")]
        public async Task<IActionResult> PostItem(Item Item)
        {
            return Ok(await Task.Run(() => new itemDLAC().guardarItem(Item)));
        }
        [HttpPut("actualizar")]
        public async Task<IActionResult> PutItem(Item Item)
        {
            return Ok(await Task.Run(() => new itemDLAC().actualizarItem(Item)));
        }

        [HttpDelete("eliminar/{id:int}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            return Ok(await Task.Run(() => new itemDLAC().eliminarItem(id)));
        }

    }    

}
