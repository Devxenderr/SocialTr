using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialTrading.Service.Interfaces.Timer
{
    public interface IGlobalTimer
    {
        event Action<DateTime> OnChangeSecondLeft;

        void StartTimer();
      
    }
}
