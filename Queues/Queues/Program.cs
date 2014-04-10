using System;
using System.Collections.Generic;


namespace Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue pq = new PriorityQueue();
            pq.Push(1);
            pq.Push(45);
            pq.Push(60);
            pq.Push(200);
            pq.Push(75);
            pq.Push(103);
            pq.Push(2);

            pq.Pop();
            pq.Pop();
            pq.Pop();


            Console.ReadKey();
        }
    }
}
