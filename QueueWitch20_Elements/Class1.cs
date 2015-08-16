using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueWitch20_Elements
{
    /// <summary>
    /// Sorted queue with 20 elements. 
    /// The addition of more than twenty elements will erase the element with the lowest value.
    /// Elements must be from range 1-10
    /// </summary>
    class Queue20_Elements
    {

        private const int _maxLenght = 19;
        private int _actualPosition;
        private int[] _tablica;

        /// <summary>
        /// Initializes a new instance of the <see cref="Array20_Elements"/> class.
        /// </summary>
        public Queue20_Elements()
        {
            _actualPosition = -1;
            _tablica = new int[_maxLenght + 1];
        }

        /// <summary>
        /// Adds the specified value.
        /// </summary>
        /// <param name="value">The value. An integer from 1 to 10</param>
        /// <exception cref="ArgumentException">Too big or too low value. Value must be from the range 1-10.</exception>
        public void Add(int value)
        {
            if (value > 0 && value < 11)
            {
                if (_actualPosition + 1 <= _maxLenght)
                {
                    //add position
                    _actualPosition++;
                    _tablica[_actualPosition] = value;
                    if (_actualPosition > 0)
                    {
                        sortuj();
                    }
                }
                else
                {
                    for (int i = 0; i < _actualPosition; i++)
                    {
                        _tablica[i] = _tablica[i + 1];
                    }
                    _tablica[_actualPosition] = value;
                }
            }
            else
            {
                throw new ArgumentException("Too big or too low value. Value must be from the range 1-10.");
            }
        }


        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns>Returns the currently highest stored value and deletes it from the queue.</returns>
        /// <exception cref="IndexOutOfRangeException">When you try to get value and the queue is empty.</exception>
        public int Get()
        {
            if (_actualPosition >= 0)
            {
                int odczyt = _tablica[_actualPosition];
                _actualPosition--;
                return odczyt;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }

        }

        /// <summary>
        /// Lenghts this instance.
        /// </summary>
        /// <returns>Returns number of positions in queue.</returns>
        public int Lenght()
        {
            return _actualPosition;
        }

        /// <summary>
        /// Sorts this instance.
        /// </summary>
        private void sortuj()
        {
            int n = _actualPosition + 1;
            do
            {
                for (int i = 0; i < n - 1; i++)
                {
                    if (_tablica[i] > _tablica[i + 1])
                    {
                        int tmp = _tablica[i];
                        _tablica[i] = _tablica[i + 1];
                        _tablica[i + 1] = tmp;
                    }
                }
                n--;
            }
            while (n > 1);
        }


    }
}
