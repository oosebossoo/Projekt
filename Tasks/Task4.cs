using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Tasks
{
    public static class Task4
    {
        static double Function(double x)
        {
            return 2 * (1 / Math.Pow(Math.Cos(x), 2) + 2 * Math.Pow(x, 3));
        }

        static double MonteCarloIntegration(int n, Random rand)
        {
            double sum = 0.0;
            for (int i = 0; i < n; i++)
            {
                double x = rand.NextDouble();
                sum += Function(x);
            }
            return sum / n;
        }

        public static void Equation()
        {
            double exactValue = 2 * Math.Tan(1) + 1;
            double eps = 1e-4;
            Random rand = new Random();

            int n = 1000;
            double approxValue;
            double error;

            do
            {
                approxValue = MonteCarloIntegration(n, rand);
                error = Math.Abs(approxValue - exactValue);
                n *= 2;
            }
            while (error > eps);

            Console.WriteLine("Analityczna wartość całki: {0}", exactValue);
            Console.WriteLine("Wartość całki obliczona metodą Monte Carlo: {0}", approxValue);
            Console.WriteLine("Liczba próbek: {0}", n);
            Console.WriteLine("Błąd: {0}", error);
        }
    }
}
