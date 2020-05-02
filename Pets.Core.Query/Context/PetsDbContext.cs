using Microsoft.EntityFrameworkCore;
using Pets.Core.Query.Context.Entities;

namespace Pets.Core.Query.Context
{
    public class PetsDbContext
        : DbContext
    {
        public DbSet<PetEntity> Pet { get; set; }
        public DbSet<FeedEntity> Feed { get; set; }
        public DbSet<ImagemEntity> Imagem { get; set; }
        public DbSet<UsuarioEntity> Usuario { get; set; }
        public DbSet<PetImagemEntity> PetImagem { get; set; }
        public DbSet<VinculoAmizadeEntity> VinculoAmizade { get; set; }
        public DbSet<SolicitacaoAmizadeEntity> SolicitacaoAmizade { get; set; }
        public PetsDbContext(DbContextOptions<PetsDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UsuarioEntity>().ToTable("Usuario");
            modelBuilder.Entity<PetEntity>().ToTable("Pet");
            modelBuilder.Entity<FeedEntity>().ToTable("Feed");
            modelBuilder.Entity<ImagemEntity>().ToTable("Imagem");
            modelBuilder.Entity<SolicitacaoAmizadeEntity>().ToTable("SolicitacaoAmizade");
            modelBuilder.Entity<PetImagemEntity>().ToTable("PetImagem")
                .HasKey(pi => new { pi.PetId, pi.ImagemId });
            modelBuilder.Entity<VinculoAmizadeEntity>().ToTable("VinculoAmizade")
                .HasKey(va => new { va.SolicitanteId, va.SolicitadoId });
        }
    }
}
