using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask6
{
    class Inventory 
    {
        private List<ProductStandart> listProduct;
        public Inventory(params ProductStandart[] products)
        {
            listProduct = products.ToList();
        }
       
        public double PriceInventory()
        {
            double totalPrice = 0;
            foreach(var product in listProduct)
            {
                totalPrice += product.Price;
            }
            return totalPrice;
        }
        public void AllProductInInventory()
        {
            foreach(var product in listProduct) Console.WriteLine($"имя продукта:{product.NameProduct} \nцена продукта: {product.Price}\nиндетификатор продукта: {product.Identity}\nколичество: {product.Quantity}\n ");
            Console.WriteLine();
        }
        public void DeletedProductInInventory(string ID) => listProduct = listProduct.Where(x => x.Identity != ID).ToList();
        public void AddProductInInventory(Product product) => listProduct.Add(product);
    }
    
}
