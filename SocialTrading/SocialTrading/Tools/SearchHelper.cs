using System;
using System.Linq;
using System.Collections.Generic;

using SocialTrading.Tools.Interfaces;

namespace SocialTrading.Tools
{
    public class SearchHelper<T>: ISearchHelper<T>
    {
        public List<Tuple<T, string>> Search(List<Tuple<T, string>> searchableList, string searchStr)
        {
            if (searchableList == null || string.IsNullOrEmpty(searchStr))
            {
                throw new ArgumentNullException();
            }

            var resList = new List<Tuple<T, string>>();

            searchStr = searchStr.Replace(" ", ".");
            var punctuation = searchStr.Where(ch => !char.IsLetter(ch) && !char.IsNumber(ch)).Distinct().ToArray();
            var words = searchStr.Split(punctuation);

            foreach (var tuple in searchableList)
            {
                var enteringInName = true;
                var pairValue = tuple.Item2.ToUpper();

                foreach (var word in words)
                {
                    int findNamePos = pairValue.IndexOf(word.ToUpper(), StringComparison.Ordinal);
                    enteringInName &= findNamePos != -1;
                    pairValue = findNamePos != -1 ? pairValue.Remove(findNamePos, word.Length) : pairValue;

                    enteringInName = enteringInName || pairValue.Replace("/", "").Equals(word.ToUpper());
                }

                if (enteringInName)
                {
                    resList.Add(tuple);
                }
            }

            return resList;
        }
    }
}