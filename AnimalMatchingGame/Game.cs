using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace AnimalMatchingGame
{
    public class Game : INotifyPropertyChanged
    {
        public int Level { get; private set; } = 1;
        public int RowNumber { get; set; } = 4;
        public List<Animal> Animals { get; private set; }
        public int MatchesFound { get; set; } = 0;
        public List<string> VisibleAnimals { get; set; } 

        public Animal AnimalClicked;

        public bool GameOver;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnProrertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public Game()
        {
            Animals = SetUpGame.CreateAnimalPairs(RowNumber);                     
            GameOver = false;
        }
        public void DisplayVisibleAnimals()
        {
            VisibleAnimals = new List<string>();
            foreach(var animal in Animals)
            {
                if (animal.IsVisible)
                    VisibleAnimals.Add(animal.AnimalEmoji);
                else
                    VisibleAnimals.Add("*");
            }
            OnProrertyChanged("VisibleAnimals");
        }
        public void CompareAnimals(int index)
        {
            if (Animals[index].IsVisible)
                return;
            if(AnimalClicked == null)
            {
                AnimalClicked = Animals[index];
                AnimalClicked.IsVisible = true;
            }
            else if(AnimalClicked.AnimalEmoji==Animals[index].AnimalEmoji)
            {
                AnimalClicked.IsVisible = true;
                Animals[index].IsVisible = true;
                AnimalClicked = null;
                MatchesFound++;
                OnProrertyChanged("MatchesFound");
            }
            else
            {
                AnimalClicked.IsVisible = false;
                AnimalClicked = null;
            }          
        }
        public bool IsGameOver()
        {
            if (MatchesFound != Animals.Count / 2)
            {
                GameOver = false;
                return false;
            }
            GameOver = true;
            return true;
        }

        public void NextLevel()
        {
            Level++;
            RowNumber++;
            if (RowNumber > 8)
                NewGame();
            GameOver = false;
            MatchesFound = 0;
            OnProrertyChanged("MatchesFound");
            Animals = SetUpGame.CreateAnimalPairs(RowNumber);
        } 
        public void NewGame()
        {
            RowNumber = 4;
            Animals = SetUpGame.CreateAnimalPairs(RowNumber);
            GameOver = false;
            MatchesFound = 0;
            OnProrertyChanged("MatchesFound");
        }
    }
}
