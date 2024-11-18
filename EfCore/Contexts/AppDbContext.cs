using EfCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;DataBase=UserEF; TRusted_Connection=True;TrustServerCertificate=true ");
            base.OnConfiguring(optionsBuilder);
        }

        static void AddUser()
        {
            Console.WriteLine("adinizi daxil edin");
            string FirstName = Console.ReadLine();
            Console.WriteLine("Soyadinizi daxil edin");
            string SurName = Console.ReadLine();
            Console.WriteLine("Istifadeci adinizi daxil edin");
            string UserName = Console.ReadLine();
            Console.WriteLine("Passwordunuzu daxil edin");
            string passWord = Console.ReadLine();
            using (AppDbContext sql = new AppDbContext())
            {


                sql.Users.Add(new Models.User
                {
                    Name = FirstName,
                    Surname = SurName,
                    Username = UserName,
                    Password = passWord

                });
                sql.SaveChanges();
                Console.WriteLine("User registered succesfully");
            }

        }
    }
}

