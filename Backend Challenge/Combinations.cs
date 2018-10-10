using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Backend_Challenge
{
    public static class Combinations
    {
        private static readonly Stopwatch StopWatch1 = new Stopwatch();

        public static string[] GetAllPossible(string[] words, int anagramLength, int anagramLongestWordLength)
        {
			var combinations = new List<int[]>();
			var phraseIndexes = new List<int>();
			
			for (var wordIndex = 0; wordIndex < 4; wordIndex++)
			{
				for (int currentIndex = 0; currentIndex <= wordIndex; currentIndex++)
				{
					if (wordIndex == 0)
						break;

					var currentPhraseIndexes = new List<int>(phraseIndexes);
					currentPhraseIndexes.Insert(currentIndex, wordIndex);
					combinations.Add(currentPhraseIndexes.ToArray());
				}

				phraseIndexes.Add(wordIndex);


					//var indexes = GetIndexes(wordIndex);

					//for (int indexPosition = 0; indexPosition <= wordIndex; indexPosition++)
					//{
					//	var indexesToPosition = indexes;
					//	var temp = indexesToPosition[indexPosition];
					//	indexesToPosition[indexPosition] = wordIndex;
					//	indexesToPosition[wordIndex] = temp;

					//	results.Add(indexes);
					//}
			}

			return new string[0];

				//var combinations = new string[10000000];
				//var combinationIndex = 0;

				//for (var phraseCount = 0; phraseCount < words.Length; phraseCount++)
				//{
				//    StopWatch1.Reset();
				//    StopWatch1.Start();
				//    for (var wordIndex = 0; wordIndex < words.Length; wordIndex++)
				//    {
				//        var phrase = GetPhrase(wordIndex, phraseCount, words);

				//        AddCombination(phrase, anagramLength, combinations, ref combinationIndex);

				//        if (phrase.Length + anagramLongestWordLength < anagramLength)
				//            break;

				//        foreach (var additionalPhraseWord in words)
				//        {
				//            phrase.Append(additionalPhraseWord);
				//            AddCombination(phrase, anagramLength, combinations, ref combinationIndex);
				//            phrase.Remove(phrase.Length - additionalPhraseWord.Length, additionalPhraseWord.Length);
				//        }
				//    }
				//    StopWatch1.Stop();
				//    Console.WriteLine($"phraseCount{phraseCount}Perf:{StopWatch1.ElapsedMilliseconds}");
				//}

				//return combinations;
		}

		private static int[] GetIndexes(int indexLength)
		{
			var indexes = new List<int>();
			var index = 0;

			while(indexLength >= index)
			{
				indexes.Add(index);
				index += 1;
			}

			return indexes.ToArray();
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
