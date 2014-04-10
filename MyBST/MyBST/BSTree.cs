using System;

class DuplicateKeyException : System.Exception { }
class InvalidRotationException : System.Exception { }
class KeyNotFoundException : System.Exception { }


namespace MyBST
{
    class BSTree
    {
        public BSTnode root;
        private int Size { get; set; }

        public BSTree() 
        {
            this.Size = 0;
            root = null;
        }

       public void Insert(int item) 
       {
           BSTnode cur = root;

           if (root == null)
           {
               root = new BSTnode(item);
               Size++;
           }

           BSTnode ant = null;

           while (cur != null)
           {
               if (item == cur.Value)
               {
                   throw new DuplicateKeyException();
               }
               ant = cur;
               if (item < cur.Value)
               {
                   cur = cur.left;
               }
               else   
               {
                   cur = cur.left;
               }
           }

           BSTnode new_node = new BSTnode(item);
           if (item < ant.Value)
           {
               ant.left = new_node;
           }
           else 
           {
               ant.right = new_node;
           }
           new_node.parent = ant;

           Size++;

           cur = new_node;
           while (cur != root)
           {
                cur = cur.parent;
           }

       }

    }
}
