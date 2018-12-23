using System.Linq;
using Backend_Challenge.Algorithms;
using Xunit;

namespace BackendChallengeTests
{
	public class WordCombinationsTests
	{
		private const int WordLimit = 3;

		[Fact]
		public void CheckOneWordCombinations()
		{
			var result = WordCombinations.GetUnique(new []{ "1"}, WordLimit).ToList();
			
			Assert.NotNull(result);
			Assert.True(result.Count == 1);
			Assert.Equal("1", result[0]);
		}

		[Fact]
		public void CheckTwoWordCombinations()
		{
			var result = WordCombinations.GetUnique(new[] { "1", "2" }, WordLimit).ToList();

			Assert.NotNull(result);
			Assert.True(result.Count == 2);
			Assert.Equal("1 2", result[0]);
			Assert.Equal("2 1", result[1]);
		}
	}
}
