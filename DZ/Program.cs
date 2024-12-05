using System;
using System.Collections.Generic;

namespace DZ_Zoopark
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            Mammal lion = new Mammal("Симба", 5, 190.5f, 100.1f, "Лев", TypeOfEating.Хищник, "Золотистый");
            Bird eagle = new Bird("Кеша", 3,  7.5f,1.1f, "Орел", TypeOfEating.Хищник, 2.5, "Темно-бурый");


            Console.WriteLine("Информация о животных в зоопарке:");
            lion.DisplayInfo();
            lion.MakeSound();
            Console.WriteLine();

            eagle.DisplayInfo();
            eagle.MakeSound();
            Console.WriteLine();


            List<Animal> zoo = new List<Animal>
            {
                lion,
                eagle,
                new Mammal("Ширхан", 4,102,200.2f,"Тигр", TypeOfEating.Хищник,"Оранжевый с черными полосами"),
                new Bird("Кез", 2,1.5f,0.45f,"Попугай", TypeOfEating.Всеядные, 0.97d,"Яркая разноцветня окраска")
            };


    
            bool continueAdding = true;

            while (continueAdding)
            {
                Console.WriteLine("Добавить животное в зоопарк? (да/нет)");
                string response = Console.ReadLine()?.Trim().ToLower();

                if (response == "да")
                {
                    Animal newAnimal = CreateAnimal();
                    if (newAnimal != null)
                    {
                        zoo.Add(newAnimal);
                        Console.WriteLine("Животное успешно добавлено!");
                        Console.WriteLine("\nОбновленный список животных в зоопарке:");
                        foreach (var animal in zoo)
                        {
                            animal.DisplayInfo();
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Не удалось добавить животное. Попробуйте еще раз.");
                    }
                }
                else if (response == "нет")
                {
                    continueAdding = false;
                    Console.WriteLine("Завершение добавления животных.");
                }
                else
                {
                    Console.WriteLine("Введите 'да' или 'нет'.");
                }
            }

            Console.WriteLine("Все животные в зоопарке:");
            foreach (var animal in zoo)
            {
                animal.DisplayInfo();
                Console.WriteLine();
            }
        }
        private static Animal CreateAnimal()
        {
            Console.WriteLine("Выберите тип животного: 1 - Млекопитающее, 2 - Птица");
            string choice = Console.ReadLine();

            string name = GetStringInput("Введите имя:");
            int age = GetIntInput("Введите возраст:");
            float weight = GetFloatInput("Введите вес:");
            float height = GetFloatInput("Введите рост:");
            string type = GetStringInput("Введите вид:");
            TypeOfEating typeOfFood = GetEnumInput<TypeOfEating>("Выберите тип питания (0 - Растительноядный, 1 - Хищник, 2 - Насекомоядный, 3 - Всеядные):");

            if (choice == "1")
            {
        
                string furColor = GetStringInput("Введите цвет шерсти:");
                return new Mammal(name, age, weight, height, type, typeOfFood, furColor);
            }
            else if (choice == "2")
            {
               
                double wingspan = GetDoubleInput("Введите размах крыльев:");
                string plumageColor = GetStringInput("Введите цвет оперения:");
                return new Bird(name, age, weight, height, type, typeOfFood, wingspan, plumageColor);
            }

            Console.WriteLine("Неверный выбор!");
            return null;
        }

        private static string GetStringInput(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }

        private static int GetIntInput(string prompt)
        {
            int result;
            while (true)
            {
                Console.WriteLine(prompt);
                if (int.TryParse(Console.ReadLine(), out result))
                    break;
                Console.WriteLine("Некорректный ввод. Попробуйте снова.");
            }
            return result;
        }

        private static float GetFloatInput(string prompt)
        {
            float result;
            while (true)
            {
                Console.WriteLine(prompt);
                if (float.TryParse(Console.ReadLine(), out result))
                    break;
                Console.WriteLine("Некорректный ввод. Попробуйте снова.");
            }
            return result;
        }

        private static double GetDoubleInput(string prompt)
        {
            double result;
            while (true)
            {
                Console.WriteLine(prompt);
                if (double.TryParse(Console.ReadLine(), out result))
                    break;
                Console.WriteLine("Некорректный ввод. Попробуйте снова.");
            }
            return result;
        }

        private static T GetEnumInput<T>(string prompt) where T : Enum
        {
            int result;
            while (true)
            {
                Console.WriteLine(prompt);
                if (int.TryParse(Console.ReadLine(), out result) && Enum.IsDefined(typeof(T), result))
                    return (T)(object)result;
                Console.WriteLine("Некорректный ввод. Попробуйте снова.");
            }
        }
    }
}
