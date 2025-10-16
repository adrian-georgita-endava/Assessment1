using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise10
{
    public class RomanianTextAnalyzer : ITextAnalyzer
    {
        private char[] _vowels = ['a', 'e', 'i', 'o', 'u', 'ă', 'â', 'î', 'A', 'E', 'I', 'O', 'U', 'Ă', 'Â', 'Î'];
        int ITextAnalyzer.GetCharactersCount(string text)
        {
            return text.Length;
        }

        int ITextAnalyzer.GetConsonantsCount(string text)
        {
            int numberOfConsonants = 0;
            foreach (char c in text)
            {
                if (!_vowels.Contains(c) && char.IsLetter(c))
                {
                    numberOfConsonants++;
                }
            }

            return numberOfConsonants;
        }

        int ITextAnalyzer.GetVowelsCount(string text)
        {
            int numberOfVowels = 0;

            foreach (char c in text)
            {
                if (_vowels.Contains(c))
                {
                    numberOfVowels++;
                }
            }

            return numberOfVowels;
        }

        int ITextAnalyzer.GetWordsCount(string text)
        {
            return text.Split(' ').Length;
        }
    }
}
