using System.Security.Cryptography.X509Certificates;

public class Student: Employee
{
    public Student(string major, string name, int age, DateTime creationTime) : base(name, age, creationTime) { 
        this.major = major;
    }

    public string major;

    public override void promptData()
    {
        name = Input.GetString(ExerciseString.validator, "Nhap ten sinh vien: ");
        age = Input.GetInt32(ExerciseInt.positiveValidator, "Nhap tuoi sinh vien: ");
        creationDate = Input.GetDateTime(ExerciseDateTime.validator, "Nhap thoi gian tao (DD/MM/YYYY): ");
        major = Input.GetString(ExerciseString.validator, "Nhap chuyen nganh: ");
    }
    public override void ShowInfo()
    {
        Console.WriteLine($"Toi ten la {name}, {age} tuoi. Toi la Sinh Vien");
    }
    public override void ExtInfo()
    {
        Console.WriteLine($"Toi la Sinh Vien ten {name}, hoc chuyen nganh {major}, duoc tao ra luc {creationDate.ToString("HH:mm:ss dd/MM/yyyy")}.");
    }
}
