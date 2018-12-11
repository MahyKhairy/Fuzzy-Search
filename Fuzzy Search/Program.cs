using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuzzy_Search
{
    class Program
    {
        static void Main(string[] args)
        {
            bool x = true;
            while (x)
            {
                Console.WriteLine("Please Enter File URL: ");
                string filePath = Console.ReadLine();
                Console.WriteLine("Please Enter Pattern: ");
                string pattern = Console.ReadLine();
                int score;
                string fileConetent = File.ReadAllText(filePath);
                FuzzyMatcher.FuzzyMatch(fileConetent, pattern, out score);
                Console.WriteLine("Matched with Score [{0}]", score);

                Console.WriteLine("Do you want to continue? Y/N");
                string answer = Console.ReadLine();
                if (answer.ToLower() != "y")
                    x = false;
            }
        }

    }
}
