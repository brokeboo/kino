using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kordamine
{
    class Program
    {
        static int Saali_suurus()
        {
            Console.WriteLine("Vali saali suurus: 1,2,3"); //Пользователь выбирает размер зала
            int suurus = int.Parse(Console.ReadLine());
            return suurus;
        }
        static int[,] saal = new int[,] { }; //ставит запятую между 
        static int[] ost = new int[] { }; //
        static int kohad, read, mitu, mitu_veel;
        static void Saali_taitmine(int suurus) //выбор ряда и места
        {
            Random rnd = new Random();
            if (suurus == 1) //если пользователь вводит маленький зал, то показывается 20 мест и 10 рядов
            { kohad = 20; read = 10; }
            else if (suurus == 2) //если пользователь вводит средний зал, то показывается 20 мест и 20 рядов
            { kohad = 20; read = 20; }
            else //если пользователь вводит большой зал, то показывается 30 мест и 20 рядов
            { kohad = 30; read = 20; }
            saal = new int[read, kohad];
            for (int rida = 0; rida < read; rida++) //рандомное заполнение массивов
            {
                for (int koht = 0; koht < kohad; koht++)
                {
                    saal[rida, koht] = rnd.Next(0, 2);
                }
            }
        }
        static void Saal_ekraanile()
        {
            Console.Write("     "); //вписывает нумирование мест
            for (int koht = 0; koht < kohad; koht++)
            {
                if (koht.ToString().Length == 2)
                { Console.Write(" {0}", koht + 1); }
                else //к каждому номеру добавляется +1 тем самым увеличивает число до тех пор пока не кончатся места в зале
                { Console.Write("  {0}", koht + 1); }
            }

            Console.WriteLine();
            for (int rida = 0; rida < read; rida++) //начинает выписывать места в зале
            {
                Console.Write("Rida " + (rida + 1).ToString() + ":"); // выписывает нумерование рядов
                for (int koht = 0; koht < kohad; koht++)
                {

                    Console.Write(saal[rida, koht] + "  ");
                }
                Console.WriteLine(); //пустая строка после окончания
            }
        }
        static void Muuk()
        {
            Console.WriteLine("Rida:"); //пользователь вводит желаем ряд
            int pileti_rida = int.Parse(Console.ReadLine());
            Console.WriteLine("Mitu piletid:"); //пользователь вводит желаемое кол во билетов
            mitu = int.Parse(Console.ReadLine());
            ost = new int[mitu]; //массив покупки билетов
            int p = (kohad - mitu) / 2; //ставит отсчет так, чтобы места, выбранные пользователем были в центре
            bool t = false;
            int k = 0; //счетчик 
            do
            {
                if (saal[pileti_rida, p] == 0) //если в зале на месте стоит "0" - значит оно свободно
                {
                    ost[k] = p; 
                    Console.WriteLine("koht {0} on vaba", p); //выводит на экран места, которые свободны(в выбранном ряду)
                    t = true;
                }
                else
                {
                    Console.WriteLine("koht {0} kinni", p); //выводит на экран места, которые заняты(в выбранном ряду)
                    t = false;
                    ost = new int[mitu];
                    k = 0;
                    p = (kohad - mitu) / 2;
                    break;
                }
                p = p + 1;
                k++;
            } while (mitu != k);
            if (t == true)
            {
                Console.WriteLine("Sinu kohad on:"); //выводит на экран выбранные места
                foreach (var koh in ost)
                {
                    Console.WriteLine("{0}\n", koh);
                }
            }
            else
            {
                Console.WriteLine("Selles reas ei ole vabu kohti. Kas tahad teises reas otsida?"); //пишет о том, что в выбранном ряду не достаточно свободных мест
            }
        }
        public static void Main(string[] args)
        {
            int suurus = Saali_suurus();
            Saali_taitmine(suurus);
            while (true)
            {
                Saal_ekraanile();
                Muuk();

            }
            //Console.ReadLine();
        }
    }
}