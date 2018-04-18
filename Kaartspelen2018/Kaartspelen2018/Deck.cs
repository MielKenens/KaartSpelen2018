using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaartspelen2018
{
    public sealed class Deck
    {
        private Card[] deck;
        public Card[] shuffledDeck;
        private static int counter; 

        public Deck()
        {
            Init();
        }

        public void Shuffle()
        {
            counter++;
            Random rndHelp = new Random();
            Random rnd = new Random(rndHelp.Next() + counter);
            shuffledDeck = deck.OrderBy(x => rnd.Next()).ToArray();

        }


        private void Init()
        {
            deck = new Card[52];

//          deck[0] = new Card(" ", "cardback", 1);

            deck[0] = new Card("Ace of Clubs", "AceClubs", 14);
            deck[1] = new Card("Ace of Diamonds", "AceDiamonds", 14);
            deck[2] = new Card("Ace of Hearts", "AceHearts", 14);
            deck[3] = new Card("Ace of Spades", "AceSpades", 14);

            deck[4] = new Card("Deuce of Clubs", "DeuceClubs", 2);
            deck[5] = new Card("Deuce of Diamonds", "DeuceDiamonds", 2);
            deck[6] = new Card("Deuce of Hearts", "DeuceHearts", 2);
            deck[7] = new Card("Deuce of Spades", "DeuceSpades", 2);

            deck[8] = new Card("Eight of Clubs", "EightClubs", 8);
            deck[9] = new Card("Eight of Diamonds", "EightDiamonds", 8);
            deck[10] = new Card("Eight of Hearts", "EightHearts", 8);
            deck[11] = new Card("Eight of Spades", "EightSpades", 8);

            deck[12] = new Card("Five of Clubs", "FiveClubs", 5);
            deck[13] = new Card("Five of Diamonds", "FiveDiamonds", 5);
            deck[14] = new Card("Five of Hearts", "FiveHearts", 5);
            deck[15] = new Card("Five of Spades", "FiveSpades", 5);

            deck[16] = new Card("Four of Clubs", "FourClubs", 4);
            deck[17] = new Card("Four of Diamonds", "FourDiamonds", 4);
            deck[18] = new Card("Four of Hearts", "FourHearts", 4);
            deck[19] = new Card("Four of Spades", "FourSpades", 4);

            deck[20] = new Card("Jack of Clubs", "JackClubs", 11);
            deck[21] = new Card("Jack of Diamonds", "JackDiamonds", 11);
            deck[22] = new Card("Jack of Hearts", "JackHearts", 11);
            deck[23] = new Card("Jack of Spades", "JackSpades", 11);

            deck[24] = new Card("King of Clubs", "KingClubs", 13);
            deck[25] = new Card("King of Diamonds", "KingDiamonds", 13);
            deck[26] = new Card("King of Hearts", "KingHearts", 13);
            deck[27] = new Card("King of Spades", "KingSpades", 13);

            deck[28] = new Card("Nine of Clubs", "NineClubs", 9);
            deck[29] = new Card("Nine of Diamonds", "NineDiamonds", 9);
            deck[30] = new Card("Nine of Hearts", "NineHearts", 9);
            deck[31] = new Card("Nine of Spades", "NineSpades", 9);

            deck[32] = new Card("Queen of Clubs", "QueenClubs", 12);
            deck[33] = new Card("Queen of Diamonds", "QueenDiamonds", 12);
            deck[34] = new Card("Queen of Hearts", "QueenHearts", 12);
            deck[35] = new Card("Queen of Spades", "QueenSpades", 12);

            deck[36] = new Card("Seven of Clubs", "SevenClubs", 7);
            deck[37] = new Card("Seven of Diamonds", "SevenDiamonds", 7);
            deck[38] = new Card("Seven of Hearts", "SevenHearts", 7);
            deck[39] = new Card("Seven of Spades", "SevenSpades", 7);

            deck[40] = new Card("Six of Clubs", "SixClubs", 6);
            deck[41] = new Card("Six of Diamonds", "SixDiamonds", 6);
            deck[42] = new Card("Six of Hearts", "SixHearts", 6);
            deck[43] = new Card("Six of Spades", "SixSpades", 6);

            deck[44] = new Card("Ten of Clubs", "TenClubs", 10);
            deck[45] = new Card("Ten of Diamonds", "TenDiamonds", 10);
            deck[46] = new Card("Ten of Hearts", "TenHearts", 10);
            deck[47] = new Card("Ten of Spades", "TenSpades", 10);

            deck[48] = new Card("Three of Clubs", "ThreeClubs", 3);
            deck[49] = new Card("Three of Diamonds", "ThreeDiamonds", 3);
            deck[50] = new Card("Three of Hearts", "ThreeHearts", 3);
            deck[51] = new Card("Three of Spades", "ThreeSpades", 3);
        }

        public int Counter { get;}
    }
}
