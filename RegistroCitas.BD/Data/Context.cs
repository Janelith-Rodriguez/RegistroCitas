using Microsoft.EntityFrameworkCore;
using RegistroCitas.BD.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroCitas.BD.Data
{
    public class Context : DbContext
    {
        public DbSet<TDocumento> TDocumentos { get; set; }
        public DbSet<Persona> Personas { get; set; }

        public Context(DbContextOptions options) : base(options)
        {
        }
    }
}
