using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RegistroCitas.BD.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroCitas.BD.Data
{
    public class Context : IdentityDbContext
    {
        public DbSet<TDocumento> TDocumentos { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<ContactosEmergencia> ContactosEmergencias { get; set; }

        public Context(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                                          .SelectMany(t => t.GetForeignKeys())
                                          .Where(fk => !fk.IsOwnership
                                              && fk.DeleteBehavior == DeleteBehavior.Cascade);
            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
