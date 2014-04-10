using System;


class MyString
{
    private char[] _arr;

    // constructores
    public MyString()
    {
        _arr = new char[0];    // arreglo de size 0
    }
    public MyString(char[] s)
    {
        _arr = (char[])s.Clone();
    }

    // Devolver la longitud de MyString
    public int Length
    {
        get
        {
            // TODO
            return _arr.Length;
        }
    }

    // Encontrar la primera posicion del caracter 'ch' en MyString, de izquierda
    // a derecha, contando a partir de la posicion 'from'
    // Devolver -1 si no lo encuentra
    public int Find(char ch, int from)
    {
        // TODO
        int pos = -1;

        for (int i = from; i < _arr.Length; i++)
        {
            if (_arr[i] == ch)
            {
                pos = i;
            }
        }

        return pos;
    }

    // Encontrar la primera posicion del caracter 'ch' en MyString, de izquierda
    // a derecha, contando a partir de la posicion 0
    // Devolver -1 si no lo encuentra
    public int Find(char ch)
    {
        // TODO
        int pos = -1;

        for (int i = 0; i < _arr.Length; i++)
        {
            if (_arr[i] == ch)
            {
                pos = i;
                break;
            }
        }

        return pos;
    }

    // Concatenar str al final de este string
    public void Concat(MyString str)
    {
        char[] newString = new char[_arr.Length + str._arr.Length];
        // TODO
        for (int i = 0; i < _arr.Length; i++)
        {
            newString[i] = _arr[i];
        }

        for (int i = 0; i < str._arr.Length; i++)
        {
            newString[i + _arr.Length] = str._arr[i];
        }

        _arr = (char[])newString.Clone();
    }

    // Retornar el substring de la posicion ini hasta la posicion fin
    public MyString Substring(int ini, int fin)
    {
        // TODO
        int charSize = (fin - ini) + 1;
        char[] sub = new char[charSize];

        for (int i = 0; i < charSize; i++)
        {
            sub[i] = _arr[ini];
            ini++;
        }

        return new MyString(sub);
    }

    // Retornar el substring de la posicion ini hasta el final del string
    public MyString Substring(int ini)
    {
        // TODO
        int charSize = _arr.Length - ini;
        char[] sub = new char[charSize];


        for (int i = 0; i < charSize; i++)
        {
            sub[i] = _arr[ini];
            ini++;
        }

        return new MyString(sub);
    }


    // indexer para comodidad de uso
    // ahora puedes accesar cualquier posicion de MyString
    public char this[int idx]
    {
        get
        {
            if (idx < 0 || idx >= _arr.Length)
                throw new System.IndexOutOfRangeException();
            return _arr[idx];
        }
        set
        {
            if (idx < 0 || idx >= _arr.Length)
                throw new System.IndexOutOfRangeException();
            _arr[idx] = value;
        }
    }

    // para imprimir como si fuera un string normal
    override public string ToString()
    {
        return new string(_arr);
    }
}

class Lab1A
{
    public static void Main()
    {
        MyString s2 = new MyString(new char[] { 'H', 'e', 'l', 'l', 'o' });
        Console.WriteLine("Longitud = {0}", s2.Length);
        // modificar la primera letra;
        // esta operacion no es permitida para string de C#
        s2[0] = 'h';
        Console.WriteLine("Despues de cambiar primera letra: {0}", s2);

        MyString s3 = new MyString(new char[] { ' ', 'w', 'o', 'r', 'l', 'd' });
        s2.Concat(s3);
        Console.WriteLine("Despues de concatenar world: {0}", s2);

        Console.WriteLine("Posicion de letra l = {0}", s2.Find('l'));
        Console.WriteLine("Posicion de letra s = {0}", s2.Find('s'));
        Console.WriteLine(
           "Posicion de letra l contando a partir del indice 6 = {0}",
           s2.Find('l', 6)
        );

        MyString s4 = s2.Substring(3, 7);
        Console.WriteLine("Substring desde la posicion 3 hasta 7: {0}", s4);

        MyString s5 = s2.Substring(6);
        Console.WriteLine("Substring desde la posicion 6 hasta el final: {0}", s5);


        /*
        Programa debe imprimir:

        Longitud = 5
        Despues de cambiar primera letra: hello
        Despues de concatenar world: hello world
        Posicion de letra l = 2
        Posicion de letra s = -1
        Posicion de letra l contando a partir del indice 6 = 9
        Substring desde la posicion 3 hasta 7: lo wo
        Substring desde la posicion 6 hasta el final: world
        */
    }
}
