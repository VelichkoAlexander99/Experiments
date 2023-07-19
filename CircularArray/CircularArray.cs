namespace CircularArray
{
    public class CircularArray<T>
    {
        protected event EventHandler? OnBeginning;
        public event EventHandler? OnEnding;
        private readonly T[] _values;

        public int NextIndex { get; private set; }

        public CircularArray(T[] values)
        {
            _values = values;
            NextIndex = 0;
        }

        public T MoveNext()
        {
            if (NextIndex == _values.Length)
                OnEnding?.Invoke(this, EventArgs.Empty);

            NextIndex %= _values.Length;

            if (NextIndex == 0)
                OnBeginning?.Invoke(this, EventArgs.Empty);

            return _values[NextIndex++];
        }
    }
}