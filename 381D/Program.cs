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
            //Random Rnd = new Random();

            // Заполнение положения людей
            //string Input1 = "6 55 34 32 20 76 2 84 47 68 31 60 14 70 99 72 21 61 81 79 26 51 96 86 10 1 43 69 87 78 13 11 80 67 50 52 9 29 94 12";
            //string Input1 = "911196469 574676950 884047241 984218701 641693148 352743122 616364857 455260052 702604347 921615943 671695009 544819698 768892858 254148055 379968391 65297129 178692403 575557323 307174510 63022600";
            string[] PeopleInput = Console.ReadLine().Split(' ');
            //string[] PeopleInput = Input1.Split(' ');
            List<int> AllPeople = new List<int>();
            for (int i = 0; i < PeopleCount; i++) { AllPeople.Add(Convert.ToInt32(PeopleInput[i])); }
            //for (int i = 0; i < PeopleCount; i++) { AllPeople.Add(Rnd.Next(1, 1000000001)); }
            AllPeople.Sort();

            // Заполнение положения ключей
            //string Input2 = "1974 1232 234 28 1456 626 408 1086 1525 1209 1096 940 795 1867 548 1774 1993 1199 1112 1087 1923 1156 876 1715 1815 1027 1658 955 398 910 620 1164 749 996 113 109 500 328 800 826 766 518 1474 1038 1029";
            //string Input2 = "1621 106 6866 6420 9307 6985 2741 9477 9837 5909 6757 3085 6139 1876 3726 9334 4321 1531 8534 560";
            string[] KeysInput= Console.ReadLine().Split(' ');
            //string[] KeysInput = Input2.Split(' ');
            List<int> AllKeys = new List<int>();
            for(int i=0; i<KeysCount; i++) { AllKeys.Add(Convert.ToInt32(KeysInput[i])); }
            //for (int i = 0; i < KeysCount; i++) { AllKeys.Add(Rnd.Next(1,1000000001)) ; }
            AllKeys.Sort();

            // Запускаем таймер тестирования
            //Stopwatch Timer = new Stopwatch();
            //Timer.Start();
            //Console.WriteLine("Старт");

            int MaxPath = 2000000000;
            for(int i=0; i<=(KeysCount-PeopleCount); i++)
            {
                int CurMaxPath = 0;
                for(int j=0; j<PeopleCount; j++)
                {
                    CurMaxPath = Math.Max(CurMaxPath, GetPath(AllPeople[j], AllKeys[j+i], OfficePosition));
                }
                MaxPath = Math.Min(MaxPath, CurMaxPath);
            }
            

            Console.WriteLine(MaxPath);
            //Console.WriteLine("Ответ: {0}. Найден за {1} мс.", MaxPath, Timer.ElapsedMilliseconds);
            //Console.ReadKey();

        }

        static int GetPath(int Man, int Key, int Office)
        {
            return (Math.Abs(Man - Key) + Math.Abs(Office - Key));
        }
    }
}
