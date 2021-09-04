using System;

namespace AnimalMatchingGame
{
    public class Animal
    {     
        public string AnimalEmoji { get; set; }
        public bool IsVisible { get; set; } = false;
        public Animal(string animalEmoj )
        {
            AnimalEmoji = animalEmoj;
        }
    }
}
