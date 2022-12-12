using BFF_preguntas_respuestas.Domain.Models;

namespace BFF_preguntas_respuestas.Domain.IServices
{
    public interface IUsuarioService
    {
        Task SaveUser(Usuario usuario);
    }
}
