using System;
using System.Threading;

using SocialTrading.Service.Interfaces.Timer;

namespace SocialTrading.Service
{
    public class GlobalTimer : IGlobalTimer
    {
        public event Action<DateTime> OnChangeSecondLeft;

        private static GlobalTimer _globalTimer;


        public static GlobalTimer GetInstance()
        {
            if (_globalTimer == null)
            {
                _globalTimer = new GlobalTimer();
                _globalTimer.StartTimer();
            }
            return _globalTimer;
        }

        public void StartTimer()
        {
            var timer = new Timer(state =>
            {
                OnChangeSecondLeft?.Invoke(DateTime.Now);
            }, null, 0, 1000);
        }

    }
}
