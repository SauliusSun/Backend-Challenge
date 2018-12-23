using System;
using System.Diagnostics;
using System.Text;
using Backend_Challenge.Helpers;

namespace Backend_Challenge
{
	public static class Combinations
	{
		private static readonly Stopwatch StopWatch1 = new Stopwatch();

		public static string[] GetAllPossible(string[] words, int phraseLength)
		{
			var combinations = new string[10000000];
			var combinationIndex = 0;

			for (var phraseCount = 0; phraseCount < words.Length; phraseCount++)
			{
				StopWatch1.Reset();
				StopWatch1.Start();
				for (var wordIndex = 0; wordIndex < words.Length; wordIndex++)
				{
					var possibleAnagramPhrase = GetPhrase(wordIndex, phraseCount, words);

					AddCombination(possibleAnagramPhrase, combinations, ref combinationIndex);

					if (possibleAnagramPhrase.Length >= 21)
						break;

					foreach (var additionalPhraseWord in words)
					{
						possibleAnagramPhrase.Append(StringHelper.WhiteSpace);
						possibleAnagramPhrase.Append(additionalPhraseWord);
						AddCombination(possibleAnagramPhrase, combinations, ref combinationIndex);
						possibleAnagramPhrase.Remove(possibleAnagramPhrase.Length - additionalPhraseWord.Length, additionalPhraseWord.Length);
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
				phrase.Append(words[phraseIndex]);

			return phrase;
		}

		private static void AddCombination(StringBuilder phrase, string[] combinations, ref int combinationIndex)
		{
			if (phrase.Length == 20 || phrase.Length == 21)
				combinations[combinationIndex++] = phrase.ToString();
		}
	}
}
