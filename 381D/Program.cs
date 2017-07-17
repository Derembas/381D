using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            // Заполнение положения людей
            string[] PeopleInput = Console.ReadLine().Split(' ');
            int[] AllPeoples = new int[PeopleCount];
            for (int i = 0; i < PeopleCount; i++) { AllPeoples[i] = Convert.ToInt32(PeopleInput[i]); }

            // Заполнение положения ключей
            string[] KeysInput= Console.ReadLine().Split(' ');
            List<KeyPositon> AllKeys = new List<KeyPositon>();
            for(int i=0; i<KeysCount; i++) { AllKeys.Add(new KeyPositon(Convert.ToInt32(KeysInput[i]), OfficePosition)); }

            // Сортируем ключи по удалению от офиса
            AllKeys.Sort();

            // Составляем матрицу всех растояний
            List<List<FromManToKey>> MyList=new List<List<FromManToKey>>();
            for (int i =0; i<PeopleCount; i++)
            {
                List<FromManToKey> CurList = new List<FromManToKey>();
                for(int j=0;j<PeopleCount; j++)
                {
                    CurList.Add(new FromManToKey(AllPeoples[i], AllKeys[j]));
                }
                CurList.Sort();
                MyList.Add(CurList);
            }

            // Поиск максимального из минимальных расстояний
            int MaxFulPath=0;
            for (int i=0; i<PeopleCount; i++)
            {
                List<FromManToKey> MinLenths = new List<FromManToKey>();
                FromManToKey CurMaxLenth = null;
                int CurMan = 0;
                for (int j =0; j<MyList.Count; j++)
                {
                    if(MyList[j].First().CompareTo(CurMaxLenth)>0)
                        {
                        CurMaxLenth = MyList[j].First();
                        CurMan = j;
                    }
                }
                // Удаляем человека в офис
                MaxFulPath = Math.Max(MaxFulPath, CurMaxLenth.FullPath);
                MyList.RemoveAt(CurMan);
                // Удаляем забранный ключ из массива
                foreach(List<FromManToKey> CurManKeys in MyList)
                {
                    CurManKeys.Remove(CurMaxLenth);
                }
            }
            Console.WriteLine(MaxFulPath);
            Console.ReadKey();

        }
    }

    public class KeyPositon: IComparable<KeyPositon>
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
                return this.officeLenth.CompareTo(other.officeLenth);
        }
        
    }

    public class FromManToKey : IComparable<FromManToKey>
    {
        public int Man { get; set; }
        public KeyPositon Key { get; set; }

        private int path;
        public int Path
        {
            get { return path; }
        }

        private int fullPath;
        public int FullPath
        {
            get { return fullPath; }
        }

        public FromManToKey(int man, KeyPositon key)
        {
            Man = man;
            Key = key;
            path = Math.Abs(Key.Position - Man);
            fullPath = Key.OfficeLenth+ Path;
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
