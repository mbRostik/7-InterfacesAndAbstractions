using System;
using System.Collections.Generic;
internal class Program
{
    static void FindWord(ref string v, ref string temp)
    {
        string b = "";
        for (int i = 0; i < v.Length; i++)
        {
            if (v[i] == ' ')
            {
                v = v.Remove(i, 1);
                break;
            }
            else
            {
                b += v[i];
                v = v.Remove(i, 1);
                i--;
            }
        }
        temp = b;
    }
    interface Iall:IPerson,IBuyer
    {

    }
    interface IPerson
    {
        string Name { get; set; }
        int Age { get; set; }
    }

    interface IBuyer
    {
        int BuyFood { get; set; }
    }
    class Rebel : IPerson, IBuyer, Iall
    {
        private string name;
        private int age;
        private string group;
        private int buyfood=0;

        public Rebel(string name, int age,string group)
        {
            Name = name;
            Age = age;
            Group = group;
        }
        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }

        public string Group { get => group; set => group = value; }
        public int BuyFood { get => buyfood; set => buyfood += 5; }
    }

    class Citizen : IPerson, IBuyer, Iall
    {
        private string name;
        private int age;
        private string bth;
        private string id;
        private int buyfood=0;
        public Citizen(string name, int age, string id, string bth)
        {
            Name = name;
            Id = id;
            Age = age;
            BTH = bth;
        }
        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public string BTH { get => bth; set => bth = value; }
        public int BuyFood { get => buyfood; set => buyfood+=10; }
    }

    class Person
    {
        private Iall person;

        public Person(string all)
        {
            string temp1 = "";
            string temp2 = "";
            string temp3 = "";
            string temp4 = "";

            FindWord(ref all, ref temp1);
            FindWord(ref all, ref temp2);
            FindWord(ref all, ref temp3);
            if (all == "" || all == " ")
            {
                person = new Rebel(temp1, int.Parse(temp2), temp3);
            }
            else
            {
                FindWord(ref all, ref temp4);
                person = new Citizen(temp1, int.Parse(temp2), temp3, temp4);
            }
        }
        public void FoodPlus()
        {
            person.BuyFood=0;
        }
        public int FoodReturn()
        {
            return person.BuyFood;
        }
        public string NameReturn()
        {
            return person.Name;
        }
    }
    static void Main()
    {
        List<Person> persons = new List<Person>();
        while (true)
        {
            string all = Console.ReadLine();
            if (all == "END" || all == "end" || all == "End")
            {
                break;
            }
            Person temp=new Person(all);
            foreach (Person p in persons)
            {
                if (temp.NameReturn() == p.NameReturn())
                {
                    continue;
                }
            }
            persons.Add(temp);
        }
        Console.WriteLine("\n\n\n");
        int food = 0;
        while (true)
        {
            string all = Console.ReadLine();
            if (all == "END" || all == "end" || all == "End")
            {
                break;
            }
            foreach (Person p in persons)
            {
                if (all == p.NameReturn())
                {
                    p.FoodPlus();
                    break;
                }
            }
        }
        foreach (Person p in persons)
        {
            food += p.FoodReturn();
        }
        Console.WriteLine("\n\n\n"+food);
    }
}
