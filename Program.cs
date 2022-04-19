using System;

namespace Romberg_Intregration
{
    class Program
    {
        static double Func(double x)
        {
            return (1 / (1 + Math.Pow(x, 2)));
        }
        static void Main(string[] args)
        {
            double x0, xn, h, sm, sl, a;
            double[,] t = new double[10, 10];
            int i, k, c, r, m, p, q;
            Console.WriteLine("Enter lower and upper limit:");
            x0 = Convert.ToDouble(Console.ReadLine());
            xn = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("enter p and q required T(p,q):");
            p = Convert.ToInt32(Console.ReadLine());
            q = Convert.ToInt32(Console.ReadLine());
            h = xn - x0;
            t[0, 0] = h / 2 * ((Func(x0)) + (Func(xn)));
            for (i = 1; i <= p; i++)
            {
                sl = Math.Pow(2, i - 1);
                sm = 0;
                for (k = 1; k <= sl; k++)
                {
                    a = x0 + (2 * k - 1) * h / Math.Pow(2, i);
                    sm = sm + (Func(a));
                }
                t[i, 0] = t[i - 1, 0] / 2 + sm * h / Math.Pow(2, i);
            }
            for (c = 1; c <= p; c++)
            {
                for (k = 1; k <= c && k <= q; k++)
                {
                    m = c - k;
                    t[m + k, k] = (Math.Pow(4, k) * t[m + k, k - 1] - t[m + k - 1, k - 1]) / (Math.Pow(4, k) - 1);
                }
            }
            Console.WriteLine("Romberg estimate of integration ={0:0.0000}", t[p, q]);


        }
    }
}