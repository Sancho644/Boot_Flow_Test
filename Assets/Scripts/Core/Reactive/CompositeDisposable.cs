using System;
using System.Collections.Generic;

namespace Core.Reactive
{
    public class CompositeDisposable : IDisposable
    {
        private readonly List<IDisposable> _items = new();

        public void Add(IDisposable disposable)
        {
            _items.Add(disposable);
        }

        public void Dispose()
        {
            for (var i = 0; i < _items.Count; i++)
            {
                _items[i]?.Dispose();
            }

            _items.Clear();
        }
    }
}