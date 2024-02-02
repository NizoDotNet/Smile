using System.Xml.Linq;

namespace Smile.Model;

public class Subject
{
    public string Name { get; set; }
    public int Credit { get; set; }
    public string Semester { get; set; }
    public int EnterScore { get; set; }
    public int OutScore { get; set; }
    public int FinalScore { get; set; }

}

public static class ExMethod
{
    public static void Print(this Subject s)
    {
        Console.WriteLine($"Name - {s.Name}");
        Console.WriteLine($"{nameof(s.Credit)} - {s.Credit}");
        Console.WriteLine($"{nameof(s.Semester)}  -  {s.Semester}");
        Console.WriteLine($"{nameof(s.EnterScore)}  -  {s.EnterScore}");
        Console.WriteLine($"{nameof(s.OutScore)}   -   {s.OutScore}");
        Console.WriteLine($"{nameof(s.FinalScore)}   -   {s.FinalScore}");

    }
}

