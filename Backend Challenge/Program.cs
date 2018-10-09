using System;
using System.IO;
using System.Linq;

namespace Backend_Challenge
{
	internal class Program
	{
		internal static void Main()
		{
			var words = File.ReadLines("wordlist").ToList(); // 99175
			var anagramWords = Anagram.FilterPossible(words); // 1788
			var longestAnagramWordLength = anagramWords.OrderByDescending(a => a.Length).First().Length;

			//var words = new List<string> { "a", "b", "c"};
			var wordCombinations = Combinations.GetAllPossible(anagramWords.ToArray(), Anagram.Phrase.Length, longestAnagramWordLength);

			foreach (var wordCombination in wordCombinations)
			{
				if (wordCombination.IsAnagram(Anagram.Phrase))
					Console.WriteLine(wordCombination);
			}

			Console.ReadLine();
		}
	}
}
