using BFF_preguntas_respuestas.Domain.IRepositories;
using BFF_preguntas_respuestas.Domain.IServices;
using BFF_preguntas_respuestas.Domain.Models;

namespace BFF_preguntas_respuestas.Services
{
    public class LoginService: ILoginService
    {
        private readonly ILoginRepository _loginRepository;

        public LoginService(ILoginRepository loginRepository)
        {
            this._loginRepository = loginRepository;
        }

        public async Task<Usuario> ValidateUser(Usuario usuario)
        {
            return await _loginRepository.ValidateUser(usuario);
        }
    }
}
