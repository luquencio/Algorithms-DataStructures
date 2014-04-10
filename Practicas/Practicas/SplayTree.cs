using System;
using System.Collections.Generic;

namespace Practicas
{
    public class SplayTree
    {
        private class Node
        {
            public Node Left { get; set; }
            public Node Right { get; set; }
            public Node Parent { get; set; }
            public int Value { get; set; }
            public int Deepness { get; set; }
            public Node()
            {
                Left = null;
                Right = null;
                Parent = null;
                Deepness = 0; // when node is alone Deepness is 0
            }
            public Node(int Value)
                : this() // builds a node using function above
            {
                this.Value = Value;
            }
            public bool isRoot()
            {
                // determines if node is a root (if has no parent)
                //throw new NotImplementedException();
                return Parent == null;
            }
        }

        Node root;

        int Size { get; set; }
        public SplayTree()
        {
            Size = 0;
            root = null;
        }

        /// <summary>
        /// Calls Insert(root,value) which can do recursion
        /// </summary>
        /// <param name='value'>integer to be inserted</param>
        public void Insert(int value)
        {
            if (this.Exist(value)) return;
            Node newNode = new Node(value);
            if (root == null)
            {
                root = newNode;
            }
            else
            {
                Insert(root, newNode);
            }
        }

        /// <summary>
        /// Insert the specified p and value.
        /// </summary>
        /// <param name='p'>node that should be the parent</param>
        /// <param name='value'>value</param>
        private static void Insert(Node p, Node value)
        {
            //throw new NotImplementedException();
            var cur = p;
            var x = p;

            while (cur != null)
            {
                if (cur.Value > value.Value)
                {
                    cur = cur.Left;
                    x = cur.Left.Parent;
                }
                else if(cur.Value < value.Value) 
                {
                    cur = cur.Right;
                    x = cur.Right.Parent;
                }
                
            }

            if (cur.Parent.Value > value.Value && cur != null )
            {
                cur.Left = value;
            }
            else if (cur.Parent.Value > value.Value)
            {
                cur.Right = value;
            }

            Splay(p);
        }


        private static void Splay(Node node)
        {
            //promote "node" until is Root

            if (node.isRoot() != true)
            {
                if (node.Parent.Parent.Value > node.Parent.Value && node.Value >node.Parent.Value)
                {
                    RotateLeft(node.Parent.Parent, node.Parent);
                    RotateLeft(node, node.Parent);
                }
                else if (node.Parent.Parent.Value < node.Parent.Value && node.Value < node.Parent.Value)
                {
                    RotateRight(node.Parent.Parent, node.Parent);
                    RotateRight(node, node.Parent);
                }
                else if(node.Parent.Parent.Value < node.Parent.Value && node.Value > node.Parent.Value)
                {
                    RotateLeft(node, node.Parent);
                    RotateRight(node.Parent, node.Parent.Parent);
                }
                else if (node.Parent.Parent.Value > node.Parent.Value && node.Value < node.Parent.Value)
                {
                    RotateRight(node, node.Parent);
                    RotateLeft(node.Parent, node.Parent.Parent);
                }

                else if (node.Value < node.Parent.Value)
                {
                    RotateRight(node, node.Parent);
                }

                else if (node.Value > node.Parent.Value)
                {
                    RotateLeft(node, node.Parent);
                }


            }
           
        }


        /// <summary>
        /// rotates a subtree to the LEFT.
        /// makes "child" as the parent of "parent" (promotes "child")
        /// NOTE: 
        /// 	this is a static function since you pass the nodes
        /// 	and this does not depends in a property of an
        /// 	instance
        /// 
        /// 		BEFORE             AFTER
        /// -----------------    ------------------	
        /// 	   parent      	        child  
        ///       /     \              /     \  
        ///      *     child        parent    * 
        ///           /    \       /     \       
        ///         *       *     *       *      
        /// 
        /// </summary>
        /// <param name='child'>is the right child of "parent"</param>
        /// <param name='parent'>is the parent of "child</param>
        private static void RotateLeft(Node child, Node parent)
        {
            //throw new NotImplementedException();
            Node X = child.Right;
            if (X == null)
                return;

            Node P = parent;
            Node A = child.Left;
            Node B = X.Left;
            Node C = X.Right;

            child.Right = B;
            if (B != null)
            {
                B.Parent = child;
            }


            X.Left = child;
            child.Parent = X;

            X.Parent = P;

            if (X.Value < P.Value)
            {
                P.Left = X;
            }

            else
            {
                P.Right = X;
            }
        }



        /// <summary>
        /// rotates a subtree to the RIGHT.
        /// makes "child" as the parent of "parent" (promotes "child")
        /// NOTE: 
        /// 	this is a static function since you pass the nodes
        /// 	and this does not depends in a property of an
        /// 	instance
        /// 	
        ///      BEFORE                AFTER
        /// -----------------    ------------------	
        /// 	   parent  	        child
        ///       /     \          /     \
        ///    child     *        *      parent
        ///   /    \                   /      \
        /// *       *                *         *
        /// 
        /// </summary>
        /// <param name='child'>is the left child of "parent"</param>
        /// <param name='parent'>is the parent of "child</param>
        private static void RotateRight(Node child, Node parent)
        {
            //throw new NotImplementedException();

              Node Y = child.Left;
              if (Y == null)
                  return;

        Node P = parent;
        Node A = child.Left;
        Node B = Y.Right;
        Node C = Y.Left;

        Y.Left = B;
        if (B != null)
        {
            B.Parent = child;
        }

        Y.Right = child;
        child.Parent = Y;

        Y.Parent = P;

        if (Y.Value < P.Value)
        {
            P.Left = Y;
        }

        else
        {
            P.Right = Y;
        }
        }

        public bool Exist(int value)
        {
            //if LowerBound implemented correctly
            return this.LowerBound(value) == value;
            //else
            /*
             * Implement this your own way
             * throw new NotImplementedException();
             */
        }

        public int LowerBound(int value)
        {
            return this._LowerBound(value).Value;
        }

        /// <summary>
        /// Return the first existing number which is >= value
        /// </summary>
        /// <returns>closest number</returns>
        /// <param name='value'>Value</param>
        private Node _LowerBound(int value)
        {
            if (root == null)
                return new Node(int.MinValue);
            else
            {
                // traverse the tree to look for this value
                //throw new NotImplementedException();
                Node cur = root;
                Node lwrbound = new Node(int.MinValue);

                while (cur != null)
                {
                    if (cur.Value <= value)
                    {
                        lwrbound= cur;
                        cur = cur.Left;
                    }
                    else if (cur.Value > value)
                    {
                        cur = cur.Right;
                    }
                }
                
                return lwrbound;
            }
        }

        public void Remove(int value)
        {
            if (!Exist(value)) return;
            //else
            //use LowerBound(value+1) to get the number you need
            //throw new NotImplementedException();

        }

        public int[] ToArray()
        {
            List<int> L = new List<int>();
            ToArray(root, L);
            return L.ToArray();
        }

        private static void ToArray(Node node, List<int> L)
        {
            if (node == null) return;
            //fill the list in infix order
            //throw new NotImplementedException();
            ToArray(node.Left, L);
            L.Add(node.Value);
            ToArray(node.Right, L);
        }
    }
}

