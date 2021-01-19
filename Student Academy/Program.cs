using System;
using System.Linq;
using System.Collections.Generic;

namespace Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();
            for (int i = 0; i < n; i++)
            {
                string studentName = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!students.ContainsKey(studentName))
                {
                    students.Add(studentName, new List<double>());
                }

                students[studentName].Add(grade);
            }
            Console.WriteLine(string.Join($"{Environment.NewLine}", students
                .Where(x => (x.Value.Sum() / x.Value.Count) >= 4.50)
                .OrderByDescending(x => x.Value.Sum() / x.Value.Count)
                .Select(x => $"{x.Key} -> {x.Value.Sum() / x.Value.Count():F2}")));
        }
    }
}
