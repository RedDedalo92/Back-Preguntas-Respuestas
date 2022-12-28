using BFF_preguntas_respuestas.Domain.IServices;
using BFF_preguntas_respuestas.Domain.Models;
using BFF_preguntas_respuestas.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace BFF_preguntas_respuestas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Usuario usuario) {
            try
            {
                usuario.Password = Encriptador.EncriptarPassword(usuario.Password);

                var user = await _loginService.ValidateUser(usuario);

                if (user == null)
                {
                    return BadRequest(new {message = "Usuario o clave invalidos"});
                }

                return Ok(new {usuario = user.NombreUsuario});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
