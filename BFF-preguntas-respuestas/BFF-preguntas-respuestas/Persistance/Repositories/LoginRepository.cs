using BFF_preguntas_respuestas.Domain.IRepositories;
using BFF_preguntas_respuestas.Domain.Models;
using BFF_preguntas_respuestas.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace BFF_preguntas_respuestas.Persistance.Repositories
{
    public class LoginRepository: ILoginRepository
    {
        private readonly ApplicationDbContext _context;
        public LoginRepository(ApplicationDbContext context)
        {
            _context = context; 
        }

        public async Task<Usuario> ValidateUser(Usuario usuario)
        {
            var user = await _context.Usuario.Where(x => x.NombreUsuario == usuario.NombreUsuario && x.Password == usuario.Password).FirstOrDefaultAsync();
            return user;
        }
    }
}
