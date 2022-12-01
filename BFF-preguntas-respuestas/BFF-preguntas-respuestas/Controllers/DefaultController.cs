using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BFF_preguntas_respuestas.Controllers
{
    public class DefaultController : Controller
    {
        [HttpGet]
        public string Get() 
        {
            return "Aplicacion corriendo";
        }
    }
}
