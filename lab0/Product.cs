using System;

namespace VendingMachineApp
{
    // Класс, описывающий товар в автомате
    public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        public Product(string name, int price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }
    }
}


