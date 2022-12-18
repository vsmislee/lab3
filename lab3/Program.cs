using System;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DArray firstarr;
                DArray secondarr;
                DArray thirdarr;

                Console.WriteLine("Задание 1.");
                Console.WriteLine();
                Console.WriteLine("Первый массив: ");
                firstarr = new DArray();
                Console.WriteLine(firstarr);

                Console.WriteLine("Второй массив: ");
                Console.WriteLine("Введите n: ");
                int n = int.Parse(Console.ReadLine());
                secondarr = new DArray(n);
                Console.WriteLine(secondarr);

                Console.WriteLine("Третий массив: ");
                Console.WriteLine("Введите n: ");
                n = int.Parse(Console.ReadLine());
                thirdarr = new DArray(n, true);
                Console.WriteLine(thirdarr);



                Console.WriteLine();
                Console.WriteLine("Задание 2.");
                firstarr = new DArray();
                Console.WriteLine("Исходный массив: ");
                Console.WriteLine(firstarr);
                Console.WriteLine();
                firstarr.Permutation();
                Console.WriteLine();
                Console.WriteLine("Результат: ");
                Console.WriteLine(firstarr);



                Console.WriteLine();
                Console.WriteLine("Задание 3.");
                Console.WriteLine("Первый массив: ");
                firstarr = new DArray();
                Console.WriteLine();
                Console.WriteLine("Второй массив: ");
                secondarr = new DArray();
                Console.WriteLine();
                Console.WriteLine("Третий массив: ");
                thirdarr = new DArray();
                DArray res = (firstarr + secondarr) * thirdarr;

                Console.WriteLine();
                Console.WriteLine("(A + B) * C");
                Console.WriteLine();
                Console.WriteLine("Первый массив: ");
                Console.WriteLine(firstarr);
                Console.WriteLine("Второй массив: ");
                Console.WriteLine(secondarr);
                Console.WriteLine("Третий массив: ");
                Console.WriteLine(thirdarr);
                Console.WriteLine("Результат: ");
                Console.WriteLine(res);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
