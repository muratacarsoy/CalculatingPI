using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsolePi
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WindowWidth = 150; Console.WindowHeight = 50;
            decimal a = 2, b = 0, c = 0, d = 2, x, y, adet = 1, r = 2, r2 = 4, pi, u, w, m2, m;
            while (true)
            {
                m2 = (a - c) * (a - c) + (b - d) * (b - d);
                u = (a + c) / 2; w = (b + d) / 2;
                x = r - (2 * r * (r - SquareRoot(u * u + w * w))) / (2 * r);
                y = SquareRoot(r2 - x * x);
                m = SquareRoot(m2);
                pi = m * adet;
                Console.WriteLine(pi + "\n\t adet: " + adet + "\t tek çizgi mesafesi: " + m + "\n"); Console.ReadKey();
                c = x; d = y;
                try
                {
                    adet = checked(adet * 2);
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Taşma hatası");
                }
            }
        }

        private static decimal MesafeKare(decimal a, decimal b, decimal c, decimal d)
        {
            decimal m2 = (a - c) * (a - c) + (d - b) * (d - b);
            return m2;
        }

        private static decimal Mesafe(decimal a, decimal b, decimal c, decimal d)
        {
            decimal ret = 0;
            decimal m2 = (a - c) * (a - c) + (d - b) * (d - b);
            ret = SquareRoot(m2);
            return ret;
        }

        private static decimal SquareRoot(decimal _bi) //Newton-Raphson Metodu
        {
            if (_bi == 0) return 0.0m;
            decimal bi = _bi * 1000000000000.0m;
            decimal ret = 0, iterasyon = bi / 2; bool hs = true;
            decimal xn = iterasyon, fxn = xn * xn - bi, _fxn, _xn; int i = 0;
            while (hs)
            {
                _fxn = fxn;
                _xn = (xn * xn + bi) / (2 * xn);
                if (_xn < 0.00000000000000001m) break;
                xn = _xn;
                fxn = xn * xn - bi;
                //hs = !((fxn - _fxn > 0 && fxn - _fxn < hassasiyet) || (_fxn - fxn > 0 && _fxn - fxn < hassasiyet));
                hs = i < 100; i++;
            }
            ret = xn / 1000000.0m;
            return ret;
        }
    }
}
