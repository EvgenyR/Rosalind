using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rslnd
{
    public interface IMyPrefixMatcher<V> where V : class
    {
        String GetPrefix();
        void ResetMatch();
        void BackMatch();
        char LastMatch();
        bool NextMatch(char next);
        List<V> GetPrefixMatches();
        bool IsExactMatch();
        V GetExactMatch();
        bool StringMatcher(string s);
    }
}
