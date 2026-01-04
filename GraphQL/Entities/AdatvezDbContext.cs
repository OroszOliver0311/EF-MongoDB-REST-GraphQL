using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace graphql.server.Entities;

public partial class AdatvezDbContext : DbContext
{
    public AdatvezDbContext()
    {
    }

    public AdatvezDbContext(DbContextOptions<AdatvezDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerSite> CustomerSites { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<InvoiceIssuer> InvoiceIssuers { get; set; }

    public virtual DbSet<InvoiceItem> InvoiceItems { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Vat> Vats { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC270700BAF1");

            entity.ToTable("Category");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.ParentCategoryId).HasColumnName("ParentCategoryID");

            entity.HasOne(d => d.ParentCategory).WithMany(p => p.InverseParentCategory)
                .HasForeignKey(d => d.ParentCategoryId)
                .HasConstraintName("FK__Category__Parent__717DADAD");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC277E6910F5");

            entity.ToTable("Customer");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BankAccount)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Login).HasMaxLength(50);
            entity.Property(e => e.MainCustomerSiteId).HasColumnName("MainCustomerSiteID");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);

            entity.HasOne(d => d.MainCustomerSite).WithMany(p => p.Customers)
                .HasForeignKey(d => d.MainCustomerSiteId)
                .HasConstraintName("Customer_MainCustomerSite");
        });

        modelBuilder.Entity<CustomerSite>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC27381018F5");

            entity.ToTable("CustomerSite");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Fax)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Street).HasMaxLength(50);
            entity.Property(e => e.Tel)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.ZipCode)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerSites)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__CustomerS__Custo__7A12F3AE");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Invoice__3214EC274947C76E");

            entity.ToTable("Invoice");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.CustomerCity).HasMaxLength(50);
            entity.Property(e => e.CustomerName).HasMaxLength(50);
            entity.Property(e => e.CustomerStreet).HasMaxLength(50);
            entity.Property(e => e.CustomerZipCode)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DeliveryDate).HasColumnType("datetime");
            entity.Property(e => e.InvoiceIssuerId).HasColumnName("InvoiceIssuerID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.PaymentDeadline).HasColumnType("datetime");
            entity.Property(e => e.PaymentMethod).HasMaxLength(20);

            entity.HasOne(d => d.InvoiceIssuer).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.InvoiceIssuerId)
                .HasConstraintName("FK__Invoice__Invoice__0955373E");

            entity.HasOne(d => d.Order).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__Invoice__OrderID__0A495B77");
        });

        modelBuilder.Entity<InvoiceIssuer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__InvoiceI__3214EC279E51DCDE");

            entity.ToTable("InvoiceIssuer");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BankAccount)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Street).HasMaxLength(50);
            entity.Property(e => e.TaxIdentifier)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ZipCode)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<InvoiceItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__InvoiceI__3214EC279228AE09");

            entity.ToTable("InvoiceItem");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.InvoiceId).HasColumnName("InvoiceID");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.OrderItemId).HasColumnName("OrderItemID");
            entity.Property(e => e.Vatpercentage).HasColumnName("VATPercentage");

            entity.HasOne(d => d.Invoice).WithMany(p => p.InvoiceItems)
                .HasForeignKey(d => d.InvoiceId)
                .HasConstraintName("FK__InvoiceIt__Invoi__0D25C822");

            entity.HasOne(d => d.OrderItem).WithMany(p => p.InvoiceItems)
                .HasForeignKey(d => d.OrderItemId)
                .HasConstraintName("FK__InvoiceIt__Order__0E19EC5B");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Order__3214EC27FA54FD67");

            entity.ToTable("Order");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CustomerSiteId).HasColumnName("CustomerSiteID");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Deadline).HasColumnType("datetime");
            entity.Property(e => e.PaymentMethodId).HasColumnName("PaymentMethodID");
            entity.Property(e => e.StatusId).HasColumnName("StatusID");

            entity.HasOne(d => d.CustomerSite).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerSiteId)
                .HasConstraintName("FK__Order__CustomerS__7DE38492");

            entity.HasOne(d => d.PaymentMethod).WithMany(p => p.Orders)
                .HasForeignKey(d => d.PaymentMethodId)
                .HasConstraintName("FK__Order__PaymentMe__7FCBCD04");

            entity.HasOne(d => d.Status).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK__Order__StatusID__7ED7A8CB");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderIte__3214EC278E078912");

            entity.ToTable("OrderItem");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.StatusId).HasColumnName("StatusID");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderItem__Order__02A839AF");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__OrderItem__Produ__039C5DE8");

            entity.HasOne(d => d.Status).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK__OrderItem__Statu__04908221");
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PaymentM__3214EC27206C1E77");

            entity.ToTable("PaymentMethod");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Method).HasMaxLength(20);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3214EC27621873C7");

            entity.ToTable("Product");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Description).HasColumnType("xml");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Vatid).HasColumnName("VATID");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Product__Categor__754E3E91");

            entity.HasOne(d => d.Vat).WithMany(p => p.Products)
                .HasForeignKey(d => d.Vatid)
                .HasConstraintName("FK__Product__VATID__745A1A58");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Status__3214EC274A7C18F0");

            entity.ToTable("Status");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<Vat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VAT__3214EC274E50DF42");

            entity.ToTable("VAT");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
