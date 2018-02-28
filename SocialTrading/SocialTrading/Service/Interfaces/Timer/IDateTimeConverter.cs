using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialTrading.Service.Interfaces.Timer
{
    public interface IDateTimeConverter
    {
        DateTime Convert(string time);
    }
}
