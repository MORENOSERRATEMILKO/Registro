using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registro.Data
{
    public class UniversidadDbContext : DbContext
    {
        public DbSet<Estudiante> Estudiantes { get; set; }
        public UniversidadDbContext(DbContextOptions<UniversidadDbContext> options) : base(options)
        {

        }
    }
}
