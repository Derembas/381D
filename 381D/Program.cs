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
            for (int i = 0; i < KeysCount; i++) { AllPeoples[i] = Convert.ToInt32(PeopleInput[i]); }

            // Заполнение положения ключей
            string[] KeysInput= Console.ReadLine().Split(' ');
            List<KeyPositon> AllKeys = new List<KeyPositon>();
            for(int i=0; i<KeysCount; i++) { AllKeys.Add(new KeyPositon(Convert.ToInt32(KeysInput[i]), OfficePosition)); }

            // Сортируем ключи по удалению от офиса
            AllKeys.Sort();


        }
    }

    public class KeyPositon: IComparable<KeyPositon>
    {
        public int Position { get; set; }
        public int OfficeLinth { get; set; }
        public KeyPositon(int Pos, int OfficePos)
        {
            Position = Pos;
            OfficeLinth = Math.Abs(OfficePos - Position);
        }

        public int CompareTo(KeyPositon other)
        {
            if (other == null)
                return 1;

            else
                return this.OfficeLinth.CompareTo(other.OfficeLinth);
        }
    }
}
