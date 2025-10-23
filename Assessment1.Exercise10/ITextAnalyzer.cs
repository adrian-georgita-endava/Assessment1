using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise10
{
    public interface ITextAnalyzer
    {
        public int GetCharactersCount(string text);
        public int GetWordsCount(string text);
        public int GetVowelsCount(string text);
        public int GetConsonantsCount(string text);
    }
}
