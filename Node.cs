using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLST
{
    public class Node<T>
    {
        public T _data { get; set; }
        public Node<T> _nxtElem { get; set; }

        public Node()
        {

        }

        public Node(T data)
        {
            _data = data;
        }
    }
}
