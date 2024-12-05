using System;


namespace DZ_Zoopark
{
    public enum TypeOfEating
    {
        Растительноядный,
        Хищник,
        Насекомоядный,
        Всеядные
    }
    public abstract class Animal
    {
        private string nickname;
        private int age;
        private string type;
        private float height;
        private float weight;
        private TypeOfEating typeOfFood;

        public string Name
        {
            get => nickname;
            set => nickname = value;
        }

        public int Age
        {
            get => age;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Возраст не может быть отрицательным.");
                age = value;
            }
        }
        public float Weight
        {
            get => weight;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Вес должен быть положительным.");
                weight = value;
            }
        }
        public float Height
        {
            get => height;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Вес должен быть положительным.");
                height = value;
            }
        }
        public string Type
        {
            get => type;
            set => type = value;
        }
        public TypeOfEating TypeOfFood
        {
            get => typeOfFood;
            set => typeOfFood = value;
        }
        protected Animal(string name, int age, float weight, float height, string type, TypeOfEating typeOfFood)
        {
            Name = name;
            Age = age;
            Height = height;
            Weight = weight;
            Type = type;
            TypeOfFood = typeOfFood;
        }
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Кличка животного:{nickname}, возраст животного:{age} лет" +
                $", рост животного:{height}м, вес животного:{weight}кг, вид животного:{type}, тип питания:{TypeOfFood}");
        }
        public abstract void MakeSound();
    }
}
