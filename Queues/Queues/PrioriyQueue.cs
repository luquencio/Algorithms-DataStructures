using System;
using System.Collections.Generic;

namespace Queues
{
    public class PriorityQueue
    {
        List<int> P;
        int SZ;
        public PriorityQueue()
        {
            P = new List<int>();
            P.Add(-1); // inserts a dummy node in position 0
            SZ = 0;
        }

        public void Push(int value)
        {
            //put value in PQ
            //throw new NotImplementedException();
            if (SZ < 0)
            {
                P.Add(value);
                SZ++;
            }
            else
            {
                ThrowUp(value);
            }
        }

        public void ThrowUp(int value) 
        {
                P.Add(value);
                SZ++;
                int n = SZ;

                while (n >= 0)
                {
                    if (P[(n - 1) / 2] > P[SZ])
                    {
                        swap((n / 2), n, P[n / 2], P[SZ]);
                    }
                    if (P[(n / 2)] > P[SZ])
                    {
                        swap((n / 2 + 1), n, P[n / 2 + 1], P[SZ]);
                    }
                    else
                    {
                        break;
                    }
                }
        }

        public void ThrowDown(int value)
        {
            int n = 1;
            while (n < SZ)
            {
                if (P[(2 * n + 1)] < P[n])
                {
                    swap((2 * n + 1), n, P[2 * n + 1], P[n]);
                }
                else if ((P[(2 * n)] < P[n]))
                {
                    swap((2 * n), n, P[2 * n], P[n]);
                }
                else
                {
                    break;
                }
            }
        }

        public void swap(int idx, int idy, int x, int y) 
        {
            P[idx] = y;
            P[idy] = x;
        }

        public void Pop()
        {
            //pops the element at the top of the queue
            P[1] = P[SZ];
          ThrowDown(P[1]);
        }

        public int Top()
        {
            // gets the element at the top of the queue
            return P[1];
        }
        public int Size()
        {
            return SZ - 1;
        }
        public int[] ToArray()
        {
            //gets the array managed inside the Priority Queue
            //throw new NotImplementedException();
            return P.ToArray();
        }
        public int[] ToSortedArray()
        {
            //gets the array manged inside the Priority Queue but sorted
            throw new NotImplementedException();
        }

    }
}

