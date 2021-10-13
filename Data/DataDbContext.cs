using Microsoft.EntityFrameworkCore;
using Registro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registro.Data
{
    public class DataDbContext: DbContext
    {
        public DbSet<Estudiante> Cliente { get; set; }

        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        {

        }
    }
}
