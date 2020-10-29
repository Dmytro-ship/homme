using System;

namespace pr2
{
    class Program
    {
        static void Main()
        {
            Worker f = new Worker();
            Company g = new Company();
            Worker[] succ = ReadWorkersArray();
            PrintWorker(succ);
            Console.WriteLine(succ[0].GetTotalMoney());
            float v, m;
            GetWorkerInfo(succ, out v, out m);
            Console.Write("MaxSalary" + v + "MinSalary" + m + ".\n");
            succ = SortWorkerBySalary(succ);
            Console.Clear(); Console.Write("SortWorkerBySalary \n"); PrintWorker(succ);
            succ = SortWorkerByWorkExperiense(succ);
            Console.Clear(); Console.Write("SortWorkerByWorkExperiense \n"); PrintWorker(succ);

        }
        //static Worker
        static Worker[] SortWorkerByWorkExperiense(Worker[] o)
        {
            for (int j = 0; j < o.Length; j++)
            {
                for (int i = 1; i < o.Length; i++)
                {
                    Worker y;
                    if ((o[i - 1].GetWorkExperience() > o[i].GetWorkExperience()))
                    {
                        Console.WriteLine("o[i-1] = " + o[i - 1].GetSalary() + ", o[i] = " + o[i].GetSalary());
                        y = o[i];
                        o[i] = o[i - 1];
                        o[i - 1] = y;
                        Console.WriteLine("o[i-1] = " + o[i - 1].GetSalary() + ", o[i] = " + o[i].GetSalary());
                    }

                }
            }
            return o;
        }
        static Worker[] SortWorkerBySalary(Worker[] o)
        {
            for (int j = 0; j < o.Length; j++)
            {
                for (int i = 1; i < o.Length; i++)
                {
                    Worker y;
                    if ((o[i - 1].GetSalary() < o[i].GetSalary()))
                    {
                        //Console.WriteLine("o[i-1] = "+o[i-1].GetSalary()+", o[i] = "+ o[i].GetSalary());
                        y = o[i];
                        o[i] = o[i - 1];
                        o[i - 1] = y;
                        //Console.WriteLine("o[i-1] = " + o[i-1].GetSalary() + ", o[i] = " + o[i].GetSalary());
                    }

                }
            }
            return o;
        }
        static void GetWorkerInfo(Worker[] o, out float v, out float m)
        {
            v = o[0].GetSalary(); m = o[0].GetSalary();
            for (int i = 1; i < o.Length; i++)
            {
                if (v < o[i].GetSalary()) { v = o[i].GetSalary(); }
                else if (m > o[i].GetSalary()) { m = o[i].GetSalary(); }
            }

        }
        static Worker[] ReadWorkersArray()
        {
            Console.Write("\n(ReadWorkersArray):\nset Worker number>> ");
            int razm = Convert.ToInt32(Console.ReadLine());
            Worker[] array = new Worker[razm];


            for (int i = 0; i < razm; i++)
            {
                array[i] = new Worker();
                Company array2 = new Company();
                Console.Write("\n(ReadWorkersArray): " + (i + 1) + "\n");
                array[i] = new Worker();
                array[i].SetName();
                array[i].SetYear();
                array[i].SetMonth();
                array2.SetName();
                array2.SetPosition();
                array2.SetSalary();
                array[i].SetWorkPlace(array2);
            }

            return array;
        }
        static void PrintWorker(Worker o)
        {
            Console.Write(o.GetName());
            Console.Write(o.GetYear());
            Console.Write(o.GetMonth());
            o.GetWorkPlace();
        }

        static void PrintWorker(Worker[] o)
        {
            for (int i = 0; i < o.Length; i++)
            {
                Console.Write("\nWorker " + (i + 1) + ":\n");
                PrintWorker(o[i]);
                Console.WriteLine("\nGetWorkExperience" + o[i].GetWorkExperience());
            }
        }
    }
    class Company
    {
        protected string Name, Position;
        protected int Salary;
        public Company()
        {
            Name = "empty";
            Position = "empty";
            Salary = 0;
        }
        public Company(string a, string b, int c)
        {
            Name = a;
            Position = b;
            Salary = c;
        }
        public void SetName()
        {
            Console.Write("\nSetCompanyName\n");
            Name = Console.ReadLine().ToString();
        }
        public void SetPosition()
        {
            //Console.Write("\nSetPosition\n");
            Position = Console.ReadLine().ToString();
        }
        public void SetSalary()
        {
            Console.Write("\nSetSalary\n");
            Salary = int.Parse(Console.ReadLine());
        }
        public string GetName()
        {
            Console.Write("\nGetCompanyName\n");
            return Name;
        }
        public string GetPosition()
        {
            Console.Write("\nGetPosition\n");
            return Position;
        }
        public int GetSalary()
        {
            Console.Write("\nGetSalary\n");
            return Salary;
        }

    }

    class Worker
    {
        protected string Name;
        protected int Year, Month;
        protected Company WorkPlace;
        public Worker()
        {
            Name = "empty";
            Year = 0;
            Month = 0;
            WorkPlace = new Company();
        }
        public Worker(string a, int b, int c, Company d)
        {
            Name = a;
            Year = b;
            Month = c;
            WorkPlace = d;

        }
        public void SetName()
        {
            Console.Write("\nSetName\n");
            Name = Console.ReadLine();
        }
        public void SetYear()
        {
            Console.Write("\nSetYear\n");
            Year = int.Parse(Console.ReadLine());
        }
        public void SetMonth()
        {
            Console.Write("\nSetMonth\n");
            Month = int.Parse(Console.ReadLine());
        }
        public void SetWorkPlace(Company WP)
        {
            WorkPlace = WP;
        }
        public int GetMonth()
        {
            Console.Write("\nGetMonth\n");
            return Month;
        }
        public int GetYear()
        {
            Console.Write("\nGetYear\n");
            return Year;
        }
        public string GetName()
        {
            Console.Write("\nGetName\n");
            return Name;
        }
        public void GetWorkPlace()
        {
            Console.Write("\nGetWorkPlace\n");
            Console.Write(WorkPlace.GetName());
            Console.Write(WorkPlace.GetPosition());
            Console.Write(WorkPlace.GetSalary());
        }
        public int GetSalary()
        {
            return WorkPlace.GetSalary();
        }

        public int GetWorkExperience()
        {
            return ((DateTime.Now.Year - Year - 1) * 12 - Month + 1 + DateTime.Now.Month);//включно з місяцем прийнятя на роботу і теперішнім
        }
        public int GetTotalMoney()
        {
            return GetWorkExperience() * WorkPlace.GetSalary();
        }
    }
}
