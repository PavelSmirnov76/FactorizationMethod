using FactorizationMethod;
using System;
using System.Globalization;
using System.Numerics;

namespace MyApp 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //вход
            var n = 25;//8191 * 131071;//661643;// 3571*3559; //455839 //
            var m = 12;
            //генерация
            while (true)
            {
                var random = new Random();

                var a = random.Next(n);
                var x = random.Next(n);
                var y = random.Next(n);
                var b = y * y - x * x * x + a * x;
                var Q = new ECPoint(a, b, x, y, n);
                var i = 0;
                var pi = 2;
                int ai = 0;

                

                var Qi = Q;
                //ищем простое

                while (i < m)
                {
                    while (!IsPrime(pi))
                    {
                        pi++;
                    }

                    i = i + 1;
                    ai = (int)Math.Truncate(0.5 * Math.Log(n) / Math.Log(pi));
                    var j = 0;

                    while (j < ai)
                    {
                        Qi = ECPoint.multiply(pi, Qi);
                        j = j + 1;
                    }

                    pi++;
                }
            }
        }
        public static bool IsPrime(int number)
        {
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }
    }
    
}