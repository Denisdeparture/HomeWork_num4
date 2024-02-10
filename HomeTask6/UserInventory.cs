using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask6
{
    public class UserInventory
    {
        private const int MaxQuanitityCategory = 2;
        public void Start()
        {
               Inventory FirstInventory = new Inventory
               (
               new Product() { CategoryProduct = CategoryProduct.Food, NameProduct = "bananas", Price = 50, Quantity = 10},
               new Product() { CategoryProduct = CategoryProduct.Cosmetic, NameProduct = "pack of napkins", Price = 80, Quantity = 5}
               );
            string[] actions = 
            {
                "1.Добавить продукт",
                "2.Удалить продукт по ID",
                "3.Вывести список всех продуктов",
                "4.Получить сумму всех продуктов"
            };
            Console.Write("Выберите действие: ");
            foreach(string action in actions ) Console.WriteLine(action);
            switch (Convert.ToUInt32(Console.ReadLine()))
            {
                case 1:
                    
                    FirstInventory.AddProductInInventory(new Product() {CategoryProduct = TakeMeCategory() } );
                    break;
            }

        }
        private string Input(string message)
        {
            Console.Write(message);
            return Console.ReadLine() ?? throw new NullReferenceException();
        }
        private CategoryProduct TakeMeCategory()
        {
            Console.Write("Выберите категорию: ");
            string[] arrayCategory =
            {
                "1.Еда"
            };
            for(int i = 0; i < MaxQuanitityCategory; i++) Console.WriteLine($"{i}.{CategoryProduct}");
        }
        
    }
}
