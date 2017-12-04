using System;

namespace Problem1_Poke_Mon
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            int Y = int.Parse(Console.ReadLine());
            int newN = N;

            int count = 0;
            while (N>=M)
            {
                var C = N - M;
                 
                if (C == newN/2 && Y>0)
                {
                    C = C / Y;
                   }
                N = C;
                count++;
                
            }
            Console.WriteLine(N);
            Console.WriteLine(count);
        }
    }
}
