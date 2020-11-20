using System;
using Oneclass;


namespace pr3_1
{
    class Program2
    {
        static void Main(string[] args)
        {
            Oneclass.Worker[] x = new Oneclass.Worker[5];
            Company y = new Oneclass.Company();
            x = Program.ReadWorkersArray();
            Program.Menub(x);
        }
    }
}
