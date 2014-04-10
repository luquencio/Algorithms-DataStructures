using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBST
{
    class BSTnode
    {
        public int Value;
        public BSTnode left;
        public BSTnode right;
        public BSTnode parent;

        public BSTnode(int item) 
        {
            this.Value = 0;
            this.left = null;
            this.right = null;
            this.parent = null;
        }
        
    }
}
