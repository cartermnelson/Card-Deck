﻿using System;
using System.Collections.Generic;

namespace Card_Deck
{
    static class Constants
    {
        public static readonly string[] vals = {"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"};
        public static readonly string[] suits = {"Clubs", "Spades", "Hearts", "Diamonds"};
    }
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            deck.Shuffle();
            // deck.Reset();

            Player player = new Player("Bob");
            player.Draw(deck);
            player.Draw(deck);
            player.Discard(0);
            player.Discard(1);
        }
    }
    class Card
    {
        public string stringVal {get;set;}
        public string suit {get;set;}
        public int val {get;set;}

        public Card(string _suit, int _val)
        {
            suit = _suit;
            val = _val;
            stringVal = Constants.vals[_val-1];
        }
    }
    class Deck
    {
        public List<Card> cards = new List<Card>();

        public Deck()
        {
            foreach (var suit in Constants.suits)
            {
                for (int i = 1; i <= 13; i++)
                {
                    cards.Add(new Card(suit, i));
                }
            }
        }
        public Card Deal()
        {
            Card carddealt = cards[0];
            cards.RemoveAt(0);
            return carddealt;
        }
        public void Reset()
        {
            cards.Clear();
            foreach (var suit in Constants.suits)
            {
                for (int i = 1; i <= 13; i++)
                {
                    cards.Add(new Card(suit, i));
                }
            }
        }
        public void Shuffle()
        {
            for (int i = 0; i < cards.Count; i++)
            {
                int r = new Random().Next(cards.Count);
                Card temp = cards[i];
                cards[i] = cards[r];
                cards[r] = temp;
            }
        }
    }
    class Player
    {
        string name {get;set;}
        List<Card> hand = new List<Card>();

        public Player(string _name)
        {
            name = _name;
        }

        public Card Draw(Deck deck)
        {
            Card card = deck.Deal();
            hand.Add(card);
            return card;
        }
        public Card Discard(int i)
        {
            if (i < hand.Count)
            {
                Card card = hand[i];
                hand.RemoveAt(i);
                return card;
            }
            else
            {
                return null;
            }
        }
    }
}
