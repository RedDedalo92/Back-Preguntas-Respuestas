using BFF_preguntas_respuestas.Domain.IServices;
using BFF_preguntas_respuestas.Domain.Models;
using BFF_preguntas_respuestas.DTO;
using BFF_preguntas_respuestas.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BFF_preguntas_respuestas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _iUsuarioService;
        public UsuarioController(IUsuarioService iUsuarioService)
        {
            this._iUsuarioService = iUsuarioService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Usuario usuario)
        {
            try
            {
                var validateExistence = await _iUsuarioService.ValidateExistence(usuario);
                if (validateExistence)
                {
                    return BadRequest(new { message = "El usuario " + usuario.NombreUsuario + " ya existe" });
                }
                usuario.Password = Encriptador.EncriptarPassword(usuario.Password);
                await _iUsuarioService.SaveUser(usuario);
                return Ok(new { message = "Usuario registrado con exito" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [Route("CambiarPassword")]
        [HttpPut]
        public async Task<IActionResult> CambiarPassword([FromBody] CambiarPasswordDTO cambiarPassword)
        {
            try
            {
                int id = 10;
                string passwordEncriptado = Encriptador.EncriptarPassword(cambiarPassword.PasswordAnterior);
                var usuario = await _iUsuarioService.ValidatePassword(id, passwordEncriptado);
                if(usuario == null)
                {
                    return BadRequest(new { message = "Password incorrecta" });
                }
                else
                {
                    usuario.Password = Encriptador.EncriptarPassword(cambiarPassword.NuevaPassword);
                    await _iUsuarioService.UpdatePassword(usuario);
                    return Ok(new { mesagge = "La password fue actualizada exitosamente" });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
