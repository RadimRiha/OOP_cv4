using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_cv4
{
    class Program
    {
        static void Main(string[] args)
        {
            string TestText = "Toto je retezec predstavovany nekolika radky,\n"
                                 + "ktere jsou od sebe oddeleny znakem LF (Line Feed).\n"
                                 + "Je tu i nejaky ten vykricnik! Pro ucely testovani i otaznik?\n"
                                 + "Toto je jen zkratka zkr. ale ne konec vety. A toto je\n"
                                 + "posledni veta!";

            StringStatistics Statistics = new StringStatistics(TestText);
            Console.WriteLine("Input string:\n{0}\n", TestText);
            Console.WriteLine("Number of words: {0}\n", Statistics.WordCount());
            Console.WriteLine("Number of lines: {0}\n", Statistics.LineCount());
            Console.WriteLine("Number of sentences: {0}\n", Statistics.SentenceCount());
            Console.WriteLine("Longest words: {0}\n", string.Join(", ", Statistics.LongestWords()));
            Console.WriteLine("Shortest words: {0}\n", string.Join(", ", Statistics.ShortestWords()));
            Console.WriteLine("Most common words: {0}\n", string.Join(", ", Statistics.MostCommonWords()));
            Console.WriteLine("Words in alphabetical order: {0}\n", string.Join(", ", Statistics.AlphabeticalOrder()));
            Console.WriteLine("Is string infected: {0}\n", Statistics.IsInfected());
        }
    }
}
