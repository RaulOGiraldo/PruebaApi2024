using Microsoft.EntityFrameworkCore;
using Prueba.Core.Entities;

namespace PostgresSql.Data;

public partial class CompanyRauloswaldogiraldoContext : DbContext
{
    public CompanyRauloswaldogiraldoContext()
    {
    }

    public CompanyRauloswaldogiraldoContext(DbContextOptions<CompanyRauloswaldogiraldoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<Role> Roles { get; set; }
    public virtual DbSet<Transaction> Transactions { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<UsersInRoles> UsersInRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProId).HasName("Products_pkey");

            entity.Property(e => e.ProId)
                .ValueGeneratedNever()
                .HasColumnName("pro_id");
            entity.Property(e => e.ProIsdeleted).HasColumnName("pro_isdeleted");
            entity.Property(e => e.ProName)
                .HasMaxLength(100)
                .HasColumnName("pro_name");
            entity.Property(e => e.ProStock).HasColumnName("pro_stock");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RolId).HasName("Roles_pkey");

            entity.Property(e => e.RolId)
                .ValueGeneratedNever()
                .HasColumnName("rol_id");
            entity.Property(e => e.RolName)
                .HasMaxLength(100)
                .HasColumnName("rol_name");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TraId).HasName("pk_trans_id");

            entity.Property(e => e.TraId)
                .ValueGeneratedNever()
                .HasColumnName("tra_id");
            entity.Property(e => e.TraDate).HasColumnName("tra_date");
            entity.Property(e => e.TraIsDeleted).HasColumnName("tra_isDeleted");
            entity.Property(e => e.TraUnits).HasColumnName("tra_units");
            entity.Property(e => e.TraProId).HasColumnName("tra_pro_id");
            entity.Property(e => e.TraUseId).HasColumnName("tra_use_id");

            entity.HasOne(d => d.TraProductos).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.TraProId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tra_pro_id");

            entity.HasOne(d => d.User).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.TraUseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tra_use_id");

        });


        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UseId).HasName("Users_pkey");

            entity.Property(e => e.UseId)
                .ValueGeneratedNever()
                .HasColumnName("use_id");
            entity.Property(e => e.UseDocument)
                .HasMaxLength(15)
                .HasColumnName("use_document");
            entity.Property(e => e.UseName)
                .HasMaxLength(100)
                .HasColumnName("use_name");


        });


        modelBuilder.Entity<UsersInRoles>(entity =>
        {
            entity.HasKey(e => new { e.UsurolUsuId, e.UsurolRolId }).HasName("pk_usurol");
            entity.Property(e => e.UsurolUsuId)
                .ValueGeneratedNever()
                .HasColumnName("usurol_usu_id");
            entity.Property(e => e.UsurolRolId)
                .ValueGeneratedNever()
                .HasColumnName("usurol_rol_id");

            entity.HasOne(d => d.Rol).WithMany(p => p.UsersInRoles)
                .HasForeignKey(d => d.UsurolRolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_usurol_rol");

            entity.HasOne(d => d.User).WithMany(p => p.UsersInRoles)
                .HasForeignKey(d => d.UsurolUsuId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_usurol_usu");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
