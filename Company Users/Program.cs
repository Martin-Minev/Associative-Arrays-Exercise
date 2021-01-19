using System;
using System.Linq;
using System.Collections.Generic;

namespace Company_Users
{                                         // only 37/100
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            SortedDictionary<string, List<string>> companyAndEmployees = new SortedDictionary<string, List<string>>();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] command = input.Split(" -> ");
                string company = command[0];
                string employeeID = command[1];

                if (!companyAndEmployees.ContainsKey(company))
                {
                    companyAndEmployees.Add(company, new List<string>());
                    companyAndEmployees[company].Add(employeeID);
                }
                //Only 37/100
                if (companyAndEmployees[company][0] != employeeID)
                {
                    companyAndEmployees[company].Add(employeeID);
                }
            }
            foreach (var item in companyAndEmployees)
            {
                Console.WriteLine($"{item.Key}");
                foreach (var value in item.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {value}");
                }
            }
        }
    }
}
