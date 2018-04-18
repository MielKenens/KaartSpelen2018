using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Kaartspelen2018
{


    public class Entity
    {
        public Deck deck = new Deck();
        private int dealCounter;


        public void Shuffle()
        {
            deck.Shuffle();
        }

        public void Deal(Image givenImageLocation)
        {
            BitmapImage bitmapimage = new BitmapImage();
            bitmapimage.BeginInit();
            bitmapimage.UriSource = new Uri("card_images/" + deck.shuffledDeck[DealCounter].Address + ".png", UriKind.Relative);
            bitmapimage.EndInit();
            givenImageLocation.Stretch = Stretch.Fill;
            givenImageLocation.Source = bitmapimage;
            
//            givenImageLocation.Height = 176;
//            givenImageLocation.Width = 103;
            Console.WriteLine(@"card_images/" + deck.shuffledDeck[DealCounter].Address + ".png");
//          dealCounter++;
        }

        public int DealCounter { get; set; }
        public int Points { get; set; }

      
    }
}
