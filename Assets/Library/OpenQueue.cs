using System;

namespace Berezhnoy.Collections.Generic
{

    public class OpenQueue<T>
        where T : class
    {

        #region Constants

        private const int StartCapacity = 8;

        #endregion

        #region Fields

        private T[] _elements;
        private int _lastElementIndex;
        private int _index = -1;

        #endregion

        #region Properties

        public int Count
        {

            get { return _lastElementIndex + 1; }

        }

        public T this[int index]
        {

            get
            {

                if(index < 0 || index > _lastElementIndex)
                {

                    return _elements[index];

                };

                return null;
                
            }

        }

        #endregion

        #region Constructors

        public OpenQueue(int capacity = StartCapacity)
        {

            _elements = new T[capacity];

            _lastElementIndex = -1;

        }

        #endregion

        #region Methods

        public T Find(Predicate<T> criteriaMatch)
        {

            T element = null;

            for (_index = 0; _index < Count; _index++)
            {

                element = _elements[_index];

                if (criteriaMatch(element))
                {

                    return element;

                };

            };

            return element;

        }

        public void Enqueue(T item)
        {

            if(_elements.Length < Count + 1)
            {

                T[] elements = new T[_elements.Length * 2];

                _elements.CopyTo(elements, 1);

                _elements = elements;

            }
            else
            {

                for(_index = Count; _index > 0; _index--)
                {

                    _elements[_index] = _elements[_index - 1];

                };

            };

            _elements[0] = item;

            _lastElementIndex++;

        }

        public T Dequeue()
        {

            if(_lastElementIndex == -1)
            {

                return null;

            };

            T lastElement = _elements[_lastElementIndex];

            Constrict(_lastElementIndex);

            return lastElement;

        }

        public T Dequeue(T item)
        {

            T element = null;

            for(_index = 0; _index < Count; _index++)
            {

                if (_elements[_index].Equals(item))
                {

                    element = _elements[_index];

                    Constrict(_index);

                    return element;

                };

            };

            return element;

        }

        public T Reenqueue()
        {

            T element = Dequeue();

            if (element != null)
            {

                Enqueue(element);

            };

            return element;

        }

        public T Reenqueue(T item)
        {
            
            // TO DO
            T element = Dequeue(item);

            if (element != null)
            {

                Enqueue(element);

            };

            return element;

        }

        private void Constrict(int indexFrom)
        {

            _elements[indexFrom] = null;

            int lastIndexElement = -1;

            for (_index = 0; _index < Count; _index++)
            {

                if (_elements[_index] != null)
                {

                    lastIndexElement++;

                    if (lastIndexElement != _index)
                    {

                        _elements[lastIndexElement] = _elements[_index];

                        _elements[_index] = null;

                    };

                };

            };

            _lastElementIndex = lastIndexElement;
            
        }

        #endregion

    }

}