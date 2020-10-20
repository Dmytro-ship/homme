using Microsoft.VisualBasic;
using System;
using System.Configuration;
using System.Reflection.Metadata.Ecma335;

using System;

namespace pr2
{
    class Worker : IComparable
    {
        protected string Name;
        protected int Year, Month;
        protected Company WorkPlace;
        public Worker()
        {
            Name = "пусто";
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
        public int CompareTo(object obj)
        {
            if (obj is Worker)
            {
                return this.Name.CompareTo((obj as Worker).Name);
            }
            throw new ArgumentException("Об'єкт не є працiвником");
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
    class Company
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
    class Program
    {
        static int Main()
        {
            int x = -1;
            Worker f = new Worker();
            Company g = new Company();
            double v, m;
            Worker[] succ = ReadWorkersArray();
            while (true)
            {

                Console.WriteLine("\nНатиснiть клавiшу, щоб продовжити "); Console.ReadKey();
                Console.Clear(); Menu();
                Console.WriteLine("\nВиберiть дiю "); x = int.Parse(Console.ReadLine());
                switch (x)
                {
                    case 1: Console.Clear(); Console.WriteLine("Зарплата " + succ[0].GetTotalMoney()); break;
                    case 2: Console.Clear(); Console.WriteLine("Досвiд роботи " + succ[0].GetWorkExperience()); break;
                    case 3: Console.Clear(); Console.WriteLine("Працiвники  "); succ = ReadWorkersArray(); break;
                    case 4: Console.Clear(); Console.WriteLine("Введiть працiвника "); PrintWorker(succ[0]); break;
                    case 5: Console.Clear(); Console.WriteLine("Введiть працiвникiв "); PrintWorker(succ); break;
                    case 6: Console.Clear(); Console.WriteLine("Iнформацiя про працiвника "); GetWorkerInfo(succ, out v, out m); Console.Write(" Максимальна зарплата - " + v + " Мінімальна зарплата - " + m + ".\n"); break;
                    case 7: Console.Clear(); Console.WriteLine("Сортування по досвiду роботи"); succ = SortWorkerByWorkExperiense(succ); break;
                    case 8: Console.Clear(); Console.WriteLine("Сортування по зарплатi "); succ = SortWorkerBySalary(succ); break;
                    case 9: Console.Clear(); Console.WriteLine("Сортування "); Array.Sort(succ); ; break;
                    case 0: Console.Clear(); Console.WriteLine("Вихiд"); return 0;
                    default: Console.Clear(); Console.WriteLine("Щось пiшло не так, повторiть попитку! "); return 0;
                }
            }


        }
        static void Menu()
        {
            Console.Write("\n.-._.-._.-._.-._.-._.-._.-._Меню_.-._.-._.-._.-._.-._.-._.-.");
            Console.Write("\n1. Зарплата за весь час");
            Console.Write("\n2. Досвiд роботи в мiсяцях");
            Console.Write("\n3. Ввiд працiвникiв");
            Console.Write("\n4. Вивiд працiвника ");
            Console.Write("\n5. Вивiд працiвникiв ");
            Console.Write("\n6. Iнформацiя про працiвника ");
            Console.Write("\n7. Сортування по досвiду ");
            Console.Write("\n8. Сортування по зарплатi ");
            Console.Write("\n9. Виконати сортування ");
            Console.Write("\n\n10. Вихiд ");
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
        static void GetWorkerInfo(Worker[] o, out double v, out double m)
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
            double bts;
            Console.Write("\nВведiть кiлькiсть працiвникiв: ");
            while (!Double.TryParse(Console.ReadLine(), out bts))
            { Console.WriteLine("Непарвильне значення!"); }
            int razm = Convert.ToInt32(bts);
            Worker[] array = new Worker[razm];


            for (int i = 0; i < razm; i++)
            {
                array[i] = new Worker();
                Company array2 = new Company();
                Console.Write("\nПрацiвник: " + (i + 1) + "\n");
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
                Console.Write("\nПрацівник " + (i + 1) + ":\n");
                PrintWorker(o[i]);
                Console.WriteLine("\nДосвiд роботи " + o[i].GetWorkExperience());
            }
        }
    }
}