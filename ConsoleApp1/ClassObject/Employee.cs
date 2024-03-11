using ConsoleApp1.PrimitiveTests;

namespace ConsoleApp1.ClassObject
{
    public class Employee(string name, int age, DateTime creationDate)
    {
        public static void AutomatedTest()
        {
            Console.WriteLine("TEST INHERITANCE");
            Console.WriteLine();

            while (true)
            {
                int type = Input.GetInt32(TypeValidator, "1 la Nhan vien, 2 la Sinh vien, 3 la Giao vien: ");
                Employee polymorphicHuman = type switch
                {
                    1 => new Employee("", 0, DateTime.Today),
                    2 => new Student("", "", 0, DateTime.Today),
                    // 3
                    _ => new Teacher("", "", 0, DateTime.Today),
                };
                polymorphicHuman.PromptData();
                polymorphicHuman.ShowInfo();
                polymorphicHuman.ExtInfo();

                if (!ExerciseTemplate.TestMore())
                {
                    break;
                }
            }

        }

        static private bool TypeValidator(string? type)
        {
            return ExerciseInt.PositiveValidator(type) && int.Parse(type!) < 4;
        }

        virtual public void PromptData()
        {
            Name = Input.GetString(ExerciseString.Validator, "Nhap ten nhan vien: ");
            Age = Input.GetInt32(ExerciseInt.PositiveValidator, "Nhap tuoi nhan vien: ");
            CreationDate = Input.GetDateTime(ExerciseDateTime.Validator, "Nhap thoi gian tao (DD/MM/YYYY): ");
        }

        public string Name { get; set; } = name;

        public int Age { get; set; } = age;

        public DateTime CreationDate { get; set; } = creationDate;

        virtual public void ShowInfo()
        {
            Console.WriteLine($"Toi ten la {Name}, {Age} tuoi.");
        }
        virtual public void ExtInfo()
        {
            Console.WriteLine($"Toi ten la {Name}, duoc tao ra luc {CreationDate:HH:mm:ss dd/MM/yyyy}.");
        }
    }
}