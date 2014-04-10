using System;

class DuplicateKeyException    : System.Exception {}
class InvalidRotationException : System.Exception {}
class KeyNotFoundException     : System.Exception {}


// Representa un nodo de un arbol
class TreeNode
{
   public int item;             // el dato a guardar en el nodo
   public TreeNode left, right; // referencias al hijo izquierdo e hijo derecho
   public TreeNode parent;      // referencia al padre de este nodo en el arbol
                                //   para root, parent == null
   public int subtree_size;     // cantidad de nodos en el subarbol cuya raiz
                                //   es este nodo
   public TreeNode(int _item)
   {
      item   = _item;
      left   = null;
      right  = null;
      parent = null;
      subtree_size = 1;
   }
}

// El Binary Search Tree
class BinarySearchTree
{
    private TreeNode root;     // raiz del arbol
    private int size;          // cantidad de elementos en el arbol
    public int Size { get { return size; } }

    // construye un arbol vacio
    public BinarySearchTree()
    {
        root = null;
        size = 0;
    }

    // Busca el item en el arbol y devuelve el TreeNode que lo contiene;
    // devuelve null si no existe
    public TreeNode Find(int _item)
    {
        TreeNode cur = root;
        while (cur != null)
        {
            if (_item == cur.item)
                return cur;
            if (_item < cur.item)
                cur = cur.left;
            else  // _item > cur.item
                cur = cur.right;
        }
        return null;
    }

    // Agrega el item al arbol
    // Si ya existe, lanza excepcion DuplicateKeyException
    // BUG: hay 3 errores en este metodo... encuentra y corrijalos?
    public void Add(int _item)
    {
        // si el arbol esta vacio
        if (root == null)
        {
            // crear la raiz del arbol
            root = new TreeNode(_item);

            // error 1: hay que aumentar el size cuando se inserta el primer item
            size++;
            return;
        }

        TreeNode cur = root, prev = null;
        while (cur != null)
        {
            if (_item == cur.item)
                // si existe, levanto una exception
                throw new DuplicateKeyException();
            prev = cur;
            if (_item < cur.item)
                cur = cur.left;
            else  // _item > cur.item
                cur = cur.right;
        }

        // crear nuevo nodo
        TreeNode new_node = new TreeNode(_item);

        // enlazar nuevo nodo al arbol
        if (_item < prev.item)
            prev.left = new_node;
        else
            prev.right = new_node;
        new_node.parent = prev;

        // aumenta la cantidad de nodos en el arbol
        size++;

        // actualizar los subtree_size de todos los nodos en la ruta hacia la raiz
        cur = new_node;
        while (cur != root)
        {
            // error 2: el subtreesize del nuevo nodo no debe ser incrementado, el del padre si
            cur = cur.parent;
            cur.subtree_size++;
        }
    }

    // Rotar un nodo hacia la derecha
    //   lanza excepcion InvalidRotationException si la rotacion NO es valida
    private void RotateRight(TreeNode X)
    {
        TreeNode Y = X.left;
        if (Y == null)
            throw new InvalidRotationException();

        // Estas variables son para simplificar el codigo
        //  Las puedes borrar si no las necesitas
        TreeNode P = X.parent;
        TreeNode A = Y.left;
        TreeNode B = Y.right;
        TreeNode C = X.right;

        // TODO: enlaza B como hijo izquierdo de X

        X.left = B;
        if (B != null)
        {
            B.parent = X;
        }


        // TODO: enlaza X como hijo derecho de Y
        Y.right = X;
        X.parent = Y;

        Y.parent = P;

        // TODO: si P == null, quiere decir que X es root y tenemos que cambiar
        //       la referencia en root
        if (P == null)
        {
            root = Y;
        }

        // TODO: de lo contrario enlaza nodo Y como hijo de P
        //   OJO: debes verificar si debe ser hijo izquierdo o derecho de P
        else if (Y.item < P.item)
        {
            P.left = Y;
        }

        else
        {
            P.right = Y;
        }

        // TODO: actualiza sizes de los subtrees afectados

        X.subtree_size = SubtreeSize(B) + SubtreeSize(C) + 1;
        Y.subtree_size = SubtreeSize(X) + SubtreeSize(A) + 1;

    }

    // Rotar un nodo hacia la izquierda
    //   lanza excepcion InvalidRotationException si la rotacion NO es valida
    private void RotateLeft(TreeNode Y)
    {
        // TODO.  Similar a RotateRight
        TreeNode X = Y.right;
        if (X == null)
            throw new InvalidRotationException();

        TreeNode P = Y.parent;
        TreeNode A = Y.left;
        TreeNode B = X.left;
        TreeNode C = X.right;

        Y.right = B;
        if (B != null)
        {
            B.parent = Y;
        }


        X.left = Y;
        Y.parent = X;

        X.parent = P;

        if (P == null)
        {
            root = X;
        }

        else if (X.item < P.item)
        {
            P.left = X;
        }

        else
        {
            P.right = X;
        }

        Y.subtree_size = SubtreeSize(A) + SubtreeSize(B) + 1;
        X.subtree_size = SubtreeSize(Y) + SubtreeSize(C) + 1;
    }

    // Localiza el item en el arbol y lo lleva al root por medio de rotaciones
    //   si no encuentra el item, levanta excepcion KeyNotFoundException
    //   si ves la operacion de rotacion, uno de los hijos sube un nivel
    //   la idea es identificar el nodo que deseamos subir en el arbol y
    //   aplicar la rotation correspondiente
    public void RotateToRoot(int _item)
    {
        // TODO

        TreeNode newRoot = Find(_item);

        if (newRoot == null)
        {
            throw new KeyNotFoundException();
        }

        else
        {
            while (newRoot != root)
            {
                if (newRoot == newRoot.parent.right)
                {
                    RotateLeft(newRoot.parent);
                }

                else
                {
                    RotateRight(newRoot.parent);
                }
            }
        }

    }

    // Encuentra el elemento predecesor de _item: el elemento mas grande cuyo
    // item es estrictamente menor que el parametro _item
    // devuelve null si no existe
    // OJO: _item NO necesariamente existe en el arbol, pero esto es permitido
    public TreeNode Predecessor(int _item)
    {
        // TODO         

        return Select(Rank(_item) - 1);
    }

    // Encuentra el elemento sucesor de _item: el elemento mas pequenio cuyo
    // item es estrictamente menor que el parametro _item
    // devuelve null si no existe
    // OJO: _item NO necesariamente existe en el arbol, pero esto es permitido
    public TreeNode Successor(int _item)
    {
        // TODO

        TreeNode succesor = Select(Rank(_item));


        return (succesor.item == _item) ? Select(Rank(succesor.item) + 1) : succesor;
    }

    // metodo para simplificar tratamiento de los null
    private int SubtreeSize(TreeNode X)
    {
        if (X == null)
            return 0;
        else
            return X.subtree_size;
    }

    // Devuelve el rank de _item: la posicion del _item si todos los datos
    //   estuvieran ordenados en un arreglo indexado desde 0
    // OJO: _item NO necesariamente existe en el arbol, pero esto es permitido
    public int Rank(int _item)
    {
        int ret = 0;
        TreeNode cur = root;
        while (cur != null)
        {
            // ORD: reordena correctamente los siguientes statements.
            //      Algunos de ellos deben estar anidados dentro los IF / ELSE

            // Statement C
            if (_item < cur.item)
            {
                // Statement A
                cur = cur.left;
            }

            // Statement D
            else if (_item == cur.item)
            {
                // Statement G
                ret += SubtreeSize(cur.left);

                // Statement H
                break;
            }

            // Statement E
            else
            {
                // Statement F
                ret += SubtreeSize(cur.left) + 1;

                // Statement B
                cur = cur.right;
            }

        }
        return ret;
    }

    // Devuelve el elemento en la posicion pos si los datos estuvieran ordenados
    //   en un arreglo indexado desde 0
    // Devuelve null si pos esta fuera de rango
    // BUG: este metodo tiene 3 defectos; identifica y corrigelos
    public TreeNode Select(int pos)
    {
        if (pos < 0 || pos > size)
            return null;
        TreeNode cur = root;
        while (cur != null)
        {
            //error 1: debe comparar con el subtreesize de cur.left no con 0
            //if (pos == 0)
            if (pos == SubtreeSize(cur.left))
                return cur;
            if (pos - SubtreeSize(cur.left) < 0)
            {
                cur = cur.left;
            }
            else
            {
                // error 2: primero debe substraerse los elementos de la izquierda y luego cambiar cur
                // error 3: debe sumarsele 1 al subtreesize de cur.left para no obviar el nodo cur 

                // cur = cur.right;
                // pos -= SubtreeSize(cur.left); (no se toma el mismo en cuenta)

                pos -= (SubtreeSize(cur.left) + 1);
                cur = cur.right;
            }
        }
        return null;
    }

}

class Lab3 {
   public static void Main() {
      BinarySearchTree bst = new BinarySearchTree();

      bst.Add(29);
      bst.Add(-5);
      bst.Add(100);
      bst.Add(8);
      bst.Add(42);
      bst.Add(50);
      bst.Add(11);
      bst.Add(10);
      bst.Add(0);
      bst.Add(22);
      bst.Add(90);
      bst.Add(-100);

      Console.WriteLine("Predecessor(31) = {0}", bst.Predecessor(31).item);
      Console.WriteLine("Successor(3) = {0}", bst.Successor(3).item);

      bst.RotateToRoot(0);
      Console.WriteLine("Despues de RotateToRoot(0)");

      Console.WriteLine("Predecessor(31) = {0}", bst.Predecessor(31).item);
      Console.WriteLine("Successor(3) = {0}", bst.Successor(3).item);

      Console.WriteLine("Rank(-5) = {0}", bst.Rank(-5));
      Console.WriteLine("Rank(10) = {0}", bst.Rank(10));
      
      Console.WriteLine("Select(1) = {0}", bst.Select(1).item);
      Console.WriteLine("Select(4) = {0}", bst.Select(4).item);
/*

Expected output:
Predecessor(31) = 29
Successor(3) = 8
Despues de RotateToRoot(0)
Predecessor(31) = 29
Successor(3) = 8
Rank(-5) = 1
Rank(10) = 4
Select(1) = -5
Select(4) = 10

*/
   }
}
