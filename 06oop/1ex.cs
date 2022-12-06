using System;

internal class Program
{
    interface IPerson
    {
        string Name { get; set; }
        int Age { get; set; }
    }

    class Citizen : IPerson
    {
        private int age;
        private string name;
        public Citizen(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public virtual string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public virtual int Age {

            get
            {
                return age;
            }
            set
            {
                age = value;
            }

        }
    }


    static void Main()
    {
        string name = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());
        IPerson person = new Citizen(name, age);
        Console.WriteLine(person.Name);
        Console.WriteLine(person.Age);
    }
}
