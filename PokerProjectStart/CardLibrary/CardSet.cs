using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardLibrary;

namespace CardLibrary
{

    public class CardSet
    {
        public SuperCard[] cardArray;

        // Instanciate random class and declare new card int as a position in a deck.
        public static Random myRand = new Random();
        int myNewCard;

        public CardSet()
        {
            cardArray = new SuperCard[52];
            int a = 0;
            foreach(Suit value in Enum.GetValues(typeof(Suit)))
            {
                 foreach (Rank value2 in Enum.GetValues(typeof(Rank)))
                {
                    switch (value)
                    {
                        case Suit.Club:
                            cardArray[a] = new CardClub();
                            cardArray[a].CardRank = value2;
                            a++;
                            break;

                        case Suit.Diamond:
                            cardArray[a] = new CardDiamond();
                            cardArray[a].CardRank = value2;
                            a++;
                            break;

                        case Suit.Heart:
                            cardArray[a] = new CardHeart();
                            cardArray[a].CardRank = value2;
                            a++;
                            break;

                        case Suit.Spade:
                            cardArray[a] = new CardSpade();
                            cardArray[a].CardRank = value2;
                            a++;
                            break;

                    }                   
                }
            }
        }

        public SuperCard[] GetCards(int howManyCards)
        {
            SuperCard[] cardHand = new SuperCard[howManyCards];
            for (int i = 0; i < cardHand.Length; i++)
            {
                int counter = 0;
                while (counter < 1)
                {
                    myNewCard = myRand.Next(1, 52);
                    if (this.cardArray[myNewCard].inplay == true)
                    {
                        cardHand[i] = this.cardArray[myNewCard];
                        this.cardArray[myNewCard].inplay = false;
                        counter++;
                    }
                }
            }
            return cardHand;
        }
        public void ResetUsage (CardSet set)
        {
            for(int i = 0; i < set.cardArray.Length;  i++)
            {
                set.cardArray[i].inplay = true;
            }
        }
        public SuperCard GetOneCard(int cardUserSelected)
        {
            SuperCard card = null;
            int counter = 0;
            while (counter < 1)
            {
                myNewCard = myRand.Next(1, 52);
                if (this.cardArray[myNewCard].inplay == true)
                {
                    card = this.cardArray[myNewCard];
                    this.cardArray[myNewCard].inplay = false;
                    counter++;
                }
            }
            return card;
        }
    }
}
