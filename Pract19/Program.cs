using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pract16
{
    class Computer
    {
        public int Code { get; set; }
        public string Brand { get; set; }
        public string ProcessorType { get; set; }
        public double ProcessorFrequency { get; set; }
        public int RAM { get; set; }
        public int HDD { get; set; }
        public int GraphicsMemory { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Computer> computers = new List<Computer>
        {
            new Computer { Code = 1, Brand = "Dell", ProcessorType = "Intel", ProcessorFrequency = 3.2, RAM = 8, HDD = 1000, GraphicsMemory = 2, Price = 700, Quantity = 20 },
            new Computer { Code = 2, Brand = "HP", ProcessorType = "AMD", ProcessorFrequency = 3.5, RAM = 16, HDD = 2000, GraphicsMemory = 4, Price = 900, Quantity = 15 },
            new Computer { Code = 3, Brand = "Lenovo", ProcessorType = "Intel", ProcessorFrequency = 2.8, RAM = 4, HDD = 500, GraphicsMemory = 1, Price = 500, Quantity = 25 },
            new Computer { Code = 4, Brand = "Asus", ProcessorType = "AMD", ProcessorFrequency = 3.0, RAM = 8, HDD = 1500, GraphicsMemory = 2, Price = 600, Quantity = 30 },
            new Computer { Code = 5, Brand = "Acer", ProcessorType = "Intel", ProcessorFrequency = 3.0, RAM = 8, HDD = 1000, GraphicsMemory = 2, Price = 650, Quantity = 10 }
        };

            Console.WriteLine("Введите тип процессора для поиска компьютеров:");
            string processorType = Console.ReadLine();

            var computersWithProcessor = computers.Where(c => c.ProcessorType == processorType);
            Console.WriteLine("\nКомпьютеры с указанным процессором:");
            PrintComputers(computersWithProcessor);

            Console.WriteLine("\nВведите минимальный объем ОЗУ для поиска компьютеров:");
            int minRAM = int.Parse(Console.ReadLine());

            var computersWithRAM = computers.Where(c => c.RAM >= minRAM);
            Console.WriteLine("\nКомпьютеры с объемом ОЗУ не ниже указанного:");
            PrintComputers(computersWithRAM);

            Console.WriteLine("\nСписок компьютеров, отсортированный по увеличению стоимости:");
            var sortedComputersByPrice = computers.OrderBy(c => c.Price);
            PrintComputers(sortedComputersByPrice);

            Console.WriteLine("\nКомпьютеры, сгруппированные по типу процессора:");
            var groupedComputersByProcessor = computers.GroupBy(c => c.ProcessorType);
            foreach (var group in groupedComputersByProcessor)
            {
                Console.WriteLine($"Процессор: {group.Key}");
                PrintComputers(group);
                Console.WriteLine();
            }

            Console.WriteLine("\nСамый дорогой компьютер:");
            var mostExpensiveComputer = computers.OrderByDescending(c => c.Price).First();
            PrintComputer(mostExpensiveComputer);

            Console.WriteLine("\nСамый бюджетный компьютер:");
            var cheapestComputer = computers.OrderBy(c => c.Price).First();
            PrintComputer(cheapestComputer);

            bool existsComputerWithQuantityAtLeast30 = computers.Any(c => c.Quantity >= 30);
            Console.WriteLine($"\nЕсть ли хотя бы один компьютер в количестве не менее 30 штук? {existsComputerWithQuantityAtLeast30}");
        }

        static void PrintComputers(IEnumerable<Computer> computers)
        {
            foreach (var computer in computers)
            {
                PrintComputer(computer);
            }
        }

        static void PrintComputer(Computer computer)
        {
            Console.WriteLine($"Код: {computer.Code}, Марка: {computer.Brand}, Тип процессора: {computer.ProcessorType}, " +
                $"Частота процессора: {computer.ProcessorFrequency}, ОЗУ: {computer.RAM}ГБ, Жесткий диск: {computer.HDD}ГБ, " +
                $"Объем видеопамяти: {computer.GraphicsMemory}ГБ, Стоимость: {computer.Price}, Количество: {computer.Quantity}");
        }
    }
}