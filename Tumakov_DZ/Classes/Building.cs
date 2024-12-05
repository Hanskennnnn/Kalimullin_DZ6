using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Tumakov_DZ
{
    public class Building
    {
        private static int lastBuildingNumber = 0;

        private readonly int buildingNumber;
        private double height;
        private int floors;
        private int apartments;
        private int entrances;

        public Building()
        {
            buildingNumber = ++lastBuildingNumber; 
        }
        public string GetBuildingNumber()
        {
            return $"Уникальный номер здания: {buildingNumber}";
        }

        public string GetHeight()
        {
            return $"Высота здания: {height} м";
        }

        public string GetFloors()
        {
            return $"Этажность здания: {floors} этажей";
        }

        public string GetApartments()
        {
            return $"Общее количество квартир: {apartments}";
        }

        public string GetEntrances()
        {
            return $"Количество подъездов: {entrances}";
        }
        public void SetBuildingDetails()
        {
            Console.WriteLine("Введите данные о здании:");


            Console.Write("Введите высоту здания (м): ");
            while (!double.TryParse(Console.ReadLine(), out height) || height <= 0)
            {
                Console.WriteLine("Ошибка: введите корректное положительное число.");
                Console.Write("Введите высоту здания (м): ");
            }


            Console.Write("Введите количество этажей: ");
            while (!int.TryParse(Console.ReadLine(), out floors) || floors <= 0)
            {
                Console.WriteLine("Ошибка: введите корректное положительное целое число.");
                Console.Write("Введите количество этажей: ");
            }


            Console.Write("Введите количество квартир: ");
            while (!int.TryParse(Console.ReadLine(), out apartments) || apartments <= 0)
            {
                Console.WriteLine("Ошибка: введите корректное положительное целое число.");
                Console.Write("Введите количество квартир: ");
            }


            Console.Write("Введите количество подъездов: ");
            while (!int.TryParse(Console.ReadLine(), out entrances) || entrances <= 0)
            {
                Console.WriteLine("Ошибка: введите корректное положительное целое число.");
                Console.Write("Введите количество подъездов: ");
            }


            while (!IsValidConfiguration())
            {
                Console.WriteLine("\nНекорректная конфигурация: невозможно распределить квартиры по этажам или подъездам без остатка.");
                Console.WriteLine("Пожалуйста, введите данные заново.");

                Console.Write("Введите количество квартир: ");
                while (!int.TryParse(Console.ReadLine(), out apartments) || apartments <= 0)
                {
                    Console.WriteLine("Ошибка: введите корректное положительное целое число.");
                    Console.Write("Введите количество квартир: ");
                }

                Console.Write("Введите количество подъездов: ");
                while (!int.TryParse(Console.ReadLine(), out entrances) || entrances <= 0)
                {
                    Console.WriteLine("Ошибка: введите корректное положительное целое число.");
                    Console.Write("Введите количество подъездов: ");
                }
            }
        }

        private bool IsValidConfiguration()
        {
            return apartments % entrances == 0 && (apartments / entrances) % floors == 0;
        }
        private double CalculateFloorHeight()
        {
            return height / floors;
        }

        private int CalculateApartmentsPerEntrance()
        {
            return apartments / entrances;
        }

        private int CalculateApartmentsPerFloor()
        {
            return apartments / floors;
        }
        public void PrintBuildingInformation()
        {
            Console.WriteLine($"\nЗдание №{buildingNumber}");
            Console.WriteLine($"Высота: {height} м");
            Console.WriteLine($"Этажей: {floors}");
            Console.WriteLine($"Квартир: {apartments}");
            Console.WriteLine($"Подъездов: {entrances}");
            Console.WriteLine($"Высота этажа: {CalculateFloorHeight():F2} м");
            Console.WriteLine($"Квартир в подъезде: {CalculateApartmentsPerEntrance()}");
            Console.WriteLine($"Квартир на этаже: {CalculateApartmentsPerFloor()}");
        }
    }
}

