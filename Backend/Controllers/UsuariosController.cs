
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Backend.Models;
using Backend.Helper;
using Microsoft.EntityFrameworkCore;
using web_api_es.DLAC;
using Microsoft.AspNetCore.Authorization;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class UsuariosController:ControllerBase
    {
       [HttpGet("")]
        public async Task<IActionResult> getUsuaios()
        {
            return Ok(await Task.Run(() => new UsuariosDLAC().listaUsuarios()));
        }

        [HttpGet("{Id:int}")]
        public async Task<IActionResult> getUsuaiosid(int id)
        {

            return Ok(await Task.Run(() => new UsuariosDLAC().usuarioPorId(id)));
        }

        [HttpPost("nuevo")]
        public async Task<IActionResult> PostUsuario(Usuario Usuario)
        {
            var Password = HashHelper.Hash(Usuario.password);
            Usuario.password = Password.password;
            Usuario.salt = Password.salt;

            await Task.Run(() => new UsuariosDLAC().guardarUsuario(Usuario));
            return Ok(new UsuarioVM()
            {
                Id = Usuario.Id,
                usuario = Usuario.usuario
            });
        }
        [HttpPut("actualizar")]
        public async Task<IActionResult> PutActualizarUsuario(Usuario Usuario)
        {
            return Ok(await Task.Run(() => new UsuariosDLAC().actualizarUsuario(Usuario)));
        }

        [HttpDelete("eliminar/{id:int}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            return Ok(await Task.Run(() => new UsuariosDLAC().eliminarUsuario(id)));
        }

    }    

}
