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

namespace Kaartspelen2018
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Player player;
        private Computer computer;
        private bool isShuffled;
        private DispatcherTimer timer;
        private bool computerTurn;
        private int turn;

        public MainWindow()
        {
            InitializeComponent();
            RoundResult.IsReadOnly = true;
            Deal.IsEnabled = false;

        }

        private void InitEntities()
        {
        player = new Player();
        computer = new Computer();
        isShuffled = false;
        computerTurn = false;
        turn = 0;
    }

        private void InitTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(2);
            timer.Tick += Timer_Tick;
        }

        private void Shuffle_Click(object sender, RoutedEventArgs e)
        {
            InitEntities();
            InitTimer();

            Message1.Content = "";
            Message2.Content = "";
            Message3.Content = "";
            Message4.Content = "";
            RoundResult.Text = "";


            computer.Shuffle();
            player.Shuffle();
            Deal.IsEnabled = true;

            if (isShuffled == false)
            {
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.UriSource = new Uri("card_images/cardback.png", UriKind.Relative);
                bitmapimage.EndInit();
                kaartRug1.Stretch = Stretch.Fill;
                kaartRug1.Source = bitmapimage;
                kaartRug2.Stretch = Stretch.Fill;
                kaartRug2.Source = bitmapimage;

                BitmapImage bitmapimageMiddle = new BitmapImage();
                bitmapimageMiddle.BeginInit();
                bitmapimageMiddle.UriSource = new Uri("card_images/NoCard.png", UriKind.Relative);
                bitmapimageMiddle.EndInit();
                kaartImage1.Source = bitmapimageMiddle;
                kaartImage1.Stretch = Stretch.Fill;
                kaartImage2.Source = bitmapimageMiddle;
                kaartImage2.Stretch = Stretch.Fill;

                isShuffled = true;
            }
        }

        private void Deal_Click(object sender, RoutedEventArgs e)
        {
          player.Deal(kaartImage2);
          computerTurn = true;
          ToggleDealButton();
          timer.Start();
        }

        private void ToggleDealButton()
        {
            if (computerTurn)
            {
                Deal.IsEnabled = false;
            }
            else
            {
                Deal.IsEnabled = true;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            computer.Deal(kaartImage1);
            timer.Stop();
            Compare();
            computerTurn = false;
            ToggleDealButton();
            CheckTurn();
        }

        private void CheckTurn()
        {
            if (52 == player.DealCounter)
            {
                EndGame();
            }
        }

        private void Compare()
        {
            if (computer.deck.shuffledDeck[computer.DealCounter].Value > player.deck.shuffledDeck[player.DealCounter].Value)
            {
                computer.Points++;
                ShowRoundResult(0);
            }
            else
            {
                if (computer.deck.shuffledDeck[computer.DealCounter].Value < player.deck.shuffledDeck[player.DealCounter].Value)
                {
                    player.Points++;
                    ShowRoundResult(1);
                }
                else
                {
                    computer.Points++;
                    player.Points++;
                    ShowRoundResult(3);
                }
            }

            UpdateDealCounter();
        }

        private void UpdateDealCounter()
        {
            computer.DealCounter = computer.DealCounter + 1;
            player.DealCounter = player.DealCounter + 1;
        }

        private void ShowValues()
        {
            Message2.Content = player.deck.shuffledDeck[player.DealCounter].Value;
            Message4.Content = computer.deck.shuffledDeck[computer.DealCounter].Value;
        }

        private void UpdatePoints()
        {
            Message1.Content = player.Points;
            Message3.Content = computer.Points;
        }

        private void ShowRoundResult(int result)
        {
            if (result == 0)
            {
                RoundResult.Text = "Computer wins";
            }
            else
            {
                if (result == 1)
                {
                    RoundResult.Text = "You win";
                }
                else
                {
                    RoundResult.Text = "Tie";
                }
            }
            UpdatePoints();
            ShowValues();
        }

        private void EndGame()
        {
            kaartImage1.Source = null;
            kaartRug1.Source = null;
            kaartImage2.Source = null;
            kaartRug2.Source = null;
            Deal.IsEnabled = false;

            Message1.Content = "";
            Message2.Content = "";
            Message3.Content = "";
            Message4.Content = "";

            if (player.Points > computer.Points)
            {
                RoundResult.Text = "Congrats, you won the game";
            }
            else
            {
                if (computer.Points > player.Points)
                {
                    RoundResult.Text = "Congrats, you lost to rng";
                }
                else
                {
                    RoundResult.Text = "Frustrating result, isn't it?";
                }
            }
        }


    }
}
