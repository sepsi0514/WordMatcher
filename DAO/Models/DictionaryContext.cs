using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace DAO.Models
{
    public partial class DictionaryContext : DbContext
    {
        public DictionaryContext()
        {
        }

        public DictionaryContext(DbContextOptions<DictionaryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Language> Languages { get; set; } = null!;
        public virtual DbSet<Translate> Translates { get; set; } = null!;
        public virtual DbSet<VerbConjugation> VerbConjugations { get; set; } = null!;
        public virtual DbSet<Word> Words { get; set; } = null!;
        public virtual DbSet<WordType> WordTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

                IConfiguration config = builder.Build();

                var connectionString = config.GetConnectionString("DictionaryDatabase");

                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ParentId).HasColumnName("Parent_Id");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Translate>(entity =>
            {
                entity.Property(e => e.Word1Id).HasColumnName("Word_1_id");

                entity.Property(e => e.Word2Id).HasColumnName("Word_2_id");
            });

            modelBuilder.Entity<VerbConjugation>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VerbConjugation");

                entity.Property(e => e.E1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("E_1");

                entity.Property(e => e.E2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("E_2");

                entity.Property(e => e.E3)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("E_3");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Mode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.T1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("T_1");

                entity.Property(e => e.T2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("T_2");

                entity.Property(e => e.T3)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("T_3");

                entity.Property(e => e.WordId).HasColumnName("Word_Id");
            });

            modelBuilder.Entity<Word>(entity =>
            {
                entity.Property(e => e.CategoryId).HasColumnName("Category_id");

                entity.Property(e => e.LanguageId).HasColumnName("Language_id");

                entity.Property(e => e.TypeId).HasColumnName("Type_id");

                entity.Property(e => e.Word1)
                    .HasMaxLength(50)
                    .HasColumnName("Word");
            });

            modelBuilder.Entity<WordType>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("WordType");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
