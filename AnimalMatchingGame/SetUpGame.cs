using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalMatchingGame
{
    public static class SetUpGame
    {
        public static List<string> AnimalEmoji = new List<string>() 
        {"🐕","🐔","🐫","🐷","🐭","🐵","🐻","🦊",
            "🦝","🐮","🐷","🐗","🐹","🐰","🐨","🐼","🐸","🦓",
            "🐴","🦄","🐲","🐒","🦍","🦧","🦮","🦺","🐩","🐈","🐅",
            "🐆","🐎","🦌","🦏","🦛","🐂","🐃","🐄","🐖","🐏","🐑","🐐",
            "🐪","🦎","🐊","🐢","🐍","🐉","🦈","🐬","🦖","🐧","🦅","🦢",
            "🕊","🐤","🐥","🦜","🦋","🐞","🐛", "🐶"};
        public static List<Animal> AnimalPairs;
        public static Random Random = new Random();     
        
        public static List<Animal> CreateAnimalPairs(int rowNumber)
        {
            AnimalPairs = new List<Animal>();
            List<string> copy = new List<string>(AnimalEmoji);

            for(int i=0; i<(rowNumber*rowNumber/2); i++)
            {
                int emojNumber = Random.Next(copy.Count);
                AnimalPairs.Add( new Animal(copy[emojNumber]));
                AnimalPairs.Add(new Animal(copy[emojNumber]));
                copy.RemoveAt(emojNumber);
            }
            ShuffleAnimals();
            if ((rowNumber * rowNumber) % 2 != 0)
            {
                Animal lastAnimal = new Animal("-");
                lastAnimal.IsVisible = true;
                AnimalPairs.Add(lastAnimal);
            }              
            return AnimalPairs;
        }        
         public static void ShuffleAnimals()
        {
            List<Animal> copy = new List<Animal>(AnimalPairs);
            AnimalPairs.Clear();
            while(copy.Count()>0)
            {
                var index = Random.Next(copy.Count);
                AnimalPairs.Add(copy[index]);
                copy.RemoveAt(index);
            }
        }
    }
}
