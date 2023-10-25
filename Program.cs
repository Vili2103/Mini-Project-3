using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;


internal class Program
{
    public static Dictionary<string, double> studentGrades = new Dictionary<string, double>()
        {
            {"Ivan",98}, {"Georgi",56}, {"Petkan",23}, {"Ivana",100}, {"Vyara",100}, {"Todor",99}
        };

    public static Dictionary<string, string> studentCourses = new Dictionary<string, string>()
        {
            {"Ivan","Mathematics"}, {"Petkan","Informatics"}, {"Georgi","Entrepreneurship"}, {"Vyara","Informatics"},
            {"Todor","Mathematics" }, {"Ivana","Entrepreneurship"}
        };

    public static Dictionary<string, int> courseHours = new Dictionary<string, int>()
        {
            {"Mathematics",100 }, {"Entrepreneurship",37}, {"Informatics",39}
        };

    public static Dictionary<string, int> studentHours = new Dictionary<string, int>();

    static void Main(string[] args)
    {
        foreach (KeyValuePair<string, double> student in studentGrades)
        {
            string course = studentCourses[student.Key];
            Console.WriteLine($"{student.Key} - {courseHours[course]}");
            studentHours.Add(student.Key, courseHours[course]);
        }

        findDuplicateElementsInDict(studentGrades);

    }
    public static void AddNewStudent(string studentName, double grade, string course)
    {
        try
        {
            studentGrades.Add(studentName, grade);
            studentCourses.Add(studentName, course);
        }
        catch
        {
            Console.WriteLine("Student with the same name already exists.");
        }
    }
    public static void RemoveStudent(string studentName)
    {
        try
        {
            studentGrades.Remove(studentName);
            studentCourses.Remove(studentName);
        }
        catch
        {
            Console.WriteLine("There is no student with this name.");
        }
    }
    public static double avgGrade()
    {
        double avg = 0;
        foreach (var student in studentGrades)
        {
            avg += student.Value;
        }
        return avg / studentGrades.Count();
    }

    public static void findDuplicateElements(Dictionary<string, double> dict1, Dictionary<string, double> dict2)
    {
        foreach (KeyValuePair<string, double> kvp in dict1)
        {
            if (dict2.ContainsKey(kvp.Key) && dict2[kvp.Key] == dict1[kvp.Key])
                Console.WriteLine($"Both dictionaries contain the Key Value Pair {kvp.Key} {kvp.Value}");
            else if (dict2.ContainsKey(kvp.Key))
                Console.WriteLine($"Both dictionaries contain the key {kvp.Key}");
            else if (dict2.ContainsValue(kvp.Value))
                Console.WriteLine($"Both dictionaries contain the value {kvp.Value}");

        }
    }

    public static void findDuplicateElementsInDict(Dictionary<string, double> dict)
    {
        if (dict.Values.Distinct().Count() == dict.Count())
            Console.WriteLine("There are no duplicates in the given dictionary");
        else
        {
            Console.WriteLine($"There are {dict.Distinct().Count() - dict.Values.Distinct().Count()} repeating element(s)");

            var result = from x in dict group x by x.Value into g where g.Distinct().Count() > 1 select g;
            foreach (var x in result)
            {
                var sameValue = (from z in x select z.Key + "").ToList();
                foreach (var z in sameValue)
                {
                    Console.WriteLine($"{z}, {x.Key}");
                }
            }

        }

    }

}





