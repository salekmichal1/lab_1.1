using System;
using System.Collections.Generic;

namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
            Ulamek a = new Ulamek(4, 9);
            Ulamek b = new Ulamek(21, 3);
            Ulamek c = new Ulamek(a);
            new Ulamek();

            List<Ulamek> ulamki = new List<Ulamek>
            {
                new Ulamek(4, 9), new Ulamek(21, 3),
                new Ulamek(),
            };
            ulamki.Sort();
            ulamki.ForEach(ulamek => Console.WriteLine(ulamek.Numerator + "/" + ulamek.Denominator));

            Console.WriteLine(a / b);

            Console.WriteLine(a.Equals(b));

            Console.WriteLine(a.RoundDown());
            Console.WriteLine(a.RoundUp());
        }
    }
}
