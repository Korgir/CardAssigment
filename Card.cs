using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codetest__Columbus
{
    //implement Icomarable interface for sorting
    public class Card : IComparable
    {
        public enum CardType { hearts=1, diamonds, clover, spades };
        public enum CardNumber { ace=1, two, three, four, five, six, seven, eight, nine , ten, knight, queen, king };
        private CardType cardType;
        private CardNumber cardNumber;
        public const int numberofTypes = 4;
        public const int numberOfDifferentValues = 13;

        public Card (CardType cardType, CardNumber cardNumber)
        {           
            this.cardType = cardType;
            this.cardNumber = cardNumber;
        }



        /// <summary>
        /// Compares Card with obj
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>
        /// negative value means card less than obj 
        /// 0 means card equals obj 
        /// positive means card greater than obj
        /// </returns>
        public int CompareTo(object obj)
        {
            if (obj is Card)
            {
                Card toCompare = (Card)obj;
                if(toCompare.cardType == this.cardType)
                {              
                    return this.cardNumber - toCompare.cardNumber;
                }
                else
                {
                    return this.cardType - toCompare.cardType ;
                }

            }
            //throws exception if obj is not a card.
            throw new ArgumentException("Object is not a Card");
        }

        public override string ToString()
        {
            return "Cardtype: " + cardType + " Number: " + cardNumber;
        }
    }
}
