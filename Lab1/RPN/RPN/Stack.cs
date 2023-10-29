using System;

namespace RpnCalculator
{
    public class Stack<T> {
		private T[] _storage;
		private int _topIndex;
		public bool IsEmpty => _topIndex == 0;

		public Stack() {
			_storage = new T[10];
		}

		public void Push(T element) {
			if (_topIndex >= _storage.Length)
            {
                EnlargeStorage();
            }
            _storage[_topIndex++] = element;
		}

        private void EnlargeStorage()
        {
            var newArray = new T[_storage.Length * 2];
            for (var i = 0; i < _storage.Length; i++)
            {
                newArray[i] = _storage[i];
            }

            _storage = newArray;
        }

        public T Pop() => _topIndex - 1 < 0 ? throw new InvalidOperationException() : _storage[--_topIndex];

        public T Peek() => _topIndex == 0 ? throw new InvalidOperationException() : _storage[_topIndex - 1];
    }
}