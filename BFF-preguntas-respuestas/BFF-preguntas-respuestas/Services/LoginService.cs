using BFF_preguntas_respuestas.Domain.IServices;

namespace BFF_preguntas_respuestas.Services
{
    public class LoginService: ILoginService
    {
        private readonly ILoginService _loginService;

        public LoginService(ILoginService loginService)
        {
            this._loginService = loginService;
        }
    }
}
