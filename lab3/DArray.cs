using System;
using System.Collections.Generic;
using System.Text;

namespace lab3
{
    class DArray
    {
        int[,] arr;

        public DArray(int n, int m)// конструктор для заполнения массива нулями
        {
            arr = new int[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    arr[i, j] = 0;
        }
        public DArray() // конструктор для заполнения массива с клавиатуры
        {
            Console.Write("Введите количество строк: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Введите количество столбцов: ");
            int m = int.Parse(Console.ReadLine());

            arr = new int[n, m];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("Введите элемент: ");
                    arr[j, i] = int.Parse(Console.ReadLine());
                }
            }
        }

        public DArray(int n) // конструктор для заполнения трехзначными случайными числами, составленными из возрастающих цифр
        {
            this.arr = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    this.arr[i, j] = this.MakeElem();
                }
            }
        }

        public DArray(int n, bool notused) // конструктор для заполнения массива по образцу из задания
        {
            this.arr = new int[n, n];
            int number = 1;

            for (int i = n - 1; i >= 0; i--)
            {
                if (i % 2 == 0)
                    for (int j = n - 1; j >= 0; j--)
                        arr[j, i] = number++;
                else
                    for (int j = 0; j < n; j++)
                        arr[j, i] = number++;
            }
        }

        public int[,] Arr
        {
            get { return this.arr; }
        }

        private int MakeElem() // метод для создания трёхзначного числа, состоящего из возрастающих цифр
        {
            Random rnd = new Random();

            int first = rnd.Next(1, 10);
            int second = this.MakeNextNumber(first, rnd);
            int third = this.MakeNextNumber(second, rnd);

            string result = first.ToString() + second.ToString() + third.ToString();
            return int.Parse(result);
        }

        private int MakeNextNumber(int first, Random rnd) // метод, возвращающий число больше, чем число переданное параметром, от 2 до 9
        {
            int next;

            switch (first)
            {
                case 1:
                    next = rnd.Next(2, 9);
                    break;
                case 2:
                    next = rnd.Next(3, 9);
                    break;
                case 3:
                    next = rnd.Next(4, 9);
                    break;
                case 4:
                    next = rnd.Next(5, 9);
                    break;
                case 5:
                    next = rnd.Next(6, 9);
                    break;
                case 6:
                    next = rnd.Next(7, 9);
                    break;
                case 7:
                    next = rnd.Next(8, 9);
                    break;
                case 8:
                    next = 9;
                    break;
                case 9:
                    next = 9;
                    break;
                default:
                    next = 0;
                    break;
            }
            return next;
        }


        public override string ToString() // перегрузка метода ToString
        {
            int rows = this.arr.GetLength(0);
            int columns = this.arr.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                    Console.Write(String.Format("{0,4}", arr[i, j]));
                Console.WriteLine();
            }
            return null;
        }

        public static DArray operator +(DArray A, DArray B) // перегрузка оператора + для соложения матриц
        {
            int rowsA = A.arr.GetLength(0);
            int columnsA = A.arr.GetLength(1);
            int rowsB = B.arr.GetLength(0);
            int columnsB = B.arr.GetLength(1);
            if (rowsA != rowsB || columnsA != columnsB)
                throw new Exception("Ошибка! Матрицы имеют разный размер!");

            DArray result = new DArray(rowsA, columnsA);

            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < columnsA; j++)
                    result.arr[i, j] = A.arr[i, j] + B.arr[i, j];
            }
            return result;
        }

        public static DArray operator *(DArray A, DArray B) // перегрузка оператора * для произведения матриц
        {
            int rowsA = A.arr.GetLength(0);
            int columnsA = A.arr.GetLength(1);
            int rowsB = B.arr.GetLength(0);
            int columnsB = B.arr.GetLength(1);
            if (columnsA != rowsB)
                throw new Exception("Ошибка! Матрицы имеют разный размер!");

            DArray result = new DArray(rowsA, columnsB);

            for (int i = 0; i < rowsA; i++)
                for (int j = 0; j < columnsB; j++)
                    for (int k = 0; k < rowsB; k++)
                        result.arr[i, j] += A.arr[i, k] * B.arr[k, j];
   
            return result;
        }

        public void Permutation() // делит на подмассивы и переставляет в них элементы
        {
            int rows = this.arr.GetLength(0);
            int columns = this.arr.GetLength(1);

            if (rows != columns)
                throw new Exception("Ошибка! Массив не квадратный!");

            int begRows = 0;
            int endRows = rows - 1;
            int begCol = 1;
            int endCol = columns;

            int step = 1;
            do
            {
                do
                {
                    int n = endRows - begRows;
                    DArray subarray = new DArray(n, n);

                    for (int i = begRows, k = 0; i < endRows; i++, k++)//копируем часть основного массива в подмассив
                        for (int j = begCol, l = 0; j < endCol; j++, l++)
                            subarray.arr[k, l] = this.arr[i, j];

                    subarray.Swap();

                    for (int i = begRows, k = 0; i < endRows; i++, k++)//копируем содержимое подмассива в основной массив
                        for (int j = begCol, l = 0; j < endCol; j++, l++)
                            this.arr[i, j] = subarray.arr[k, l];

                    Console.WriteLine(subarray);

                    begRows++; endRows++; // сдвигаемся по строкам вниз
                    begCol--; endCol--; // по столбцам влево
                } while (endRows <= rows || begCol >= 0);

                begRows = 0;
                endRows = rows - 1 - step;
                begCol = 1 + step;
                endCol = columns;

                step++;
            } while ((endCol - begCol) >= 2);
        }

        private void Swap() // перемещает наибольший элемент в правый верхний угол массива
        {
            IndexOfElement maxElemIndex = this.MaxElemIndex();
            int upperRow = 0;
            int righterCol = this.arr.GetLength(1) - 1;
            this.SwapRow(maxElemIndex.Row, upperRow);
            this.SwapColumn(maxElemIndex.Col, righterCol);
        }
        private void SwapColumn(int i, int j) // меняю i-й столбец с j-м
        {
            if (i == j) return;

            int[] tmpArr = new int[this.arr.GetLength(1)];

            for (int k = 0; k < this.arr.GetLength(0); k++)// запоминаем j столбец
                tmpArr[k] = this.arr[k, j]; 
            for (int k = 0; k < this.arr.GetLength(0); k++) // копируем i столбец в j
                this.arr[k, j] = this.arr[k, i];
            for (int k = 0; k < this.arr.GetLength(0); k++) // копируем элементы из временного массива в столбец i
                this.arr[k, i] = tmpArr[k];
        }

        private void SwapRow(int i, int j) // меняю i-ю строку с j-ой
        {
            if (i == j) return;

            int[] tmpArr = new int[this.arr.GetLength(0)];

            for (int k = 0; k < this.arr.GetLength(1); k++) // запоминаю j строку
                tmpArr[k] = this.arr[j, k];
            for (int k = 0; k < this.arr.GetLength(1); k++) // копируем i строку в j
                this.arr[j, k] = this.arr[i, k];
            for (int k = 0; k < this.arr.GetLength(1); k++) // копируем элементы из временного массива в i строку
                this.arr[i, k] = tmpArr[k];
        }

        public int Max() // возврщает наибольший элемент в массиве
        {
            int max = int.MinValue;
            foreach (int item in this.arr)
            {
                if (max < item)
                    max = item;
            }
            return max;
        }

        private IndexOfElement MaxElemIndex() // возврщает индекс наибольшего элемента в массиве
        {
            int maxelem = this.Max();

            for (int i = 0; i < this.arr.GetLength(0); i++)
                for (int j = 0; j < this.arr.GetLength(1); j++)
                    if (this.arr[i, j] == maxelem)
                        return new IndexOfElement(i, j);
            return new IndexOfElement(-1, -1);
        }
    }
}
