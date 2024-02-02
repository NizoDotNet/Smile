namespace Smile.Model;

public class Student
{
    public string Name { get; set; }
    public List<Subject> Subjects { get; set; } = new();
}
