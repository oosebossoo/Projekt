namespace Projekt.Tasks
{
    
    public static class Task1
    {
        public static void Equation()
        {
            List<double> xData = new List<double> { -1, 0, 1, 2 };
            List<double> yData = new List<double> { 1, 0, 1, 6 };

            double[] coefficients = CalculateQuadraticLeastSquares(xData, yData);

            double a = coefficients[0];
            double b = coefficients[1];
            double c = coefficients[2];

            Console.WriteLine("Wyznaczone współczynniki:");
            Console.WriteLine($"a = {a}");
            Console.WriteLine($"b = {b}");
            Console.WriteLine($"c = {c}");

            Console.WriteLine("\nTablicowanie funkcji F(x) = ax^2 + bx + c:");
            double step = 0.2;
            for (double x = -1; x <= 2; x += step)
            {
                double y = a * x * x + b * x + c;
                Console.WriteLine($"F({x:F1}) = {y:F4}");
            }
        }

        static double[] CalculateQuadraticLeastSquares(List<double> xData, List<double> yData)
        {
            int n = xData.Count;

            double sumX = xData.Sum();
            double sumX2 = xData.Sum(x => x * x);
            double sumX3 = xData.Sum(x => x * x * x);
            double sumX4 = xData.Sum(x => x * x * x * x);
            double sumY = yData.Sum();
            double sumXY = xData.Zip(yData, (x, y) => x * y).Sum();
            double sumX2Y = xData.Zip(yData, (x, y) => x * x * y).Sum();

            double[,] A = new double[3, 3];
            double[] B = new double[3];

            A[0, 0] = n;
            A[0, 1] = sumX;
            A[0, 2] = sumX2;
            A[1, 0] = sumX;
            A[1, 1] = sumX2;
            A[1, 2] = sumX3;
            A[2, 0] = sumX2;
            A[2, 1] = sumX3;
            A[2, 2] = sumX4;

            B[0] = sumY;
            B[1] = sumXY;
            B[2] = sumX2Y;

            double[] coefficients = GaussianElimination(A, B);

            return coefficients;
        }

        static double[] GaussianElimination(double[,] A, double[] B)
        {
            int n = B.Length;
            double[] X = new double[n];

            for (int i = 0; i < n; i++)
            {
                int max = i;
                for (int k = i + 1; k < n; k++)
                {
                    if (Math.Abs(A[k, i]) > Math.Abs(A[max, i]))
                    {
                        max = k;
                    }
                }

                for (int k = i; k < n; k++)
                {
                    double tmp = A[max, k];
                    A[max, k] = A[i, k];
                    A[i, k] = tmp;
                }
                {
                    double tmp = B[max];
                    B[max] = B[i];
                    B[i] = tmp;
                }

                for (int k = i + 1; k < n; k++)
                {
                    double factor = A[k, i] / A[i, i];
                    B[k] -= factor * B[i];
                    for (int j = i; j < n; j++)
                    {
                        A[k, j] -= factor * A[i, j];
                    }
                }
            }

            for (int i = n - 1; i >= 0; i--)
            {
                double sum = 0;
                for (int j = i + 1; j < n; j++)
                {
                    sum += A[i, j] * X[j];
                }
                X[i] = (B[i] - sum) / A[i, i];
            }

            return X;
        }
    }
}
