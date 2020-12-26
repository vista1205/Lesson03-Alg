using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson03_Alg
{
    class Program
    {
        #region Функция для обмена значений элементов массива Общая часть для 1 и 2 задания
        /// <summary>
        /// Функция для обмена значений элементов массива Общая часть для 1 и 2 задания
        /// </summary>
        /// <param name="arr"> Массив на вход</param>
        /// <param name="i"> Первый элемент</param>
        /// <param name="j"> Второй элемент</param>
        static void MySwap(int [] arr, int i, int j)
        {
            int buff = arr[i];
            arr[i] = arr[j];
            arr[j] = buff;
        }
        #endregion
        #region Попробовать оптимизировать пузырьковую сортировку. Сравнить количество операций сравнения оптимизированной и не оптимизированной программы.Написать функции сортировки, которые возвращают количество операций
        /*/// <summary>
        /// Улучшенная пузырьковая сортировка
        /// </summary>
        /// <param name="arr"> Массив на вход</param>
        /// <param name="size"> Размер Массива</param>
        /// <returns>Возвращается число итераций</returns>
        static int MySortBoulV2(int [] arr, int size)
        {
            int count = 0;
            for(int i = 0; i < size; i++)
            {
                bool st = true;
                for(int j = 0; j < size - 1 - i; j++)
                {
                    if(arr[j]>arr[j+1])
                    {
                        st = false;
                        MySwap(arr, j,j+1);
                    }
                }
                Console.WriteLine($"Итерация №: {i + 1}");
                if(st)
                    break;
                count++;
            }
            return count;
        }
        /// <summary>
        /// Функция для сортировки массива Пузырьковым методом 
        /// </summary>
        /// <param name="arr"> Массив на вход</param>
        /// <param name="size"> Размер Массива</param>
        /// <returns>Возвращается число итераций</returns>
        static int MySortBoul(int[] arr, int size)
        {
            int count = 0;
            for(int i = 0; i < size; i++)
            {
                for(int j = i+1; j < size; j++)
                {
                    if (arr[j] < arr[i]) MySwap(arr,i,j);
                }
                Console.WriteLine($"Итерация №: {i + 1}");
                count++;
            }
            return count;
        }*/
        #endregion
        #region *Реализовать шейкерную сортировку.
        /// <summary>
        /// Функция для сортировки массива Шейкерным методом 
        /// </summary>
        /// <param name="arr"> Массив на вход</param>
        /// <param name="size"> Размер массива</param>
        static void MySortShaekr(int [] arr, int size)
        {
            int left = 1;
            int right = size - 1;
            while (left <= right)
            {
                for (int i = right; i >= left; i--)
                    if (arr[i - 1] > arr[i]) MySwap(arr, i-1,i);
                left++;
                for(int i = left; i <= right; i++)
                {
                    if (arr[i - 1] > arr[i])
                        MySwap(arr, i-1,i);                    
                }
                right--;
                Console.WriteLine($"Итерация №: {left - 1}");
            }
        }
        #endregion
        class BubbleSort
        {
            public BubbleSort()
            {

            }
            public static int BubbleSortV1(int [] arr, int size)
            {
                int count = 0;
                for(int i = 0; i < size; i++)
                {
                    for(int j = i+1; j < size; j++)
                    {
                        if (arr[j] < arr[i])
                            MySwap(arr, i, j);
                    }
                    count++;
                    Console.WriteLine($"Итерация №: {count}");
                }
                return count;
            }
            public static int BubbleSortV2(int[] arr, int size)
            {
                int count = 0;
                for (int i = 0; i < size; i++)
                {
                    bool st = true;
                    for (int j = 0; j < size - 1 - i; j++)
                    {
                        if (arr[j] > arr[j + 1])
                        {
                            st = false;
                            MySwap(arr, j, j + 1);
                        }
                    }
                    Console.WriteLine($"Итерация №: {i + 1}");
                    if (st)
                        break;
                    count++;                    
                }
                return count;
            }
        }
        static void Main(string[] args)
        {
            int[] arr = new int [10];
            Random rnd = new Random();
            for(int i = 0; i < 10; i++)
            {
                arr[i] = rnd.Next(1, 100);
                Console.Write($"{arr[i]} ");
            }
            int[] a = arr;
            int[] b = arr;
            Console.WriteLine();
            MySortShaekr(arr, 10);
            Console.WriteLine("Массив после сортировки");
            for (int i = 0; i < 10; i++)
                Console.Write($"{arr[i]} ");
            int ar = BubbleSort.BubbleSortV1(a, 10);
            int br = BubbleSort.BubbleSortV1(b, 10);
            Console.WriteLine("\nМассив после сортировки обычным пузырьком");
            for (int i = 0; i < 10; i++)
                Console.Write($"{a[i]} ");
            Console.WriteLine("\nМассив после сортировки улучшенным пузырьком");
            for (int i = 0; i < 10; i++)
                Console.Write($"{b[i]} ");

            Console.ReadKey();
        }
    }
}
