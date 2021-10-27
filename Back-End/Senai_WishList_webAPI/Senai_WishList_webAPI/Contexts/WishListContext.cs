using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Senai_WishList_webAPI.Domains;

#nullable disable

namespace Senai_WishList_webAPI.Contexts
{
    public partial class WishListContext : DbContext
    {
        public WishListContext()
        {
        }

        public WishListContext(DbContextOptions<WishListContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Desejo> Desejos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-R3SNJAL\\SQLEXPRESS; initial catalog=WishList; user Id=sa; pwd=senai@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Desejo>(entity =>
            {
                entity.HasKey(e => e.IdDesejo)
                    .HasName("PK__Desejos__2563CB63460EA159");

                entity.HasIndex(e => e.DescricaoDesejo, "UQ__Desejos__2091F2A9F9C638F8")
                    .IsUnique();

                entity.Property(e => e.IdDesejo).HasColumnName("Id_Desejo");

                entity.Property(e => e.DescricaoDesejo)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Descricao_Desejo");

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Desejos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Desejos__Id_Usua__3C69FB99");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__63C76BE282E7537F");

                entity.HasIndex(e => e.Senha, "UQ__Usuarios__7ABB9731D85479DB")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__Usuarios__A9D105343E558A7F")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
