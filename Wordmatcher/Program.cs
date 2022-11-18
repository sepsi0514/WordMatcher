// See https://aka.ms/new-console-template for more information
using SQLiteDao;
using Wordmatcher;

var sqliteDb = new DictionaryContext();

Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("F1: new Word");
Console.WriteLine("F2: random Word");
Console.WriteLine("F3: new verb conjugation");

var mode = Console.ReadKey();
Console.Clear();

if (mode.Key == ConsoleKey.F1) NewWord();
if (mode.Key == ConsoleKey.F3) NewVorbConjugation();


if (mode.Key == ConsoleKey.F2)
{
    Console.WriteLine("F1: Spanyol");
    Console.WriteLine("F2: Magyar");
    mode = Console.ReadKey();

    RandomWord(mode.Key == ConsoleKey.F1);
}

Console.ReadLine();

/**
 * Methods
 */
void NewWord()
{
    var newWord = new WordCreator(sqliteDb);
    newWord.CreateNewWord();
}

void RandomWord(bool mode)
{
    WordMatcher wordmatcher = new WordMatcher(sqliteDb);
    wordmatcher.RandomWord(mode);
}

void NewVorbConjugation()
{
    VerbConjugationCreator verbConjugationCreator = new VerbConjugationCreator(sqliteDb);
    verbConjugationCreator.CreateNewVerbConjugation();
}
