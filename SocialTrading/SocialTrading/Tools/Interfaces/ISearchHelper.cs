using System;
using System.Collections.Generic;

namespace SocialTrading.Tools.Interfaces
{
    public interface ISearchHelper<T>
    {
        List<Tuple<T, string>> Search(List<Tuple<T, string>> searchableList, string searchStr);
    }
}