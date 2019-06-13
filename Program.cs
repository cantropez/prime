using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLST
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedLst<string> lst1 = new LinkedLst<string>();
            lst1.AddToEnd("a");
            lst1.AddToEnd("s");
            lst1.AddToEnd("d");
            lst1.AddToEnd("f");
            lst1.AddToEnd("b");

            lst1.AddToPos(3, "y");

            foreach (var a in lst1)
            {
                Console.WriteLine(a);
            }
            Console.ReadKey();


        }
    }
}
