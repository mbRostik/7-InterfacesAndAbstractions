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
    }
    interface IRobot : IPerson
    {
        string Id { get; set; }
        string Model { get; set; }
    }
    interface IPeople : IPerson
    {
        string Id { get; set; }
        string Name { get; set; }
        int Age { get; set; }

        string BTH { get; set; }
    }
    interface IPet : IPerson 
    {
        string Name { get; set; }
        string BTH { get; set; }
    }

    class Robot : IRobot
    {
        private string model;
        private string id;

        public Robot(string model, string id)
        {
            this.Id = id;
            this.Model = model;
        }
        public string Id { get => id; set => id = value; }
        public string Model { get => model; set => model = value; }
    }

    class People : IPeople
    {
        private string id;
        private string name;
        private int age;
        private string bth;

        public People(string name, int age, string id, string bth)
        {
            Name = name;
            Id = id;
            Age = age;
            BTH = bth;
        }
        public People() { }
        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public string BTH { get => bth; set => bth = value; }
    }

    class Pet : IPet
    {
        private string name;
        private string bth;

        public Pet(string name, string bth)
        {
            Name = name;
            BTH = bth;
        }
        public Pet() { }
        public string Name { get => name; set => name = value; }
        public string BTH { get => bth; set => bth = value; }
    }
    static void Main()
    {
        List<IPerson> allp = new List<IPerson>();

        string all;
        while (true)
        {
            all = Console.ReadLine();
            if (all == "END" || all == "end" || all == "End")
            {
                break;
            }
            string temp = "";
            FindWord(ref all, ref temp);
            if (temp == "Robot")
            {
                string temp1 = "";
                string temp2 = "";
                FindWord(ref all, ref temp1);
                FindWord(ref all, ref temp2);
                Robot temprobot = new Robot(temp1, temp2);
                allp.Add(temprobot);
            }
            else if (temp == "Person")
            {
                string temp1 = "";
                string temp2 = "";
                string temp3 = "";
                string temp4 = "";
                FindWord(ref all, ref temp1);
                FindWord(ref all, ref temp2);
                FindWord(ref all, ref temp3);
                FindWord(ref all, ref temp4);
                People tempperson = new People(temp1, int.Parse(temp2), temp3, temp4);
                allp.Add(tempperson);
            }
            else if (temp == "Pet")
            {
                string temp1 = "";
                string temp2 = "";
                FindWord(ref all, ref temp1);
                FindWord(ref all, ref temp2);
                Pet temppet = new Pet(temp1, temp2);
                allp.Add(temppet);
            }
            else
            {
                Console.WriteLine("\nSMT incorrect\n");
            }
        }
        Console.WriteLine("\n\n\nVvedit 4islo: ");

        string chislo = Console.ReadLine();
        foreach (IPerson person in allp)
        {
            string b = person.GetType().ToString();
            if (b=="Program+Pet")
            {
                Pet temp = new Pet();
                temp = (Pet)person;
                int kemp = 0;
                for (int i = 0; i < chislo.Length; i++)
                {
                    if (chislo[i] == temp.BTH[temp.BTH.Length - chislo.Length + i])
                    {

                    }
                    else
                    {
                        kemp++;
                    }
                }
                if (kemp == 0)
                {
                    Console.WriteLine(temp.BTH);
                }
                else
                {
                }
            }
            else if(b == "Program+People")
            {
                People temp = new People();
                temp = (People)person;

                int kemp = 0;
                for (int i = 0; i < chislo.Length; i++)
                {
                    if (chislo[i] == temp.BTH[temp.BTH.Length - chislo.Length + i])
                    {

                    }
                    else
                    {
                        kemp++;
                    }
                }
                if (kemp == 0)
                {
                    Console.WriteLine(temp.BTH);
                }
                else
                {
                }

            }
            else
            {

            }
        }
    }
}

