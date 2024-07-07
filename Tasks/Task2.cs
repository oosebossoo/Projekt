using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Tasks
{
    public class Task2
    {
        static double[] xValues = { -1.0, 0.0, 1.0, 2.0, 3.0 };
        static double[] fValues = { 1.0, 0.0, 1.0, 4.0, 9.0 };

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
