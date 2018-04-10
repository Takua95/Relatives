using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace RelativesList
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            int selection = 0;
            List<Relative> relatives = new List<Relative>();
            
            while (!exit)
            {
                WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ("Main Menu".Length / 2)) + "}", "Main Menu"));
                Write(
                    "\n1: Add Relative" +
                    "\n2: View Relatives alphabeticaly" +
                    "\n3: Search by Name" +
                    "\n4: Search by Month of Birth" + 
                    "\n5: Exit" +
                    "\n->");
                selection = Convert.ToInt32(ReadLine());
                switch (selection)
                {
                    case 1:
                        relatives.Add(Relative.addRelative());
                        break;
                    case 2:
                        Relative.search(relatives);
                        break;
                    case 3:
                        Relative.search(relatives, "");
                        break;
                    case 4:
                        Relative.search(relatives, 00);
                        break;
                    case 5:
                        WriteLine("\nGoodbye!");
                        exit = true;
                        break;
                    default:
                        break;
                }
            }
        }
        
    }
    class Relative
    {
        public string FirstName { get; set; } = "NULL";
        public string LastName { get; set; } = "NULL";
        public string Relation { get; set; } = "NULL";
        public string phoneNumber { get; set; } = "000-000-000";
        public string BirthdayMonth { get; set; } = "00";
        public string BirthdayDay { get; set; } = "00";
        public string BirthdayYear { get; set; } = "0000";

        public static Relative addRelative()
        {
            Relative temp = new Relative();
            WriteLine("Please enter the first name of the Relative: ");
            temp.FirstName = ReadLine();
            WriteLine("Please enter the last name of the Relative: ");
            temp.LastName = ReadLine();
            WriteLine("Please enter the relation to you of the Relative: ");
            temp.Relation = ReadLine();
            WriteLine("Please enter the phone number of the Relative: ");
            temp.Relation = ReadLine();
            WriteLine("Please enter the month Relative was born in (e.g. 01, 02, 03... 12.): ");
            temp.BirthdayMonth = ReadLine();
            WriteLine("Please enter the day Relative was born on: ");
            temp.BirthdayDay = ReadLine();
            WriteLine("Please enter the year Relative was born in: ");
            temp.BirthdayYear = ReadLine();
            return temp;
        }
        public static void search(List<Relative> relatives)
        {
            List<Relative> SortedList = relatives.OrderBy(o => o.FirstName).ToList();
            for (int i = 0; i < SortedList.Count; i++)
                WriteLine(
                    "\nFirst Name: {0}" +
                    "\nLast Name: {1}" +
                    "\nRelation: {2}" +
                    "\nPhone Number: {6}" +
                    "\nBirthday: {3}/{4}/{5}" +
                    "\n-----------------------------------\n",
                    SortedList[i].FirstName, SortedList[i].LastName, SortedList[i].Relation,
                    SortedList[i].BirthdayMonth, SortedList[i].BirthdayDay, SortedList[i].BirthdayYear,
                    SortedList[i].phoneNumber);
        }
        public static void search(List<Relative>relatives, string name)
        {
            if (name == "")
            {
                Write("Please enter the name to search: ");
                name = ReadLine();
            }
            for (int i = 0; i < relatives.Count; i++)
                if (relatives[i].FirstName == name || relatives[i].LastName == name)
                    WriteLine(
                    (String.Format("{0," + ((Console.WindowWidth / 2) + ("Found!".Length / 2)) + "}", "Main Menu")) +
                    "\nFirst Name: {0}" +
                    "\nLast Name: {1}" +
                    "\nRelation: {2}" +
                    "\nPhone Number: {6}" +
                    "\nBirthday: {3}/{4}/{5}" +
                    "\n-----------------------------------\n",
                    relatives[i].FirstName, relatives[i].LastName, relatives[i].Relation,
                    relatives[i].BirthdayMonth, relatives[i].BirthdayDay, relatives[i].BirthdayYear,
                    relatives[i].phoneNumber);
            
        }
        public static void search(List<Relative> relatives, int nA)
        {
            string month = "";
            if (nA == 00)
            {
                Write("\nPlease enter the month to search for: ");
                month = ReadLine();
            }
            for (int i = 0; i < relatives.Count; i++)
                if (relatives[i].BirthdayMonth == month)
                    WriteLine(
                    "\nFirst Name: {0}" +
                    "\nLast Name: {1}" +
                    "\nRelation: {2}" +
                    "\nPhone Number: {6}" +
                    "\nBirthday: {3}/{4}/{5}" +
                    "\n-----------------------------------\n",
                    relatives[i].FirstName, relatives[i].LastName, relatives[i].Relation,
                    relatives[i].BirthdayMonth, relatives[i].BirthdayDay, relatives[i].BirthdayYear,
                    relatives[i].phoneNumber);
        }
        
    }
    

}