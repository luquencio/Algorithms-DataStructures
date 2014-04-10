using System;
using System.Collections.Generic;

namespace Practicas
{
    public class Trie
    {
        private const int ALPHABET = 26;
        private class Node
        {
            public Node[] childs { get; set; } //porque no usar una lista?
            public bool StringEndsHere { get; set; }
            public Node()
            {
                this.childs = new Node[ALPHABET];
                this.StringEndsHere = false;
            }

            //movi la funcion get value
        }

        private Node root;
        public int Size { get; private set; }
        public Trie()
        {
            root = new Node();// represents empty string
        }
        
        public void Clear()
        {
            root = new Node();
            Size = 0;
        }

        //esta funcion tenia problemas de acceso, entonces desde el nodo no sabia como llamarla.
        public static int getValue(char c)
        {
            if (!char.IsLetter(c))
                throw new InvalidCastException();
            return char.ToLower(c) - 'a';
        }

        //NOTE: not recursion needed
        public void Insert(string s) //cambie el insert a public para que se pueda hacer desde el main
        {
            if (Exist(s)) return;
            // start at the root and traverse 
            // or create nodes when needed

            //at the and set the "StringEndsHere" flag to true
            //throw new NotImplementedException();

            var cur = root;

            int i = 0;   

            while (i < s.Length)
            {
                if (cur.childs[getValue(s[i])] != null)
                {
                    cur = cur.childs[getValue(s[i])];
                    i++;
                    cur.StringEndsHere = true;
                }
                else
                    break;                
            }

            while (i < s.Length)
            {
                cur.childs[getValue(s[i])] = new Node();
                cur = cur.childs[getValue(s[i])];
                i++;
                cur.StringEndsHere = true;
            }

        }

        //NOTE: not recursion needed
        private bool Exist(string s)
        {
            //traverse from the root 
            //if one needed node is null
            //the string does not exist

            //at the end if a String ends here return true
            //throw new NotImplementedException();

            var cur = root;
            int i = 0;
            if (cur.childs[getValue(s[i])] == null) 
            {
                //Console.WriteLine("Exists");
                return false;
            }

            while (i < s.Length)
            {


                    if (cur.childs[getValue(s[i])].StringEndsHere == false)
                    {
                        cur = cur.childs[getValue(s[i])];
                        i++; 
                    }
                    else if (cur.childs[getValue(s[i])].StringEndsHere == true)
                    {
                        return true;
                    }
            }

            return false;
        }

        //prints a the sorted list of strings in O(N)
        public string[] ToArray()
        {
            List<string> RET = new List<string>();
            ToArray("", root, RET);
            return RET.ToArray();
        }

        //recursion needed
        private void ToArray(string StringSoFar, Node node, List<string> L)
        {
            //puts the elements int the list
            //throw new NotImplementedException();
            if (node == null) return;
            if (node.StringEndsHere == true)
                L.Add(StringSoFar);
               
            for (int i = 0; i < ALPHABET; i++)
            {
                string newstring = StringSoFar + ('A' + i);
                ToArray(StringSoFar, node, L);
            }

        }


        //EXTRA: enlist all the strings that starts with "StringSoFar"
        public string[] Suggestions(string StringSoFar)
        {
            //find the last node prefix of StringSoFar
            Node lastNode = null;// <-- put this node here

            List<string> RET = new List<string>();
            ToArray("", lastNode, RET);
            return RET.ToArray();
        }
    }
}

