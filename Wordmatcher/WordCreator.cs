using SQLiteDao;
using SQLiteDao.Models;

namespace Wordmatcher
{
    public class WordCreator
    {
        private readonly DictionaryContext _dbContext;

        public WordCreator(DictionaryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateNewWord()
        {
            var wordTypes = _dbContext.WordType.ToList();

            while (true)
            {                
                Console.Write("Spanyolul: ");
                var esp = Console.ReadLine();

                Console.Write("Magyarul: ");
                var hun = Console.ReadLine();

                //foreach (var item in wordTypes)
                //{
                //    Console.WriteLine($"{item.Id}: {item.Type}");
                //}

                //Console.Write("Típus: ");

                int typeInt = 2;

                //Int32.TryParse(Console.ReadLine(), out typeInt);

                if (CheckDuplication(esp))
                {
                    Console.Clear();
                    Console.WriteLine("A szó már egyszer fel lett véve!");                    
                    continue;
                }

                _dbContext.Words.Add(new Words { Category_id = 14, Description = null, Language_id = 1, Word = esp, Type_id = typeInt });
                _dbContext.Words.Add(new Words { Category_id = 14, Description = null, Language_id = 2, Word = hun, Type_id = typeInt });

                _dbContext.SaveChanges();

                var hunId = _dbContext.Words.FirstOrDefault(word => word.Word == hun)?.Id;
                var espId = _dbContext.Words.FirstOrDefault(word => word.Word == esp)?.Id;

                if (hunId != null && espId != null)
                {
                    _dbContext.Translates.Add(new Translate { Word_1_id = (int)espId, Word_2_id= (int)hunId });
                }
                _dbContext.SaveChanges();

                Console.Clear();
                Console.WriteLine("Szó felvéve");
            }
        }

        private bool CheckDuplication(string? newWord) =>
            _dbContext.Words.FirstOrDefault(word => word.Word == newWord) != null;

    }
}