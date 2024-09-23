using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using subenok23.Models;

namespace subenok23.Context;

public partial class User724Context : DbContext
{
    public User724Context()
    {
    }

    public User724Context(DbContextOptions<User724Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<PunktVydahi> PunktVydahis { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SrokDostavki> SrokDostavkis { get; set; }

    public virtual DbSet<StatusZakaz> StatusZakazs { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Visit> Visits { get; set; }

    public virtual DbSet<Zakaz> Zakazs { get; set; }

    public virtual DbSet<ZakazProduct> ZakazProducts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=192.168.2.159;Database=user724;Username=user724;password=68202");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Discount>(entity =>
        {
            entity.HasKey(e => e.IdDiscount).HasName("discounts_pk");

            entity.ToTable("discounts", "shubenok23");

            entity.Property(e => e.IdDiscount).HasColumnName("id_discount");
            entity.Property(e => e.ValueDiscount).HasColumnName("value_discount");
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.HasKey(e => e.IdManufacturer).HasName("manufacturer_pk");

            entity.ToTable("manufacturer", "shubenok23");

            entity.Property(e => e.IdManufacturer).HasColumnName("id_manufacturer");
            entity.Property(e => e.NameManufacturer)
                .HasColumnType("character varying")
                .HasColumnName("name_manufacturer");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("product_pk");

            entity.ToTable("product", "shubenok23");

            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.Cost).HasColumnName("cost");
            entity.Property(e => e.Descriprion)
                .HasColumnType("character varying")
                .HasColumnName("descriprion");
            entity.Property(e => e.IdDiscount).HasColumnName("id_discount");
            entity.Property(e => e.IdManufacturer).HasColumnName("id_manufacturer");
            entity.Property(e => e.Image)
                .HasColumnType("character varying")
                .HasColumnName("image");
            entity.Property(e => e.NameProduct)
                .HasColumnType("character varying")
                .HasColumnName("name_product");

            entity.HasOne(d => d.IdDiscountNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdDiscount)
                .HasConstraintName("product_discounts_fk");

            entity.HasOne(d => d.IdManufacturerNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdManufacturer)
                .HasConstraintName("product_manufacturer_fk");
        });

        modelBuilder.Entity<PunktVydahi>(entity =>
        {
            entity.HasKey(e => e.IdPunkt).HasName("punkt_vydahi_pk");

            entity.ToTable("punkt_vydahi", "shubenok23");

            entity.Property(e => e.IdPunkt).HasColumnName("id_punkt");
            entity.Property(e => e.NamePunkt)
                .HasColumnType("character varying")
                .HasColumnName("name_punkt");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRole).HasName("roles_pk");

            entity.ToTable("roles", "shubenok23");

            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.NameRole)
                .HasColumnType("character varying")
                .HasColumnName("name_role");
        });

        modelBuilder.Entity<SrokDostavki>(entity =>
        {
            entity.HasKey(e => e.IdSrokDost).HasName("srok_dostavki_pk");

            entity.ToTable("srok_dostavki", "shubenok23");

            entity.Property(e => e.IdSrokDost).HasColumnName("id_srok_dost");
            entity.Property(e => e.ValueSrok)
                .HasColumnType("character varying")
                .HasColumnName("value_srok");
        });

        modelBuilder.Entity<StatusZakaz>(entity =>
        {
            entity.HasKey(e => e.IdStatus).HasName("status_zakaz_pk");

            entity.ToTable("status_zakaz", "shubenok23");

            entity.Property(e => e.IdStatus).HasColumnName("id_status");
            entity.Property(e => e.NameStatus)
                .HasColumnType("character varying")
                .HasColumnName("name_status");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("newtable_1_pk");

            entity.ToTable("users", "shubenok23");

            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Login)
                .HasColumnType("character varying")
                .HasColumnName("login");
            entity.Property(e => e.NameUser)
                .HasColumnType("character varying")
                .HasColumnName("name_user");
            entity.Property(e => e.Password)
                .HasColumnType("character varying")
                .HasColumnName("password");
            entity.Property(e => e.SurnameUser)
                .HasColumnType("character varying")
                .HasColumnName("surname_user");
        });

        modelBuilder.Entity<Visit>(entity =>
        {
            entity.HasKey(e => e.IdVisit).HasName("newtable_pk");

            entity.ToTable("visits", "shubenok23");

            entity.Property(e => e.IdVisit).HasColumnName("id_visit");
            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.IdUser).HasColumnName("id_user");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Visits)
                .HasForeignKey(d => d.IdRole)
                .HasConstraintName("visits_roles_fk");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Visits)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("visits_users_fk");
        });

        modelBuilder.Entity<Zakaz>(entity =>
        {
            entity.HasKey(e => e.IdZakaz).HasName("zakaz_pk");

            entity.ToTable("zakaz", "shubenok23");

            entity.Property(e => e.IdZakaz).HasColumnName("id_zakaz");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.IdPunkt).HasColumnName("id_punkt");
            entity.Property(e => e.IdSrok).HasColumnName("id_srok");
            entity.Property(e => e.IdStatus).HasColumnName("id_status");
            entity.Property(e => e.IdUser).HasColumnName("id_user");

            entity.HasOne(d => d.IdPunktNavigation).WithMany(p => p.Zakazs)
                .HasForeignKey(d => d.IdPunkt)
                .HasConstraintName("zakaz_punkt_vydahi_fk");

            entity.HasOne(d => d.IdSrokNavigation).WithMany(p => p.Zakazs)
                .HasForeignKey(d => d.IdSrok)
                .HasConstraintName("zakaz_srok_dostavki_fk");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.Zakazs)
                .HasForeignKey(d => d.IdStatus)
                .HasConstraintName("zakaz_status_zakaz_fk");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Zakazs)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("zakaz_users_fk");
        });

        modelBuilder.Entity<ZakazProduct>(entity =>
        {
            entity.HasKey(e => new { e.IdZakaz, e.IdProduct }).HasName("zakaz_product_pk");

            entity.ToTable("zakaz_product", "shubenok23");

            entity.Property(e => e.IdZakaz).HasColumnName("id_zakaz");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.Amount).HasColumnName("amount");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.ZakazProducts)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("zakaz_product_product_fk");

            entity.HasOne(d => d.IdZakazNavigation).WithMany(p => p.ZakazProducts)
                .HasForeignKey(d => d.IdZakaz)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("zakaz_product_zakaz_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
