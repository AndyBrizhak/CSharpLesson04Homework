using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
// Брижак Андрей
//Домашнее задание к уроку 4

//1. Дан целочисленный массив из 20 элементов.Элементы массива могут принимать целые
//значения от –10 000 до 10 000 включительно.Написать программу, позволяющую найти и
//вывести количество пар элементов массива, в которых хотя бы одно число делится на 3. В
//данной задаче под парой подразумевается два подряд идущих элемента массива.Например,
//для массива из пяти элементов: 6; 2; 9; –3; 6 – ответ: 4.
//2. а) Дописать класс для работы с одномерным массивом.Реализовать конструктор, создающий
//массив заданной размерности и заполняющий массив числами от начального значения с
//заданным шагом.Создать свойство Sum, которые возвращают сумму элементов массива, метод
//Inverse, меняющий знаки у всех элементов массива, Метод Multi, умножающий каждый элемент
//массива на определенное число, свойство MaxCount, возвращающее количество максимальных
//элементов.В Main продемонстрировать работу класса.
//б)* Добавить конструктор и методы, которые загружают данные из файла и записывают данные в
// файл.
// 3. Решить задачу с логинами из предыдущего урока, только логины и пароли считать из файла в
// массив.
// 4. *а) Реализовать класс для работы с двумерным массивом.Реализовать конструктор,
// заполняющий массив случайными числами.Создать методы, которые возвращают сумму всех
//элементов массива, сумму всех элементов массива больше заданного, свойство, возвращающее
//минимальный элемент массива, свойство, возвращающее максимальный элемент массива,
//метод, возвращающий номер максимального элемента массива(через параметры, используя
//модификатор ref или out)
//** б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные
// в файл.

namespace Lesson04Homework
{
    class Program
    {
        static void Task1()
        {
            int[] arraytask1;     // создание массива
            int n = 20;
            int min = -10000;
            int max = 10000;
            arraytask1 = new int[n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                arraytask1[i] = rnd.Next(min, max);
                Console.WriteLine(arraytask1[i]);
            }
            //вывести количество пар элементов массива, в которых хотя бы одно число делится на 3
            int count = 0;
            for (int i = 0; i < (arraytask1.Length-1); i++)
            {
                if ((arraytask1[i] % 3 ==0) || (arraytask1[i+1] % 3 ==0))
                {
                    count ++;
                }
            }
            Console.WriteLine(count);
            Console.ReadKey();

        }
        // нужно дописать в классе OneDimAr
        //static void Inv(int[] a)
        //{
        //    for (int i = 0; i < a.Length; i++)
        //        a[i] = -a[i];
        //}

        static void Task2()
          {
            int n = 30;
            int init = 1;
            int step = 3;
           
            OneDimAr arraytask2 =  new OneDimAr(n, init, step);// создаем массив заданной размерности

            Console.WriteLine(arraytask2.ToString());
            Console.WriteLine("Sum");
            Console.WriteLine(arraytask2.Sum);   // демонстрируем свойство Sum
            Console.ReadKey();

            Console.WriteLine(arraytask2.ToString());
            Console.WriteLine("CountMax");
            Console.WriteLine(arraytask2.CountMax);   // демонстрируем свойство CountMax
            Console.ReadKey();

            arraytask2.Inv();
            Console.WriteLine("Inv");// Inv
            Console.WriteLine(arraytask2.ToString());
            Console.ReadKey();

            arraytask2.Multi(2);
            Console.WriteLine("Multi");// multi
            Console.WriteLine(arraytask2.ToString());
            Console.ReadKey();

        }

        //3. Решить задачу с логинами из предыдущего урока, только логины и пароли считать из файла в
        // массив.
        static void Task3()
        {
            
            string log = "*";
            string pas = "*";
            
            
            StreamReader sr = new StreamReader("C:\\Users\\Andy\\Google Диск\\GeekBrains\\GeekBrains\\Lesson04Homework\\ident.txt");
            // Считаем количество cлов.
            int n = int.Parse(sr.ReadLine());
            string truelog = sr.ReadLine();
            //Console.WriteLine(truelog);
            string truepas = sr.ReadLine();
            //Console.WriteLine(truepas);
            // Освобождаем файл data.txt для использования другими программами.
            sr.Close();

            int i = 0;
            do
            {
                Console.WriteLine("Введите логин:");
                log = Console.ReadLine();
                Console.WriteLine("Введите пароль:");
                pas = Console.ReadLine();
                if ((log == truelog) && (pas == truepas))
                {
                    Console.WriteLine("Ok:");
                    Console.ReadKey();
                    break;
                }
                i++;
            }
            while (i < 3);

            Console.WriteLine("Bye");
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("1 - Task 1");
            Console.WriteLine("2 - Task 2");
            Console.WriteLine("3 - Task 3");
            Console.WriteLine("0 - Exit");
            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    Console.WriteLine();
                    Task1();
                    break;
                case ConsoleKey.D2:
                    Console.WriteLine();
                    Task2();
                    break;
                case ConsoleKey.D3:
                    Console.WriteLine();
                    Task3();
                    break;
                case ConsoleKey.D0:
                case ConsoleKey.Escape:
                    Console.WriteLine("Bye-bye");
                    return;
                default:
                    break;

            }
        }

    }
}
