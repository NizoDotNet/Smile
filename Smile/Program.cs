using Smile;
using Smile.Model;
using Smile.Parser;
using System.Text;
Console.OutputEncoding = Encoding.UTF8;


Parser parser = new(new ConsoleLogger());

var sts = await parser.ParseStudentsAsync(6358, 6388);
//var sts = parser.ParseStudents(6358, 6388)
//    .Select(s => new Student()
//    {
//        Name = s.Name,
//        Subjects = s.Subjects.Where(c => c.Semester == "P-3").ToList(),
//    })
//    .ToList(); ;
foreach (var student in sts)
{
    Console.WriteLine(student.Name);
    foreach (var sub in student.Subjects)
    {
        Console.WriteLine($"{sub.Name}: {sub.EnterScore} {sub.OutScore}");
    }
}

//var a = AVG.GetAvgOfFinalScore(sts);
//var arrA = a.OrderByDescending(c => c.AVG).ToArray();
//for (int i = 0; i < arrA.Length; i++)
//{
//    Console.WriteLine($"{i + 1}. {arrA[i].Student.Name} - {arrA[i].AVG}");
//}
//Console.ReadLine();