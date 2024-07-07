using Projekt.Tasks;

namespace Projekt
{
    class Program
    {
        static void Main(string[] args)
        {
            bool loop = true;
            
            Console.Clear();
            Console.WriteLine(
                            "Witaj w programie zaliczeniowym przedmiot Metody numeryczne.\n\n" +
                            "Możesz wybrać dowolne zadnie i podpunkt, żeby sprawdzić \n" +
                            "poprawność działać.\n"
            );
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Zapraszam do programu!!!");
            Console.ReadKey();
            Console.Clear();

            do
            {
                Console.WriteLine(
                    "Wybierz opcje\n"+
                    "1 - Zadanie 6.1\n"+
                    "2 - Zadanie 6.2\n"+
                    "3 - Zadanie 6.3\n"+
                    "4 - Zadanie 6.4\n"+
                    "0 - WYJDŹ"
                );

                ConsoleKeyInfo input = Console.ReadKey();
                switch(input.Key)
                {
                    case ConsoleKey.D1:
                        showTask3();
                        break;
                    case ConsoleKey.D2:
                        showTask2();
                        break;
                    case ConsoleKey.D3:
                        showTask3();
                        break;
                    case ConsoleKey.D4:
                        showTask3();
                        break;
                    case ConsoleKey.D0:
                        loop = false;
                        break;
                    default:
                        break;
                }
            } while (loop);
        }

        public static void showTask2()
        {
            Console.Clear();
            Task2.Equation();
            Console.ReadKey();
            Console.Clear();
        }

        public static void showTask3()
        {
            bool loop = false;
            do
            {
                Console.Clear();
                Console.WriteLine(
                    "Wybierz podpunkt\n\n" +
                    "1 - Podpunkt A\n" +
                    "2 - Podpunkt B\n" +
                    "3 - Podpunkt C\n" +
                    "0 - WYJDŹ"
                );
                double a = 1;
                double b = 5;
                ConsoleKeyInfo input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        double equation = Task3.Equation(a, b);
                        Console.WriteLine($"Pierwiastek równania: {equation}");

                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        double eps = 0.0001;
                        Task3.Bisect(a, b, eps);

                        break;
                    case ConsoleKey.D3:
                        Console.WriteLine("Obliczenia i podsumawnie programu w sprawozdaniu");
                        break;
                    case ConsoleKey.D0:
                        break;
                    default:
                        loop = false;
                        break;
                }
            } while (loop);
            Console.ReadKey();
            Console.Clear();
        }
    }
}