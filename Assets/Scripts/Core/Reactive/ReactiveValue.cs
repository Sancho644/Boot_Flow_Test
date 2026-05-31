using System;
using System.Collections.Generic;

namespace Core.Reactive
{
    public class ReactiveValue<T> : IDisposable
    {
        private readonly List<Action<T>> _listeners = new();

        private T _value;

        public T Value
        {
            get => _value;
            set
            {
                _value = value;

                for (var i = 0; i < _listeners.Count; i++)
                {
                    _listeners[i]?.Invoke(_value);
                }
            }
        }

        public ReactiveValue(T initialValue = default)
        {
            _value = initialValue;
        }

        public IDisposable Subscribe(Action<T> callback, bool invokeImmediately = true)
        {
            _listeners.Add(callback);

            if (invokeImmediately)
            {
                callback?.Invoke(_value);
            }

            return new Subscription(_listeners, callback);
        }

        public void Dispose()
        {
            _listeners.Clear();
        }

        private class Subscription : IDisposable
        {
            private readonly List<Action<T>> _listeners;
            private readonly Action<T> _callback;

            public Subscription(List<Action<T>> listeners, Action<T> callback)
            {
                _listeners = listeners;
                _callback = callback;
            }

            public void Dispose()
            {
                _listeners.Remove(_callback);
            }
        }
    }
}