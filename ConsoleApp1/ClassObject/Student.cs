using ConsoleApp1.PrimitiveTests;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1.ClassObject
{
    public class Student(string major, string name, int age, DateTime creationTime) : Employee(name, age, creationTime)
    {
        public string major = major;

        public override void PromptData()
        {
            Name = Input.GetString(ExerciseString.Validator, "Nhap ten sinh vien: ");
            Age = Input.GetInt32(ExerciseInt.PositiveValidator, "Nhap tuoi sinh vien: ");
            CreationDate = Input.GetDateTime(ExerciseDateTime.Validator, "Nhap thoi gian tao (DD/MM/YYYY): ");
            major = Input.GetString(ExerciseString.Validator, "Nhap chuyen nganh: ");
        }
        public override void ShowInfo()
        {
            Console.WriteLine($"Toi ten la {Name}, {Age} tuoi. Toi la Sinh Vien");
        }
        public override void ExtInfo()
        {
            Console.WriteLine($"Toi la Sinh Vien ten {Name}, hoc chuyen nganh {major}, duoc tao ra luc {CreationDate:HH:mm:ss dd/MM/yyyy}.");
        }
    }
}