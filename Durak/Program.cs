using System;
using System.Collections.Generic;



enum AllCards
{
    SixOfClubs = 1,
    SevenOfClubs,
    EightOfClubs,
    NineOfClubs,
    TenOfClubs,
    JackOfClubs,
    QueenOfClubs,
    KingOfClubs,
    AceOfClubs,
    SixOfSpades,
    SevenOfSpades,
    EightOfSpades,
    NineOfSpades,
    TenOfSpades,
    JackOfSpades,
    QueenOfSpades,
    KingOfSpades,
    AceOfSpades,
    SixOfDiamonds,
    SevenOfDiamonds,
    EightOfDiamonds,
    NineOfDiamonds,
    TenOfDiamonds,
    JackOfDiamonds,
    QueenOfDiamonds,
    KingOfDiamonds,
    AceOfDiamonds,
    SixOfHearts,
    SevenOfHearts,
    EightOfHearts,
    NineOfHearts,
    TenOfHearts,
    JackOfHearts,
    QueenOfHearts,
    KingOfHearts,
    AceOfHearts,
}

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
    public Dictionary<AllCards, bool> Accesibility = new Dictionary<AllCards, bool>();
    public int Highness;
    
    public Cards[] AllCardsArray = new Cards[36];

    Cards(AllCards card)
    {
        Accesibility[card] = true;
    }

    public static void GetCardsToArray()
    {
        int i = 0;
        // foreach (AllCards card in Enum.GetValues(typeof(AllCards)))
        // {
        //     
        // }
    }
}

class Deck
{
    private AllCards[] MyDeck = new AllCards[6];

    Deck(int[] givenCards)
    {
        if (givenCards.Length == 6)
        {
            MyDeck[0] = (AllCards)givenCards[0];
            MyDeck[1] = (AllCards)givenCards[1];
            MyDeck[2] = (AllCards)givenCards[2];
            MyDeck[3] = (AllCards)givenCards[3];
            MyDeck[4] = (AllCards)givenCards[4];
            MyDeck[5] = (AllCards)givenCards[5];
        }
        else
        {
            throw new ArgumentException("The given array must have 6 elements.");
        }
    }
}

class Game
{
    static void Main(string[] args)
    {
        
    }
}
