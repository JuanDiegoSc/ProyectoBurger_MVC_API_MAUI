using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProyectoBurgerApi.Data.Models;

namespace ProyectoBurgerApi.Data;

public partial class ProyectoBurgerMvcApiMauicontextContext : DbContext
{
    public ProyectoBurgerMvcApiMauicontextContext()
    {
    }

    public ProyectoBurgerMvcApiMauicontextContext(DbContextOptions<ProyectoBurgerMvcApiMauicontextContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Burger_JDS> BurgerJds { get; set; }

    public virtual DbSet<Promo_JDS> PromoJds { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Database=ProyectoBurger_MVC_API_MAUIContext;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Burger_JDS>(entity =>
        {
            entity.HasKey(e => e.BurgerId_JDS);

            entity.ToTable("Burger_JDS");

            entity.Property(e => e.BurgerId_JDS).HasColumnName("BurgerId_JDS");
            entity.Property(e => e.Name_JDS).HasColumnName("Name_JDS");
            entity.Property(e => e.Precio_JDS)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Precio_JDS");
            entity.Property(e => e.WithCheese_JDS).HasColumnName("WithCheese_JDS");
        });

        modelBuilder.Entity<Promo_JDS>(entity =>
        {
            entity.HasKey(e => e.PromoId_JDS);

            entity.ToTable("Promo_JDS");

            entity.HasIndex(e => e.Burger_JDS, "IX_Promo_JDS_Burger_JDSBurgerId_JDS");

            entity.Property(e => e.PromoId_JDS).HasColumnName("PromoId_JDS");
            entity.Property(e => e.BurgerId_JDS).HasColumnName("BurgerId_JDS");
            entity.Property(e => e.Burger_JDS).HasColumnName("Burger_JDSBurgerId_JDS");
            entity.Property(e => e.Descripcion_JDS).HasColumnName("Descripcion_JDS");
            entity.Property(e => e.FechaPromo_JDS).HasColumnName("FechaPromo_JDS");

            entity.HasOne(d => d.Burger_JDS).WithMany(p => p.Promo_JDS).HasForeignKey(d => d.Burger_JDS);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
