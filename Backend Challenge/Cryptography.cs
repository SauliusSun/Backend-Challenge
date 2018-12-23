using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Backend_Challenge
{
	public static class Md5Cryptography
	{
		private const string EasySecretPhrase = "e4820b45d2277f3844eac66c903e84be";
		private const string MediumSecretPhrase = "23170acc097c24edb98fc5488ab033fe";
		private const string HardSecretPhrase = "665e5bcb0c20062fe8abaaf4628bb154";

		public static void Check(IEnumerable<string> anagrams)
		{
			foreach (var anagram in anagrams)
			{
				switch (anagram.GetMd5())
				{
					case EasySecretPhrase:
						Console.WriteLine($"Easy secret phrase is {anagram}");
						break;
					case MediumSecretPhrase:
						Console.WriteLine($"Medium secret phrase is {anagram}");
						break;
					case HardSecretPhrase:
						Console.WriteLine($"Hard secret phrase is {anagram}");
						break;
				}
			}
		}

		public static string GetMd5(this string phrase)
		{
			using (var md5 = MD5.Create())
			{
				var phraseBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(phrase));
				var hash = new StringBuilder();

				foreach (var t in phraseBytes)
					hash.Append(t.ToString("x2"));

				return hash.ToString();
			}
		}
	}
}
