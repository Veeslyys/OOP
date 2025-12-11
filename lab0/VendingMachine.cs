using System;
using System.Collections.Generic;

namespace VendingMachineApp
{
    // Класс вендингового автомата
    public class VendingMachine
    {
        private readonly List<Product> _products = new List<Product>();
        private int _insertedAmount = 0;
        private int _collectedFunds = 0;
        private readonly int[] _allowedCoins = new[] { 1, 2, 5, 10 };

        public VendingMachine()
        {
            _products.Add(new Product("Вода", 25, 5));
            _products.Add(new Product("Сок", 45, 4));
            _products.Add(new Product("Шоколад", 60, 3));
            _products.Add(new Product("Чипсы", 50, 6));
        }

        public void ShowProducts()
        {
            Console.WriteLine("\nДоступные товары:");
            for (int i = 0; i < _products.Count; i++)
            {
                Product p = _products[i];
                Console.WriteLine($"{i + 1}. {p.Name} — {p.Price} руб. (остаток: {p.Quantity})");
            }
            Console.WriteLine($"\nВнесено: {_insertedAmount} руб.");
        }

        public void InsertCoin()
        {
            Console.WriteLine("\nВведите номинал монеты (1, 2, 5 или 10). Для отмены введите 0:");
            int coin = ReadInt();
            if (coin == 0)
            {
                Console.WriteLine("Внесение монеты отменено.");
                return;
            }

            bool isAllowed = false;
            foreach (int allowed in _allowedCoins)
            {
                if (coin == allowed)
                {
                    isAllowed = true;
                    break;
                }
            }

            if (!isAllowed)
            {
                Console.WriteLine("Такой монеты автомат не принимает. Попробуйте снова.");
                return;
            }

            _insertedAmount += coin;
            Console.WriteLine($"Текущая сумма: {_insertedAmount} руб.");
        }

        public void SelectProduct()
        {
            Console.WriteLine("\nВведите номер товара, который хотите купить (или 0 для отмены):");
            int choice = ReadInt();
            if (choice == 0)
            {
                Console.WriteLine("Покупка отменена.");
                return;
            }

            int index = choice - 1;
            if (index < 0 || index >= _products.Count)
            {
                Console.WriteLine("Неверный номер товара. Попробуйте снова.");
                return;
            }

            Product product = _products[index];

            if (product.Quantity <= 0)
            {
                Console.WriteLine("К сожалению, этого товара больше нет.");
                return;
            }

            if (_insertedAmount < product.Price)
            {
                int need = product.Price - _insertedAmount;
                Console.WriteLine($"Недостаточно средств. Внесите: {need} руб.");
                return;
            }

            product.Quantity -= 1;
            _insertedAmount -= product.Price;
            _collectedFunds += product.Price;

            Console.WriteLine($"Спасибо за покупку!");

            if (_insertedAmount > 0)
            {
                GiveChange();
            }
        }

        public void GiveChange()
        {
            if (_insertedAmount <= 0)
            {
                Console.WriteLine("Сдачи нет.");
                return;
            }

            int change = _insertedAmount;
            _insertedAmount = 0;
            Console.WriteLine($"Ваша сдача: {change} руб. Заберите монеты.");
        }

        public void Cancel()
        {
            Console.WriteLine("\nОперация отменена пользователем.");
            GiveChange();
        }

        public void RestockProduct()
        {
            ShowProducts();
            Console.WriteLine("\nВведите номер товара для пополнения (или 0 для отмены):");
            int choice = ReadInt();
            if (choice == 0) return;

            int index = choice - 1;
            if (index < 0 || index >= _products.Count)
            {
                Console.WriteLine("Неверный номер товара.");
                return;
            }

            Console.WriteLine("Введите, сколько единиц товара добавляется:");
            int add = ReadInt();
            if (add < 0)
            {
                Console.WriteLine("Число должно быть положительным или 0.");
                return;
            }

            _products[index].Quantity += add;
            Console.WriteLine($"Остаток товара '{_products[index].Name}' увеличен на {add}. Новый остаток: {_products[index].Quantity}");
        }

        public void AddNewProduct()
        {
            Console.WriteLine("\nВведите название нового товара:");
            string? name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Название не может быть пустым.");
                return;
            }

            Console.WriteLine("Введите цену товара (в рублях, целое число):");
            int price = ReadInt();
            if (price <= 0)
            {
                Console.WriteLine("Цена должна быть положительной.");
                return;
            }

            Console.WriteLine("Введите количество товара(целое число):");
            int qty = ReadInt();
            if (qty < 0)
            {
                Console.WriteLine("Количество не может быть отрицательным.");
                return;
            }

            _products.Add(new Product(name, price, qty));
            Console.WriteLine($"Товар '{name}' добавлен. Цена: {price}, Кол-во: {qty}");
        }

        public void ChangeProductPrice()
        {
            ShowProducts();
            Console.WriteLine("\nВведите номер товара для изменения цены (или 0 для отмены):");
            int choice = ReadInt();
            if (choice == 0) return;

            int index = choice - 1;
            if (index < 0 || index >= _products.Count)
            {
                Console.WriteLine("Неверный номер товара.");
                return;
            }

            Console.WriteLine("Введите новую цену (в рублях):");
            int newPrice = ReadInt();
            if (newPrice <= 0)
            {
                Console.WriteLine("Цена должна быть положительной.");
                return;
            }

            _products[index].Price = newPrice;
            Console.WriteLine($"Новая цена товара '{_products[index].Name}': {newPrice} руб.");
        }

        public void CollectFunds()
        {
            Console.WriteLine($"\nВ автомате накоплено: {_collectedFunds} руб.");
            Console.WriteLine("Забрать всю сумму? 1 — Да, 0 — Нет");
            int ans = ReadInt();
            if (ans == 1)
            {
                Console.WriteLine($"Вы забрали: {_collectedFunds} руб.");
                _collectedFunds = 0;
            }
            else
            {
                Console.WriteLine("Деньги оставлены в автомате.");
            }
        }

        private static int ReadInt()
        {
            while (true)
            {
                string? s = Console.ReadLine();
                if (int.TryParse(s, out int value))
                {
                    return value;
                }
                Console.WriteLine("Нужно ввести целое число. Попробуйте ещё раз:");
            }
        }
    }
}


