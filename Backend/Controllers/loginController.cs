
using System.Threading.Tasks;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Backend.Helper;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using web_api_es.DLAC;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class loginController: ControllerBase
    {

        private readonly IConfiguration config;

        public loginController(IConfiguration _config)
        {
            config = _config;
        }

        [HttpPost]
        public async Task<IActionResult> Post(LoginVM Login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Error 400");
            }

            Usuario usuario = await new UsuariosDLAC().usuarioPorusuario(Login.Usuario);

            if (usuario == null)
            {
              return NotFound("usuario no encontrado");
            }

            if (HashHelper.CheckHash(Login.Password, usuario.password, usuario.salt))
            {
                var secretKey = config.GetValue<string>("AppSettings:SecretKey");
                var key = Encoding.ASCII.GetBytes(secretKey);
                var claims = new ClaimsIdentity();

                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, Login.Usuario));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddHours(4),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                };

                var tokenHander = new JwtSecurityTokenHandler();
                var createdToken = tokenHander.CreateToken(tokenDescriptor);


                string bearer_token =  tokenHander.WriteToken(createdToken);
                return Ok(bearer_token);   
                  

            }
            else
            {
                return Forbid();
            }

            

            //if (HashHelper.CheckHash(Login.Password, Usuario.) )
        }
    };
}
