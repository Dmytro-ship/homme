using System;

namespace Oneclass
{
    public class Program
    {
        public static int MainWindow()
        {
            int x = -1;
            Worker wor = new Worker();
            Company com = new Company();
            double v, m;
            Worker[] succ = ReadWorkersArray();
            while (true)
            {

                Console.WriteLine("\nНатиснiть для продовження: "); Console.ReadKey();
                Console.Clear(); Menu();
                Console.WriteLine("\nВиберiть параметр:  "); x = int.Parse(Console.ReadLine());
                switch (x)
                {
                    case 1: Console.Clear(); Console.WriteLine("Робiтник: "); PrintWorker(succ[0]); break;
                    case 2: Console.Clear(); Console.WriteLine("Робiтники:  "); PrintWorker(succ); break;
                    case 3: Console.Clear(); Console.WriteLine("Досвiд роботи:  " + succ[0].GetWorkExperience()); break;
                    case 4: Console.Clear(); Console.WriteLine("Загальна сума грошей: " + succ[0].GetTotalMoney()); break;
                    case 5: Console.Clear(); Console.WriteLine("Додати робiтникiв: "); succ = ReadWorkersArray(); break;
                    case 6: Console.Clear(); Console.WriteLine("Iнформацiя робiтникiв: "); GetWorkerInfo(succ, out v, out m); Console.Write(" MaxSalary = " + v + " MinSalary = " + m + ".\n"); break;
                    case 7: Console.Clear(); Console.WriteLine("Сортування: "); Array.Sort(succ); ; break;
                    case 8: Console.Clear(); Console.WriteLine("Сортування за досвiдом роботи: "); succ = SortWorkerByWorkExperiense(succ); break;
                    case 9: Console.Clear(); Console.WriteLine("Сортування по зарплатi: "); succ = SortWorkerBySalary(succ); break;
                    case 0: Console.Clear(); Console.WriteLine("Вихiд iз прграми виконано!"); return 0;
                    default: Console.Clear(); Console.WriteLine("Некоректне число, повторiть попитку!"); return 0;
                }
            }


        }
        public static void Menu()
        {
            Console.Write("\nОсновне меню");
            Console.Write("\n1. Робiтник: ");
            Console.Write("\n2. Робiтники: ");
            Console.Write("\n3. Досвiд роботи: ");
            Console.Write("\n4. Загальна сума грошей: ");
            Console.Write("\n5. Добавити робiтникiв: ");
            Console.Write("\n6. Iнформацiя про робiтникiв: ");
            Console.Write("\n7. Сортування: ");
            Console.Write("\n8. Сортування працівникiв за досвiдом роботи: ");
            Console.Write("\n9. Сортування працiвникiв за зарплатою: ");
            Console.Write("\n\n10. Вихiд з програми");

        }
        public static int Menub(Worker[] succ)
        {
            int x = -1;
            double v, m;
            while (true)
            {

                Console.WriteLine("\nНатиснiть для продовження:  "); Console.ReadKey();
                Console.Clear(); Menu();
                Console.WriteLine("\nВиберiть параметр: "); x = int.Parse(Console.ReadLine());
                switch (x)
                {
                    case 1: Console.Clear(); Console.WriteLine("Робiтник: "); PrintWorker(succ[0]); break;
                    case 2: Console.Clear(); Console.WriteLine("Робiтники:  "); PrintWorker(succ); break;
                    case 3: Console.Clear(); Console.WriteLine("Досвiд роботи:  " + succ[0].GetWorkExperience()); break;
                    case 4: Console.Clear(); Console.WriteLine("Загальна сума грошей: " + succ[0].GetTotalMoney()); break;
                    case 5: Console.Clear(); Console.WriteLine("Додати робiтників: "); succ = ReadWorkersArray(); break;
                    case 6: Console.Clear(); Console.WriteLine("Iнформацiя робiтникiв: "); GetWorkerInfo(succ, out v, out m); Console.Write(" MaxSalary = " + v + " MinSalary = " + m + ".\n"); break;
                    case 7: Console.Clear(); Console.WriteLine("Сортування: "); Array.Sort(succ); ; break;
                    case 8: Console.Clear(); Console.WriteLine("Сортування за досвiдом роботи: "); succ = SortWorkerByWorkExperiense(succ); break;
                    case 9: Console.Clear(); Console.WriteLine("Сортування по зарплатi: "); succ = SortWorkerBySalary(succ); break;
                    case 0: Console.Clear(); Console.WriteLine("Вихiд iз прoграми виконано!"); return 0;
                    default: Console.Clear(); Console.WriteLine("Некоректне число, повторiть спробу!"); return 0;
                }
            }
        }
        public static void Menu2()
        {
            Console.Write("\nВиберiть валюту: ");

            Console.Write("\n1. Гривня");
            Console.Write("\n2. Долар");
            Console.Write("\n3. Євро");
        }

        static Worker[] SortWorkerByWorkExperiense(Worker[] o)
        {
            for (int j = 0; j < o.Length; j++)
            {
                for (int i = 1; i < o.Length; i++)
                {
                    Worker y;
                    if ((o[i - 1].GetWorkExperience() > o[i].GetWorkExperience()))
                    {
                        Console.WriteLine("До сортування: " + o[i - 1].GetWorkExperience() + ", " + o[i].GetWorkExperience());
                        y = o[i];
                        o[i] = o[i - 1];
                        o[i - 1] = y;
                        Console.WriteLine("Пiсля сортування: " + o[i - 1].GetWorkExperience() + ", " + o[i].GetWorkExperience());
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
                        Console.WriteLine("До сортування: " + o[i - 1].GetSalary() + ", " + o[i].GetSalary());
                        y = o[i];
                        o[i] = o[i - 1];
                        o[i - 1] = y;
                        Console.WriteLine("Пiсля сортування: " + o[i - 1].GetSalary() + ", " + o[i].GetSalary());
                    }

                }
            }
            return o;
        }
        public static void GetWorkerInfo(Worker[] o, out double v, out double m)
        {
            v = o[0].GetSalary(); m = o[0].GetSalary();
            for (int i = 1; i < o.Length; i++)
            {
                if (v < o[i].GetSalary()) { v = o[i].GetSalary(); }
                else if (m > o[i].GetSalary()) { m = o[i].GetSalary(); }
            }

        }

        public static Worker[] ReadWorkersArray()
        {
            double bts;
            Console.Write("\nДобавлення працiвникiв\nВведiть кiлькiсть: ");
            while (!Double.TryParse(Console.ReadLine(), out bts))
            { Console.WriteLine("Некоректно, повторiть спробу!"); }
            int razm = Convert.ToInt32(bts);
            Worker[] array = new Worker[razm];


            for (int i = 0; i < razm; i++)
            {
                array[i] = new Worker();
                Company array2 = new Company();
                Console.Write("\nДобавлення працiвникiв: " + (i + 1) + "\n");
                array[i] = new Worker();
                array[i].SetName();
                array[i].SetYear();
                array[i].SetMonth();
                array2.SetName();
                array2.SetPosition();
                array2.SetSalary();
                array[i].SetWorkPlace(array2);
                int x = -1;
                int y = 0;
                while (y != 79)
                {


                    Menu2();
                    Console.WriteLine("\nОберiть параметр: "); x = int.Parse(Console.ReadLine());
                    switch (x)
                    {
                        case 1: array[i].SetPremGrn(); y = 79; break;
                        case 2: array[i].SetPremDol(); y = 79; break;
                        case 3: array[i].SetPremEu(); y = 79; break;
                        default: Console.Clear(); Console.WriteLine("Некоректно, повторiть спробу!"); Console.WriteLine("\nНатисніть для продовження! "); Console.ReadKey(); break;
                    }
                }

            }

            return array;
        }

        public static void PrintWorker(Worker o)
        {
            Console.Write(o.GetName());
            Console.Write(o.GetYear());
            Console.Write(o.GetMonth());
            o.GetWorkPlace();
            Console.Write(o.GetPremGrn());
            Console.Write(o.GetPremDol());
            Console.Write(o.GetPremEu());

        }

        public static void PrintWorker(Worker[] o)
        {
            for (int i = 0; i < o.Length; i++)
            {
                Console.Write("\nПрацiвник " + (i + 1) + ":\n");
                PrintWorker(o[i]);
                Console.WriteLine("\nДосвiд роботи: " + o[i].GetWorkExperience());
            }
        }
    }
    public class Company
    {
        protected string Name, Position;
        protected double Salary;
        public Company()
        {
            Name = "пусто";
            Position = "пусто";
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
            Console.Write("\nВведiть iм'я компанiї\n");
            Name = Console.ReadLine().ToString();
        }
        public void SetPosition()
        {
            Console.Write("\nВведiть мiсцеположення\n");
            Position = Console.ReadLine().ToString();
        }
        public void SetSalary()
        {
            double bts;
            Console.Write("\nВведiть зарплату\n");
            while (!Double.TryParse(Console.ReadLine(), out bts))
            { Console.WriteLine("Неправильне значення!"); }
            Salary = bts;
        }
        public string GetName()
        {
            Console.Write("\nIм'я компанiї\n");
            return Name;
        }
        public string GetPosition()
        {
            Console.Write("\nМiсцеположення\n");
            return Position;
        }
        public double GetSalary()
        {
            return Salary;
        }

    }

    public class Worker : IComparable
    {
        protected string Name;
        protected int Year, Month;
        protected Company WorkPlace;

        private float Prem;
        public void SetPremGrn()
        {
            Console.Write("\nВведiть премiю: \n");
            int bts;
            while (!int.TryParse(Console.ReadLine(), out bts))
            { Console.WriteLine("Неконектно, повторiть спробу!"); }
            Console.Write("\nВведiть премiю: \n");
            Prem = bts;
        }
        public void SetPremDol()
        {
            Console.Write("\nВведiть премiю: \n");
            int bts;
            while (!int.TryParse(Console.ReadLine(), out bts))
            { Console.WriteLine("Неконектно, повторiть спробу!"); }
            Console.Write("\nВведiть премiю: \n");
            Prem = bts * 28;
        }
        public void SetPremEu()
        {
            Console.Write("\nВведiть премiю: \n");
            int bts;
            while (!int.TryParse(Console.ReadLine(), out bts))
            { Console.WriteLine("Неконектно, повторiть спробу!"); }
            Console.Write("\nВведiть премiю: \n");
            Prem = bts * 33;
        }

        public float GetPremGrn()
        {
            Console.Write("\nПремiя в гривнях: \n");
            return Prem;

        }
        public float GetPremDol()
        {
            Console.Write("\nПремiя в доларах: \n");
            return Prem / 28;

        }
        public float GetPremEu()
        {
            Console.Write("\nПремiя в Євро: \n");
            return Prem / 33;
        }


        public Worker()
        {
            Name = "пусто";
            Year = 0;
            Month = 0;
            Prem = 0;
            WorkPlace = new Company();
        }
        public Worker(string a, int b, int c, Company d)
        {
            Name = a;
            Year = b;
            Month = c;
            WorkPlace = d;

        }
        public int CompareTo(object obj)
        {
            if (obj is Worker)
            {
                return this.Name.CompareTo((obj as Worker).Name);
            }
            throw new ArgumentException("Об'єкт не використовується!");
        }

        public int CompareTo(Worker other) { return this.Name.CompareTo(other.Name); }

        public void SetName()
        {
            Console.Write("\nВведiть iм'я\n");
            Name = Console.ReadLine();
        }
        public void SetYear()
        {
            Console.Write("\nВведiть рiк\n");
            int bts;
            while (!int.TryParse(Console.ReadLine(), out bts))
            { Console.WriteLine("Неправильне значення!"); }
            Year = bts;
        }
        public void SetMonth()
        {
            Console.Write("\nВведiть мiсяць\n");
            int bts;
            while (!int.TryParse(Console.ReadLine(), out bts))
            { Console.WriteLine("Неправилльне значення!"); }
            Month = bts;
        }
        public void SetWorkPlace(Company WP)
        {
            WorkPlace = WP;
        }
        public int GetMonth()
        {
            Console.Write("\nМiсяць\n");
            return Month;
        }
        public int GetYear()
        {
            Console.Write("\nРiк\n");
            return Year;
        }
        public string GetName()
        {
            Console.Write("\nIм'я\n");
            return Name;
        }
        public void GetWorkPlace()
        {
            Console.Write("\nМiсцеположення роботи\n");
            Console.Write(WorkPlace.GetName());
            Console.Write(WorkPlace.GetPosition());
            Console.Write(WorkPlace.GetSalary());
        }
        public double GetSalary()
        {
            return WorkPlace.GetSalary();
        }

        public int GetWorkExperience()
        {
            return ((DateTime.Now.Year - Year - 1) * 12 - Month + 1 + DateTime.Now.Month);
        }
        public double GetTotalMoney()
        {
            return GetWorkExperience() * WorkPlace.GetSalary();
        }
    }
}
