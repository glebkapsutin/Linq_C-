using Linq_C_.Models;
using System;
using System.Security.Cryptography.X509Certificates;
namespace Linq_C_
{


    class Program
    {


        static void Main()
        {


            GroupProducts();




        }
        public static void ProductsCountPrice40()
        {
            var Base = new InitialCreate();
            var products = Base.products
                              .Where(x => x.Category == "Фрукты" && x.Price > 40)
                              .Select(p => new { p.Name, NewPrice = p.Price * 1.05m });
            foreach (var product in products)
            {
                Console.WriteLine($"Название: {product.Name}, Новая цена: {product.NewPrice:F2}");
            }
        }
        public static void SortedProducts()
        {
            var Base = new InitialCreate();
            var products = Base.products
                                .OrderByDescending(x => x.Price)
                                .ThenBy(x => x.Name)
                                .Take(3);
            foreach (var product in products)
            {
                Console.WriteLine($"Название: {product.Name}, цена: {product.Price:F2}");
            }

        }
        public static void GroupProducts()
        {
            var Base = new InitialCreate();
            var products = Base.products
                .GroupBy(x => x.Category)
                .Select(g => new { g.Key, Count = g.Count(), TotalPrice = g.Sum(p => p.Price) })
                .OrderByDescending(g => g.Count);


            foreach (var product in products)
            {
                Console.WriteLine(product);
            }

        }


    }


}