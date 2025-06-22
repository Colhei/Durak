using System;
using System.Collections.Generic;




enum CardsSuits
{
    Clubs = 1,
    Spades,
    Diamonds,
    Hearts,
}

enum HighnessOfCards
{
    Six = 1,
    Seven,
    Eight,
    Nine,
    Ten,
    Jack,
    Queen,
    King,
    Ace
}


class Cards
{
    public HighnessOfCards Highness;
    public CardsSuits Suit;

    public static Cards[] AllCardsArray = new Cards[36];



    public static void GetCardsToArray()
    {
        int i = 0;
        foreach (CardsSuits suit in Enum.GetValues(typeof(CardsSuits)))
        {
            foreach (HighnessOfCards highness in Enum.GetValues(typeof(HighnessOfCards)))
            {
                AllCardsArray[i] = new Cards();
                AllCardsArray[i].Suit = suit;
                AllCardsArray[i].Highness = highness;
                i++;
            }
        }

        // foreach (Cards card in AllCardsArray)
        // {
        //     Console.WriteLine($"{card.Highness} of {card.Suit}");
        // }
    }
}



class OtherMethods
{
    // static string UserInput(string input)
    // {
    //     
    // }

    // static Cards[] Shuffle()
    // {
    //     
    // }
}

class Program
{
    static void Main(string[] args)
    {
        Cards.GetCardsToArray();
    }
}
