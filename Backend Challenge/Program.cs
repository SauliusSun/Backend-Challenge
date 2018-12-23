using System;
using System.IO;
using System.Linq;

namespace Backend_Challenge
{
	internal class Program
	{
		internal static void Main()
		{
			Console.WriteLine("Start");
			var words = File.ReadLines("wordlist").ToList(); // 99175
			var possibleWords = Anagram.Filter(words); // 1659
			File.WriteAllLines(@"c:\Users\sauli\Desktop\possibleWords.txt", possibleWords);

			var anagrams = Anagram.SearchForAnagram(Anagram.Phrase, possibleWords.ToList(), 3);
			File.WriteAllLines(@"c:\Users\sauli\Desktop\anagrams.txt", anagrams);

			Md5Cryptography.Check(anagrams);
			Console.WriteLine("End");
		}
	}
}
