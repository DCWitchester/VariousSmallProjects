using System;
using System.Timers;

namespace POSTable.Services
{
    public class TimerService
    {
        /// <summary>
        /// the timer object instance used by the class
        /// </summary>
        private Timer _timer;
        /// <summary>
        /// the boolean value that determines the stoping of the program after the first run
        /// </summary>
        private Boolean _singleRun;

        /// <summary>
        /// this function will initailize the timer and starts executing the elapsed timer
        /// </summary>
        /// <param name="interval">the interval at which the timer starts</param>
        /// <param name="singleRun">the instance of the single run</param>
        public void SetTimer(Double interval, Boolean singleRun = false)
        {
            _singleRun = singleRun;
            _timer = new Timer(interval);
            _timer.Elapsed += NotifyTimerElapsed;
            _timer.Enabled = true;
        }

        /// <summary>
        /// this function will stop the timer and dispose it
        /// </summary>
        public void StopTimer() => _timer.Dispose();

        /// <summary>
        /// this function will reset the elapsed time to 0
        /// </summary>
        public void ResetTimer() => _timer.Enabled = true;

        /// <summary>
        /// the base action to be raised by the elapsed timer
        /// </summary>
        public event Action OnElapsed;

        /// <summary>
        /// this function will be called by the timer on the elapsed time event
        /// </summary>
        /// <param name="source">the timer object</param>
        /// <param name="e">the elapsed time event</param>
        private void NotifyTimerElapsed(Object source, ElapsedEventArgs e)
        {
            OnElapsed?.Invoke();
            if(_singleRun) _timer.Dispose();

        }
    }
}
