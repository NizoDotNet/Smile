using Smile;
using Smile.Model;
using Smile.Parser;
using System.Diagnostics;
using System.Text;
Console.OutputEncoding = Encoding.UTF8;

Stopwatch stopwatch = new();
Parser parser = new(new ConsoleLogger());

stopwatch.Start();




var sts = parser.ParseStudents(6358, 6388);
foreach (var student in sts)
{
    Console.WriteLine(student.Name);
    foreach (var sub in student.Subjects)
    {
        //Console.WriteLine($"{sub.Name}: {sub.EnterScore} {sub.OutScore}");
    }
}

stopwatch.Stop();
Console.WriteLine(stopwatch.Elapsed.TotalSeconds);


stopwatch.Restart();
var tasks = new List<Task<Student>>();
for (int i = 6358; i <= 6388; i++)
{
    tasks.Add(parser.ParseStudentAsync(i));
}
sts = await Task.WhenAll(tasks);
foreach (var student in sts)
{
    //Console.WriteLine(student.Name);
    foreach (var sub in student.Subjects)
    {
        //Console.WriteLine($"{sub.Name}: {sub.EnterScore} {sub.OutScore}");
    }
}
stopwatch.Stop();

Console.WriteLine(stopwatch.Elapsed.TotalSeconds);

//var a = AVG.GetAvgOfFinalScore(sts);
//var arrA = a.OrderByDescending(c => c.AVG).ToArray();
//for (int i = 0; i < arrA.Length; i++)
//{
//    Console.WriteLine($"{i + 1}. {arrA[i].Student.Name} - {arrA[i].AVG}");
//}
//Console.ReadLine();