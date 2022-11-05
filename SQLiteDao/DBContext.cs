using Microsoft.EntityFrameworkCore;
using SQLiteDao.Models;

namespace SQLiteDao
{
    public class DictionaryContext : DbContext
    {
        public string DbPath { get; }

        public DictionaryContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "Dictionary.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
       => options.UseSqlite($"Data Source={DbPath}");

        public DbSet<Words> Words { get; set; }
        public DbSet<Translate> Translates { get; set; }
        public DbSet<WordType> WordType { get; set; }
    }
}
