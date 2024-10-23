using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите начало отрезка (a):");
        double a = double.Parse(Console.ReadLine());
        Console.WriteLine("Введите конец отрезка (b):");
        double b = double.Parse(Console.ReadLine());
        Console.WriteLine("Введите шаг (h):");
        double h = double.Parse(Console.ReadLine());

        if (h <= 0)
        {
            Console.WriteLine("Шаг h должен быть положительным числом");
            return;
        }
        if (a > b)
        {
            Console.WriteLine("Начальное значение a должно быть меньше или равно конечному значению b");
            return;
        }

        TabulateFunction(a, b, h);

    static void TabulateFunction(double a, double b, double h)
    {
        double maxY = double.MinValue;
        double minY = double.MaxValue;
        int crossCount = 0;
        double previosY = 0;
        Console.WriteLine("x\t\t|y(x)");
        Console.WriteLine("----------------------");

        for (double x = a; x <= b; x += h)
        {
            double y = Math.Cos(x * x) + Math.Cos(x * x);
            if (y > maxY) maxY = y;
            if (y < minY) minY = y;
            if (previosY * y < 0)
            {
                crossCount++;
            }
            previosY = y;

            Console.WriteLine($"{x:F4}\t|{y:F4}");
        }

        Console.WriteLine("\nмаксимальное значение функции: " + maxY.ToString("F4"));
        Console.WriteLine("Минимальное значение функции: " + minY.ToString("F4"));
        Console.WriteLine("Функция пересекает ось X: " + crossCount + " раз(a).");

    }
        int n = (int)((b - a) / h) + 1;
        List<(double x, double y)> results = new List<(double x, double y)>();

        double x = a;

        for (int i = 0; i < n; i++)
        {
            double y = Math.Cos(x * x) + Math.Sin(x * x);
            results.Add((x, y));
            x += h;
        }

        Console.WriteLine("---------------------------------");
        Console.WriteLine("|      x      |       y      |");
        Console.WriteLine("---------------------------------");

        foreach (var result in results)
        {
            Console.WriteLine($"|{result.x,9:F3}|{result.y,9:F3}");
        }    
        Console.WriteLine("---------------------------------");

        Console.WriteLine($"Количество точек в таблице: {n}");

        Console.ReadKey();
    }
}