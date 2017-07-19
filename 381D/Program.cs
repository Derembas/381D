using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _381D
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] Input = Console.ReadLine().Split(' ');
            int PeopleCount = Convert.ToInt32(Input[0]); // Количество людей
            int KeysCount = Convert.ToInt32(Input[1]); // Количество Ключей
            int OfficePosition = Convert.ToInt32(Input[2]); // Положение офиса
            //int PeopleCount = 40; // Количество людей
            //int KeysCount = 45; // Количество Ключей
            //int OfficePosition = 1000; // Положение офиса


            // Генератор случайных чисел
            Random Rnd = new Random();

            // Заполнение положения людей
            //string Input1 = "6 55 34 32 20 76 2 84 47 68 31 60 14 70 99 72 21 61 81 79 26 51 96 86 10 1 43 69 87 78 13 11 80 67 50 52 9 29 94 12";
            string[] PeopleInput = Console.ReadLine().Split(' ');
            //string[] PeopleInput = Input1.Split(' ');
            List<Positon> AllPeoples = new List<Positon>();
            for (int i = 0; i < PeopleCount; i++) { AllPeoples.Add(new Positon(Convert.ToInt32(PeopleInput[i]),OfficePosition)); }
            //for (int i = 0; i < PeopleCount; i++) { AllPeoples.Add(new Positon(Rnd.Next(1,1000000001),OfficePosition)); }

            // Заполнение положения ключей
            //string Input2 = "1974 1232 234 28 1456 626 408 1086 1525 1209 1096 940 795 1867 548 1774 1993 1199 1112 1087 1923 1156 876 1715 1815 1027 1658 955 398 910 620 1164 749 996 113 109 500 328 800 826 766 518 1474 1038 1029";
            string[] KeysInput= Console.ReadLine().Split(' ');
            //string[] KeysInput = Input2.Split(' ');
            List<Positon> AllKeys = new List<Positon>();
            for(int i=0; i<KeysCount; i++) { AllKeys.Add(new Positon(Convert.ToInt32(KeysInput[i]), OfficePosition)); }
            //for (int i = 0; i < KeysCount; i++) { AllKeys.Add(new Positon(Rnd.Next(1,1000000001), OfficePosition)); }

            // Запускаем таймер тестировпния
            //Stopwatch Timer = new Stopwatch();
            //Timer.Start();
            //Console.WriteLine("Старт");

            // Сортируем людей по удалению от офиса
            AllPeoples.Sort();

            // Пока все люди не уйдут в офис
            int MaxPath = 0;
            foreach(Positon CurMan in AllPeoples )
            {
                int CurMinPath = 1000000000;
                Positon KeyToTake = null;
                foreach (Positon CurKey in AllKeys)
                {
                    int CurPath = Math.Abs(CurKey.Position - CurMan.Position) + CurKey.PathLenth;
                    if (CurPath<CurMinPath)
                    {
                        CurMinPath = CurPath;
                        KeyToTake = CurKey;
                    }
                }
                MaxPath = Math.Max(MaxPath, CurMinPath);
                AllKeys.Remove(KeyToTake);
            }
            
            Console.WriteLine(MaxPath);
            //Console.WriteLine("Ответ: {0}. Найден за {1} мс.", MaxPath, Timer.ElapsedMilliseconds);
            //Console.ReadKey();

        }
    }

    public class Positon : IComparable<Positon>
    {
        public int Position { get; set; }
        private int pathLenth;
        public int PathLenth
        {
            get { return pathLenth; }
        }

        public Positon(int Pos, int OfficePos)
        {
            Position = Pos;
            pathLenth = Math.Abs(OfficePos - Position);
        }
        
        public int CompareTo(Positon other)
        {
            if (other == null)
                return 1;

            else
                return -this.PathLenth.CompareTo(other.PathLenth);
        }
    }
}
