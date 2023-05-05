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

            var AllCompany = from comp in companies
                             select comp;
            Show(AllCompany);

            var FoodCompany = from comp in companies
                              where comp.Name.StartsWith("Food")
                              select comp;
            Show(FoodCompany);

            var Marcketing = from comp in companies
                             where comp.Profile == "Marketing"
                             select comp;
            Show(Marcketing);

            var MarcketingOrIt = from comp in companies
                                 where comp.Profile == "Marketing" || comp.Profile == "IT"
                                 select comp;
            Show(MarcketingOrIt);

            var CountMore100 = from comp in companies
                               where comp.CountWorkers > 100
                               select comp;
            Show(CountMore100);

            var CountRange100And300 = from comp in companies
                                      where comp.CountWorkers >= 100 && comp.CountWorkers <= 300
                                      select comp;
            Show(CountRange100And300);
            var CompanyInLondon = from comp in companies
                                  where comp.address == "London"
                                  select comp;

            Show(CompanyInLondon);
            var NameCEOWhite = from comp in companies
                               where comp.Director.EndsWith("White")
                               select comp;
            Show(NameCEOWhite);

            DateTime date = DateTime.Now;
            var More2Years = from comp in companies
                             where date.Year - comp.date.Year > 2
                             select comp;
            Show(More2Years);

            var More123Days = from comp in companies
                              where date.Date.Year - comp.date.Year >= 1 || date.Date.DayOfYear - comp.date.DayOfYear >= 123
                              select comp;
            Show(More123Days);

            var BlackWhite = from comp in companies
                             where comp.Director.EndsWith("Black") && comp.Name.StartsWith("White")
                             select comp;
            Show(BlackWhite);
        }

        static void Show(IEnumerable<Company> company)
        {
            foreach (var item in company)
            {
                item.Output();
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