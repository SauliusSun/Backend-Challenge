using System;
using System.Diagnostics;
using System.Text;

namespace Backend_Challenge
{
	public static class Combinations
	{
		private static readonly Stopwatch StopWatch1 = new Stopwatch();

		public static string[] GetAllPossible(string[] words, int anagramLength, int anagramLongestWordLength)
		{
			var combinations = new string[10000000];
			var combinationIndex = 0;

			for (var phraseCount = 0; phraseCount < words.Length; phraseCount++)
			{
				StopWatch1.Reset();
				StopWatch1.Start();
				for (var wordIndex = 0; wordIndex < words.Length; wordIndex++)
				{
					var phrase = GetPhrase(wordIndex, phraseCount, words);

					AddCombination(phrase, anagramLength, combinations, ref combinationIndex);

					if (phrase.Length + anagramLongestWordLength < anagramLength)
						break;

					foreach (var additionalPhraseWord in words)
					{
						phrase.Append(additionalPhraseWord);
						AddCombination(phrase, anagramLength, combinations, ref combinationIndex);
						phrase.Remove(phrase.Length - additionalPhraseWord.Length, additionalPhraseWord.Length);
					}
				}
				StopWatch1.Stop();
				Console.WriteLine($"phraseCount{phraseCount}Perf:{StopWatch1.ElapsedMilliseconds}");
			}

			return combinations;
		}

		private static StringBuilder GetPhrase(int wordIndex, int phraseCount, string[] words)
		{
			var phrase = new StringBuilder();

			if (phraseCount == 0)
				return phrase.Append(words[wordIndex]);

			for (var phraseIndex = 0; phraseIndex < phraseCount; phraseIndex++)
			{
				phrase.Append(words[phraseIndex]);
			}

			return phrase;
		}

		private static void AddCombination(StringBuilder phrase, int anagramLength, string[] combinations, ref int combinationIndex)
		{
			if (phrase.Length == anagramLength)
			{
				combinations[combinationIndex++] = phrase.ToString();
			}
		}
	}
}
