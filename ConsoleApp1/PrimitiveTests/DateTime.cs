using System.Data;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp1.PrimitiveTests
{
    public class ExerciseDateTime
    {
        public static void AutomatedTest()
        {
            Console.WriteLine("DATETIME TEST");
            DateTime datetime;


            datetime = DateTime.Today;
            Console.WriteLine($"1.1: Hom nay la {dayName[datetime.DayOfWeek]}, thang {datetime.Month}, nam {datetime.Year}");
            Console.WriteLine();

            Console.WriteLine("1.2: In ra ngay duoc nhap");
            datetime = Input.GetDateTime(Validator);
            Console.WriteLine($"Hom nay la {dayName[datetime.DayOfWeek]}, thang {datetime.Month}, nam {datetime.Year}");
            Console.WriteLine();

            Console.WriteLine("1.3: In ra ngay hom sau");
            datetime = Input.GetDateTime(Validator).AddDays(1);
            Console.WriteLine($"Hom sau la {dayName[datetime.DayOfWeek]}, thang {datetime.Month}, nam {datetime.Year}");
            Console.WriteLine();


            Console.WriteLine("1.4: In ra ngay hom qua");
            datetime = Input.GetDateTime(Validator).AddDays(-1);
            Console.WriteLine($"Hom qua la {dayName[datetime.DayOfWeek]}, thang {datetime.Month}, nam {datetime.Year}");
            Console.WriteLine();

            Console.WriteLine("1.5: Cho biet ngay duoc nhap la tuong lai, hien tai, hay qua khu.");
            datetime = Input.GetDateTime(Validator);

            var diffFromNow = datetime.CompareTo(DateTime.Now.Date);

            if (diffFromNow > 0)
            {
                Console.WriteLine("Ngay tuong lai");
            }
            else if (diffFromNow == 0)
            {
                Console.WriteLine("Ngay hom nay");
            }
            else
            {
                Console.WriteLine("Ngay qua khu");
            }
            Console.WriteLine();

            Console.WriteLine("1.6: In ra du the loai format ngay.");
            datetime = Input.GetDateTime(Validator);
            Console.WriteLine($"Ngay/Thang/Nam: {datetime.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Nam/Thang/Ngay: {datetime.ToString("yyyy/MM/dd")}");
            Console.WriteLine($"Thang/Nam: {datetime.ToString("MM/yyyy")}");
            Console.WriteLine($"Thang-Nam: {datetime.ToString("MM-yyyy")}");
            Console.WriteLine();

            Console.WriteLine("1.7: In ra 10 ngay truoc la thu may.");
            datetime = Input.GetDateTime(Validator).AddDays(-10);
            Console.WriteLine($"{datetime:dd/MM/yyyy} la {dayName[datetime.DayOfWeek]}");
            Console.WriteLine();


            Console.WriteLine("1.8: In ra cuoi thang nay la thu may.");
            datetime = GetLastDayOfMonth(Input.GetDateTime(Validator));
            Console.WriteLine($"{datetime:dd/MM/yyyy} la {dayName[datetime.DayOfWeek]}");
            Console.WriteLine();

            Console.WriteLine("1.9: In ra cuoi nam nay la thu may.");
            datetime = GetLastDayOfYear(Input.GetDateTime(Validator));
            Console.WriteLine($"{datetime:dd/MM/yyyy} la {dayName[datetime.DayOfWeek]}");
            Console.WriteLine();

            Console.WriteLine("1.10: In ra hai ngay cach nhau bao nhieu ngay.");
            datetime = Input.GetDateTime(Validator);
            var datetime2 = Input.GetDateTime(Validator);
            Console.WriteLine($"{datetime2:dd/MM/yyyy} cach {datetime:  dd/MM/yyyy} {datetime2.Subtract(datetime).Days} ngay.");
            Console.WriteLine();

        }


        public static DateTime GetLastDayOfMonth(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, DateTime.DaysInMonth(dateTime.Year, dateTime.Month));
        }

        public static DateTime GetLastDayOfYear(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, 12, 31);
        }

        public static bool Validator(string? s)
        {
            var isDateTime = DateTime.TryParseExact(s,
                "d/M/yyyy",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out _);
            if (!isDateTime)
            {
                Console.WriteLine("Ngay thang khong dung dinh dang");
            }
            return isDateTime;
        }

        private static Dictionary<DayOfWeek, string> dayName = new()
        {
            [DayOfWeek.Sunday] = "chu nhat",
            [DayOfWeek.Monday] = "thu hai",
            [DayOfWeek.Tuesday] = "thu ba",
            [DayOfWeek.Wednesday] = "thu tu",
            [DayOfWeek.Thursday] = "thu nam",
            [DayOfWeek.Friday] = "thu sau",
            [DayOfWeek.Saturday] = "thu bay",
        };
    }
}