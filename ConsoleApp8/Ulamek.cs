using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ConsoleApp8
{
    public class Ulamek : IEquatable<Ulamek>, IComparable<Ulamek>
    {

        // zmienne
        public int Numerator { get; set; }
        public int Denominator { get; set; }


        // konstruktor domyslny
        public Ulamek()
        {
            Numerator = 5;
            Denominator = 5;
        }

        // konstruktor
        public Ulamek(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        // konstruktor kopiujacy
        public Ulamek(Ulamek previusUlamek)
        {
            Numerator = previusUlamek.Numerator;
            Denominator = previusUlamek.Denominator;
        }

        // konwertowanie obiektu na string
        public override string ToString()
        {
            return Numerator.ToString() + "/" + Denominator.ToString();
        }

        // obliczanie najwiekszego wspolnego dzielnika
        private static int GCD(int a, int b)
        {
            int x;
            while (b != 0)
            {
                x = b;
                b = a % b;
                a = x;
            }
            return a;
        }

        // metoda zaokraglenie w dol
        public int RoundDown()
        {
            double digitDown = (double)Numerator / (double)Denominator;
            return (int)Math.Floor(digitDown);
        }
        
        // metoda zaokraglenie w gore
        public int RoundUp()
        {
            double digitUp = (double)Numerator / (double)Denominator;
            return (int)Math.Ceiling(digitUp);
        }

        // interfejs sprawdzanie czy rowne
        public bool Equals([AllowNull] Ulamek other)
        {
            if( Numerator / Denominator == other.Numerator / Denominator)
            {
                return true;
            }
            return false;
        }

        // interfejs porownania
        public int CompareTo([AllowNull] Ulamek other)
        {
            return Numerator / Denominator.CompareTo(other.Numerator / Denominator);
        }

        // operatory dodawania, odejmowania, mnozenia, dzielenia + - * / 
        public static Ulamek operator +(Ulamek ulamek1, Ulamek ulamek2)
        {
            if (ulamek1.Denominator == ulamek2.Denominator) {

                return new Ulamek(ulamek1.Numerator + ulamek2.Numerator / GCD(ulamek1.Numerator + ulamek2.Numerator, ulamek1.Denominator), ulamek1.Denominator / GCD(ulamek1.Numerator + ulamek2.Numerator, ulamek1.Denominator));
            }
            else
            {
                int numerator = ulamek1.Numerator * ulamek2.Denominator + ulamek1.Denominator * ulamek2.Numerator;
                int denominator = ulamek1.Denominator * ulamek2.Denominator;
                return new Ulamek(numerator / GCD(numerator, denominator), denominator / GCD(numerator, denominator));
            }
        }
        public static Ulamek operator -(Ulamek ulamek1, Ulamek ulamek2)
        {
            if (ulamek1.Denominator == ulamek2.Denominator)
            {
                return new Ulamek(ulamek1.Numerator - ulamek2.Numerator / GCD(ulamek1.Numerator - ulamek2.Numerator, ulamek1.Denominator), ulamek1.Denominator / GCD(ulamek1.Numerator - ulamek2.Numerator, ulamek1.Denominator));
            }
            else
            {
                int numerator = ulamek1.Numerator * ulamek2.Denominator - ulamek1.Denominator * ulamek2.Numerator;
                int denominator = ulamek1.Denominator * ulamek2.Denominator;
                return new Ulamek(numerator / GCD(numerator, denominator), denominator / GCD(numerator, denominator));
            }
        }
        public static Ulamek operator *(Ulamek ulamek1, Ulamek ulamek2)
        {
            int numerator, denominator;

            numerator = ulamek1.Numerator * ulamek2.Numerator;
            denominator = ulamek1.Denominator* ulamek2.Denominator;

            return new Ulamek(numerator / GCD(numerator, denominator), denominator / GCD(numerator, denominator) );
        }
        public static Ulamek operator /(Ulamek ulamek1, Ulamek ulamek2)
        {
            int numerator, denominator;

            numerator = ulamek1.Numerator * ulamek2.Denominator;
            denominator = ulamek1.Denominator * ulamek2.Numerator;

            return new Ulamek(numerator / GCD(numerator, denominator), denominator / GCD(numerator, denominator));
        }

    }
}
