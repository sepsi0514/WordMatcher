using Microsoft.EntityFrameworkCore;
using SQLiteDao.Models;

namespace SQLiteDao
{
    public class DictionaryContext : DbContext
    {
        public string DbPath { get; }

        public DictionaryContext()
        {
            DbPath = "C:\\Repos\\WordMatcher\\Databases\\Dictionary.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
       => options.UseSqlite($"Data Source={DbPath}");

        public DbSet<Words> Words { get; set; }
        public DbSet<Translate> Translates { get; set; }
        public DbSet<WordType> WordType { get; set; }
        public DbSet<VerbConjugation> VerbConjugation { get; set; }
    }
}
