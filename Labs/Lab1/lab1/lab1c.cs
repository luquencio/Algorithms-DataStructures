using System;

class DuplicateScoreException : System.Exception { }

class ScoreNotFoundException : System.Exception { }

class HighScoreLeaderBoard
{
    // TODO: declara los atributos (privados y/o publicos) que necesites
    long[] scores;
    string[] names;
    int size;


    // crear un LeaderBoard para top K scores
    public HighScoreLeaderBoard(int K)
    {
        // TODO: implementa el constructor
        // inicialmente el LeaderBoard debe estar "vacio"
        scores = new long[K];
        names = new string[K];
        size = K;
    }

    // agrega el score
    public void AddScore(long score, string name)
    {
        // TODO: implementacion
        // primero, verifica que el score y name no existan
        //   si existe, levanta alguna excepcion
        // luego, verifica si el leader board esta "lleno" o no
        // si no esta lleno, agregalo a un espacio vacio
        // de lo contrario, verifica si el score es mayor que el score mas bajo
        //   si es mayor, reemplaza el mas bajo por el nuevo score
        //   de lo contrario, no haces nada

        if (NameExist(name) && ScoreExist(score))
        {

        }

        if (!IsFull())
        {
            AddNewScore(name, score);
        }

        else
        {
            if (score > LowerScore())
            {
                ReplaceScore(score, name);
            }
        }
    }

    private bool NameExist(string name)
    {
        // asume que nombre no existe
        bool exist = false;

        foreach (string n in names)
        {
            if (n == name)
            {
                exist = true;
                break;
            }
        }

        return exist;
    }

    private bool ScoreExist(long score)
    {
        // asume que nombre no existe
        bool exist = false;

        foreach (long s in scores)
        {
            if (s == score)
            {
                exist = true;
                break;
            }
        }

        return exist;
    }

    private bool IsFull()
    {
        // asume que esta lleno
        bool full = true;

        foreach (string name in names)
        {
            if (name.Length == 0)
            {
                full = false;
                break;
            }
        }

        return full;
    }

    private long LowerScore()
    {
        long lower = 0;

        for (int i = 0; i < scores.Length; i++)
        {
            if (lower < scores[i])
            {
                lower = scores[i];
            }
        }

        return lower;
    }

    private void ReplaceScore(long score, string name)
    {
        for (int i = 0; i < scores.Length; i++)
        {
            if (scores[i] == LowerScore())
            {
                scores[i] = score;
                names[i] = name;
                break;
            }
        }
    }

    private void AddNewScore(string n, long s)
    {
        for (int i = 0; i < names.Length; i++)
        {
            if (names[i].Length == 0)
            {
                names[i] = n;
                scores[i] = s;
                break;
            }
        }
    }

    // elimina un score
    public void RemoveScore(int score, string name)
    {
        // TODO: implementacion
        // ubica el score y name en el leader board
        //   eliminalo si lo encuentras
        //   de lo contrario, levanta alguna excepcion
        for (int i = 0; i < names.Length; i++)
        {
            if (name == names[i] && score == scores[i])
            {
                names[i] = name;
                scores[i] = score;
            }
        }
    }

    public void Print()
    {
        // TODO
        for (int i = 0; i < names.Length; i++)
        {
            Console.WriteLine("{0} {1}", scores[i], names[i]);
        }
    }
}

class Lab1C
{
    static void Main(string[] args)
    {
        HighScoreLeaderBoard b = new HighScoreLeaderBoard(5);
        b.AddScore(99999, "Gisele");
        b.AddScore(12345, "Javier");
        b.AddScore(55599, "Manuel");
        b.AddScore(10050, "Katiuska");
        b.RemoveScore(55599, "Manuel");
        b.AddScore(33137, "Raul");
        b.AddScore(43201, "Reyna");
        b.AddScore(87654, "Ana");
        b.Print();
        /*
        99999 Gisele
        12345 Javier
        33137 Raul
        87654 Ana
        43201 Reyna
        */
    }
}