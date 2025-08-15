using Linq_C_.Models;
using System;
using System.Security.Cryptography.X509Certificates;
namespace Linq_C_
{


    class Program
    {


        static void Main()
        {


            AnalyzeOrdersByDate();


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
        public static void JoinOrderAndProducts()
        {
            var Base = new InitialCreate();
            var products = Base.products;

            var result = Base.orders.Join(
                products,
                o => o.ProductId,
                p => p.Id,
                (o, p) => new { Order = o, Products = p }



            ).Select(g => new { g.Products.Name, g.Order.Quantity, TotalPrice = g.Order.Quantity * g.Products.Price });
            int count = 1;
            foreach (var item in result)
            {
                Console.WriteLine($"{count}  Название: {item.Name}\tКоличество : {item.Quantity}\tОбщая цена: {item.TotalPrice}");
                count += 1;
            }
        }

        public static void AnyAllOrderAndProducts()
        {
            var Base = new InitialCreate();

            var products = Base.products;
            bool check = Base.orders.Any(x=>x.Quantity > 4);

            var ProductResult = products
                        .GroupBy(x=> x.Category)
                        .Where(g=> g.All(x=>x.Price > 50 ))
                        .Select(g=> g.Key)
                        .ToList();
            
            Console.WriteLine($"Есть заказы с количеством > 4:{check}");
            foreach (var product in ProductResult)
            {
                Console.WriteLine(product);
            }

                        
        }
        public static void AnalyzeOrdersByDate()
        {
            var Base = new InitialCreate();
 
            var result = Base.orders
                .Join( Base.products,
                o => o.ProductId,
                p => p.Id,
                (o, p) => new { Order = o, Products = p })
                .GroupBy(x=> x.Order.OrderDate)
                .Select(g => new
                {
                    Date = g.Key,
                    TotalQuantity = g.Sum(x => x.Order.Quantity),
                    ProductNames = string.Join(", ",g.Select(x => x.Products.Name).Distinct().OrderBy(name => name))
                })
                .OrderByDescending(g => g.Date);
            
            foreach (var item in result)
            {
                Console.WriteLine($"Дата: {item.Date:dd.MM.yyyy}, Количество: {item.TotalQuantity}, Продукты: {item.ProductNames}");
            }
        }

    }


}