using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codetest__Columbus
{
    public class Deck
    {
        private List<Card> deck;
        

        public Deck()
        {
            deck = new List<Card>();
            //create unused deck
            createCardPile();
        }

        public List<Card> Cards
        {
            get { return deck; }
            set { deck = value; }
        }

        
        public void createCardPile()
        {
            
            //clear the deck before we add the new cards in to the deck.
            deck.Clear();
            //the value of the first for loop determens the card type, 
            //, the value of the 2nd loop determens the card number            
            for (int i = 1; i < Card.numberofTypes+1; i++)
            {
                for (int j = 1; j < Card.numberOfDifferentValues+1; j++)
                {
                    //adding the cards with the correct type and number. 
                    deck.Add( new Card((Card.CardType)i, (Card.CardNumber)j));
                }
            }
        }

        public void  ShufflePile()
        {
            //use current time in millis as seed.
            Random rand = new Random(DateTime.Now.Millisecond);
            
            //checking to make sure there are cards in the deck.
            if(deck.Count > 0)
            {
                //switching the position of two cards in the deck a 1000 times.
                for (int i = 0; i < 1000; i++)
                {
                    int previndex = rand.Next(0, deck.Count());
                    int newindex = rand.Next(0, deck.Count());

                    Card IndexCard = deck[previndex];
                    Card newIndexCard = deck[newindex];

                    deck[previndex] = newIndexCard;
                    deck[newindex] = IndexCard;
                }
            }
            
        }

        //sort the deck using the comparedTo in the card class.
        public void SortPile()
        {
            deck.Sort();
        }

        
        public Card PullCard()
        {
            //checking if there are any cards in the deck.
            if (deck.Count > 0)
            {
                //choose the first/top card, (posistion 0), 
                //remove it from the deck and use the card as the return value.
                Card topCard = deck[0];
                deck.RemoveAt(0);
                return topCard;
            }
            //if deck is empty, return null
            return null;
        }

    }


    
}
