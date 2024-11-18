using EfCore.Contexts;
using EfCore.Helper.Exceptions;
using EfCore.Models;
using Microsoft.Identity.Client;

namespace EfCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool f = false;
            string operation;


            do
            {
                Console.WriteLine("1-register  , 2- login");
                operation = Console.ReadLine();
                switch (operation)
                {
                    case "1":


                        AddUser();

                        break;
                    case "2":
                        CheckUser();
                        bool f2 = false;

                        do
                        {
                            Console.WriteLine("1-mehsullara bax , 2-sebete bax , 3-exit");
                            string choice = Console.ReadLine();
                            switch (choice)
                            {
                                case "0":
                                    f2 = true;
                                    break;
                                case "1":
                                    using (var query = new AppDbContext())
                                    {
                                        ShowProducts(query);
                                      
                                    }
                                    
                                    break;
                                case "2":
                                    break;
                                case "3":
                                    break;
                                default:
                                    break;

                            }

                        } while (!f2);
                        break;
                    default:
                        break;
                }



            } while (!f);
            static void ShowProducts(AppDbContext ct )
            {
                var products = ct.Products.ToList();
                foreach (var product in products)
                {
                    Console.WriteLine($"'{product.Id}'       ||    '{product.Name}'       ||         '{product.Price}' ");
                }
            }
            //static void AddBaskets(AppDbContext ct)
            //{
            //    Console.WriteLine("Məhsul seçin (0 - geri):");
            //    int productId = int.Parse(Console.ReadLine());

            //    if (productId == 0) return;

            //    var product = ct.Products.FirstOrDefault(x => x.Id == productId);


            //    var basket = new Basket
            //    {
            //        UserId = 
            //        ProductId = productId
            //    };

            //    ct.Baskets.Add(basket);
            //    ct.SaveChanges();

            //    Console.WriteLine("Məhsul səbətə əlavə edildi!");
            //    Console.ReadLine();

            //}
        }

        private static void ShowProducts(AppDbContext query)
        {
            throw new NotImplementedException();
        }

        static void CheckUser()
        {
            Console.WriteLine("Username daxil edin");
            string username = Console.ReadLine();
            Console.WriteLine("parolunuzu daxil edin");
            string password = Console.ReadLine();
            using (AppDbContext db = new AppDbContext())
            {
                var query = db.Users.FirstOrDefault(x => x.Username == username && x.Password == password);
                if (query != null)
                {
                    Console.WriteLine("User founded");
                }
                else { throw new UserNotFoundException("User Doesnt found"); }




            }
        }


        static void Addproduct()
        {
            Console.WriteLine("Elave etmek istediyiniz mehsulun idsini daxil edin");
            string eded = Console.ReadLine();
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


        //using (AppDbContext sql = new AppDbContext())
        //{
        //    sql.Products.Add(new Models.Product
        //    {
        //        Name = "cay",
        //        Price = 2,

        //    });
        //    sql.Products.Add(new Models.Product
        //    {
        //        Name = "kompot",
        //        Price = 1,
        //    });
        //    sql.Products.Add(new Models.Product
        //    {
        //        Name = "sirab",
        //        Price = 3,

        //    });
        //    sql.Products.Add(new Models.Product
        //    {
        //        Name = "kofta",
        //        Price = 15,
        //    });
        //    sql.Products.Add(new Models.Product
        //    {
        //        Name = "qelyan",
        //        Price = 20
        //    });
        //    sql.Products.Add(new Models.Product
        //    {
        //        Name = "kofe",
        //        Price = 7,
        //    });
        //    sql.SaveChanges();
        //}
    }
}
