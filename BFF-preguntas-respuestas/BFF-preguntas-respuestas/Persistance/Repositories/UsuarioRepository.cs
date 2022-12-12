using BFF_preguntas_respuestas.Domain.IRepositories;
using BFF_preguntas_respuestas.Domain.Models;
using BFF_preguntas_respuestas.Persistance.Context;

namespace BFF_preguntas_respuestas.Persistance.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;
        public UsuarioRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task SaveUser(Usuario usuario)
        {
            _context.Add(usuario);
            await _context.SaveChangesAsync();
        }
    }
}
