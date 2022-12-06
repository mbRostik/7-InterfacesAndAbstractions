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
    abstract class Soldier
    {
        public string id;
        public string name;
        public string secname;

        public override string ToString()
        {
            return base.ToString(); 
        }
    }

    interface IPrivates
    {
        public double Salary { get; set; }
    }

    interface ISpecialisedSoldier
    {
        public string Corp { get; set; }
    }

    class Private : Soldier, IPrivates
    {
        private double salary;

        public Private(string id, string name, string secname, double salary)
        {
            Id = id;
            Name = name;
            Secname = secname;
            Salary = salary;

        }

        public string Name { get => name; set => name = value; }
        public string Secname { get => secname; set => secname = value; }
        public string Id { get => id; set => id = value; }
        public double Salary { get => salary; set => salary = value; }

        public override string ToString()
        {
            return "Name: " + Name + " " + Secname + " Id:" + Id + " Salary: " + Salary;
        }

    }

    class LeutenantGeneral : Soldier, IPrivates
    {
        private double salary;
        List<Soldier> persons = new List<Soldier>();
        public LeutenantGeneral(string id, string name, string secname, double salary, string pod, List<Soldier> slaves)
        {
            Id = id;
            Name = name;
            Secname = secname;
            Salary = salary;

            while (true)
            {
                string temp = "";
                if (pod == "" || pod == " ")
                {
                    break;
                }
                FindWord(ref pod, ref temp);
                for(int i = 0; i < slaves.Count; i++)
                {
                    if (slaves[i].GetType() == typeof(Private))
                    {
                        if (slaves[i].id == temp)
                        {
                            persons.Add(slaves[i]);
                        }

                    }
                }
            }
        }

        public string Name { get => name; set => name = value; }
        public string Secname { get => secname; set => secname = value; }
        public string Id { get => id; set => id = value; }

        public double Salary { get => salary; set => salary = value; }

        public override string ToString()
        {
            Console.WriteLine("Name: " + Name + " " + Secname + " Id:" + Id + " Salary: " + Salary);
            Console.WriteLine("    Privates:" );
            foreach (Private pr in persons)
            {
                Console.WriteLine("    " + pr.ToString());
            }
            return null;
            
        }


        
    }

    class Engineer : Soldier, IPrivates, ISpecialisedSoldier
    {
        private double salary;
        private string corp;
        private string rep;

        public Engineer(string id, string name, string secname, double salary, string corp, string all)
        {
            Id = id;
            Name = name;
            Secname = secname;
            Corp = corp;
            Salary = salary;

            while (true)
            {
                if (all==""||all==" ")
                {
                    break;
                }
                string temp1 = "";
                string temp2 = "";
                FindWord(ref all, ref temp1);
                FindWord(ref all, ref temp2);
                try
                {
                    int t = int.Parse(temp2);
                    rep += "   Part Name: " + temp1 + "  Hours Worked: " + t+"\n";
                }
                catch (Exception)
                {
                    return;
                }
            }
        }


        public double Salary { get => salary; set => salary = value; }
        public string Corp
        {
            get => corp;


            set
            {

                try
                {
                    if (value == "Airforces")
                    {
                        corp = "Airforces";
                    }
                    else if (value == "Marines")
                    {
                        corp = "Marines";
                    }
                    else
                    {
                        corp = "Airforces";
                        throw new ArgumentException("Invalid corp, 'Airforces' will be added");
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    return;
                }
            }
        }

        public string Name { get => name; set => name = value; }
        public string Secname { get => secname; set => secname = value; }
        public string Id { get => id; set => id = value; }

        public override string ToString()
        {
            Console.WriteLine("Name: " + Name + " " + Secname + " Id:" + Id + " Salary: " + Salary);
            Console.WriteLine("Corp: "+Corp);
            Console.WriteLine(rep);
            return null;
        }
    }

    class Commando:Soldier, IPrivates, ISpecialisedSoldier
    {
        private double salary;
        private string corp;
        private string miss;


        public Commando(string id, string name, string secname, double salary, string corp, string all)
        {
            Id = id;
            Name = name;
            Secname = secname;
            Salary = salary;
            Corp = corp;
            while (true)
            {
                if(all==""||all==" ")
                {
                    break;
                }
                string temp = "";
                string temp2 = "";
                FindWord(ref all, ref temp);
                FindWord(ref all, ref temp2);
                if (temp2 != "finished" || temp2 != "Finished" || temp2 != "inProgress" || temp2 != "Inprogress" || temp2 != "inprogress" || temp2 != "InProgress")
                {
                    Console.WriteLine("Status of mission - wrong. Def: inProgress");
                    temp2 = "inProgress";
                }
                miss += "   Code Name: " + temp + "; State: " + temp2 + "\n";
               
            }
        }
       


        public double Salary { get => salary; set => salary = value; }
        public string Corp
        {
            get => corp;


            set
            {

                try
                {
                    if (value == "Airforces")
                    {
                        corp = "Airforces";
                    }
                    else if (value == "Marines")
                    {
                        corp = "Marines";
                    }
                    else
                    {
                        corp = "Airforces";
                        throw new ArgumentException("Invalid corp, 'Airforces' will be added");
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    return;
                }
            }
        }

        public string Name { get => name; set => name = value; }
        public string Secname { get => secname; set => secname = value; }
        public string Id { get => id; set => id = value; }

        public override string ToString()
        {
            Console.WriteLine("Name: " + Name + " " + Secname + " Id:" + Id + " Salary: " + Salary);
            Console.WriteLine("Corp: " + Corp);
            Console.WriteLine(miss);
            return null;
        }
    }
    class Spy : Soldier
    {
        private int cod;

        public Spy(string id, string name, string secname, int cod) 
        {
            Id = id;
            Name = name;
            Secname = secname;
            Cod= cod;

        }

        public string Name { get => name; set => name = value; }
        public string Secname { get => secname; set => secname = value; }
        public string Id { get => id; set => id = value; }
        public int Cod { get => cod; set => cod = value; }

        public override string ToString()
        {
            return "Name: "+Name+" "+Secname+" Id:"+Id + " Cod: "+Cod+"  (SPY)  ";
        }

    }
    static void Main()
    {
        List<Soldier> persons = new List<Soldier>();

        while (true)
        {
            string a = Console.ReadLine();

            if (a == "end" || a == "End" || a == "END")
            {
                break;
            }

            string temp = "";
            FindWord(ref a, ref temp);


            if (temp == "LeutenantGeneral")
            {
                string temp1 = "";
                string temp2 = "";
                string temp3 = "";
                string temp4 = "";
                FindWord(ref a, ref temp1);
                FindWord(ref a, ref temp2);
                FindWord(ref a, ref temp3);
                FindWord(ref a, ref temp4);
                double salary = int.Parse(temp4);

                LeutenantGeneral pr = new LeutenantGeneral(temp1, temp2, temp3, salary, a, persons);
                persons.Add(pr);
            }

            else if (temp == "Private")
            {
                string temp1 = "";
                string temp2 = "";
                string temp3 = "";
                string temp4 = "";
                FindWord(ref a, ref temp1);
                FindWord(ref a, ref temp2);
                FindWord(ref a, ref temp3);
                FindWord(ref a, ref temp4);
                double salary = int.Parse(temp4);

                Private pr = new Private(temp1, temp2, temp3, salary);
                persons.Add(pr);
            }

            else if (temp == "Spy")
            {
                string temp1 = "";
                string temp2 = "";
                string temp3 = "";
                string temp4 = "";
                FindWord(ref a, ref temp1);
                FindWord(ref a, ref temp2);
                FindWord(ref a, ref temp3);
                FindWord(ref a, ref temp4);
                int cod = int.Parse(temp4);

                Spy pr = new Spy(temp1, temp2, temp3, cod);
                persons.Add(pr);
            }

            else if (temp == "Engineer")
            {
                string temp1 = "";
                string temp2 = "";
                string temp3 = "";
                string temp4 = "";
                string temp5 = "";
                FindWord(ref a, ref temp1);
                FindWord(ref a, ref temp2);
                FindWord(ref a, ref temp3);
                FindWord(ref a, ref temp4);
                FindWord(ref a, ref temp5);
                double salary = int.Parse(temp4);

                Engineer pr = new Engineer(temp1, temp2, temp3, salary, temp5, a);
                persons.Add(pr);
            }

            else if(temp== "Commando")
            {
                string temp1 = "";
                string temp2 = "";
                string temp3 = "";
                string temp4 = "";
                string temp5 = "";
                FindWord(ref a, ref temp1);
                FindWord(ref a, ref temp2);
                FindWord(ref a, ref temp3);
                FindWord(ref a, ref temp4);
                FindWord(ref a, ref temp5);
                double salary = int.Parse(temp4);

                Commando pr = new Commando(temp1, temp2, temp3, salary, temp5, a);
                persons.Add(pr);
            }
        }

        Console.WriteLine("\n\n");


        foreach (Soldier s in persons)
        {
            Console.WriteLine(s.ToString());
        }
    }

}
