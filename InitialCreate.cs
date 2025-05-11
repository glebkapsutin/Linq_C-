using Linq_C_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_C_
{
    public class InitialCreate
    {
        public ICollection<Product> products { get; set; } = new List<Product>();
        public ICollection<Order> orders { get; set; } = new List<Order>();
        public InitialCreate()
        {
            products = new List<Product>
            {
                new Product { Id = 1, Name = "Яблоки", Price = 50.0m, Category = "Фрукты" },
                new Product { Id = 2, Name = "Молоко", Price = 80.0m, Category = "Молочные" },
                new Product { Id = 3, Name = "Бананы", Price = 60.0m, Category = "Фрукты" },
                new Product { Id = 4, Name = "Сыр", Price = 200.0m, Category = "Молочные" },
                new Product { Id = 5, Name = "Хлеб", Price = 30.0m, Category = "Хлебобулочные" }
            };

             orders = new List<Order>
            {
                new Order { Id = 1, ProductId = 1, Quantity = 5, OrderDate = new DateTime(2025, 5, 1) },
                new Order { Id = 2, ProductId = 2, Quantity = 2, OrderDate = new DateTime(2025, 5, 2) },
                new Order { Id = 3, ProductId = 1, Quantity = 3, OrderDate = new DateTime(2025, 5, 3) },
                new Order { Id = 4, ProductId = 4, Quantity = 1, OrderDate = new DateTime(2025, 5, 4) },
                new Order { Id = 5, ProductId = 3, Quantity = 4, OrderDate = new DateTime(2025, 5, 3) }
            };
        }
    }
}
