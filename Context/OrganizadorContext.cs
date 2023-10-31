using Microsoft.EntityFrameworkCore;
using TrilhaApiDesafio.Models;

namespace TrilhaApiDesafio.Context
{
    public class OrganizadorContext : DbContext
    {
        public OrganizadorContext(DbContextOptions<OrganizadorContext> options) : base(options)
        {
            
        }
        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarefa>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasColumnName("ID")
                    .HasColumnType("INTEGER")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasColumnName("Titulo")
                    .HasColumnType("VARCHAR(100)");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("Descricao")
                    .HasColumnType("VARCHAR(100)");

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasColumnName("Data")
                    .HasColumnType("DATETIME2");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("Status")
                    .HasColumnType("VARCHAR(20)");
            });
        }

    }
}