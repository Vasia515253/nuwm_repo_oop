using System;

namespace NuwmRepoOop
{
    /// <summary>
    /// Клас, який моделює геометричну прогресію з першим членом <c>a1</c>, знаменником <c>q</c> та кількістю членів <c>n</c>.
    /// </summary>
    public class GeometricProgression
    {
        /// <summary>Перший член прогресії.</summary>
        public double A1 { get; }

        /// <summary>Знаменник прогресії.</summary>
        public double Q { get; }

        /// <summary>Кількість членів (повинна бути >= 1).</summary>
        public int N { get; }

        /// <summary>
        /// Створює нову геометричну прогресію.
        /// </summary>
        /// <param name="a1">Перший член.</param>
        /// <param name="q">Знаменник (може бути будь-яким дійсним числом).</param>
        /// <param name="n">Кількість членів (повинна бути >= 1).</param>
        public GeometricProgression(double a1, double q, int n)
        {
            if (n < 1) throw new ArgumentOutOfRangeException(nameof(n), "Кількість членів має бути принаймні 1.");
            A1 = a1;
            Q = q;
            N = n;
        }

        /// <summary>Повертає k-й член прогресії (1-based).</summary>
        public double GetTerm(int k)
        {
            if (k < 1 || k > N) throw new ArgumentOutOfRangeException(nameof(k));
            return A1 * Math.Pow(Q, k - 1);
        }

        /// <summary>Повертає останній (n-й) член.</summary>
        public double GetLastTerm() => GetTerm(N);

        /// <summary>Повертає найбільший член серед усіх n членів (за стандартним порядком для double).</summary>
        public double GetMaxTerm()
        {
            double max = double.NegativeInfinity;
            for (int k = 1; k <= N; k++)
            {
                double t = GetTerm(k);
                if (t > max) max = t;
            }
            return max;
        }

        /// <summary>
        /// Визначає, чи є останній член найбільшим серед усіх членів прогресії.
        /// Повертає true, якщо останній член є максимальним (з невеликою дозволеною похибкою для double).
        /// </summary>
        public bool IsLastLargest()
        {
            double last = GetLastTerm();
            // адаптивний eps, щоб коректно порівнювати числа різного масштабу
            double eps = 1e-12 * Math.Max(1.0, Math.Abs(last));
            for (int k = 1; k <= N; k++)
            {
                double t = GetTerm(k);
                if (t > last + eps) return false; // знайшли член, який строго більший за останній
            }
            return true;
        }
    }
}
