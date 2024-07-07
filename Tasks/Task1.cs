using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Tasks
{
    public static class Task1
    {
        public static void Equation()
        {
            double a = 1;
            double b = -2;
            double c = 1;

            List<double> xTable = new List<double>();
            List<double> fTable = new List<double>();

            for (double x = -1.0; x <= 2.0; x += 0.2)
            {
                double fx = a * x * x + b * x + c;
                xTable.Add(x);
                fTable.Add(fx);
            }

            Console.WriteLine("x\tF(x)");
            for (int i = 0; i < xTable.Count; i++)
            {
                Console.WriteLine($"{xTable[i]:F2}\t{fTable[i]:F6}");
            }
        }
    }
}
