using System;

namespace TheBoyKnowsClass.FolderWatchers.Common.Models
{
    public class FolderWatcherQueueItem : IEquatable<FolderWatcherQueueItem>
    {
        public DateTime? Time { get; set; }
        public string Path { get; set; }

        public bool Equals(FolderWatcherQueueItem other)
        {
            return Path == other.Path;
        }
    }
}
