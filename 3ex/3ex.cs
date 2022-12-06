using System;

internal class Program
{
 
    interface Car
    {
        string Driver { get; set; }
        string brakes ();
        string push();

        string Model { get;}
    }

    class Ferrari : Car
    {
        private string model = "488-Spider";
        private string driver;


        public Ferrari(string driver)
        {
            this.Driver = driver;
        }

        public string Driver { get => driver; set => driver = value; }

        public string brakes()
        {
            return "Brakes!";
        }

        public string push()
        {
           return "Zadu6avam sA!";
        }

        public string Model { get => model; }

    }
    static void Main()
    {
        string name = Console.ReadLine();
        Car ferrari = new Ferrari(name);
        Console.WriteLine(ferrari.Model + "/"+ferrari.brakes()+"/"+ferrari.push()+"/"+ferrari.Driver);
    }
}
