using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdTask
{
    internal class Ex3
    {
        static void Main(string[] args)
        {
            Worker[] worker1 = {
                new Worker("Egor Nikitenko", "Food", "96-57-04-32", "egor@gmail.com", 1000),
                new Worker("Sima Nikitenko", "Managment", "23-40-75-69", "sima@gmail.com", 2000),
            };
            Worker[] worker2 = {
                new Worker("Egor Nikitenko", "Food", "96-57-04-32", "egor@gmail.com", 2000),
                new Worker("Sima Nikitenko", "Managment", "23-40-75-69", "sima@gmail.com", 1000),
            };
            Worker[] worker3 = {
                new Worker("Lionel Nikitenko", "Food", "96-57-04-32", "egor@gmail.com", 1000),
                new Worker("Sima Nikitenko", "Managment", "23-40-75-69", "disima@gmail.com", 2000),
            };

            Company[] companies = {
                new Company("ATB", "06.05.2023", "Marketing", "Egor Nikitenko" , 200, "Ukraine", worker1),
                new Company("Pyzata Hata Food", "06.05.2020", "Delivery", "Waken White", 150, "London", worker2),
                new Company("White", "06.05.2019", "Marketing", "Sima Black", 50, "London", worker3),
            };

            var AllWorkersToCompany = from comp in companies
                                      from worker in comp.workers
                                      select worker;
            Output(AllWorkersToCompany);


            var MoreThen = from comp in companies
                           from worker in comp.workers
                           where worker.Salary > 2000
                           select worker;
            Output(MoreThen);

            var AllManager = from comp in companies
                             from worker in comp.workers
                             where worker.Job == "Managment"
                             select worker;
            Output(AllManager);

            var StatrWith_23 = from comp in companies
                               from worker in comp.workers
                               where worker.Phone.StartsWith("23")
                               select worker;
            Output(StatrWith_23);

            var StartWith_di = from comp in companies
                               from worker in comp.workers
                               where worker.Email.StartsWith("di")
                               select worker;
            Output(StartWith_di);

            var NameLionel = from comp in companies
                             from worker in comp.workers
                             where worker.Name.StartsWith("Lionel")
                             select worker;
            Output(NameLionel);
        }

        static void Output(IEnumerable<Worker> companies)
        {
            foreach (var comp in companies)
            {
                comp.Output();
            }
        }

        class Worker
        {
            public string Name { get; set; }
            public string Job { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
            public int Salary { get; set; }

            public Worker(string Names, string Jobs, string Phone, string Email, int Salary)
            {
                this.Name = Names;
                this.Job = Jobs;
                this.Phone = Phone;
                this.Email = Email;
                this.Salary = Salary;

            }

            public void Output()
            {
                Console.WriteLine("Name: " + Name);
                Console.WriteLine("Job: " + Job);
                Console.WriteLine("Number: " + Phone);
                Console.WriteLine("Email: " + Email);
                Console.WriteLine("Salary: " + Salary);
            }



        }

        class Company
        {
            public string Name { get; set; }
            public string Profile { get; set; }
            public DateTime date { get; set; }
            public string Director { get; set; }
            public int CountWorkers { get; set; }
            public Worker[] workers { get; set; }
            public string address { get; set; }


            public Company(string Names, string date, string profile, string DirectorName, int countWorkers, string address, Worker[] workers)
            {
                Name = Names;
                Profile = profile;
                this.date = DateTime.Parse(date);
                this.address = address;
                Director = DirectorName;
                CountWorkers = countWorkers;
                this.workers = workers;
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