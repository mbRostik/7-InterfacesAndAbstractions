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
    interface IPerson
    {
        string Id { get; set; }
    }
    interface IRobot : IPerson
    {
        string Model { get; set; }
    }
    interface IPeople : IPerson
    {
        string Name { get; set; }
        int Age { get; set; }
    }

    class Robot : IRobot
    {
        private string id;
        private string model;

        public Robot(string model ,string id)
        {
            this.Model = model;
            this.Id = id;
        }
        public string Id { get => id; set => id = value; }
        public string Model { get => model; set => model = value; }
    }
    class People : IPeople
    {
        private string id;
        private string name;
        private int age;

        public People(string name, string id,  int age)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
        }
        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
    }

    class Person
    {
        private IPerson p;

        public Person(string all)
        {
            RP(ref all, ref p);
        }

        public IPerson P { get => p;}
    }

    static void RP(ref string all, ref IPerson person)
    {
        string temp1 = "";
        string temp2 = "";
        string temp3 = "";

        FindWord(ref all, ref temp1);
        FindWord(ref all, ref temp2);
        if(all==""||all==" ")
        {
            person = new Robot(temp1, temp2);
        }
        else
        {
            FindWord(ref all, ref temp3);
            person = new People(temp1, temp3, int.Parse(temp2));
        }
    }

    static bool Proverka(string a, Person p)
    {
        int temp = 0;
        for(int i = 0; i < a.Length; i++)
        {
            if (a[i] == p.P.Id[p.P.Id.Length - a.Length + i])
            {

            }
            else{
                temp++;
            }
        }
        if (temp == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    static void Main()
    {
        string all;

        List<Person> people = new List<Person>();

        while (true)
        {
            all= Console.ReadLine();
            if (all == "END" || all=="end"||all=="End")
            {
                break;
            }
            Person temp = new Person(all);
            people.Add(temp);
        }
        Console.WriteLine("\n\n\nVvedit 4islo: ");

        string chislo = Console.ReadLine();
        foreach(Person person in people)
        {
            if(Proverka(chislo, person) == true)
            {
                Console.WriteLine(person.P.Id);
            }
        }
    }
}
