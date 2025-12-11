using System;

namespace VendingMachineApp
{
    public class Program
    {
        // Главная точка входа в программу
        public static void Main(string[] args)
        {
            VendingMachine machine = new VendingMachine();

            while (true)
            {
                Console.WriteLine("\n=== Вендинговый автомат ===");
                Console.WriteLine("1. Показать товары");
                Console.WriteLine("2. Внести монету");
                Console.WriteLine("3. Выбрать товар и купить");
                Console.WriteLine("4. Отменить операцию (вернуть деньги)");
                Console.WriteLine("5. Администраторский режим");
                Console.WriteLine("0. Выход");
                Console.Write("Ваш выбор: ");

                int cmd = ReadInt();

                if (cmd == 0)
                {
                    machine.Cancel();
                    Console.WriteLine("Выход из программы. До свидания!");
                    break;
                }

                switch (cmd)
                {
                    case 1:
                        machine.ShowProducts();
                        break;
                    case 2:
                        machine.InsertCoin();
                        break;
                    case 3:
                        machine.SelectProduct();
                        break;
                    case 4:
                        machine.Cancel();
                        break;
                    case 5:
                        Admin.AdminConsole admin = new Admin.AdminConsole(machine);
                        admin.Run();
                        break;
                    default:
                        Console.WriteLine("Неизвестная команда. Попробуйте снова.");
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
