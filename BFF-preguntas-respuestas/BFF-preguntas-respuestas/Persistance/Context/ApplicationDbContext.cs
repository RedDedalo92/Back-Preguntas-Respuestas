using BFF_preguntas_respuestas.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace BFF_preguntas_respuestas.Persistance.Context
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }
    }
}
