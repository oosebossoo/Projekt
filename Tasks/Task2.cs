using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Tasks
{
    public class Task2
    {
        static double[] xValues = { -1.0, 0.0, 1.0, 2.0 };
        static double[] fValues = { 1.0, 0.0, 1.0, 6.0 };

        public static double LagrangeInterpolation(double x)
        {
            int n = xValues.Length;
            double result = 0.0;

            for (int i = 0; i < n; i++)
            {
                double term = fValues[i];
                for (int j = 0; j < n; j++)
                {
                    if (j != i)
                    {
                        term *= (x - xValues[j]) / (xValues[i] - xValues[j]);
                    }
                }
                result += term;
            }

            return result;
        }

        public static void Equation()
        {
            double a = 1.0;
            double b = 0.0;
            double c = 0.0;

            List<double> xTable = new List<double>();
            List<double> wTable = new List<double>();
            List<double> fTable = new List<double>();

            for (double x = -1.0; x <= 3.0; x += 0.2)
            {
                xTable.Add(x);
                wTable.Add(LagrangeInterpolation(x));
                fTable.Add(a * x * x + b * x + c);
            }

            Console.WriteLine("x\tW3(x)\tF(x)");
            for (int i = 0; i < xTable.Count; i++)
            {
                Console.WriteLine($"{xTable[i]:F2}\t{wTable[i]:F6}\t{fTable[i]:F6}");
            }
        }
    }
}

//using System;

//namespace Projekt.Tasks
//{
//    public class Task2
//    {
//        public static void Equation()
//        {
//            // Współrzędne punktów
//            double[][] punkty = {
//                new double[] { -1, -1 },
//                new double[] { 0, 0 },
//                new double[] { 1, 1 },
//                new double[] { 2, 4 },
//                new double[] { 3, 9 }
//            };

//            // Tworzenie wielomianu interpolacyjnego Lagrange'a
//            double[] wspolczynnikiLagrange = Lagrange(punkty);

//            // Tworzenie funkcji kwadratowej
//            double a = 1;
//            double b = 2;
//            double c = 1;

//            // Tablica wartości
//            Console.WriteLine("x | W3(x) | F(x)");
//            Console.WriteLine("--|-------|------");
//            for (double x = -1; x <= 3; x += 0.2)
//            {
//                // Wartość wielomianu interpolacyjnego Lagrange'a
//                double w3 = 0;
//                for (int i = 0; i < wspolczynnikiLagrange.Length; i++)
//                {
//                    w3 += wspolczynnikiLagrange[i] * Math.Pow(x, i);
//                }

//                // Wartość funkcji kwadratowej
//                double f = a * x * x + b * x + c;

//                // Wyświetlanie wartości
//                Console.WriteLine($"{x,-3} | {w3,-6:F4} | {f,-4:F2}");
//            }
//        }

//        static double[] Lagrange(double[][] punkty)
//        {
//            int n = punkty.Length;
//            double[] wspolczynniki = new double[n];

//            for (int i = 0; i < n; i++)
//            {
//                double licznik = 1;
//                double mianownik = 1;

//                for (int j = 0; j < n; j++)
//                {
//                    if (i == j)
//                    {
//                        continue;
//                    }

//                    licznik *= punkty[i][0] - punkty[j][0];
//                    mianownik *= punkty[i][0] - punkty[j][0];
//                }

//                wspolczynniki[i] = licznik / mianownik;
//            }

//            return wspolczynniki;
//        }
//    }
//}