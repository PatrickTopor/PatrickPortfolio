using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLibrary
{
    public enum Suit
    {
        Club = 1,
        Diamond,
        Heart,
        Spade
    }

    public enum Rank
    {
        Deuce = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
        Ace = 14
    }
 
     public abstract class SuperCard: IComparable<SuperCard>, IEquatable<SuperCard> 
    {
        public Rank CardRank { get; set; }
        public abstract Suit CardSuit { get; set; }
        public bool inplay { get; set; }

        // This code implements the comapreTo(object) method.
        public int CompareTo(SuperCard other)
        {
            if (this.CardSuit > other.CardSuit)
            {
                return 1;
            }
            else if (this.CardSuit < other.CardSuit)
            {
                return -1;
            }
            else
            {
                if (this.CardRank > other.CardRank)
                {
                    return -1;
                }
                else if(this.CardRank < other.CardRank)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public abstract void Display();

        public bool Equals(SuperCard other)
        {
            bool cardsAreComparable = false;
            
            if(this.CardSuit == other.CardSuit)
            {
                cardsAreComparable = true;
            }
            return cardsAreComparable;
        }
    }

    public class CardClub : SuperCard
    {
        private Suit _CardSuit = Suit.Club;
        public override Suit CardSuit
        {
            get { return _CardSuit; }
            set { _CardSuit = value; }
        }

        public override void Display()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(CardRank + " of " + _CardSuit + "s ♣");
            Console.ResetColor();
        }
    }

    public class CardDiamond : SuperCard
    {
        private Suit _CardSuit = Suit.Diamond;
        public override Suit CardSuit
        {
            get { return _CardSuit; }
            set { _CardSuit = value; }
        }

        public override void Display()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(CardRank + " of " + _CardSuit + "s ♦");
            Console.ResetColor();
        }

    }

    public class CardHeart : SuperCard
    {
        private Suit _CardSuit = Suit.Heart;
        public override Suit CardSuit
        {
            get { return _CardSuit; }
            set { _CardSuit = value; }
        }

        public override void Display()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(CardRank + " of " + _CardSuit + "s ♥");
            Console.ResetColor();
        }

    }

    public class CardSpade : SuperCard
    {
        private Suit _CardSuit = Suit.Spade;

        public override Suit CardSuit
        {
            get { return _CardSuit; }
            set { _CardSuit = value; }
        }
        public override void Display()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(CardRank + " of " + _CardSuit + "s ♠");
            Console.ResetColor();
        }

    }
}
