
using System;


namespace DZ_Zoopark
{
    public class Bird : Animal
    {
        private double wingspan; // Размах крыльев
        private string plumageColor; // Цвет оперения
        public double Wingspan
        {
            get => wingspan;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Размах крыльев должен быть положительным.");
                wingspan = value;
            }
        }
        public string PlumageColor
        {
            get => plumageColor;
            set => plumageColor = value;
    
        }

        // Конструктор
        public Bird(string name, int age, float weight, float height, string type, TypeOfEating typeOfFood, double wingspan, string plumageColor)
            : base(name, age, weight, height, type, typeOfFood)
        {
            Wingspan = wingspan;
            PlumageColor = plumageColor;
        }

        // Реализация абстрактного метода
        public override void MakeSound()
        {
            Console.WriteLine($"{Name} издает звук, типичный для птиц.");
        }

        // Переопределение метода для вывода информации
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Размах крыльев: {Wingspan} м, цвет оперения:{plumageColor}");
        }
    }

}

