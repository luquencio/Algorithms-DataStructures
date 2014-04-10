using System;
using System.Collections.Generic;

namespace Practicas
{
    public class PriorityQueue
    {
        public class priorityQueue 
        {
             public class Node 
            {
                public int value;
                public Node left;
                public Node right;
                public Node parent;
                
                public Node(int Val) 
                {
                    this.value = Val;
                    this.parent = null;
                    this.left = null;
                    this.right = null;
                }
            }

            public Node root = new Node(int.MinValue);
            public List<int> N = new List<int>();
          
            public priorityQueue() 
            {
                this.root = null;
            }

            public static void swap(int x, int y) 
            {
                int temp = x;
                x = y;
                y = temp;
                //and swap done
            }

            public void Add(int item) 
            {

                if (root == null)
                {
                    root = new Node(item);
                    //root.parent = root;
                    return;
                }
                else
                {
                    var cur = root;
                    var p = new Node(int.MinValue); //"parent"
                    
                    while (cur != null)
                    {
                        p = cur;
                        if (item < cur.value )
                        {
                            cur = cur.left;
                        }
                        else 
                        {
                           cur = cur.right;
                        }
                    }

                    if (p.value > item)
                    {
                        Node leaf = new Node(item);
                        p.left = leaf;
                        leaf.parent = p;
                        Promote(leaf);
                    }
                    else
                    {
                        Node leaf = new Node(item);
                        p.right = leaf;
                        leaf.parent = p;
                        Promote(leaf);
                    }
                }
                
            }

            public void Promote(Node x) 
            { 
                //action to "promote" the node into the root position
                while (x.value < root.value)
                {
                    if (x.value > x.parent.value )
                    {
                        swap(x.parent.value, x.value);
                    }
                    x = x.parent;
                }


            }

            public Node Pop() 
            {
                var x = new Node(int.MinValue); //node to return
                x = root;
               // root.left.parent = null;
                root.left = root;

                return x;
            }

            public int[] ToArray() 
            {
                List<int> L = new List<int>();
                ToArray(root, L);
                return L.ToArray();            
            }

            public void ToArray(Node nodo, List<int> N) 
            {
                if (nodo == null) return;
                
                ToArray(nodo.left, N);
                N.Add(nodo.value);
                ToArray(nodo.right,N);
            }

            public void Print() 
            {
                _print(root);
            }

            public  void _print(Node Q) 
            {
                if (Q != null) 
                {
                    _print(Q.left);
                    Console.WriteLine(Q.value);
                    _print(Q.right);
                }

            }

        }

        //List<int> P;  // Im using a tree
        int SZ = 0;
        priorityQueue PQ = new priorityQueue();
        
        //public PriorityQueue()
        //{
        //    //P = new List<int>();
        //    //P.Add(-1); // inserts a dummy node in position 0
        
        //}

        public void Push(int value)
        {
            //put value in PQ
            PQ.Add(value);
            SZ++;
        }

        public void Pop()
        {
            //pops the element at the top of the queue
            //throw new NotImplementedException();
            PQ.Pop();
            SZ--;
        }

        public int Top()
        {
            // gets the element at the top of the queue
            //throw new NotImplementedException();

            return PQ.root.value;
        }
        public int Size()
        {
            return SZ;
        }
        
        public int[] ToArray() 
        {
            //gets the array managed inside the Priority Queue
            //throw new NotImplementedException(); 
            return PQ.ToArray();
        }
        public int[] ToSortedArray()
        {
            //gets the array manged inside the Priority Queue but sorted
            throw new NotImplementedException();            
        }

        public void Print() 
        {
            PQ.Print();
        }

    }
}

