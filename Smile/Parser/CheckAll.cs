namespace Smile.Parser;

public class CheckAll
{
    private Parser parser = new();
    private string URL = "http://tnis.adau.edu.az/forparents/marks.php?studentid=";
    private string subject = "ARK və hüququn əsasları";
    private HashSet<string> _s = new();
    public List<int> CheckAllStudents(int startId, int endId)
    {
        List<int> res = new();
        while(startId <= endId)
        {
            Console.WriteLine($"Parsing {startId}");
            var p = parser.ParseSubjectNameONly(URL, startId);
            if (CheckForSubject.Check(p.Item1, subject)
                && !_s.Contains(p.Item2))
            {
                res.Add(startId);
                _s.Add(p.Item2);
            }
            startId++;
        }
        return res;
    }
}
