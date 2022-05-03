using System;
using System.Collections.Generic;
using LibreriaColibri.Models;
using LibreriaColibri.Models.Dtos;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LibreriaColibri.Data
{
    public partial class LibraryContext : IdentityDbContext
    {
        public LibraryContext()
        {
        }

        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TAuthor> TAuthors { get; set; } = null!;
        public virtual DbSet<TBook> TBooks { get; set; } = null!;
        public virtual DbSet<TBookAuthor> TBookAuthors { get; set; } = null!;
        public virtual DbSet<TBookCategory> TBookCategories { get; set; } = null!;
        public virtual DbSet<TCarBook> TCarBooks { get; set; } = null!;
        public virtual DbSet<TCategory> TCategories { get; set; } = null!;
        public virtual DbSet<TOrder> TOrders { get; set; } = null!;
        public virtual DbSet<TOrderBook> TOrderBooks { get; set; } = null!;
        public virtual DbSet<TPublishingHouse> TPublishingHouses { get; set; } = null!;
        public virtual DbSet<TShoppingCar> TShoppingCars { get; set; } = null!;
        public virtual DbSet<TStatus> TStatuses { get; set; } = null!;

        public DbSet<Usuario> Usuario { get; set; } = null!;

        //Dto's
        public DbSet<GetBooksDto> GetBooks { get; set; } = null!;
        public DbSet<GetBookDetailsDto> GetBookDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TAuthor>(entity =>
            {
                entity.ToTable("t_Authors");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.NameAuthor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nameAuthor");
            });

            modelBuilder.Entity<TBook>(entity =>
            {
                entity.ToTable("t_Books");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Depot).HasColumnName("depot");

                entity.Property(e => e.IdPh).HasColumnName("idPH");

                entity.Property(e => e.Img)
                    .IsUnicode(false)
                    .HasColumnName("img");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(6, 2)")
                    .HasColumnName("price");

                entity.Property(e => e.Sold).HasColumnName("sold");

                entity.Property(e => e.Stock).HasColumnName("stock");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tittle");

                entity.HasOne(d => d.IdPhNavigation)
                    .WithMany(p => p.TBooks)
                    .HasForeignKey(d => d.IdPh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_t_PublishingHouse_t_Books");
            });

            modelBuilder.Entity<TBookAuthor>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("t_BookAuthor");

                entity.Property(e => e.IdAuthor).HasColumnName("idAuthor");

                entity.Property(e => e.IdBook).HasColumnName("idBook");

                entity.HasOne(d => d.IdAuthorNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdAuthor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__t_BookAut__idAut__5535A963");

                entity.HasOne(d => d.IdBookNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdBook)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__t_BookAut__idBoo__5441852A");
            });

            modelBuilder.Entity<TBookCategory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("t_BookCategory");

                entity.Property(e => e.IdBook).HasColumnName("idBook");

                entity.Property(e => e.IdCategory).HasColumnName("idCategory");

                entity.HasOne(d => d.IdBookNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdBook)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__t_BookCat__idBoo__6EF57B66");

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__t_BookCat__idCat__6FE99F9F");
            });

            modelBuilder.Entity<TCarBook>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("t_CarBook");

                entity.Property(e => e.IdBook).HasColumnName("idBook");

                entity.Property(e => e.IdCar).HasColumnName("idCar");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.IdBookNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdBook)
                    .HasConstraintName("FK__t_CarBook__idBoo__6D0D32F4");

                entity.HasOne(d => d.IdCarNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdCar)
                    .HasConstraintName("FK__t_CarBook__idCar__0C85DE4D");
            });

            modelBuilder.Entity<TCategory>(entity =>
            {
                entity.ToTable("t_Categories");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.NameCat)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nameCat");
            });

            modelBuilder.Entity<TOrder>(entity =>
            {
                entity.ToTable("t_Orders");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.IdStatus).HasColumnName("idStatus");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.TOrders)
                    .HasForeignKey(d => d.IdStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_t_Orders_t_Status");
            });

            modelBuilder.Entity<TOrderBook>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("t_OrderBook");

                entity.Property(e => e.IdBook).HasColumnName("idBook");

                entity.Property(e => e.IdOrder).HasColumnName("idOrder");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.IdBookNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdBook)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__t_OrderBo__idBoo__628FA481");

                entity.HasOne(d => d.IdOrderNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__t_OrderBo__idOrd__6383C8BA");
            });

            modelBuilder.Entity<TPublishingHouse>(entity =>
            {
                entity.ToTable("t_PublishingHouse");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.NamePh)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("namePH");
            });

            modelBuilder.Entity<TShoppingCar>(entity =>
            {
                entity.ToTable("t_ShoppingCar");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdUser).HasColumnName("idUser");
            });

            modelBuilder.Entity<TStatus>(entity =>
            {
                entity.ToTable("t_Status");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.StatusName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("statusName");
            });

            modelBuilder.Entity<GetBooksDto>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<GetBookDetailsDto>(entity =>
            {
                entity.HasNoKey();
            });


            base.OnModelCreating(modelBuilder);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
