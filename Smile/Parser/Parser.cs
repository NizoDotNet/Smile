using HtmlAgilityPack;
using Smile.Model;
using System.Collections.Concurrent;
namespace Smile.Parser;

public class Parser
{
    private string url = "http://tnis.adau.edu.az/forparents/marks.php?studentid=";
    private ILogger _logger;
    
    public Parser(ILogger logger) 
    {
        _logger = logger;
    }
    public bool ShowLogs { get; set; } = false;
    public (HtmlNodeCollection, string) ParseSubjectNameOnly(string URL, int id) => ParseSubjectNameOnly(URL+id);
    
    public (HtmlNodeCollection, string) ParseSubjectNameOnly(string URL)
    {
        HtmlWeb htmlWeb = new HtmlWeb();
        var htDoc = htmlWeb.Load(URL);
        var nodes = htDoc.DocumentNode.SelectNodes("//table[@id='datatable']/tbody/tr/td[2]");
        string s = htDoc.DocumentNode.SelectSingleNode("//section[@class='marks']/h2").InnerText;
        return (nodes, s);
    }
    public Student ParseStudent(int id)
    {
        Student student = new();
        HtmlWeb htmlWeb = new();

        var htDoc = htmlWeb.Load(url+id);
        student.Name = htDoc.DocumentNode.SelectSingleNode("//section[@class='marks']/h1").InnerText;
        var subjects = htDoc.DocumentNode.SelectNodes("//table[@id='datatable']/tbody/tr");
        foreach (var subject in subjects)
        {
            if(subject.ChildNodes.Count <= 0) continue;
            Subject s = new();
            s.Name = subject.ChildNodes[3].InnerText;
            s.Semester = subject.ChildNodes[5].InnerText;
            try
            {
                s.Credit = int.Parse(subject.ChildNodes[7].InnerText);
                s.EnterScore = int.Parse(subject.ChildNodes[9].InnerText);
                s.OutScore = int.Parse(subject.ChildNodes[11].InnerText);
                s.FinalScore = int.Parse(subject.ChildNodes[13].InnerText);
            }
            catch(Exception ex) 
            {
                if(ShowLogs)
                {
                    _logger.LogError(ex.Message);                
                }
            }
            student.Subjects.Add(s);
        }
        return student;
    }

    public async Task<Student> ParseStudentAsync(int id)
    {
        Student student = new();
        HtmlWeb htmlWeb = new();

        var htDoc = await htmlWeb.LoadFromWebAsync(url + id);
        student.Name = htDoc.DocumentNode.SelectSingleNode("//section[@class='marks']/h1").InnerText;
        var subjects = htDoc.DocumentNode.SelectNodes("//table[@id='datatable']/tbody/tr");
        foreach (var subject in subjects)
        {
            if (subject.ChildNodes.Count <= 0) continue;
            Subject s = new();
            s.Name = subject.ChildNodes[3].InnerText;
            s.Semester = subject.ChildNodes[5].InnerText;
            try
            {
                s.Credit = int.Parse(subject.ChildNodes[7].InnerText);
                s.EnterScore = int.Parse(subject.ChildNodes[9].InnerText);
                s.OutScore = int.Parse(subject.ChildNodes[11].InnerText);
                s.FinalScore = int.Parse(subject.ChildNodes[13].InnerText);
            }
            catch (Exception ex)
            {
                if (ShowLogs)
                {
                    _logger.LogError(ex.Message);
                }
            }
            student.Subjects.Add(s);
        }
        return student;
    }

    public IEnumerable<Student> ParseStudents(int firstId, int lastId)
    {
        while(firstId <= lastId)
        {
            yield return ParseStudent(firstId);
            firstId++;
        }
    }

    public async Task<ConcurrentBag<Student>> ParseStudentsAsync(int firstId, int lastId)
    {
        ConcurrentBag<Student> students = new();
        while (firstId <= lastId)
        {
            var student = await ParseStudentAsync(firstId);
            students.Add(student);
            firstId++;
        }
        return students;
    }

}
