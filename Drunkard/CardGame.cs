using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static Drunkard.Card;

namespace Drunkard
{
    class CardGame
    {
        public List<Card> Deck { get; set; }
        public List<Card> Player1 { get; set; }
        public List<Card> Player2 { get; set; }

        public void CreatingDeck()
        {
            Deck = new List<Card>();
            foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
            {
                foreach (CardValue value in Enum.GetValues(typeof(CardValue)))
                {
                    Deck.Add(new Card { Suit = suit, Value = value });
                }
            }
        }

        public void ShuffleDeck()
        {
            Deck = Deck.OrderBy(c => Guid.NewGuid()).ToList();
        }

        public void ShowDeck()
        {
            Console.WriteLine("This is Player1's deck:");
            Player1.ForEach(Console.WriteLine);
            Console.WriteLine();
            Console.WriteLine("This is Player2's deck:");
            Player2.ForEach(Console.WriteLine);
        }

        public void DeckDivision()
        {
           Player1 = new List<Card>();
           Player2 = new List<Card>();
           Player1 = Deck.GetRange(0, Deck.Count/2);
           Player2 = Deck.GetRange(18, Deck.Count/2);
        }

        public void Game()
        {
            
            while (Player1.Count != 0 || Player2.Count != 0)
            {
                Console.WriteLine($"Player1's card: {Player1[0]}. Player2's card: {Player2[0]}");
                if ((int)Player1[0].Value > (int)Player2[0].Value)
                {

                    Player1.Add(Player2[0]);
                    Player2.RemoveAt(0);
                    Console.WriteLine($"Player1 won.");
                    Player1.Add(Player1[0]);
                    Player1.RemoveAt(0);

                }

                else if ((int)Player1[0].Value < (int)Player2[0].Value)
                {
                    Player2.Add(Player1[0]);
                    Player1.RemoveAt(0);
                    //Console.WriteLine($"Player2 won.");
                    Player2.Add(Player2[0]);
                    Player2.RemoveAt(0);

                }

                else
                {
                    Player2.Add(Player2[0]);
                    Player2.RemoveAt(0);
                    Player1.Add(Player1[0]);
                    Player2.RemoveAt(0);
                }


            }
            
        }
        

        public void Start()
        {
            CreatingDeck();
            ShuffleDeck();
            DeckDivision();
            Game();
            ShowDeck();
        }
    }

    
}
