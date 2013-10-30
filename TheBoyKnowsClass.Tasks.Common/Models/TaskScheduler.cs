using System;
using System.Diagnostics;
using System.Threading;
using TheBoyKnowsClass.Common.Models.Queue;
using TheBoyKnowsClass.FolderWatchers.Common.Models;
using TheBoyKnowsClass.Schedules.Common.Models;

namespace TheBoyKnowsClass.Tasks.Common.Models
{
    public class TaskScheduler
    {
        private readonly SyncItemQueue<FolderWatcherQueueItem> _fileQueue;
        private readonly WaitHandle[] _queueEvents;
        private readonly WaitHandle[] _tickerEvents;
        private readonly TaskFactory _taskFactory;
        private readonly TimeSpan _taskDelay;
        private readonly ScheduleTicker _scheduleTicker;

        public TaskScheduler(SyncItemQueue<FolderWatcherQueueItem> q, EventWaitHandle exitThreadEvent, Tasks.Common.Models.TaskFactory taskFactory, TimeSpan taskDelay, ScheduleTicker scheduleTicker)
        {
            _fileQueue = q;

            _queueEvents = new WaitHandle[] { exitThreadEvent, q.ItemsQueuedEvent};
            _tickerEvents = new WaitHandle[] { exitThreadEvent, scheduleTicker.TickerEvent};
            _taskFactory = taskFactory;
            _taskDelay = taskDelay;
            _scheduleTicker = scheduleTicker;
        }

        public void ThreadRun()
        {
            _scheduleTicker.TimerStart();

            while (WaitHandle.WaitAny(_queueEvents) != 0)
            {
                while (WaitHandle.WaitAny(_tickerEvents) != 0)
                {
                    FolderWatcherQueueItem item = _fileQueue.DequeueSyncConditional(ShouldProcess);

                    if (item != null)
                    {
                        _taskFactory.ProcessItem(item.Path);
                    }
                }
            }

            _scheduleTicker.TimerStop();
        }

        private bool ShouldProcess(FolderWatcherQueueItem item)
        {
            Debug.Assert(item.Time != null, "item.Time != null");
            return DateTime.Now.Subtract(item.Time.Value) > _taskDelay;
        }
    }
}
