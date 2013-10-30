using System;
using System.Threading;

namespace TheBoyKnowsClass.Schedules.Common.Models
{
    public class ScheduleTicker
    {
        private readonly TimeSpan _timerInterval;
        private readonly Timer _timer;
        private readonly Schedule _schedule;
        private readonly EventWaitHandle _tickerEvent;

        public ScheduleTicker(Schedule schedule, TimeSpan timerInterval)
        {
            _schedule = schedule;
            _timerInterval = timerInterval;
            _tickerEvent = new AutoResetEvent(true);
            _timer = new Timer(TimerCallback, _tickerEvent, Timeout.Infinite, _timerInterval.Milliseconds);
        }

        public EventWaitHandle TickerEvent
        {
            get { return _tickerEvent; }
        }

        private void TimerCallback(object state)
        {
            if (_schedule.IsCurrentlyActive())
            {
                _tickerEvent.Set();
            }

        }

        public void TimerStart()
        {
            TimerStart(_timer, _schedule.GetNextStart(), _timerInterval );
        }

        public void TimerStop()
        {
            TimerStop(_timer);
        }

        private static void TimerStart(Timer timer, TimeSpan dueTime, TimeSpan timerInterval)
        {
            timer.Change(dueTime, timerInterval);
        }

        private static void TimerStop(Timer timer)
        {
            timer.Change(Timeout.Infinite, 0);
        }
    }
}
