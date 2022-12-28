using BFF_preguntas_respuestas.Domain.IRepositories;

namespace BFF_preguntas_respuestas.Persistance.Repositories
{
    public class LoginRepository: ILoginRepository
    {
        private readonly ILoginRepository _loginRepository;
        public LoginRepository(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository; 
        }
    }
}
