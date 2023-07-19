using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularArray
{
    public class CircularArrayDecorator<T> : CircularArray<T>
    {
        private readonly Stack<T> _result;

        public CircularArrayDecorator(
            T[] values, 
            CircularArray<T> circleArray, 
            in Stack<T> result) : base(values)
        {
            _result = result;
            base.OnBeginning += (o, e) => ActionResult(circleArray);
        }

        public new T MoveNext() => ActionResult(this);

        private T ActionResult(CircularArray<T> array)
        {
            if (array.NextIndex != 0)
                _result.Pop();
            var tmp = array.MoveNext();
            _result.Push(tmp);
            return tmp;
        }
    }
}
