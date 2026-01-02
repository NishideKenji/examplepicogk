using System;

class Program
{
    static void Main()
    {
        try
        {
            // 0.5f はボクセル解像度[mm]。まずは 0.5〜1.0 がおすすめ
            PicoGK.Library.Go(0.5f, PipeStraightExample.Task);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}