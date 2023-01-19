using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Backend.Models
{
    public partial class BackendCTX : DbContext
    {
        public BackendCTX()
        {
        }
        public BackendCTX(DbContextOptions<BackendCTX> options)
            :base(options)
        {

        }

        public virtual DbSet<Usuario> Usuario { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            { 
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.usuario).IsUnicode(false);

                entity.Property(e => e.password).IsUnicode(false);

                entity.Property(e => e.estado).IsUnicode(false);

                entity.Property(e => e.salt).IsUnicode(false);

            });
        }


      
        
    }
}
