using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace apotekkk.Models
{
    public partial class ApotekContext : DbContext
    {
        public ApotekContext()
        {
        }

        public ApotekContext(DbContextOptions<ApotekContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Apoteker> Apoteker { get; set; }
        public virtual DbSet<Nota> Nota { get; set; }
        public virtual DbSet<Obat> Obat { get; set; }
        public virtual DbSet<Pembeli> Pembeli { get; set; }
        public virtual DbSet<Transaksi> Transaksi { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-QHB05ME0\\FAFA;Database=Apotek;Trusted_Connection=True;MultipleActiveResultSets=true;User Id=sa;Password=123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apoteker>(entity =>
            {
                entity.HasKey(e => e.IdApoteker);

                entity.Property(e => e.IdApoteker).HasColumnName("Id_Apoteker");

                entity.Property(e => e.Password)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Nota>(entity =>
            {
                entity.HasKey(e => e.IdNota);

                entity.Property(e => e.IdNota).HasColumnName("Id_nota");

                entity.Property(e => e.IdTransaksi).HasColumnName("Id_transaksi");

                entity.Property(e => e.TotalHarga).HasColumnName("total_harga");

                entity.HasOne(d => d.IdTransaksiNavigation)
                    .WithMany(p => p.Nota)
                    .HasForeignKey(d => d.IdTransaksi)
                    .HasConstraintName("FK_Nota_Transaksi");
            });

            modelBuilder.Entity<Obat>(entity =>
            {
                entity.HasKey(e => e.IdObat);

                entity.Property(e => e.IdObat).HasColumnName("Id_obat");

                entity.Property(e => e.Harga).HasColumnName("harga");

                entity.Property(e => e.JenisObat)
                    .HasColumnName("jenis_obat")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NamaObat)
                    .HasColumnName("nama_obat")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Quantity).HasColumnName("quantity");
            });

            modelBuilder.Entity<Pembeli>(entity =>
            {
                entity.HasKey(e => e.IdPembeli);

                entity.Property(e => e.IdPembeli).HasColumnName("Id_Pembeli");

                entity.Property(e => e.PasswordPembeli)
                    .HasColumnName("Password_pembeli")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.UsernamePembeli)
                    .HasColumnName("Username_pembeli")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Transaksi>(entity =>
            {
                entity.HasKey(e => e.IdTransaksi);

                entity.Property(e => e.IdTransaksi).HasColumnName("Id_transaksi");

                entity.Property(e => e.IdApoteker).HasColumnName("Id_Apoteker");

                entity.Property(e => e.IdObat).HasColumnName("Id_obat");

                entity.Property(e => e.IdPembeli).HasColumnName("Id_Pembeli");

                entity.Property(e => e.TglTransaksi)
                    .HasColumnName("tgl_transaksi")
                    .HasColumnType("date");

                entity.Property(e => e.TotalHarga).HasColumnName("total_harga");

                entity.HasOne(d => d.IdApotekerNavigation)
                    .WithMany(p => p.Transaksi)
                    .HasForeignKey(d => d.IdApoteker)
                    .HasConstraintName("FK_Transaksi_Apoteker");

                entity.HasOne(d => d.IdObatNavigation)
                    .WithMany(p => p.Transaksi)
                    .HasForeignKey(d => d.IdObat)
                    .HasConstraintName("FK_Transaksi_Obat");

                entity.HasOne(d => d.IdPembeliNavigation)
                    .WithMany(p => p.Transaksi)
                    .HasForeignKey(d => d.IdPembeli)
                    .HasConstraintName("FK_Transaksi_Pembeli");
            });
        }
    }
}
