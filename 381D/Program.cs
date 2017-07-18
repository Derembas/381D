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

            // Генератор случайных чисел
            //Random Rnd = new Random();

            // Заполнение положения людей
            string[] PeopleInput = Console.ReadLine().Split(' ');
            int[] AllPeoples = new int[PeopleCount];
            for (int i = 0; i < PeopleCount; i++) { AllPeoples[i] = Convert.ToInt32(PeopleInput[i]); }
            //for (int i = 0; i < PeopleCount; i++) { AllPeoples[i] = Rnd.Next(1,1000000001); }

            // Заполнение положения ключей
            string[] KeysInput= Console.ReadLine().Split(' ');
            List<KeyPositon> AllKeys = new List<KeyPositon>();
            for(int i=0; i<KeysCount; i++) { AllKeys.Add(new KeyPositon(Convert.ToInt32(KeysInput[i]), OfficePosition)); }
            //for (int i = 0; i < KeysCount; i++) { AllKeys.Add(new KeyPositon(Rnd.Next(1,1000000001), OfficePosition)); }

            // Запускаем таймер тестировпния
            //Stopwatch Timer = new Stopwatch();
            //Timer.Start();
            //Console.WriteLine("Старт");

            // Сортируем ключи по удалению от офиса
            AllKeys.Sort();

            // Составляем матрицу всех растояний
            List<FromManToKey> MyList=new List<FromManToKey>();
            for (int i =0; i<PeopleCount; i++)
            {
                for(int j=0;j<PeopleCount; j++)
                {
                    MyList.Add(new FromManToKey(i, AllPeoples[i], AllKeys[j]));
                }
            }
            MyList.Sort(); // Сортируем по возрастанию пути
            //Console.WriteLine("Матрица составлена за: {0} мс.", Timer.ElapsedMilliseconds);

            int MaxFulPath=0;
            bool[] ManInOffice = new bool[PeopleCount];
            int PeopleInOffice = 0;
            foreach(FromManToKey CurMan in MyList)
            {
                if (!ManInOffice[CurMan.Man])
                {
                    PeopleInOffice++;
                    ManInOffice[CurMan.Man] = true;
                    MaxFulPath = CurMan.Path;
                }
                if (PeopleInOffice == PeopleCount) { break; }
            }
            
            
            Console.WriteLine(MaxFulPath);
            //Console.WriteLine("Ответ: {0}. Найден за {1} мс.", MaxFulPath, Timer.ElapsedMilliseconds);
            //Console.ReadKey();

        }
    }

    public class KeyPositon : IComparable<KeyPositon>
    {
        public int Position { get; set; }
        private int officeLenth;
        public int OfficeLenth
        {
            get { return officeLenth; }
        }
        public KeyPositon(int Pos, int OfficePos)
        {
            Position = Pos;
            officeLenth = Math.Abs(OfficePos - Position);
        }

        public int CompareTo(KeyPositon other)
        {
            if (other == null)
                return 1;

            else
                return this.OfficeLenth.CompareTo(other.OfficeLenth);
        }
    }

    public class FromManToKey :IComparable<FromManToKey>
    {
        public int Man { get; set; }
        public int ManPosition { get; set; }
        public KeyPositon Key { get; set; }

        private int path;
        public int Path
        {
            get { return path; }
        }

        public FromManToKey(int man, int manPosition, KeyPositon key)
        {
            Man = man;
            ManPosition = manPosition;
            Key = key;
            path = Math.Abs(Key.Position - ManPosition) + Key.OfficeLenth;
        }

        public int CompareTo(FromManToKey other)
        {
            if (other == null)
                return 1;

            else
                return this.Path.CompareTo(other.Path);
        }
    }
}
