using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections
{

    /// <summary>
    /// In addition to the generic GetEnumerator method, 
    /// the non-generic GetEnumerator method must also be implemented. 
    /// This is because IEnumerable<T> inherits from IEnumerable. 
    /// The non-generic implementation defers to the generic implementation.
    /// </summary>
    /// <typeparam name="T">Type of object being placed on the stack</typeparam>
    public class GenericStack<T> : IEnumerable<T>
    {
        private T[] values = null;
        private int top = 0;
        private int maxLength;


        // This method implements the GetEnumerator method. It allows
        // an instance of the class to be used in a foreach statement.
        public IEnumerator<T> GetEnumerator()
        {
            for (int index = top - 1; index >= 0; index--)
            {
                yield return values[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        public GenericStack(int MaxLength = 200)
        {
            maxLength = MaxLength;
            values = new T[maxLength];
        }

        public void Push(T t)
        {
            if (top > maxLength)
                throw new Exception($"Exceeded max number of items on stack {maxLength}");

            values[top] = t;
            top++;
        }
        public T Pop()
        {
            top--;

            if (top < 0)
                throw new Exception("Nothing in stack to pop");

            return values[top];
        }

        public IEnumerable<T> TopToBottom
        {
            get { return this; }
        }

        public IEnumerable<T> BottomToTop
        {
            get
            {
                for (int index = 0; index <= top - 1; index++)
                {
                    yield return values[index];
                }
            }
        }

        public IEnumerable<T> TopN(int itemsFromTop)
        {
            // Return less than itemsFromTop if necessary.
            int startIndex = itemsFromTop >= top ? 0 : top - itemsFromTop;

            for (int index = top - 1; index >= startIndex; index--)
            {
                yield return values[index];
            }
        }
    }


}
