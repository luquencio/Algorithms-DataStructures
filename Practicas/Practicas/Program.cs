using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicas
{
    class Program
    {
        static void Main(string[] args)
        {
 //           PriorityQueue PQ = new PriorityQueue();

            //GPriorityQueue<string> PQ = new GPriorityQueue<string>();

            //PQ.Push("w");
            //PQ.Push("t");
            //PQ.Push(400);
            //PQ.Push(75);
            //PQ.Push(2);
            //PQ.Push(0);

            //Trie t = new Trie();
            //t.Insert("abcd");
            //t.Insert("hielo");
            //t.Insert("hola");
            //t.Insert("abcd");

            //SplayTree sp = new SplayTree();

            //sp.Insert(1);
            //sp.Insert(7);

            PriorityQueue PQ = new PriorityQueue();
            //PQ.Push(1);
            PQ.Push(7);
            //PQ.Push(1);
            PQ.Push(25);
            PQ.Push(45);
            //PQ.Push(3);

            Console.WriteLine(PQ.Top());
            PQ.Print();
            PQ.Pop();
            PQ.Print();
            //PQ.Top();
            //PQ.Pop();
            //PQ.ToArray();


            Console.ReadKey();
        }
    }
}
