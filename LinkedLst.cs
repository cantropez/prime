using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace LinkedLST
{
    public class LinkedLst<T> 
        : IEnumerable<T>
    {
        private int count;
        Node<T> _first;
        Node<T> _last;

        public void AddToEnd(T _data)
        {
            Node<T> node = new Node<T>(_data);
            if (_first == null)
                _first = node;
            else
                _last._nxtElem = node;
            _last = node;
            count++;
        }

        public bool AddToPos(int index, T value)
        {
            Node<T> node = new Node<T>(value);
            Node<T> current = _first;
            Node<T> cur_prev = null;
            int i = 0;
            if (index < 0 || index > this.Count + 1)
            {
                throw new ArgumentOutOfRangeException("index");
            }
            if (index == Count)
            {
                if (_first == null) _first = node;
                else
                {
                    _last._nxtElem = node;
                    _last = _last._nxtElem;
                }
                count++;
                return true;
            }
            else if (index == 0)
            {
                node._nxtElem = _first;
                _first = node;
                if (count == 0)
                    _last = _first;
                count++;
                return false;
            }

            while (current != null)
            {
                if (i == index)
                {
                    if (cur_prev != null)
                    {
                        cur_prev._nxtElem = node;
                        node._nxtElem = current;
                        if (current._nxtElem == null)
                            _last = cur_prev;
                    }
                    count++;
                    return true;
                }
                i++;
                cur_prev = current;
                current = current._nxtElem;
            }
            return false;
        }

        public bool Remooove(int index)
        {
            Node<T> current = _first;
            Node<T> previous = null;
            int i = 0;
            if (index < 0 || index > this.Count() - 1)
            {
                throw new ArgumentOutOfRangeException("index");
            }
            while (current != null)
            {
                if (i == index)
                {
                    if (previous != null)
                    {
                        previous._nxtElem = current._nxtElem;
                        if (current._nxtElem == null)
                            _last = previous;
                    }
                    else
                    {
                        _first = _first._nxtElem;

                        if (_first == null)
                            _last = null;
                    }
                    count--;
                    return true;
                }
                i++;
                previous = current;
                current = current._nxtElem;
            }
            return false;
        }

        public T Shoow(int index)
        {
            Node<T> current = _first;
            if (index < 0 || index > this.Count() - 1)
            {
                throw new ArgumentOutOfRangeException("index");
            }
            for (int i = 0; i < index; i++)
            {
                current = current._nxtElem;
            }
            return current._data;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index > this.Count() - 1)
                {
                    throw new ArgumentOutOfRangeException("index");
                }
                return this.Skip(index).First();
            }
            set
            {
                if (index < 0)
                {
                    throw new ArgumentOutOfRangeException("index");
                }
                Node<T> current = _first;
                int i = 0;
                while (current != null && i < index)
                {
                    current = current._nxtElem; i++;
                }
                if (current == null)
                {
                    throw new ArgumentOutOfRangeException("index");
                }
                current._data = value;
            }
        }

        public int Count { get { return count; } }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = _first;
            while (current != null)
            {
                yield return current._data;
                current = current._nxtElem;
            }
        }
    }
}
