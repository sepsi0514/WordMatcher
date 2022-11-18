using SQLiteDao;
using SQLiteDao.Models;

namespace Wordmatcher
{
    public class VerbConjugationCreator
    {
        private readonly List<string> pronouns = new() { "E1", "E2", "E3", "T1", "T2", "T3" };
        private readonly DictionaryContext _dbContext;

        public VerbConjugationCreator(DictionaryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateNewVerbConjugation()
        {            
            while (true)
            {
                var pronounResult = new List<string>();
                Console.WriteLine("A szó spanyolul");
                var wordStr = Console.ReadLine();

                var wordModel = _dbContext.Words.FirstOrDefault(word => word.Word == wordStr);                

                if (wordModel == null)
                {
                    Console.WriteLine("Nem található a szó");
                    continue;
                }

                foreach (var pronoun in pronouns)
                {
                    Console.Write($"{pronoun}: ");
                    pronounResult.Add(Console.ReadLine());
                }

                var verbConjugationId = _dbContext.VerbConjugation.ToList().OrderByDescending(v => v.Id).FirstOrDefault()?.Id ?? 0;
                var verbConjugation = new VerbConjugation()
                {
                    Id = ++verbConjugationId,
                    Word_Id = wordModel.Id,
                    Mode = "Indefinido",
                    E_1 = pronounResult[0],
                    E_2 = pronounResult[1],
                    E_3 = pronounResult[2],
                    T_1 = pronounResult[3],
                    T_2 = pronounResult[4],
                    T_3 = pronounResult[5],
                };

                _dbContext.VerbConjugation.Add(verbConjugation);
                _dbContext.SaveChanges();
                Console.Clear();
            }
        }
    }
}
