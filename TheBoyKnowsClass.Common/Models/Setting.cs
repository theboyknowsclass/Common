using System;

namespace TheBoyKnowsClass.Common.Models
{
    public struct Setting<T>
    {
        private DateTime? _lastUpdated;
        private T _value;

        public Setting(T value)
        {
            _lastUpdated = DateTime.Now;
            _value = value;
        }

        public DateTime? LastUpdated
        {
            get { return _lastUpdated; }
            set { _lastUpdated = value; }
        }

        public T Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public void Sync(Setting<T> other)
        {
            if (other.LastUpdated.HasValue)
            {
                if (LastUpdated.HasValue)
                {
                    if (LastUpdated > other.LastUpdated)
                    {
                        SyncFrom(other);
                    }
                    else if (LastUpdated < other.LastUpdated)
                    {
                        SyncTo(other);
                    }
                }
                else
                {
                    SyncFrom(other);
                }
            }
            else
            {
                if (LastUpdated.HasValue)
                {
                    SyncTo(other);
                }
            }
        }

        private void SyncTo(Setting<T> other)
        {
            other.Value = Value;
            other.LastUpdated = LastUpdated;
        }

        private void SyncFrom(Setting<T> other)
        {
            Value = other.Value;
            LastUpdated = other.LastUpdated;
        }

        public void SetValue(T value)
        {
            if (Value != null && Value.Equals(value))
            {
                return;
            }

            Value = value;
            LastUpdated = DateTime.Now;
        }

        public static implicit operator T(Setting<T> t)
        {
            return t.Value; 
        }

        public static implicit operator Setting<T>(T value)
        {
            return new Setting<T>(value);
        }
        
    }
}
