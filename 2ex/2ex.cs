using System;

internal class Program
{

    interface IPerson
    {
        string Name { get; set; }
        int Age { get; set; }
    }

    interface IIdentifiable
    {
        string Id { get; set; }
    }
    interface IBirthable
    {
        string Birthdate { get; set; }
    }
    class Citizen : IPerson, IIdentifiable, IBirthable
    {
        private int age;
        private string name;
        private string id;
        private string birthdate;
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
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
        public virtual int Age
        {

            get
            {
                return age;
            }
            set
            {
                age = value;
            }

        }

        public string Id { get => id; set => id=value; }
        public string Birthdate { get => birthdate; set => birthdate=value; }
    }
    static void Main()
    {
        string name = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());
        string id = Console.ReadLine();
        string birthdate = Console.ReadLine();
        IIdentifiable identifiable = new Citizen(name, age, id, birthdate);
        IBirthable birthable = new Citizen(name, age, id, birthdate);
        Console.WriteLine(identifiable.Id);
        Console.WriteLine(birthable.Birthdate);

    }
}
