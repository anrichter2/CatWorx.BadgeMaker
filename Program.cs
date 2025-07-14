// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatWorx.BadgeMaker
{
    class Program
    {
        async static Task Main(string[] args)
        {
            Console.Write("Type Y to download employees from API or N to enter employee data manually: ");
            string response = Console.ReadLine() ?? "";
            List<Employee> employees = new List<Employee>();
            if (response == "Y")
            {
                employees = await PeopleFetcher.GetFromApi();
            }
            else
            {
                employees = PeopleFetcher.GetEmployees();
            }
            Util.PrintEmployees(employees);
            Util.MakeCSV(employees);
            await Util.MakeBadges(employees);
        }
    }
}