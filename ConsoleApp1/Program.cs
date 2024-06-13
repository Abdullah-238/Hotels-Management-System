using DVLD_Buisness;
using HMS_BusinessLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<clsPerson> list = new List<clsPerson>
            {
                clsPerson.Find(1),
                clsPerson.Find(2),
                clsPerson.Find(3),
                clsPerson.Find(4)
            };

            clsPerson person1 = new clsPerson();

            list[0].Name = "Noori9";


            List<clsPerson> list2 = list.FindAll(x => x.Name.Length > 4);


            foreach (clsPerson person in list2)
            {
                Console.WriteLine(person.Name);
            }

            Console.ReadLine();
        }
    }
}
