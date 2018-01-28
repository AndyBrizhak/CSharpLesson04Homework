using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lesson04Homework
{
    class OneDimAr
    {

        private int[] a;

        //public OneDimAr(int n)
        //{
        //    a = new int[n];
        //    for (int i = 0; i < a.Length; i++) a[i] = 0;
        //}

        /// <summary>
        /// конструктор, создающий
        ///массив заданной размерности n и заполняющий массив числами от начального значения init с
        ///заданным шагом step
        /// </summary>
        /// <param name="n"></param>
        /// <param name="init"></param>
        /// <param name="step"></param>
        public OneDimAr(int n, int init, int step)
        {
            a = new int[n];
            for (int i = 0, q = init; i < a.Length; i++, q += step) a[i] = q;
        }

        public OneDimAr(int n, int max)
        {
            Random random = new Random();
            a = new int[n];
            for (int i = 0; i < a.Length; i++) a[i] = random.Next(0, max + 1);
        }

        /// <summary>
        /// метод Inverse
        /// </summary>
        public void Inv()
        {
            for (int i = 0; i < this.a.Length; i++)
              a[i] *= (-1);
         }

        /// <summary>
        /// Метод Multi, умножающий каждый элемент
        /// </summary>
        /// <param name="m"></param>
        public void Multi (int m)  //Метод Multi, умножающий каждый элемент
        {
          for (int i = 0; i < this.a.Length; i++)
                this.a[i] *= m ;
         }

        /// <summary>
        /// подсчет количества максимальных значений массива
        /// </summary>
        public int CountMax
        {
            get
            {
                int count = 0;
                int max = a[0];
                for (int i = 0; i < a.Length; i++) // находим значение max
                    if (a[i] > max) max = a[i];
                for (int i = 0; i < a.Length; i++)
                    if (a[i] == max) count++;   // если текущее значение == max увеличиваем счетчик
                return count;
            }
        }

        public void PrintConsole()
        {
            foreach (int el in a)
                Console.Write("{0,4}", el);
        }

        public int Max
        {
            get
            {
                //int max = a[0];
                //for (int i = 1; i < a.Length; i++)
                //    if (a[i]>max) max = a[i];
                //return max;

                return a.Max();//Linq!!!
            }
        }



        /// <summary>
        /// возвращаeт сумму элементов массива
        /// </summary>
        public int Sum
        {
            get
            {
                int sum = 0;
                for (int i = 0; i < (a.Length - 1); i++)
                {
                    sum = sum + a[i];
                }
                return sum;

             }
        }



        //public OneDimAr Copy()
        //{
        //    OneDimAr myArray = new OneDimAr(a.Length);
        //    a.CopyTo(myArray.a, 0);
        //    return myArray;

        //}

        //public void Sort()
        //{
        //    Array.Sort(a);
        //}

        //public OneDimAr Sort()
        //{
        //    OneDimAr copy = this.Copy();
        //    Array.Sort(copy.a);
        //    return copy;
        //}


        public override string ToString()
        {
            string s = "";
            foreach (int el in a) s = s + el.ToString() + " ";
            return s;
        }

        public void WriteToFile(string file)
        {

            StreamWriter streamWriter = null;
            try
            {
                streamWriter = new StreamWriter(file);
                streamWriter.WriteLine(a.Length);
                for (int i = 0; i < a.Length; i++)
                    streamWriter.WriteLine(a[i]);
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Не найден путь");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Не правильный аргумент");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (streamWriter != null) streamWriter.Close();
            }
        }


        public void ReadFromFile(string filename)
        {
            //string[] str=File.ReadAllLines(filename);
            //a = new int[str.Length - 1];
            //for (int i = 1; i < str.Length; i++)
            //    a[i - 1] = Convert.ToInt32(str[i]);
            StreamReader streamReader = new StreamReader(filename);
            int N = Convert.ToInt32(streamReader.ReadLine());
            a = new int[N];
            for (int i = 0; i < N; i++)
                a[i] = Convert.ToInt32(streamReader.ReadLine());
            streamReader.Close();
        }
    }


}

