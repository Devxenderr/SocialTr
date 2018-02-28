using System;
using System.Collections.Generic;

namespace SocialTrading.Service.Interfaces.Repository
{
    public interface IRepositoryNames
    {
        List<Tuple<string,string>>GetNames();
    }
}
