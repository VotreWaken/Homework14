using System.Collections.Generic;
using System.Linq;
using System;

namespace Homework14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Company[] companies = {
                new Company("ATB", "06.05.2023", "Marketing", "Egor Nikitenko" , 200, "Ukraine"),
                new Company("Pyzata Hata Food", "06.05.2020", "Delivery", "Waken White", 150, "London"),
                new Company("White", "06.05.2019", "Marketing", "Sima Black", 50, "London"),
            };

            var AllCompany = companies.Select(x => x);

            var FoodCompany = companies.Where(x => x.Name.StartsWith("Food")).Select(x => x);

            var Marcketing = companies.Where(x => x.Profile == "Marketing").Select(x => x);

            var MarcketingOrIt = companies.Where(x => x.Profile == "Marketing" || x.Profile == "IT").Select(x => x);

            var CountMore100 = companies.Where(x => x.CountWorkers > 100).Select(x => x);

            var CountRange100And300 = companies.Where(x => x.CountWorkers >= 100 && x.CountWorkers <= 300).Select(x => x);

            var CompanyInLondon = companies.Where(x => x.address == "London").Select(x => x);

            var NameCEOWhite = companies.Where(x => x.Director.EndsWith("White")).Select(x => x);

            DateTime date = DateTime.Now;
            var More2Years = companies.Where(x => date.Year - x.date.Year > 2).Select(x => x);

            var More123Days = companies.Where(x => date.Date.Year - x.date.Year >= 1 || date.Date.DayOfYear - x.date.DayOfYear >= 123).Select(x => x);

            var BlackWhite = companies.Where(x => x.Director.EndsWith("Black") && x.Name.StartsWith("White")).Select(x => x);
        }

        static void Output(IEnumerable<Company> companies)
        {
            foreach (var comp in companies)
            {
                comp.Output();
                Console.WriteLine();
            }
        }

        class Company
        {
            public string Name { get; set; }
            public string Profile { get; set; }
            public DateTime date { get; set; }
            public string Director { get; set; }
            public int CountWorkers { get; set; }
            public string address { get; set; }


            public Company(string Names, string date, string profile, string DirectorName, int countWorkers, string address)
            {
                Name = Names;
                Profile = profile;
                this.date = DateTime.Parse(date);
                this.address = address;
                Director = DirectorName;
                CountWorkers = countWorkers;
            }

            public void Output()
            {
                Console.WriteLine("Name: " + Name);
                Console.WriteLine("Profile: " + Profile);
                Console.WriteLine("Date: " + date.ToShortDateString());
                Console.WriteLine("Address: " + address);
                Console.WriteLine("Director: " + Director);
                Console.WriteLine("Workers: " + CountWorkers);

            }


        }

    }
}