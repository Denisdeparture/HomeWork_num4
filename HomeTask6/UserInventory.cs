using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask6
{
    public class UserInventory
    {
        Inventory UserInv;
        public UserInventory()
        {
            UserInv = new Inventory
               (
               new Product() { CategoryProduct = CategoryProduct.Food, NameProduct = "bananas", Price = 50, Quantity = 10 },
               new Product() { CategoryProduct = CategoryProduct.Cosmetic, NameProduct = "pack of napkins", Price = 80, Quantity = 5 }
               );
        }
        public void Start()
        {
               
            string[] actions = 
            {
                "1.Добавить продукт",
                "2.Удалить продукт по ID",
                "3.Вывести список всех продуктов",
                "4.Получить сумму всех продуктов"
            };
            Console.WriteLine("Выберите действие: ");
            foreach(string action in actions ) Console.WriteLine(action);
            switch (Convert.ToUInt32(Console.ReadLine()))
            {
                case 1:
                    UserInv.AddProductInInventory(new Product() { CategoryProduct = TakeMeCategory(), NameProduct = Input("Введите название продукта: "), Price = Convert.ToUInt32(Input("Введите цену на продукт: ")), Quantity = Convert.ToUInt32(Input("Введите количество продукта: ")) });
                    break;
                case 2:
                    UserInv.DeletedProductInInventory(Input("Введите ID продукта: "));
                break;
                case 3:
                    UserInv.AllProductInInventory();
                break;
                case 4:
                    Console.WriteLine($"цена корзины на текущий момент: {UserInv.PriceInventory()}");
                    break;
                default:
                    Console.WriteLine("unknown action");
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
            
            string[] arrayCategory =
            {
                "Еда",
                "Косметика"
            };
            for(int i = 0; i < arrayCategory.Length; i++) Console.WriteLine($"{i + 1}.{arrayCategory[i]}");
            Console.Write("Выберите категорию: ");
            uint j = Convert.ToUInt32(Console.ReadLine()) + 1;
            return (CategoryProduct) ((j <= arrayCategory.Length) ? j : 0);
        }
        
    }
}
