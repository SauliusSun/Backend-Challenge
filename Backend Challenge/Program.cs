using System;
using System.IO;
using System.Linq;
using Backend_Challenge.Helpers;

namespace Backend_Challenge
{
	internal class Program
	{
		internal static void Main()
		{
			Console.WriteLine("Start");

			var words = File.ReadLines("wordlist").ToList(); // 99175
			var possibleWords = Anagram.FilterPossible(words); // 1659
			File.WriteAllLines(@"c:\Users\sauli\Desktop\possibleWords.txt", possibleWords);

			var wordCombinations = Combinations.GetAllPossible(possibleWords.ToArray(), Anagram.Phrase.GetComparable().Length);
			File.WriteAllLines(@"c:\Users\sauli\Desktop\combinations.txt", wordCombinations);

			Console.WriteLine("End");
			Console.ReadLine();
		}
	}
}
