using CardLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int howManyCards = 5;
            int balance = 10;
            CardLibrary.CardSet myDeck = new CardLibrary.CardSet();
            //myDeck.ResetUsage(myDeck);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("WELCOME TO POKER!");
            Console.WriteLine("In this game, you will start with $10.  In each round, you will be given a hand of 5 cards.");
            Console.WriteLine("If you win, you will get $1, but if you lose, you will lose $1.  This will continue until you quit or you run out of money, most likely the latter.");
            Console.ReadLine();

            while(balance != 0)
            {
                myDeck.ResetUsage(myDeck);
                SuperCard[] computerHand = myDeck.GetCards(howManyCards); 
                SuperCard [] playersHand = myDeck.GetCards(howManyCards);

                Array.Sort(computerHand);
                Array.Sort(playersHand);

                DisplayHands(computerHand, playersHand);
                
                PlayerDrawsOne(playersHand, myDeck);
                if(Flush(computerHand)==false)
                {
                    ComputerDrawsOne(computerHand, myDeck);
                }
                DisplayHands(computerHand, playersHand);
                bool won = CompareHands (computerHand, playersHand);  
                
                if (won == true)  //if user won a round
                {
                    balance++;
                    Console.WriteLine("Congrats!  You have won this round!  Your balance is now ${0}", balance);
                    Console.WriteLine("Please press the enter key to go for another round.");
                    Console.ReadLine();
                }

                else //if user loses a round
                {
                    balance--;
                    Console.WriteLine("Unfortunately the house won, you have only ${0}.  But I bet if you just went one more time, your luck might change.", balance);
                    Console.WriteLine("What do you say?  Press enter to try one more time.");
                    Console.ReadLine();
                }
            }
            //if user has no money left
            Console.WriteLine("It seems that you have no more money.  Do come again next time you are in town!");
            Console.ReadLine();
            // end of program
            Console.ReadLine();
    }

        private static void ComputerDrawsOne(SuperCard[] computerHand, CardSet myDeck)
        {
            bool done = false;
            for (int i = 0; i < computerHand.Length; i++)
            {
                if (computerHand[i].CardRank < Rank.Eight)
                {
                    if (!done)
                    {
                        computerHand[i] = myDeck.GetOneCard(1);
                        done = true;
                    }
                }
            }
        }

        private static void PlayerDrawsOne(SuperCard[] playersHand, CardSet myDeck)
        {
            bool done = false;
            while (!done)
            {
                Console.WriteLine("You can replace one of the cards in the deck if you want!");
                Console.Write("Type a number 1 - 5 to replace the corrosponding card, or press 0 to keep all cards.");
                int cardPlayerSelected = 0;
                string userInput = Console.ReadLine();
                cardPlayerSelected = Convert.ToInt32(userInput);
                if (cardPlayerSelected > 5 || cardPlayerSelected < 0)
                {
                    Console.WriteLine("ERROR selecting card!");
                }
                else if (cardPlayerSelected <= 5 && cardPlayerSelected>0)
                {
                    playersHand[cardPlayerSelected-1] = myDeck.GetOneCard(1);
                    done = true;
                }
                else if (cardPlayerSelected == 0)
                {
                    done = true;
                }
            }
        }

        private static bool CompareHands(SuperCard[] computerHands, SuperCard[] playersHands)
        {
            //Add up the value of the computerHands and the playersHands
            int playerTotal = 0;
            int computerTotal = 0;
            bool computerFlush = false;
            bool playerFlush = false;
            bool userWon = false;
            computerFlush = Flush(computerHands);
            playerFlush = Flush(playersHands);
            if (playerFlush == true && computerFlush == false)
            {
                userWon = true;
                Console.WriteLine("It's a flush!");
            }
            else if (computerFlush == true)
            {
                Console.WriteLine("It's a flush!");
            }
            else

            {
                for (int i = 0; i < computerHands.Length; i++)
                {
                    computerTotal = computerTotal + (int)computerHands[i].CardRank;
                    playerTotal = playerTotal + (int)playersHands[i].CardRank;
                }

                if (computerTotal < playerTotal)
                {
                    //return true;
                    userWon = true;
                }
                else
                {
                    //return false;
                    userWon = false;
                }
            }
            return userWon;
        }

        private static void DisplayHands(SuperCard[] computerHand, SuperCard[] playersHand)// how many cards in a hand??
                                                                                            //The number of cards are already set when the hands are declared on lines 27/28.  
        {
            Console.WriteLine("Hello!  The cards below are the computer's hand: ");
            for (int i = 0; i < computerHand.Length; i++)
            {
                computerHand[i].Display();    
            }

            Console.WriteLine("And this is your hand: ");
            for (int a = 0; a < playersHand.Length; a++)
            {
                playersHand[a].Display(); 
            }
        }

        private static bool Flush(SuperCard[] hand)
        {
            bool isFlush = false;
            int counter = 0;

            for (int i = 1; i < hand.Length; i++)
            {
                if (hand[0].Equals(hand[i]))
                {
                    counter++;
                }
                if(counter == 4)
                {
                    isFlush = true;
                }
            }
            return isFlush;
        }
    }
}
