using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Baseinfo
{
    public partial class baseinfoContext : DbContext
    {
        public baseinfoContext()
        {
        }

        public baseinfoContext(DbContextOptions<baseinfoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Animal> Animals { get; set; } = null!;
        public virtual DbSet<Sex> Sexes { get; set; } = null!;
        public virtual DbSet<Type> Types { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=baseinfo;Username=postgres;Password=1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("accounts_pkey");

                entity.ToTable("accounts");

                entity.HasIndex(e => e.Username, "accounts_username_key")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Animal>(entity =>
            {
                entity.HasKey(e => e.AnimalsId)
                    .HasName("animals_pkey");

                entity.ToTable("animals");

                entity.HasIndex(e => e.Name, "animals_Unique_name")
                    .IsUnique();

                entity.Property(e => e.AnimalsId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("animals_id");

                entity.Property(e => e.DateBorn).HasColumnName("date_born");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying(50)[]")
                    .HasColumnName("name");

                entity.Property(e => e.Person).HasColumnName("person");

                entity.Property(e => e.Sex)
                    .HasColumnName("sex")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.HasOne(d => d.Animals)
                    .WithOne(p => p.Animal)
                    .HasForeignKey<Animal>(d => d.AnimalsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("animals_animals_id_fkey");

                entity.HasOne(d => d.PersonNavigation)
                    .WithMany(p => p.Animals)
                    .HasForeignKey(d => d.Person)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("animals_person_fkey");

                entity.HasOne(d => d.SexNavigation)
                    .WithMany(p => p.Animals)
                    .HasForeignKey(d => d.Sex)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("animals_sex_fkey");
            });

            modelBuilder.Entity<Sex>(entity =>
            {
                entity.ToTable("sex");

                entity.Property(e => e.SexId).HasColumnName("sex_id");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.ToTable("type");

                entity.HasIndex(e => e.Name, "type_name_key")
                    .IsUnique();

                entity.Property(e => e.TypeId)
                    .HasColumnName("type_id")
                    .HasDefaultValueSql("nextval('type_tpye_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
