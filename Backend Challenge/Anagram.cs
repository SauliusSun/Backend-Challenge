using System;
using Backend_Challenge.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Backend_Challenge
{
	public static class Anagram
	{
		public const string Phrase = "poultry outwits ants";

		//public static bool IsAnagram(this string phrase, string anagramOf)
		//{
		//	if (phrase == null || anagramOf == null)
		//		return false;

		//	if (phrase.Length != anagramOf.Length)
		//		return false;

		//	foreach (var letter in phrase)
		//	{
		//		if (!anagramOf.Contains(letter))
		//			return false;

		//		var wordLetterCount = phrase.Count(l => l == letter);
		//		var anagramLetterCount = anagramOf.Count(l => l == letter);
		//		if (wordLetterCount != anagramLetterCount)
		//			return false;
		//	}

		//	return true;
		//}

		public static IEnumerable<string> Filter(ICollection<string> words)
		{
			var possibleWords = new HashSet<string>();
			var comparablePhrase = Phrase.GetComparable();

			foreach (var word in words)
			{
				if (string.IsNullOrWhiteSpace(word))
					continue;

				var comparableWord = word.GetComparable();
				var add = true;
				foreach (var letter in comparableWord)
				{
					if (!comparablePhrase.Contains(letter))
					{
						add = false;
						break;
					}

					var comparableWordLetterCount = comparableWord.Count(l => l == letter);
					var comparablePhraseLetterCount = comparablePhrase.Count(l => l == letter);
					if (comparableWordLetterCount > comparablePhraseLetterCount)
					{
						add = false;
						break;
					}
				}

				if (add)
				{
					possibleWords.Add(word);
				}
			}

			return possibleWords;
		}

		public static List<string> SearchForAnagram(string anagram, List<string> words, int wordsLeft)
		{
			List<string> foundWords;
			List<string> subsets = FindSubsets(anagram, words);
			if (wordsLeft == 1)
			{
				foundWords = subsets;
			}
			else
			{
				foundWords = new List<string>(subsets.Count);

				int i = 0;

				foreach (string word in subsets)
				{

					//Console.WriteLine("Level {0} iter {1}/{2}", wordsLeft, i, subsets.Count);
					//if (wordsLeft == 3)
					//{
					//	Thread.Sleep(200);
					//}


					string rest = anagram.Subtract(word);

					if (String.IsNullOrEmpty(rest.Trim()))
						continue;

					List<string> nextWords = SearchForAnagram(rest, subsets, wordsLeft - 1);
					foreach (string nw in nextWords)
					{
						if (nw.Replace(" ", "").Length == rest.Replace(" ", "").Length)
						{
							string combined = word + " " + nw;
							foundWords.Add(combined);
						}
					}
				}
			}

			return foundWords;
		}

		public static List<string> FindSubsets(string superset, List<string> words)
		{
			List<string> subsets = new List<string>();
			foreach (string word in words)
				if (word.IsSubsetOf(superset))
					subsets.Add(word);

			return subsets;
		}

		public static bool IsSubsetOf(this string s, string other)
		{
			if (s.Length > other.Length)
				return false;

			foreach (char c in other)
			{
				if (other.Contains(c.ToString()) == false)
					return false;
			}

			Dictionary<char, uint> countsS = s.Counts();
			Dictionary<char, uint> countsOther = other.Counts();

			foreach (KeyValuePair<char, uint> p in countsS)
			{
				if ((countsOther.ContainsKey(p.Key) && countsOther[p.Key] >= p.Value))
					continue;
				return false;
			}

			return true;
		}

		public static Dictionary<char, uint> Counts(this string s)
		{
			Dictionary<char, uint> counts = new Dictionary<char, uint>(s.Length);
			foreach (char c in s)
			{
				if (counts.ContainsKey(c))
					counts[c]++;
				else
					counts.Add(c, 1);
			}
			return counts;
		}

		public static string Subtract(this string s, string other)
		{
			int[] drops = new int[other.Length];
			// initialize to -1
			for (int i = 0; i < drops.Length; i++)
				drops[i] = -1;

			for (int i = 0; i < other.Length; i++)
			{
				char c = other[i];
				int index = s.IndexOf(c);
				while (Array.IndexOf(drops, index) >= 0)
				{
					index += s.Substring(index + 1).IndexOf(c) + 1;
				}

				drops[i] = index;

			}

			return s.Drop(drops);
		}

		public static string Drop(this string s, int[] indices)
		{
			const char delChar = '_';
			char[] newChars = new char[s.Length - indices.Length];
			char[] sChars = s.ToCharArray();

			foreach (int i in indices)
			{
				sChars[i] = delChar;
			}

			int j = 0;
			foreach (char c in sChars)
			{
				if (c == delChar)
					continue;
				newChars[j++] = c;
			}

			return new string(newChars);
		}

	}
}