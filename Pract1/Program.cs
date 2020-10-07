using System;

namespace ZD1
{
    struct Date
    {
        public int Year;
        public int Month;
        public int Day;
        public  int Hours;
        public int Minutes;

        public Date(int Year = 0, int Month = 0, int Day = 0, int Hours = 0, int Minutes = 0)
        {
            this.Year = Year;
            this.Month = Month;
            this.Day = Day;
            this.Hours = Hours;
            this.Minutes = Minutes;
        }
    }
    struct Airplane
    {
        public string StartCity;
        public string FinishCity;
        public Date StartDate;
        public Date FinishDate;

        public Airplane(string StartCity, string FinishCity, Date StartDate, Date FinishDate)
        {
            this.StartCity = StartCity;
            this.FinishCity = FinishCity;
            this.StartDate = StartDate;
            this.FinishDate = FinishDate;
        }
        public int GetTotalTime()
        {
            int Total_time = (FinishDate.Year - StartDate.Year) * (365 * 1440);
            if (FinishDate.Month < StartDate.Month)
                Total_time += FinishDate.Month * 1440;
            else
                Total_time += (FinishDate.Month - StartDate.Month) * 1440;

            if (FinishDate.Day < StartDate.Day)
                Total_time += FinishDate.Day * 1440;
            else
                Total_time += (FinishDate.Day - StartDate.Day) * 1440;

            if (FinishDate.Hours < StartDate.Hours)
                Total_time += FinishDate.Hours * 60;
            else
                Total_time += (FinishDate.Hours - StartDate.Hours) * 60;
            if (FinishDate.Minutes < StartDate.Minutes)
                Total_time += FinishDate.Minutes;
            else
                Total_time += (FinishDate.Minutes - StartDate.Minutes);

            return Total_time;
        }
        public bool IsArrivingToday()
        {
            return StartDate.Day == FinishDate.Day;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Airplane[] MyAirplanes = ReadAirplaneArray();
            PrintAirplanes(MyAirplanes);
            int max_time, min_time;
            GetAirplaneInfo(MyAirplanes, out max_time, out min_time);
            Console.WriteLine("Максимальний час подорожi = " + max_time + ", Мiнiмальний час подорожi = " + min_time);
            Console.WriteLine("====Сортування по датi початку польоту====");
            PrintAirplanes(SortAirplanesByDate(MyAirplanes));
            Console.WriteLine("====Сортування по тривалостi польоту====");
            PrintAirplanes(SortAirplanesByTotalTime(MyAirplanes));
            Console.ReadKey();
        }

        static Airplane[] ReadAirplaneArray()
        {

            int size_arr;
            Console.WriteLine("Введiть кiлькiсть рейсiв !");
            size_arr = Convert.ToInt32(Console.ReadLine());
            Airplane[] temp_arr = new Airplane[size_arr];

            for (int i = 0; i < size_arr; i++)
            {
                Console.WriteLine("Рейс №-" + (i + 1));
                Console.WriteLine("");

                Console.WriteLine("Введiть назву мiста вiдльоту ");
                temp_arr[i] = new Airplane();
                temp_arr[i].StartCity = Console.ReadLine();
                Console.WriteLine("Введiть назву мiста прильоту ");
                temp_arr[i].FinishCity = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Введiть наступнi данi дати вiдльоту ");
                Console.WriteLine("(цiлочисельними значеннями)");

                Date temp_date_input = new Date();

                Console.WriteLine("Введiть рiк");
                temp_date_input.Year = (Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("Введiть мiсяць");
                temp_date_input.Month = (Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("Введiть день");
                temp_date_input.Day = (Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("Введiть годину");
                temp_date_input.Hours = (Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("Введiть хвилину");
                temp_date_input.Minutes = (Convert.ToInt32(Console.ReadLine()));
                temp_arr[i].StartDate = (temp_date_input);
                Console.WriteLine();

                Date temp_date_out = new Date();

                Console.WriteLine("Введiть наступнi данi дати прильоту ");
                Console.WriteLine("(цiлочисельними значеннями)");
                Console.WriteLine("Введiть рiк");
                temp_date_out.Year = (Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("Введiть мiсяць");
                temp_date_out.Month = (Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("Введiть день");
                temp_date_out.Day = (Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("Введiть годину");
                temp_date_out.Hours = (Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("Введiть хвилину");
                temp_date_out.Minutes = (Convert.ToInt32(Console.ReadLine()));
                temp_arr[i].FinishDate = (temp_date_out);
            }
            return temp_arr;
        }

        static void PrintAirplanes(Airplane[] obj)
        {
            Console.WriteLine("---------------Вивiд данних----------------");
            Console.WriteLine();
            for (int i = 0; i < obj.Length; i++)
            {
                Console.WriteLine("Рейс №" + (i + 1));
                PrintAirplane(obj[i]);
            }

        }
        static void PrintAirplane(Airplane obj)
        {
            Console.WriteLine("Початкове мiсто - " + obj.StartCity);
            Console.WriteLine("Фiнальне мiсти  - " + obj.FinishCity);
            Console.WriteLine("Дата вiдльоту   - " + obj.StartDate.Year + "," + obj.StartDate.Month + "," + obj.StartDate.Day + "," + obj.StartDate.Hours + ":" + obj.StartDate.Minutes + ".");
            Console.WriteLine("Дата прильоту   - " + obj.FinishDate.Year + "," + obj.FinishDate.Month + "," + obj.FinishDate.Day + "," + obj.FinishDate.Hours + ":" + obj.FinishDate.Minutes + ".");
            Console.WriteLine("");
        }
        static void GetAirplaneInfo(Airplane[] obj, out int max_time, out int min_time)
        {
            max_time = obj[0].GetTotalTime();
            min_time = max_time;
            for (int i = 1; i < obj.Length; i++)
            {
                if (max_time < obj[i].GetTotalTime())
                {
                    max_time = obj[i].GetTotalTime();
                }
                else if (min_time > obj[i].GetTotalTime())
                {
                    min_time = obj[i].GetTotalTime();
                }
            }
        }

        static Airplane[] SortAirplanesByDate(Airplane[] obj)
        {
            for (int i = 1; i < obj.Length; i++)
            {
                for (int j = 0; j < obj.Length - i; j++)
                {
                    if (obj[j].StartDate.Year > obj[j].StartDate.Year ||
                        (obj[j].StartDate.Year == obj[j].StartDate.Year && obj[j].StartDate.Month > obj[j + 1].StartDate.Month) ||
                        (obj[j].StartDate.Year == obj[j].StartDate.Year && obj[j].StartDate.Month == obj[j + 1].StartDate.Month && obj[j].StartDate.Day > obj[j + 1].StartDate.Day) ||
                        (obj[j].StartDate.Year == obj[j].StartDate.Year && obj[j].StartDate.Month == obj[j + 1].StartDate.Month && obj[j].StartDate.Day == obj[j + 1].StartDate.Day && obj[j].StartDate.Hours > obj[j + 1].StartDate.Hours) ||
                        (obj[j].StartDate.Year == obj[j].StartDate.Year && obj[j].StartDate.Month == obj[j + 1].StartDate.Month && obj[j].StartDate.Day == obj[j + 1].StartDate.Day && obj[j].StartDate.Hours == obj[j + 1].StartDate.Hours && obj[j].StartDate.Minutes > obj[j + 1].StartDate.Minutes))
                    {
                        Airplane temp_obj;
                        temp_obj = obj[j];
                        obj[j] = obj[j + 1];
                        obj[j + 1] = temp_obj;
                    }
                }
            }
            return obj;
        }

        static Airplane[] SortAirplanesByTotalTime(Airplane[] obj)
        {
            for (int i = 1; i < obj.Length; i++)
            {
                for (int j = 0; j < obj.Length - i; j++)
                {
                    if (obj[j].GetTotalTime() > obj[j + 1].GetTotalTime())
                    {
                        Airplane temp_obj;
                        temp_obj = obj[j];
                        obj[j] = obj[j + 1];
                        obj[j + 1] = temp_obj;
                    }
                }
            }
            return obj;
        }
    }
}
