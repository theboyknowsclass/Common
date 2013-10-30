using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace TheBoyKnowsClass.Common.Models.Queue
{
    public class SyncItemQueue<T>
        where T : class, IEquatable<T>
    {
        public bool UniqueQueue { get; private set; }
        private readonly List<T> _queue;

        private readonly EventWaitHandle _itemsQueuedEvent;

        private readonly object _syncRoot;

        public SyncItemQueue() : this(false)
        {
        }

        public SyncItemQueue(bool uniqueQueue)
        {
            UniqueQueue = uniqueQueue;
            _itemsQueuedEvent = new ManualResetEvent(false);
            _queue = new List<T>();
            _syncRoot = ((ICollection) _queue).SyncRoot;
        }

        public EventWaitHandle ItemsQueuedEvent
        {
            get { return _itemsQueuedEvent; }
        }

        #region Synchronized Methods

        public void EnqueueSync(T item)
        {
            DoSync(() => Enqueue(item));
        }

        public void DequeueSync(T item)
        {
            DoSync(() => Dequeue());
        }

        public void DequeueEnqueueMultiple(IEnumerable<T> dequeueItems, IEnumerable<T> enqueueItems)
        {
            DoSync(() =>
                {
                    if (dequeueItems != null)
                    {
                        foreach (T dequeueItem in dequeueItems)
                        {
                            Dequeue(dequeueItem);
                        }
                    }

                    if (enqueueItems != null)
                    {
                        foreach (T enqueueItem in enqueueItems)
                        {
                            Enqueue(enqueueItem);
                        }
                    }

                });
        }

        public T DequeueSync()
        {
            return DoSync<T>(Dequeue);
        }

        public T DequeueSyncConditional(Func<T,bool> condition)
        {
            return DoSync(() =>
                {
                    if (condition(Peek()))
                    {
                        return Dequeue();
                    }
                    return null;
                });
        }

        public void DoSync(Action action)
        {
            lock (_syncRoot)
            {
                action();

                SetItemQueuedEvent();
            }
        }

        public TReturn DoSync<TReturn>(Func<TReturn> func)
        {
            lock (_syncRoot)
            {
                var rv = func();
                SetItemQueuedEvent();
                return rv;
            }
        }

        public T PeekSync()
        {
            return DoSync(() => Peek());
        }

        public List<T> GetItems()
        {
            return DoSync(() => _queue);
        }

        #endregion

        private void SetItemQueuedEvent()
        {
            if (_queue.Count == 0)
            {
                _itemsQueuedEvent.Reset();
            }
            else
            {
                _itemsQueuedEvent.Set();
            }
        }

        #region private unsynchronized methods

        private void Enqueue(T item)
        {
            if (UniqueQueue && _queue.Contains(item))
            {
                Dequeue(item);
                Enqueue(item);
            }
            else
            {
                _queue.Add(item);
            }
        }

        private T Dequeue()
        {
            T topItem = Peek();

            if (topItem != null)
            {
                Dequeue(topItem);
            }

            return topItem;
        }

        private void Dequeue(T item)
        {
            if (_queue.Contains(item))
            {
                _queue.Remove(item);
            }
        }

        private T Peek()
        {
            return  (from item in _queue select item).FirstOrDefault();
        }

        #endregion

        public override string ToString()
        {
            return string.Join(",",_queue);
        }

    }
}
