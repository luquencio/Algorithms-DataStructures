using System;


class MyMatrix
{
   // TODO: declara el arreglo que representaria la matrix y otros atributos
   //       que consideres necesario

   // Construye la matrix N x M (N filas, M columnas), cada celda
   // inicialmente con valor 0.0
   public MyMatrix(int N, int M)
   {
      // TODO
   }

   // Construye la matrix N x M (N filas, M columnas), copia los valores del
   // arreglo 'A'
   public MyMatrix(double[,] A)
   {
      // TODO
   }
   
   // devuelve la matrix transpuesta
   public MyMatrix Transpose()
   {
      // TODO
   }

   // devuelve la matrix que resulta de sumar esta matrix por la matrix B
   //  lanza excepcion si las matrices tienen las mismas dimensiones
   public MyMatrix Add(MyMatrix B)
   {
      // TODO
   }

   // devuelve la matrix que resulta de multiplicar esta matrix por la matrix B
   //  lanza excepcion si las dimensiones no son compatibles
   public MyMatrix Multiply(MyMatrix B)
   {
      // TODO
   }

   // TODO
   // indexer para comodidad


   // ToString para impresion
   override public string ToString()
   {
      // TODO
   }
}

class Lab1B
{
   public static void Main()
   {
      MyMatrix A = new MyMatrix(3, 4);
      A[0, 0] = -1;  A[0, 1] =  0;  A[0, 2] =   8;  A[0, 3] = -5;
      A[1, 0] =  0;  A[1, 1] = -3;  A[1, 2] = -11;  A[1, 3] =  2;
      A[2, 0] =  1;  A[2, 1] = -1;  A[2, 2] =   0;  A[2, 3] =  4;
      Console.WriteLine("A = \n{0}", A);
      Console.WriteLine("transpose(A) = \n{0}", A.Transpose());

      MyMatrix B = new MyMatrix(new double[,] {
         { 6,  0},
         { 3, -1},
         {-4,  8},
      });
      Console.WriteLine("B = \n{0}", B);

      MyMatrix C = new MyMatrix(new double[,] {
         { 8,  7},
         {-1,  2},
         {-4, -2}
      });
      Console.WriteLine("C = \n{0}", C);

      Console.WriteLine("B + C = \n{0}", B.Add(C));

      Console.WriteLine(A.Transpose().Multiply(B));

/*
A =
-1 0 8 -5
0 -3 -11 2
1 -1 0 4

transpose(A) =
-1 0 1
0 -3 -1
8 -11 0
-5 2 4

B =
6 0
3 -1
-4 8

C =
8 7
-1 2
-4 -2

B + C =
14 7
2 1
-8 6

-10 8
-5 -5
15 11
-40 30
*/
   }
}
