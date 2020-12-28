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
        /// <summary>
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
                count++;
                if(st)
                    break;
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
                count++;
            }
            return count;
        }
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
                //Console.WriteLine($"Итерация №: {left - 1}");
            }
        }
        #endregion        
        static void Main(string[] args)
        {
            Console.Write("Введите разсерность массива: ");
            int size = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int [size];
            int[] arra = new int[size];
            int[] arrb = new int[size];
            Random rnd = new Random();
            for(int i = 0; i < size; i++)
            {
                arr[i] = rnd.Next(1, 100);
                arra[i] = rnd.Next(1, 100);
                arrb[i] = rnd.Next(1, 100);
            }            
            Console.WriteLine();
            MySortShaekr(arr, size);
            int a = MySortBoul(arra, size);
            int b = MySortBoulV2(arrb, size);
            Console.WriteLine("Массив после сортировки Шейкерным методом:");
            for (int i = 0; i < size; i++)
                Console.Write($"{arr[i]} ");
            Console.WriteLine("\nМассив после сортировки пузырьком:");
            for (int i = 0; i < size; i++)
                Console.Write($"{arra[i]} ");
            Console.WriteLine($"\nКоличество итераций для сортировки обычным пузырьком: {a}");
            Console.WriteLine("\nМассив после сортировки улучшенным пузырьком:");
            for (int i = 0; i < size; i++)
                Console.Write($"{arrb[i]} ");
            Console.WriteLine($"\nКоличество итераций для сортировки улучшенным пузырьком: {b}");
            Console.WriteLine($"На сколько итераций отличается Улучшенный Пузырёк от Обычного: {a - b}");
            Console.ReadKey();
        }
    }
}
