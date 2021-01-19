using System;
using System.Linq;
using System.Collections.Generic;

namespace SoftUni_Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, int> results = new Dictionary<string, int>();
            Dictionary<string, int> submissions = new Dictionary<string, int>();

            while (input != "exam finished")
            {
                string[] cmdArgs = input.Split("-");
                string userName = cmdArgs[0];

                if (cmdArgs.Length > 2)
                {
                    string language = cmdArgs[1];
                    int points = int.Parse(cmdArgs[2]);

                    if (!results.ContainsKey(userName))
                    {
                        results.Add(userName, points);
                    }
                    else
                    {
                        if (results[userName] < points)
                        {
                            results[userName] = points;
                        }
                    }
                    if (!submissions.ContainsKey(language))
                    {
                        submissions.Add(language, 0);
                    }
                    submissions[language]++;
                }
                else
                {
                    results.Remove(userName);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Results:");
            foreach (var currentStudent in results.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{currentStudent.Key} | { currentStudent.Value}");
            }
            Console.WriteLine($"Submissions:");

            foreach (var item in submissions.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
    }
}
