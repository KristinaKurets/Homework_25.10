using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
            Console.WriteLine("Let's play the Drunkard! The rules are very simple:each of the players throws the top card of his deck onto the table." +
                "A player whose card is older takes all the cards from the table and puts them under the bottom of his deck.Ace is older than all cards except six.");
            Console.WriteLine("Press any key to start the game.");
            Console.ReadKey();
            int count = 0;
            while (Player1.Count != 0 && Player2.Count != 0)
            {
                Console.WriteLine($"\nYour card is: {Player1[0]}. My card is: {Player2[0]}");
                Thread.Sleep(200);
                if ((int)Player1[0].Value > (int)Player2[0].Value)
                {

                    if (Player1[0].Value == CardValue.Ace && Player2[0].Value == CardValue.six)
                    {
                        TakeCards(Player1, Player2);
                        Console.WriteLine($"I take your card. There are {Player1.Count} cards in your deck, and {Player2.Count} in mine.");
                    }
                    else
                    {
                        TakeCards(Player2, Player1);
                        Console.WriteLine($"You take my card. There are {Player1.Count} cards in your deck, and {Player2.Count} in mine.");
                    }
                }

                else if ((int)Player1[0].Value < (int)Player2[0].Value)
                {
                    if (Player2[0].Value == CardValue.Ace && Player1[0].Value == CardValue.six)
                    {
                        TakeCards(Player1, Player2);
                        Console.WriteLine($"You take my card. There are {Player1.Count} cards in your deck, and {Player2.Count} in mine.");
                    }
                    else
                    {
                        TakeCards(Player1, Player2);
                        Console.WriteLine($"I take your card. There are {Player1.Count} cards in your deck, and {Player2.Count} in mine.");
                    }
                }

                else
                {
                    EqualCards(Player1, Player2);
                    Console.WriteLine("We have equal cards.");
                }

                if (Player1.Count == 0) Console.WriteLine("You won!");
                else if (Player2.Count == 0) Console.WriteLine("I won!");
                
                count++;
                if (count > 500)
                {
                    Console.WriteLine("It's too boring. Let's drink better");
                    break;
                }
            }
        }

        public void TakeCards(List<Card> FromPlayer, List <Card>ToPlayer)
        {
            ToPlayer.Add(FromPlayer[0]);
            FromPlayer.RemoveAt(0);
            ToPlayer.Add(ToPlayer[0]);
            ToPlayer.RemoveAt(0);
        }

        public void EqualCards(List<Card> player2, List<Card> player1)
        {
            player2.Add(player2[0]);
            player2.RemoveAt(0);
            player1.Add(player1[0]);
            player1.RemoveAt(0);
        }

        public void Start()
        {
            CreatingDeck();
            ShuffleDeck();
            DeckDivision();
            Game();
            //ShowDeck();
        }
    }

    
}
