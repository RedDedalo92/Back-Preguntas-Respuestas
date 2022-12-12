using BFF_preguntas_respuestas.Domain.Models;

namespace BFF_preguntas_respuestas.Domain.IRepositories
{
    public interface IUsuarioRepository
    {
        Task SaveUser(Usuario usuario);
    }
}
