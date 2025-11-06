using System;
using NuwmRepoOop;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        var examples = new[]
        {
            new GeometricProgression(2, 3, 4),      // 2,6,18,54 -> останній найбільший
            new GeometricProgression(16, 0.5, 4),   // 16,8,4,2 -> останній НЕ найбільший
            new GeometricProgression(-1, -2, 4),    // -1,2,-4,8 -> останній найбільший
            new GeometricProgression(-1, 2, 3),     // -1, -2, -4 -> останній НЕ найбільший
            new GeometricProgression(0, 5, 5),      // 0,0,0,0,0 -> останній найбільший (усі рівні)
        };

        for (int i = 0; i < examples.Length; i++)
        {
            var g = examples[i];
            Console.WriteLine($"Приклад {i + 1}: a1={g.A1}, q={g.Q}, n={g.N}");
            Console.WriteLine("Члени: ");
            for (int k = 1; k <= g.N; k++)
            {
                Console.Write($"{g.GetTerm(k)}");
                if (k < g.N) Console.Write(", ");
            }
            Console.WriteLine();
            Console.WriteLine($"Останній член: {g.GetLastTerm()}");
            Console.WriteLine($"Найбільший член: {g.GetMaxTerm()}");
            Console.WriteLine($"Чи останній є найбільшим? {g.IsLastLargest()}\n");
        }

        Console.WriteLine("Готово. Натисніть Enter для виходу.");
        Console.ReadLine();
    }
}
