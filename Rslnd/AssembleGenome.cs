using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rslnd
{
    public static class AssembleGenome
    {
        public static List<string> StringComposition(int k, string inp)
        {
            List<string> result = new List<string>();

            for (int i = 0; i <= inp.Length - k; i++)
            {
                result.Add(inp.Substring(i, k));
            }

            result.Sort();

            return result;
        }
    }
}
