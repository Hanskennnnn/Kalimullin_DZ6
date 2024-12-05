
using System;


namespace DZ_Zoopark
{
    public class Mammal : Animal
    {
        private string furColor; 
        public string FurColor
        {
            get => furColor;
            set => furColor = value;
        }  
        public Mammal(string name, int age, float weight, float height, string type, TypeOfEating typeOfFood, string furColor)
            : base(name, age, weight, height, type, typeOfFood)
        {
            this.FurColor = furColor;
        }

      
        public override void MakeSound()
        {
            Console.WriteLine($"{Name} издает звук, типичный для млекопитающих.");
        }

    
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Цвет шерсти:{furColor}");
        }
    }
}
