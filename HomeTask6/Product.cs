using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
enum CategoryProduct
{
    Unknow,
    Food,
    Cosmetic,
    
}
namespace HomeTask6
{
    class Product
    {
        public uint Quantity { get; set; }
        public double Price { get; set; }
        public string? NameProduct { get; set; }
        public string? Identity { get; private set; }
        public CategoryProduct CategoryProduct {  get; set; }
        public Product()
        {
            const int MaxValueIDCode = 10;
            foreach(int i in Enumerable.Range(0, MaxValueIDCode)) Identity += new Random().Next(0,9).ToString();
        }
    }
}
