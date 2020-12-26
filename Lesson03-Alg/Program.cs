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
        /// <summary>
        /// Функция для обмена значений элементов массива для Пузырькового метода
        /// </summary>
        /// <param name="arr"> Массив на вход</param>
        /// <param name="i"> Индекс элемента</param>
        static void MySwap1(int [] arr, int i, int j)
        {
            int buff = arr[i];
            arr[i] = arr[j];
            arr[j] = buff;
        }
        /// <summary>
        /// Функция для обмена значений элементов массива для Шейкерного метода
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="i"></param>
        static void MySwap (int [] arr, int i)
        {
            int buff;
            buff = arr[i];
            arr[i] = arr[i - 1];
            arr[i - 1] = buff;
        }

         static void MySortBoulV2(int [] arr, int size)
        {
            for(int i = 0; i < size; i++)
            {
                int min = i;
                for(int j = i; j < size - 1 - i; j++)
                {
                    bool st = false;
                    if (arr[j] > arr[j + 1])
                    {
                        int buff = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = buff;
                        st = true;
                    }
                    if (arr[j] < arr[min])
                        min = j;
                    if (min != i)
                    {
                        int buff = arr[i];
                        arr[i] = arr[min];
                        arr[min] = buff;
                    }                    
                }
                Console.WriteLine($"Итерация №: {i + 1}");
            }
        }
        /// <summary>
        /// Функция для сортировки массива Пузырьковым методом 
        /// </summary>
        /// <param name="arr"> Массив на вход</param>
        /// <param name="size"> Размер Массива</param>
        static void MySortBoul(int[] arr, int size)
        {
            for(int i = 0; i < size; i++)
            {
                for(int j = i+1; j < size; j++)
                {
                    if (arr[j] < arr[i]) MySwap1(arr, i, j);
                }
                Console.WriteLine($"Итерация №: {i + 1}");
            }
        }
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
                    if (arr[i - 1] > arr[i]) MySwap(arr, i);
                left++;
                for(int i = left; i <= right; i++)
                {
                    if (arr[i - 1] > arr[i])
                        MySwap(arr, i);                    
                }
                right--;
                Console.WriteLine($"Итерация №: {left - 1}");
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
            Console.WriteLine();
            MySortShaekr(arr, 10);
            Console.WriteLine("Массив после сортировки");
            for (int i = 0; i < 10; i++)
                Console.Write($"{arr[i]} ");


            Console.WriteLine();
            for (int i = 0; i < 10; i++)
            {
                arr[i] = rnd.Next(1, 100);
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine();
            MySortBoul(arr, 10);
            Console.WriteLine("Массив после сортировки");
            for (int i = 0; i < 10; i++)
                Console.Write($"{arr[i]} ");

            Console.WriteLine();
            for (int i = 0; i < 10; i++)
            {
                arr[i] = rnd.Next(1, 100);
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine();
            MySortBoulV2(arr, 10);
            Console.WriteLine("Массив после сортировки");
            for (int i = 0; i < 10; i++)
                Console.Write($"{arr[i]} ");
            Console.ReadKey();
        }
    }
}
