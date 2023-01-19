
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
    public class ClientesController:ControllerBase
    {
       [HttpGet("")]
        public async Task<IActionResult> getClientes()
        {
            return Ok(await Task.Run(() => new clientesDLAC().listaclientes()));
        }

        [HttpGet("{Id:int}")]
        public async Task<IActionResult> getClienteId(int id)
        {
            return Ok(await Task.Run(() => new clientesDLAC().clientesPorId(id)));
        }

        [HttpGet("buscar/{cel:int}")]
        public async Task<IActionResult> getClienteCelular(int cel)
        {
            return Ok(await Task.Run(() => new clientesDLAC().clientesPorCelular(cel)));
        }

        [HttpPost("nuevo")]
        public async Task<IActionResult> PostCliente(clientes clientes)
        {
            return Ok(await Task.Run(() => new clientesDLAC().guardarclientes(clientes)));
        }
        [HttpPut("actualizar")]
        public async Task<IActionResult> PutCliente(clientes clientes)
        {
            return Ok(await Task.Run(() => new clientesDLAC().actualizarcliente(clientes)));
        }

        [HttpDelete("eliminar/{id:int}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            return Ok(await Task.Run(() => new clientesDLAC().eliminarCliente(id)));
        }

    }    

}
