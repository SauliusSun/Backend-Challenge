using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Backend_Challenge
{
    internal class Program
    {
        private const string AnagramOf = "poultryoutwitsants";

        internal static void Main()
        {

            var words = File.ReadLines("wordlist").ToList();
            //Console.WriteLine(words.Count);
            var anagramWords = GetWordsForAnagram(words);
            var longestAnagramWordLength = anagramWords.OrderByDescending(a => a.Length).First().Length;
            //Console.WriteLine(anagramWords.Count);

            //var words = new List<string> { "a", "b", "c"};
            var wordCombinations = Combinations.GetAllPossible(anagramWords.ToArray(), AnagramOf.Length, longestAnagramWordLength);
          
            foreach (var wordCombination in wordCombinations)
            {
                if (wordCombination.IsAnagram(AnagramOf))
                    Console.WriteLine(wordCombination);
            }
        }

        private static IList<string> GetWordsForAnagram(IList<string> words)
        {
            var anagramWords = new List<string>();
            foreach (var word in words)
            {
                var add = true;
                foreach (var letter in word)
                {
                    if (!AnagramOf.Contains(letter))
                    {
                        add = false;
                        break;
                    }

                    var wordLetterCount = word.Count(l => l == letter);
                    var anagramLetterCount = AnagramOf.Count(l => l == letter);
                    if (wordLetterCount > anagramLetterCount)
                    {
                        add = false;
                        break;
                    }

                }

                if (add)
                    anagramWords.Add(word);
            }

            return anagramWords;
        }
    }
}
