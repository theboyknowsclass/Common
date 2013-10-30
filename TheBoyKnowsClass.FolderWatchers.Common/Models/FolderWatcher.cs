using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using TheBoyKnowsClass.Common.Models.Queue;

namespace TheBoyKnowsClass.FolderWatchers.Common.Models
{
    /// <summary>
    /// This is the Folder Watcher Class for queuing items
    /// </summary>
    public class FolderWatcher
    {
        private readonly SyncItemQueue<FolderWatcherQueueItem> _queue;
        private readonly EventWaitHandle _exitThreadEvent;
        private readonly FileSystemWatcher _folderWatcher;
        private readonly bool _addParentFolder;


        /// <summary>
        /// This is the constructor
        /// </summary>
        /// <param name="queue">the item queue to use</param>
        /// <param name="exitThreadEvent">the event to trigger the folder watcher to exit</param>
        /// <param name="folderPath">the folder path to watch</param>
        /// <param name="filePattern">the file pattern filter</param>
        /// <param name="addParentFolder">this flag triggers an event for the parent folder to be added to the queue as well</param>
        public FolderWatcher(SyncItemQueue<FolderWatcherQueueItem> queue, EventWaitHandle exitThreadEvent, string folderPath, string filePattern, bool addParentFolder)
        {
            _queue = queue;
            _exitThreadEvent = exitThreadEvent;
            _folderWatcher = new FileSystemWatcher(folderPath, filePattern)
                                 {
                                     NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite,
                                     IncludeSubdirectories = true,
                                     EnableRaisingEvents = false
                                 };

            _folderWatcher.Created += FolderWatcherChanged;
            _folderWatcher.Deleted += FolderWatcherChanged;
            _folderWatcher.Renamed += FolderWatcherRenamed;
            _folderWatcher.Changed += FolderWatcherChanged;

            _addParentFolder = addParentFolder;
        }


        /// <summary>
        /// Alters the queue on detection of a Renamed event
        /// </summary>
        /// <param name="sender">the Sender of the event</param>
        /// <param name="renamedEventArgs">the event arguments from the Renamed Event</param>
        private void FolderWatcherRenamed(object sender, RenamedEventArgs renamedEventArgs)
        {
            var oldItem = new FolderWatcherQueueItem {Path = renamedEventArgs.OldFullPath};
            _queue.DequeueEnqueueMultiple(new[] { oldItem }, AddParent(renamedEventArgs.FullPath));
        }


        /// <summary>
        /// Alters the queue on detection of a Changed event
        /// </summary>
        /// <param name="sender">the Sender of the event</param>
        /// <param name="changedEventArgs">the event arguments from the Changed Event</param>
        private void FolderWatcherChanged(object sender, FileSystemEventArgs changedEventArgs)
        {
            if (changedEventArgs.ChangeType == WatcherChangeTypes.Deleted)
            {
                _queue.DequeueSync(new FolderWatcherQueueItem {Path = changedEventArgs.FullPath});
            }
            else
            {
                _queue.DequeueEnqueueMultiple(null, AddParent(changedEventArgs.FullPath));
            }
        }


        /// <summary>
        /// This starts monitoring for events , and continues to monitor until the exit thread event is triggered
        /// </summary>
        public void ThreadRun()
        {
            _folderWatcher.EnableRaisingEvents = true;
            _exitThreadEvent.WaitOne();
            _folderWatcher.EnableRaisingEvents = false;
        }

        #region Helper Methods

        private IEnumerable<FolderWatcherQueueItem> AddParent(string path)
        {
            var queue = new FolderWatcherQueueItem[2];

            queue[0] = new FolderWatcherQueueItem { Path = path, Time = DateTime.Now };
            if (_addParentFolder && File.Exists(path))
            {
                queue[1] = new FolderWatcherQueueItem {Path = Path.GetDirectoryName(path), Time = DateTime.Now};
            }

            return queue;
        }

        #endregion

    }
}
