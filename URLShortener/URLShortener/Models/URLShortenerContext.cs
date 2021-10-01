using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Configuration;
#nullable disable

namespace URLShortener.Models
{
    public partial class URLShortenerContext : DbContext
    {
        public URLShortenerContext()
        {
        }

        public URLShortenerContext(DbContextOptions<URLShortenerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Urlshortener> Urlshorteners { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=V002219;Database=URLShortener;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Urlshortener>(entity =>
            {
                entity.HasKey(e => e.UrlId);

                entity.ToTable("URLSHORTENER");

                entity.Property(e => e.UrlId).HasColumnName("urlID");

                entity.Property(e => e.UrlMaster).HasColumnName("urlMaster");

                entity.Property(e => e.UrlShort).HasColumnName("urlShort");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
