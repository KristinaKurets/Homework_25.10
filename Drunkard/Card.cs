using System;
using System.Collections.Generic;
using System.Text;

namespace Drunkard
{
    class Card
    {
        public CardValue Value { get; set; }
        public CardSuit Suit { get; set; }
        public override string ToString()
        {
            return $"{Suit}:{Value}";
        }

        public enum CardSuit
        {
            Diamonds,
            Hearts,
            Spades,
            Clubs
        }

        public enum CardValue
        {
            six = 6,
            seven = 7,
            eight = 8,
            nine = 9,
            ten = 10,
            Jack = 11,
            Queen = 12,
            King = 13,
            Ace = 14
        }

        public int ValueToInt()
        {
            switch (Value)
            {
                case CardValue.six:
                    return 6;
                case CardValue.seven:
                    return 7;
                case CardValue.eight:
                    return 8;
                case CardValue.nine:
                    return 9;
                case CardValue.ten:
                    return 10;
                case CardValue.Jack:
                    return 11;
                case CardValue.Queen:
                    return 12;
                case CardValue.King:
                    return 13;
                case CardValue.Ace:
                    return 14;
            }
            return 0;
        }
    }
}
