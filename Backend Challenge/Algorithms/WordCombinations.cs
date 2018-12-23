using System.Collections.Generic;
using System.Text;

namespace Backend_Challenge.Algorithms
{
	public static class WordCombinations
	{
		public static IEnumerable<string> GetUnique(string[] words, int wordLimit)
		{
			var combinations = new List<string>();
			var combinationIndexes = GetIndexes(words.Length, wordLimit);

			foreach (var combinationIndex in combinationIndexes)
			{
				var combination = new StringBuilder();

				for (var index = 0; index < combinationIndex.Count; index++)
				{
					if (index == 0)
					{
						combination.Append(words[combinationIndex[index]]);
					}
					else
					{
						combination.Append(" ");
						combination.Append(words[combinationIndex[index]]);
					}
				}

				combinations.Add(combination.ToString());
			}

			return combinations;
		}

		private static IEnumerable<List<int>> GetIndexes(int count, int limit)
		{
			var result = new List<List<int>>();
			var currentCombination = new List<int>();

			for (int i = 0; i < count; i++)
			{
				if (currentCombination.Count == limit)
				{
					currentCombination = new List<int>();
					currentCombination.Add(i);
					result.Add(currentCombination);
				}
				else if (i == count - 1)
				{
					currentCombination.Add(i);
					result.Add(currentCombination);
				}
				else
				{
					currentCombination.Add(i);
				}
			}

			return result;
		}
	}


}
