using ConsoleApp1.PrimitiveTests;

namespace ConsoleApp1.ClassObject
{
    public class Teacher(string profession, string name, int age, DateTime creationTime) : Employee(name, age, creationTime)
    {
        public string Profession { get; set; } = profession;


        public override void PromptData()
        {
            Name = Input.GetString(ExerciseString.Validator, "Nhap ten giao vien: ");
            Age = Input.GetInt32(ExerciseInt.PositiveValidator, "Nhap tuoi giao vien (DD/MM/YYYY): ");
            CreationDate = Input.GetDateTime(ExerciseDateTime.Validator, "Nhap thoi gian tao: ");
            Profession = Input.GetString(ExerciseString.Validator, "Nhap bo mon: ");
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Toi la Giao Vien, {Age} tuoi, toi ten la {Name}.");
        }

        public override void ExtInfo()
        {
            Console.WriteLine($"Toi la Giao Vien ten {Name}, thuoc bo mon {Profession}, duoc tao ra luc {CreationDate:HH:mm:ss dd/MM/yyyy}.");
        }
    }
}