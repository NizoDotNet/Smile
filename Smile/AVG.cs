using Smile.Model;
using Smile.Model.DTO;

namespace Smile;

public static class AVG
{
    public static List<StudentAndAvg> GetAvgEnterScore(List<Student> students, string semester)
    {
        List<StudentAndAvg> res = new();
        double avg = 0;
        double credits = 0;
        foreach (var stu in students)
        {
            foreach (var sub in stu.Subjects)
            {
                if(sub.Semester == semester && sub.EnterScore != 0)
                {
                    avg += sub.EnterScore * sub.Credit;
                    credits += sub.Credit;
                }
            }
            res.Add(new() { Student = stu, AVG = avg / credits });
        }
        return res;
    }
    public static List<StudentAndAvg> GetAvgEnterScore(List<Student> students)
    {
        List<StudentAndAvg> res = new();
        double avg = 0;
        double credits = 0;
        foreach (var stu in students)
        {
            foreach (var sub in stu.Subjects)
            {
                if (sub.EnterScore != 0)
                {
                    avg += sub.EnterScore * sub.Credit;
                    credits += sub.Credit;
                }
            }
            res.Add(new() { Student = stu, AVG = avg / credits});
        }
        return res;
    }

    public static List<StudentAndAvg> GetAvgOfFinalScore(List<Student> students, string semester)
    {
        List<StudentAndAvg> res = new();
        foreach (var student in students)
        {
            double avg = 0, credits = 0;
            foreach (var subject in student.Subjects)
            {
                if(subject.Semester == semester && subject.FinalScore != 0)
                {
                    avg += subject.FinalScore * subject.Credit;
                    credits += subject.Credit;
                }
            }
            res.Add(new() { AVG = avg / credits, Student = student });
        }
        return res;
    }
    public static List<StudentAndAvg> GetAvgOfFinalScore(List<Student> students)
    {
        List<StudentAndAvg> res = new();
        foreach (var student in students)
        {
            double avg = 0, credits = 0;
            foreach (var subject in student.Subjects)
            {
                if(subject.FinalScore != 0)
                {
                    avg += subject.FinalScore * subject.Credit;
                    credits += subject.Credit;
                }                
            }
            res.Add(new() { AVG = avg / credits, Student = student });
        }
        return res;
    }
    //Test
    public static List<StudentAndAvg> GetAvgOfFinalScore(List<Student> students, Predicate<Subject> predicate)
    {
        List<StudentAndAvg> res = new();
        foreach (var student in students)
        {
            double avg = 0, credits = 0;
            foreach (var subject in student.Subjects)
            {
                if (subject.FinalScore != 0 && predicate(subject))
                {
                    avg += subject.FinalScore * subject.Credit;
                    credits += subject.Credit;
                }
            }
            res.Add(new() { AVG = avg / credits, Student = student });
        }
        return res;
    }
}
