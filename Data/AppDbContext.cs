using Microsoft.EntityFrameworkCore;
using SimuladoVeterinaria.Models;

namespace SimuladoVeterinaria.Data
{
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions options) : base(options)
            {
            }

        public DbSet<Tutor> Tutores { get; set; }
        public DbSet<Pet> pets { get; set; }
        public DbSet<Agendamento> agendamentos { get; set; }
        public DbSet<Usuario> usuarios { get; set; } 

        }
    }

