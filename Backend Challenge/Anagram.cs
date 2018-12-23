using Backend_Challenge.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace Backend_Challenge
{
	public static class Anagram
	{
		public const string Phrase = "poultry outwits ants";

		public static bool IsAnagram(this string phrase, string anagramOf)
		{
			if (phrase == null || anagramOf == null)
				return false;

			if (phrase.Length != anagramOf.Length)
				return false;

			foreach (var letter in phrase)
			{
				if (!anagramOf.Contains(letter))
					return false;

				var wordLetterCount = phrase.Count(l => l == letter);
				var anagramLetterCount = anagramOf.Count(l => l == letter);
				if (wordLetterCount != anagramLetterCount)
					return false;
			}

			return true;
		}

		public static IEnumerable<string> FilterPossible(ICollection<string> words)
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
	}
}