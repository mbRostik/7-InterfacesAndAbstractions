using System;

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
    interface Call
    {
      void Call(string number);

    }
    interface Browse
    {
        void Browse(string site);
    }

    class Mobile : Call, Browse
    {
        public void Browse(string site)
        {
            try
            {
                foreach (char item in site)
                {
                    if ((int)item >= 48 && (int)item <= 57)
                    {
                        throw new ArgumentException("Invalid site"+"\n");
                    }
                }
                Console.WriteLine("Browsing: "+site+"\n");
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                return;
            }
        }
        public void Call(string number)
        {
            try
            {
                foreach (char item in number)
                {
                    if ((int)item >= 48 && (int)item <= 57)
                    {
                        
                    }
                    else
                    {
                        throw new ArgumentException("Invalid number"+"\n");
                    }
                }
                Console.WriteLine("Calling... " + number+"\n");
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                return;
            }
        }
    }
    static void Main()
    {
        Mobile mobile = new Mobile();

        string numbers = Console.ReadLine();
        string sites = Console.ReadLine();
        string temp = "";
        Console.WriteLine();
        while (true)
        {
            while (true)
            {
                if(numbers==""||numbers==" ")
                {
                    break;
                }
                FindWord(ref numbers, ref temp);
                mobile.Call(temp);
            }
            Console.WriteLine("\n\n\n\n");
            while (true)
            {
                if (sites == "" || sites == " ")
                {
                    break;
                }
                FindWord(ref sites, ref temp);
                mobile.Browse(temp);
            }
            break;
        }
    }
}
