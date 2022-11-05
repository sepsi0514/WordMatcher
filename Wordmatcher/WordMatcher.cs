using SQLiteDao;
using SQLiteDao.Models;
using Wordmatcher.Models;

namespace Wordmatcher
{
    public class WordMatcher
    {
        private readonly DictionaryContext _dbContext;

        public WordMatcher(DictionaryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void RandomWord(bool isEsp)
        {
            int wordMatchCounter = 1;
            Console.WriteLine("Random Word");
            Random rnd = new Random();
            var missMatch = -1;

            var words = (from t1 in _dbContext.Words
                         join t2 in _dbContext.Translates on t1.Id equals t2.Word1_id
                         join t3 in _dbContext.Words on t2.Word2_id equals t3.Id
                         where t1.Category_id == 3
                         select new WordMatcherResult
                         {
                             Word1 = t1.Word,
                             Word2 = t3.Word,
                             WordMatch = 0
                         }).ToList();

            while (words.FirstOrDefault(word => word.WordMatch < wordMatchCounter) != null)
            {
                Console.ForegroundColor = ConsoleColor.White;

                Console.Clear();
                Console.WriteLine($"Még {words.Where(word => word.WordMatch < wordMatchCounter).ToList().Count} szó van");
                Console.WriteLine("Új kör");
                var inGameWords = words.Where(word => word.WordMatch < wordMatchCounter).ToList();

                int r = missMatch < 0 ? rnd.Next(inGameWords.Count) : missMatch;
                var randomWord = inGameWords[r];

                Console.WriteLine(isEsp ? randomWord.Word1 : randomWord.Word2);
                var answer = Console.ReadLine();
                if (answer == (isEsp ? randomWord.Word2 : randomWord.Word1))
                {
                    var wordToUpdate = words.FirstOrDefault(word => word.Word1 == randomWord.Word1);

                    if (wordToUpdate != null)
                    {
                        wordToUpdate.WordMatch++;
                    }

                    missMatch = -1;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Nem talált. A megfejtés: {(isEsp ? randomWord.Word2 : randomWord.Word1)}");
                    var wordToUpdate = words.FirstOrDefault(word => word.Word1 == randomWord.Word1);

                    if(wordToUpdate != null)
                    {
                        wordToUpdate.WordMatch--;
                    }

                    missMatch = r;
                    Console.ReadLine();
                }
            }
        }
    }
}
