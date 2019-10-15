using System;
using System.Collections.Generic;
using Codetest__Columbus;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DeckUnitTest
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestSort()
        {

            //create a set of test cards
            Card D4 = new Card(Card.CardType.diamonds, Card.CardNumber.four);
            Card SKn = new Card(Card.CardType.spades, Card.CardNumber.knight);
            Card H7 = new Card(Card.CardType.hearts, Card.CardNumber.seven);
            Card Ca = new Card(Card.CardType.clover, Card.CardNumber.ace);
            Card S3 = new Card(Card.CardType.spades, Card.CardNumber.three);

            //add test cards to list
            List<Card> UnitTestList = new List<Card>();
            UnitTestList.Add(D4);
            UnitTestList.Add(SKn);
            UnitTestList.Add(H7);
            UnitTestList.Add(Ca);
            UnitTestList.Add(S3);

            //create a custom deck
            Deck deck = new Deck();
            deck.Cards = UnitTestList;
            //sorting the custom deck.
            deck.SortPile();
            //checking if the deck has been sorted according to the correct rules.
            Assert.AreEqual(UnitTestList[0], H7);
            Assert.AreEqual(UnitTestList[1], D4);
            Assert.AreEqual(UnitTestList[2], Ca);
            Assert.AreEqual(UnitTestList[3], S3);
            Assert.AreEqual(UnitTestList[4], SKn);

        }

        [TestMethod]
        public void TestSortRandom()
        {
            Deck deck = new Deck();
            Random rand = new Random();
            List<Card> UnitTestList = new List<Card>();
            //adding 20 random cards to the deck.
            for (int i = 0; i < 20; i++)
            {
                UnitTestList.Add(new Card((Card.CardType)rand.Next(1, Card.numberofTypes+1), (Card.CardNumber)rand.Next(1, Card.numberOfDifferentValues+1)));
            }
            deck.Cards = UnitTestList;
            //sorting the deck.
            deck.SortPile();
            //checking if the deck has been sorted according to the correct rules.
            for (int i = 1; i < 20; i++)
            {
                //using cards ComparedTo method to verify order
                Assert.IsTrue(deck.Cards[i - 1].CompareTo(deck.Cards[i]) <= 0);
            }
        }

        [TestMethod]
        public void TestShuffle()
        {
            Deck deck = new Deck();
            Random rand = new Random();
            List<Card> UnitTestList = new List<Card>();
            //create a thousand cards.
            for (int i = 0; i < 1000; i++)
            {
                UnitTestList.Add(new Card((Card.CardType)rand.Next(1, Card.numberofTypes+1), (Card.CardNumber)rand.Next(1, Card.numberOfDifferentValues+1)));
            }
            //making a copy.
            deck.Cards = new List<Card>(UnitTestList);
            //shuffle the non copy deck.
            deck.ShufflePile();
            bool diff = false;
            for (int i = 0; i < deck.Cards.Count; i++)
            {
                //comparing the two decks, if they are not the same set diff to true.
                if (deck.Cards[i] != UnitTestList[i])
                {
                    diff = true;
                }
            }
            Assert.IsTrue(diff);
        }

        [TestMethod]
        public void TestPull()
        {
            //creating the cards and the deck.
            Deck deck = new Deck();
            Card D4 = new Card(Card.CardType.diamonds, Card.CardNumber.four);
            Card SKn = new Card(Card.CardType.spades, Card.CardNumber.knight);
            Card H7 = new Card(Card.CardType.hearts, Card.CardNumber.seven);
            Card Ca = new Card(Card.CardType.clover, Card.CardNumber.ace);
            Card S3 = new Card(Card.CardType.spades, Card.CardNumber.three);
            List<Card> UnitTestList = new List<Card>();
            UnitTestList.Add(D4);
            UnitTestList.Add(SKn);
            UnitTestList.Add(H7);
            UnitTestList.Add(Ca);
            UnitTestList.Add(S3);
            deck.Cards = UnitTestList;
            //pulling the top card and checking that the correct card was pulled.
            Assert.AreEqual(deck.PullCard(), D4);
            Assert.AreEqual(deck.PullCard(), SKn);
            Assert.AreEqual(deck.PullCard(), H7);
            Assert.AreEqual(deck.PullCard(), Ca);
            Assert.AreEqual(deck.PullCard(), S3);
            Assert.AreEqual(deck.PullCard(), null);
        }

        [TestMethod]
        public void TestCreatDeck()
        {
            //creat a cardtype list with the different types
            List<Card.CardType> cardTypes = new List<Card.CardType>();
            cardTypes.Add(Card.CardType.hearts);
            cardTypes.Add(Card.CardType.diamonds);
            cardTypes.Add(Card.CardType.clover);
            cardTypes.Add(Card.CardType.spades);

            //create the correct hashset with correct tostrings.
            // hashset is used  for contains check and to remove order dependency.
            HashSet<string> correctToStringHashSet = new HashSet<string>();
            for (int i = 0; i < cardTypes.Count; i++)
            {
                //loop through card types and add them to the hashset with the correct toString value
                Card.CardType cardTypeVarible = cardTypes[i];
                for (int j = 1; j < Card.numberOfDifferentValues+1; j++)
                {
                    correctToStringHashSet.Add("Cardtype: " + cardTypeVarible + " Number: " + (Card.CardNumber)j);
                }
            }
            //create the default deck and add to string in to a hashset.
            Deck defaultDeck = new Deck();
            defaultDeck.createCardPile();
            Assert.IsTrue(defaultDeck.Cards.Count == Card.numberOfDifferentValues*Card.numberofTypes);
            HashSet<string> deckCardsHashSet = new HashSet<string>();
            for (int i = 0; i < defaultDeck.Cards.Count; i++)
            {
                deckCardsHashSet.Add(defaultDeck.Cards[i].ToString());
            }
      
            // loop through the correct tostring  hashset and check so that the decks hashset contains the correct to string.
            foreach (string toStringCompare in correctToStringHashSet)
            {
                Assert.IsTrue(deckCardsHashSet.Contains(toStringCompare));
                
            }

            
            
        }

    }
}
