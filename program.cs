using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ovning14._1_BinarSokning
{
    //Klass som hanterar personer med namn och personnummer
    class Person
    {
        string name;
        int personnummer;

        //METOD: Konstruktor
        public Person(string name, int personnummer)
        {
            this.name = name;
            this.personnummer = personnummer;
        }
        //Egenskaper för name
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        //Egenskaper för personnummmer
        public int Personnummer
        {
            get { return personnummer; }
            set { personnummer = value; }
        }
        public override string ToString()//Ställer in vad som ska skrivas ut när vektorn skrivs ut
        {
            return "Namn: " + name + ", Personnummer: " + Personnummer;
        }
    }
    //KLASS: Program med exempel på binär sökning
    class Program
    {

        //Metod PrintList
        static void PrintList(List<Person> list)
        {
            for (int i=0; i<list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }

        //Metod SelectionSortPersNr - sorterar listan utifrån personnummer
        static void SelectionSortPersNr(List<Person> list)
        {
            for (int m = 0; m < list.Count; m++)
            {
                int position = m;

                for (int n = m + 1; n < list.Count; n++)
                {
                    if (list[n].Personnummer < list[position].Personnummer)
                    {
                        position = n;
                    }
                }
                if (m != position)
                {
                    int temp = list[m].Personnummer;
                }
            }
            //För att testa att sorteringen fungerar
            Console.WriteLine("Fungerar sorteringen?");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }
        #region Linjär sökning
        ////METOD: LinearSearch. Tar emot en lista av typen Person och sorterar.
        //static int LinearSearch(List <Person>list, int key)
        //{            
        //    //Gå igenom listan element för element och se om key går att hitta
        //    for (int i = 0; i < list.Count; i++)
        //    {
        //        if (list[i].Personnummer == key)
        //            return i;
        //    }

        //    //Kommer vi hit har hela listan gåtts igenom utan att key har hittats
        //    return -1;
        //} 
        #endregion

        //METOD binär sökning. Kräver att listan är sorterad, metoden börjar med att listan sorteras utifrån personnummer 
        static int BinarySearch (List<Person>list, int key)
        {

                int low = 0, high = list.Count - 1, midpoint = 0;

                while (low <= high)
                {
                    midpoint = low + (high - low) / 2;

                    //Kolla om key är samma som elementet i listan
                    if (key == list[midpoint].Personnummer)
                    {
                        return midpoint;
                    }
                    else if (key < list[midpoint].Personnummer)
                    {
                        high = midpoint - 1;
                    }
                    else
                        low = midpoint + 1;
                }
                //Key hittades inte
                return -1;
            }


            //METOD: Main, start på programmet
            static void Main(string[] args)
        {
            //Skapa en lista av typen Person:
            List<Person> myList = new List<Person>();

            //Fyll på listan med personer med hjälp av ordet new och konstruktorn i klassen Person,
            //så kan vi skapa dem direkt med metoden Add. Vi är noga med att lägga dem i ordning efter personnummer
            myList.Add(new Person("Lisa", 330112));
            myList.Add(new Person("Pelle", 420721));
            myList.Add(new Person("Fia", 421221));
            myList.Add(new Person("Nissa", 691122));
            myList.Add(new Person("Kalle", 811126));
            myList.Add(new Person("Klara", 840717));
            myList.Add(new Person("Maja", 920411));
            myList.Add(new Person("Stina", 940723));
            myList.Add(new Person("Olle", 950318));

            PrintList(myList); //Hämtar metoden PrintList
            Console.ReadLine();

            //Låter använder lägga till namn i listan
            Console.Write("Skriv in förnamn: ");
            string myName = Console.ReadLine();

            Console.WriteLine("Skriv in personnummer, sex siffror: ");
            string strP = Console.ReadLine();
            int myPersonnummer = Convert.ToInt32(strP);

            myList.Add(new Person(myName, myPersonnummer)); //Lägger till de inlagda namnen till listan 

            PrintList(myList); //Hämtar metoden PrintList
            Console.ReadLine();

            SelectionSortPersNr(myList); //Hämtar metoden SelectionSort - sorteringen fungerar inte!
            Console.ReadLine();

            //Låt användaren mata in personnummer:
            Console.Write("Mata in personnummer att söka: ");
            string str = Console.ReadLine();
            int key = Convert.ToInt32(str);

            int index = BinarySearch(myList, key); //Hämtar metoden BinarySearch

            //Skriv ut resultat
            if (index == -1)
            {
                Console.WriteLine("Personen fanns ej!");
            }
            else
            {
                Console.WriteLine("Personen med personnummer {0}, finns på index {1} och heter {2}.", key, index, myList[index].Name);
            }

        }
    }
}
