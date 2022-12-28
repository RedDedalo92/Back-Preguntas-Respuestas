using BFF_preguntas_respuestas.Domain.Models;

namespace BFF_preguntas_respuestas.Domain.IServices
{
    public interface ILoginService
    {
        Task<Usuario> ValidateUser(Usuario usuario);
    }
}
