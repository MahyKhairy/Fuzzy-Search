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
                string[] paragraphs = fileConetent.Split(new string[] { Environment.NewLine },StringSplitOptions.RemoveEmptyEntries);
                Dictionary<int, int> scoreAndLocation = new Dictionary<int, int>();
                for (int i = 0; i < paragraphs.Length; i++)
                {
                    score = MatchParagraph(pattern, paragraphs[i]);
                    int index = fileConetent.IndexOf(paragraphs[i]);
                    //Assuming correct score won't be duplicated
                    if (!scoreAndLocation.ContainsKey(score))
                        scoreAndLocation.Add(score, index);

                }

                var highScore = scoreAndLocation.OrderByDescending(d => d.Key).First();
                string newFilecontent = fileConetent.Remove(highScore.Value);
                File.WriteAllText("result.txt", newFilecontent);

                Console.WriteLine("New File was Created");
                Console.WriteLine("Do you want to continue? Y/N");
                string answer = Console.ReadLine();
                if (answer.ToLower() != "y")
                    x = false;
            }
        }

        private static int MatchParagraph(string pattern, string paragraph)
        {
            int score;
            FuzzyMatcher.FuzzyMatch(paragraph, pattern, out score);
            Console.WriteLine("Paragraph '{0}' Matched with Score [{1}]", paragraph, score);
            return score;
        }
    }
}
