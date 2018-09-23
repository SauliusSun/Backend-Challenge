using System.Linq;

namespace Backend_Challenge
{
    public static class Anagram
    {
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
    }
}