using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DSED_07_Web_Development.Models;

namespace DSED_07_Web_Development.Models
{
    public partial class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
       : base(options)
        { }

        public virtual DbSet<ComuterScience> ComuterScience { get; set; }
        public virtual DbSet<Novels> Novels { get; set; }
        public virtual DbSet<Sports> Sports { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComuterScience>(entity =>
            {
                entity.HasKey(e => e.BookId);

                entity.Property(e => e.BookId)
                    .HasColumnName("BookID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BookAuthor).HasMaxLength(50);

                entity.Property(e => e.BookName).HasMaxLength(50);
            });

            modelBuilder.Entity<Novels>(entity =>
            {
                entity.HasKey(e => e.NovelId);

                entity.Property(e => e.NovelId)
                    .HasColumnName("NovelID")
                    .ValueGeneratedNever();

                entity.Property(e => e.NovelAuthor).HasMaxLength(50);

                entity.Property(e => e.NovelName).HasMaxLength(50);
            });

            modelBuilder.Entity<Sports>(entity =>
            {
                entity.HasKey(e => e.SportId);

                entity.Property(e => e.SportId).ValueGeneratedNever();

                entity.Property(e => e.SportCoach).HasMaxLength(50);

                entity.Property(e => e.SportName).HasMaxLength(50);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.Property(e => e.CustomerId).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Mobile).HasMaxLength(50);
                entity.Property(e => e.Email).HasMaxLength(50);
                entity.Property(e => e.Age).HasMaxLength(50);
            });
        }

       
    }
}
