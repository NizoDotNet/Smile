using Smile;
using Smile.Model;
using Smile.Parser;
using System.Text;
Console.OutputEncoding = Encoding.UTF8;


Parser parser = new();
var sts = parser.ParseStudents(6358, 6387);
Console.WriteLine("Parsing Completed");
List<Student> notZerbeciler = new List<Student>();
foreach (var student in sts)
{
    Console.WriteLine(student.Name);
    foreach (var sub in student.Subjects)
    {
        if (sub.FinalScore != 0 && sub.FinalScore < 71 && sub.Semester == "P-2")
        {
            notZerbeciler.Add(student);
            break;
        }
    }
}

var a = AVG.GetAvgOfFinalScore(sts, c => c.Semester == "P-2");
var arrA = a.OrderByDescending(c => c.AVG).ToArray();
for (int i = 0; i < arrA.Length; i++)
{
    Console.WriteLine($"{i + 1}. {arrA[i].Student.Name} - {arrA[i].AVG}");
}
Console.ReadLine();