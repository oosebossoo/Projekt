using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Tasks
{
    public class Task3
    {
        /**
         * Zadanie 6.3
         */

        public static double Function(double x)
        {
            return Math.Log(x) + Math.Exp(0.5 * x) - 4;
        }

        public static double Equation(double a, double b)
        {
            Console.Clear();
            Console.WriteLine("Schemat blokowy równanie\n");
            Console.Write(
                "+---------------------------------+\n" +
                "|     Start                       |\n" +
                "+---------------------------------+\n" +
                "| Wybierz przedział [a,b]         |\n" +
                "+---------------------------------+\n" +
                "| Sprawdź warunek z epsilonem:    |\n" +
                "| |b - a| < epsilon?              |\n" +
                "+---------------------------------+\n" +
                "| ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Tak");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(
                "-> Koniec (c = pierwiastek) |\n" +
                "| ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Nie");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(
                "                             |\n" +
                "+---------------------------------+\n" +
                "| Oblicz c = (a + b) / 2          |\n" +
                "+---------------------------------+\n" +
                "| Oblicz f(a), f(b), f(c)         |\n" +
                "+---------------------------------+\n" +
                "| Sprawdź f(a) * f(c) < 0?        |\n" +
                "+---------------------------------+\n" +
                "| ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Tak");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(
                " -> b = c                    |\n" +
                "| ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Nie");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(
                " -> a = c                    |\n" +
                "+---------------------------------+\n" +
                "| Wróć do sprawdzenia             |\n" +
                "| warunku epsilonem               |\n" +
                "+---------------------------------+"
            );

            Console.WriteLine("\n\n" +
                "Działanie zaprezentowanego programu:\n");
            double epsilon = 1e-6;
            double c = 0;

            while ((b - a) > epsilon)
            {
                c = (a + b) / 2;
                if (Task3.Function(a) * Task3.Function(c) < 0)
                {
                    b = c;
                }
                else
                {
                    a = c;
                }
            }

            return c;
        }

        public static void Bisect(double a, double b, double eps)
        {
            double epsilon = 0.0001;
            double c = 0;
            int iteration = 0;

            Console.WriteLine("Iteracja\t a\t\t b\t\t c\t\t f(c)");

            while (true)
            {
                c = (a + b) / 2;
                double fc = Function(c);
                iteration++;

                Console.WriteLine($"{iteration}\t {a:F6}\t {b:F6}\t {c:F6}\t {fc:F6}");

                if (Math.Abs(fc) <= epsilon)
                {
                    break;
                }

                if (Function(a) * fc < 0)
                {
                    b = c;
                }
                else
                {
                    a = c;
                }
            }
            Console.WriteLine("Pierwiastek równania: " + c);
        }

        /**
         * Zadanie 6.2
         */
        
    }
}
