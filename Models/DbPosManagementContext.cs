using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace web_app.Models;

public partial class DbPosManagementContext : DbContext
{
    public DbPosManagementContext()
    {
    }

    public DbPosManagementContext(DbContextOptions<DbPosManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbMEmployee> TbMEmployees { get; set; }

    public virtual DbSet<TbMProduct> TbMProducts { get; set; }

    public virtual DbSet<TbMRole> TbMRoles { get; set; }

    public virtual DbSet<TbMTransactionItem> TbMTransactionItems { get; set; }

    public virtual DbSet<TbMUnit> TbMUnits { get; set; }

    public virtual DbSet<TbTrPrice> TbTrPrices { get; set; }

    public virtual DbSet<TbTrTransaction> TbTrTransactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-SJCEEP0M;User ID=MCC79;Password=12345678;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False; database = db_pos_management");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbMEmployee>(entity =>
        {
            entity.HasKey(e => e.Guid);

            entity.ToTable("tb_m_employee");

            entity.HasIndex(e => e.RoleGuid, "IX_tb_m_employee_role_guid");

            entity.HasIndex(e => e.Username, "IX_tb_m_employee_username").IsUnique();

            entity.Property(e => e.Guid)
                .ValueGeneratedNever()
                .HasColumnName("guid");
            entity.Property(e => e.Firstname)
                .HasMaxLength(200)
                .HasColumnName("firstname");
            entity.Property(e => e.Isdelete).HasColumnName("isdelete");
            entity.Property(e => e.Lastname)
                .HasMaxLength(200)
                .HasColumnName("lastname");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.RoleGuid).HasColumnName("role_guid");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .HasColumnName("username");
        });

        modelBuilder.Entity<TbMProduct>(entity =>
        {
            entity.HasKey(e => e.Guid);

            entity.ToTable("tb_m_product");

            entity.Property(e => e.Guid)
                .ValueGeneratedNever()
                .HasColumnName("guid");
            entity.Property(e => e.BarcodeId)
                .HasMaxLength(255)
                .HasColumnName("barcode_id");
            entity.Property(e => e.Isdelete).HasColumnName("isdelete");
            entity.Property(e => e.Title)
                .HasMaxLength(150)
                .HasColumnName("title");
        });

        modelBuilder.Entity<TbMRole>(entity =>
        {
            entity.HasKey(e => e.Guid);

            entity.ToTable("tb_m_role");

            entity.Property(e => e.Guid)
                .ValueGeneratedNever()
                .HasColumnName("guid");
            entity.Property(e => e.Isdelete).HasColumnName("isdelete");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<TbMTransactionItem>(entity =>
        {
            entity.HasKey(e => e.Guid);

            entity.ToTable("tb_m_transaction_item");

            entity.HasIndex(e => e.PriceGuid, "IX_tb_m_transaction_item_price_guid");

            entity.HasIndex(e => e.ProductGuid, "IX_tb_m_transaction_item_product_guid");

            entity.HasIndex(e => e.TransactionGuid, "IX_tb_m_transaction_item_transaction_guid");

            entity.Property(e => e.Guid)
                .ValueGeneratedNever()
                .HasColumnName("guid");
            entity.Property(e => e.Isdelete).HasColumnName("isdelete");
            entity.Property(e => e.PriceGuid).HasColumnName("price_guid");
            entity.Property(e => e.ProductGuid).HasColumnName("product_guid");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Subtotal)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("subtotal");
            entity.Property(e => e.TransactionGuid).HasColumnName("transaction_guid");
        });

        modelBuilder.Entity<TbMUnit>(entity =>
        {
            entity.HasKey(e => e.Guid);

            entity.ToTable("tb_m_unit");

            entity.Property(e => e.Guid)
                .ValueGeneratedNever()
                .HasColumnName("guid");
            entity.Property(e => e.Isdelete).HasColumnName("isdelete");
        });

        modelBuilder.Entity<TbTrPrice>(entity =>
        {
            entity.HasKey(e => e.Guid);

            entity.ToTable("tb_tr_price");

            entity.HasIndex(e => e.UnitGuid, "IX_tb_tr_price_price_guid");

            entity.HasIndex(e => e.ProductGuid, "IX_tb_tr_price_product_guid");

            entity.Property(e => e.Guid)
                .ValueGeneratedNever()
                .HasColumnName("guid");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.Isdelete).HasColumnName("isdelete");
            entity.Property(e => e.ProductGuid).HasColumnName("product_guid");
            entity.Property(e => e.UnitGuid).HasColumnName("unit_guid");
        });

        modelBuilder.Entity<TbTrTransaction>(entity =>
        {
            entity.HasKey(e => e.Guid);

            entity.ToTable("tb_tr_transaction");

            entity.HasIndex(e => e.EmployeeGuid, "IX_tb_tr_transaction_employee_guid");

            entity.Property(e => e.Guid)
                .ValueGeneratedNever()
                .HasColumnName("guid");
            entity.Property(e => e.EmployeeGuid).HasColumnName("employee_guid");
            entity.Property(e => e.Isdelete).HasColumnName("isdelete");
            entity.Property(e => e.TotalAmmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("total_ammount");
            entity.Property(e => e.TransactionDate).HasColumnName("transaction_date");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
