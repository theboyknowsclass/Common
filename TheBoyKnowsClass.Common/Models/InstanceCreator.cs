using System;

namespace TheBoyKnowsClass.Common.Models
{
    public static class InstanceCreator<T>
    where T : class, new ()
    {
        private static volatile T _instance;
        private static readonly object SyncRoot = new Object();

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (_instance == null)
                        {
                            _instance = new T();
                        }
                    }
                }

                return _instance;
            }
        }
    }
}
