using System;

namespace VendingMachineApp.Admin
{
    // Отдельный класс для админ-меню
    public class AdminConsole
    {
        private readonly VendingMachine _machine;

        private const string AdminPassword = "1234";

        public AdminConsole(VendingMachine machine)
        {
            _machine = machine;
        }

        public void Run()
        {
            Console.Write("\nВведите пароль администратора: ");
            string? pass = Console.ReadLine();
            if (pass != AdminPassword)
            {
                Console.WriteLine("Неверный пароль.");
                return;
            }

            while (true)
            {
                Console.WriteLine("\n=== Админ-меню ===");
                Console.WriteLine("1. Показать товары");
                Console.WriteLine("2. Пополнить остаток товара");
                Console.WriteLine("3. Добавить новый товар");
                Console.WriteLine("4. Изменить цену товара");
                Console.WriteLine("5. Собрать выручку");
                Console.WriteLine("0. Выход из админ-меню");
                Console.Write("Ваш выбор: ");

                int cmd = ReadInt();
                if (cmd == 0) break;

                switch (cmd)
                {
                    case 1:
                        _machine.ShowProducts();
                        break;
                    case 2:
                        _machine.RestockProduct();
                        break;
                    case 3:
                        _machine.AddNewProduct();
                        break;
                    case 4:
                        _machine.ChangeProductPrice();
                        break;
                    case 5:
                        _machine.CollectFunds();
                        break;
                    default:
                        Console.WriteLine("Неизвестная команда.");
                        break;
                }
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


