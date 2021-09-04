using AnimalMatchingGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace AnimalMatchingGameUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Game game;
        DispatcherTimer timer = new DispatcherTimer();
        int tenthOfSecondsElapsed;
        TextBlock timeTextBlock;
       
        public MainWindow()
        {         
            InitializeComponent();
            game = Resources["game"] as Game;

            AddRow(1);
            AddRow(1, 50);
            TextBlock startGame = new TextBlock();
            startGame.Text = "🐭";
            startGame.FontSize = 16;
            startGame.FontSize = 100;
            startGame.Padding = new Thickness(0, 150, 0, 0);
            startGame.Background = new SolidColorBrush(Colors.LightGreen);
            startGame.VerticalAlignment = VerticalAlignment.Stretch;
            startGame.HorizontalAlignment = HorizontalAlignment.Stretch;
            startGame.TextAlignment = TextAlignment.Center;
            
            Grid.SetColumn(startGame, 0);
            Grid.SetRow(startGame,0);           
            Grid1.Children.Add(startGame);
            SetUpStartButton(1);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tenthOfSecondsElapsed++;
            timeTextBlock.Text = (tenthOfSecondsElapsed/10F).ToString("0.0s");
            if (game.IsGameOver())
                timer.Stop();
        }

        private void T1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            int.TryParse(textBlock.Name.Substring(1), out int index);           
            game.CompareAnimals(index-1);
            game.DisplayVisibleAnimals();                                                             
        }

        private void New_Game_Click(object sender, RoutedEventArgs e)
        {           
            game.NewGame();
            Grid1.ColumnDefinitions.Clear();
            Grid1.RowDefinitions.Clear();          
            AddRow(game.RowNumber);
            AddRow(2, 40);
            AddColumn(game.RowNumber);
            SetUpTextBlocks();
            game.DisplayVisibleAnimals();

            timer.Interval = TimeSpan.FromSeconds(0.1);
            timer.Tick += Timer_Tick;
            AddTimeTextBlock();
            tenthOfSecondsElapsed = 0;
            timer.Start();
        }

        private void Next_Level_Click(object sender, RoutedEventArgs e)
        {           
            game.NextLevel();
            Grid1.ColumnDefinitions.Clear();
            Grid1.RowDefinitions.Clear();
            AddRow(game.RowNumber);
            AddRow(2, 40);
            AddColumn(game.RowNumber);
            SetUpTextBlocks(); 
            game.DisplayVisibleAnimals();

            AddTimeTextBlock();
            timer.Interval = TimeSpan.FromSeconds(0.1);
            timer.Tick += Timer_Tick;
            tenthOfSecondsElapsed = 0;
            timer.Start();          
        }
        
        public void SetUpTextBlocks()
        {
            Grid1.Children.Clear();
            
            int n = 1;
            for (int i = 0; i < game.RowNumber; i++)
            {
                for (int j = 0; j < game.RowNumber; j++)
                {
                    TextBlock newTextBlock = new TextBlock();
                    newTextBlock.Name = $"T{n:D2}";

                    newTextBlock.MouseDown += new MouseButtonEventHandler(T1_MouseDown);
                    newTextBlock.SetBinding(TextBlock.TextProperty, $"VisibleAnimals[{n - 1}]");
                    newTextBlock.VerticalAlignment = VerticalAlignment.Stretch;
                    newTextBlock.HorizontalAlignment = HorizontalAlignment.Stretch;
                    newTextBlock.TextAlignment = TextAlignment.Center;
                    
                    newTextBlock.FontSize = 30;                    
                    newTextBlock.Background = new SolidColorBrush(Colors.LightGreen);
                    newTextBlock.Margin = new Thickness(1, 1, 1, 1);                                     
                    newTextBlock.Padding = new Thickness(10, 10, 10, 10);

                    Grid.SetColumn(newTextBlock, i);
                    Grid.SetRow(newTextBlock, j);                  
                    Grid1.Children.Add(newTextBlock);
                    n++;
                }
            }
            TextBlock matchesFound = new TextBlock();
            matchesFound.Text = "Matches found:";
            matchesFound.FontSize = 16;
            matchesFound.Margin = new Thickness(0, 15, 0, 0);
            Grid.SetColumn(matchesFound, 0);
            Grid.SetRow(matchesFound, game.RowNumber);
            Grid.SetColumnSpan(matchesFound, 2);
            Grid1.Children.Add(matchesFound);

            TextBlock matchesFoundCount = new TextBlock();
            matchesFoundCount.SetBinding(TextBlock.TextProperty, "MatchesFound");
            matchesFoundCount.FontSize = 16;         
            matchesFoundCount.Margin = new Thickness(0, 15, 0, 0);
            matchesFoundCount.FontWeight = FontWeights.Bold;
            Grid.SetColumn(matchesFoundCount, 2);
            Grid.SetRow(matchesFoundCount, game.RowNumber);
            Grid1.Children.Add(matchesFoundCount);

            SetUpStartButton(game.RowNumber);
            SetUpNextLevelButton(game.RowNumber);
        }
        
        public void AddRow(int n, int h=0)
        {
            if(h==0)
            for(int i=0; i < n; i++)
            {
                RowDefinition gridRow = new RowDefinition();
                Grid1.RowDefinitions.Add(gridRow);
            }
            else
            {
                for(int i=0; i<n; i++)
                {
                    RowDefinition gridRow = new RowDefinition();
                    gridRow.Height = new GridLength(h);
                    Grid1.RowDefinitions.Add(gridRow);
                }              
            }
        }
        public void AddColumn(int n)
        {
            for (int i = 0; i < n; i++)
            {
                ColumnDefinition gridCol = new ColumnDefinition();
                Grid1.ColumnDefinitions.Add(gridCol);
            }
        }
        public void SetUpStartButton(int rowNumber)
        {
            Button newGameButton = new Button();
            newGameButton.Content = "Start";
            newGameButton.Click += new RoutedEventHandler(New_Game_Click);
            newGameButton.Height = 30;
            newGameButton.FontSize = 18;
            newGameButton.Margin = new Thickness(2, 2, 2, 2);
            Grid.SetColumn(newGameButton, 0);
            Grid.SetRow(newGameButton, game.RowNumber + 1);
            Grid.SetColumnSpan(newGameButton, 2);
            Grid1.Children.Add(newGameButton);
        }
        public void SetUpNextLevelButton(int rowNumber)
        {
            Button nextLevelButton = new Button();
            nextLevelButton.Content = "Next level";
            nextLevelButton.Click += new RoutedEventHandler(Next_Level_Click);
            nextLevelButton.Height = 30;
            nextLevelButton.FontSize = 18;
            nextLevelButton.Margin = new Thickness(2, 2, 2, 2);
            Grid.SetColumn(nextLevelButton, 2);
            Grid.SetRow(nextLevelButton, game.RowNumber + 1);
            Grid.SetColumnSpan(nextLevelButton, 2);
            Grid1.Children.Add(nextLevelButton);
        }
        public void AddTimeTextBlock()
        {
            timeTextBlock = new TextBlock();
            Grid.SetColumn(timeTextBlock, 3);
            Grid.SetRow(timeTextBlock, game.RowNumber);
            if (game.RowNumber >= 5)
                Grid.SetColumnSpan(timeTextBlock, 2);
            Grid1.Children.Add(timeTextBlock);
            timeTextBlock.FontSize = 30;
            timeTextBlock.TextAlignment = TextAlignment.Center;
        }
    }
}
