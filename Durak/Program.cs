using System;
using System.Collections.Generic;



enum AllCardsInDeck // перелік усіх кард та їх нумерація
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
    SixOfSpades, // індекс - 10
    SevenOfSpades, 
    EightOfSpades,
    NineOfSpades,
    TenOfSpades,
    JackOfSpades,
    QueenOfSpades,
    KingOfSpades,
    AceOfSpades,
    SixOfDiamonds, // індекс - 19
    SevenOfDiamonds,
    EightOfDiamonds,
    NineOfDiamonds,
    TenOfDiamonds,
    JackOfDiamonds,
    QueenOfDiamonds,
    KingOfDiamonds,
    AceOfDiamonds,
    SixOfHearts, // індекс - 28
    SevenOfHearts,
    EightOfHearts,
    NineOfHearts,
    TenOfHearts,
    JackOfHearts,
    QueenOfHearts,
    KingOfHearts,
    AceOfHearts,
}

enum CardsSuits // масті карт
{
    Clubs = 1,
    Spades,
    Diamonds,
    Hearts,
}

enum HighnessOfCards // старшинство карт
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


class Cards // клас "карти"
{
    public HighnessOfCards Highness;
    public CardsSuits Suit;
    private bool CardAccessibility = true;

    public static Cards[] AllCardsArray = new Cards[36]; // масив з усіма картами у вигляді об'єктів класу

    public static void GetCardsToArray() // метод утворення масиву з картами AllCardsArray
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

        
    }
    

    public static void ShuffleCards() // метод перемішування карт
    {
        AllCardsInDeck[] NewShuffledDeck = new AllCardsInDeck[36];
        int iter = 0;
        NewShuffledDeck = OtherMethods.Shuffle();
        // створення масиву з пересортованими картами переведений у об'єкти класу Cards
        // Cards[] ShuffledDeck = new  Cards[36];
        foreach (var card in AllCardsArray)
        {
            (CardsSuits, HighnessOfCards) Card = OtherMethods.Convert(NewShuffledDeck[iter]);
            // Console.WriteLine($"{Card.Item1} {Card.Item2}");
            
            // ShuffledDeck[iter].Suit = Card.Item1;
            // ShuffledDeck[iter].Highness = Card.Item2;

            card.Suit = Card.Item1;
            card.Highness = Card.Item2;
            
            iter++;
        }
        // AllCardsArray = ShuffledDeck;
        
        
    }
}



class OtherMethods // клас з усіма іншими методами
{
    private static Random rand = new Random();
    public static (CardsSuits, HighnessOfCards) Convert(AllCardsInDeck card) // метод конвертації з обєкту переліку AllCardsInDeck
    {
        CardsSuits suit;
        HighnessOfCards rank;
        int[] Inted; // індекси (масть, старшинство) переліків CardsSuits та HighnessOfCards
        static int[] ConvertToInt(AllCardsInDeck card) //Конвертування з переліку всіх карт до класу Cards
        {
            int[] result = new int[2]; // результат у вигляді масиву з двох чисел (масть, старшинство)
            int Input = (int)card; // індекс вхідної карти з переліку AllCardsInDeck
            if (Input <= 9) // перевірка масті
            {
                result[0] = 1;
            }
            else if (Input <= 18)
            {
                result[0] = 2;
            }
            else if (Input <= 27)
            {
                result[0] = 3;
            }
            else
            {
                result[0] = 4;
            }

            switch (Input) // перевірка старшинства
            {
                case 1 or 10 or 19 or 28:
                    result[1] = 1;
                    break;
                case 2 or 11 or 20 or 29:
                    result[1] = 2;
                    break;
                case 3 or 12 or 21 or 30:
                    result[1] = 3;
                    break;
                case 4 or 13 or 22 or 31:
                    result[1] = 4;
                    break;
                case 5 or 14 or 23 or 32:
                    result[1] = 5;
                    break;
                case 6 or 15 or 24 or 33:
                    result[1] = 6;
                    break;
                case 7 or 16 or 25 or 34:
                    result[1] = 7;
                    break;
                case 8 or 17 or 26 or 35:
                    result[1] = 8;
                    break;
                case 9 or 18 or 27 or 36:
                    result[1] = 9;
                    break;
            }

            if (result[0] != null && result[1] != null) // перевірка можливості результату
            {
                return result;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }

        }

        Inted = ConvertToInt(card);
        switch (Inted[0]) // генерування масті карти з переліку CardsSuits
        {
            case 1:
                suit = CardsSuits.Clubs;
                break;
            case 2:
                suit = CardsSuits.Spades;
                break;
            case 3:
                suit = CardsSuits.Diamonds;
                break;
            case 4:
                suit = CardsSuits.Hearts;
                break;
            default:
                throw new IndexOutOfRangeException();
        }

        switch (Inted[1])
        {
            case 1:
                rank = HighnessOfCards.Six;
                break;
            case 2:
                rank = HighnessOfCards.Seven;
                break;
            case 3:
                rank = HighnessOfCards.Eight;
                break;
            case 4:
                rank = HighnessOfCards.Nine;
                break;
            case 5:
                rank = HighnessOfCards.Ten;
                break;
            case 6:
                rank = HighnessOfCards.Jack;
                break;
            case 7:
                rank = HighnessOfCards.Queen;
                break;
            case 8:
                rank = HighnessOfCards.King;
                break;
            case 9:
                rank = HighnessOfCards.Ace;
                break;
            default:
                throw new IndexOutOfRangeException();
        }
        
        return (suit, rank);
    }
    

    public static AllCardsInDeck[] Shuffle()
    {
        static AllCardsInDeck[] CreateNewShuffledDeck()
        {
            AllCardsInDeck[] NewShuffledDeck = new AllCardsInDeck[36];
            int cardToShuffle;
            for (int i = 0; i < 36; i++)
            {
                while (true)
                {
                    cardToShuffle = rand.Next(1, 37);
                    if (NewShuffledDeck.Contains((AllCardsInDeck)cardToShuffle)==false)
                    {
                        NewShuffledDeck[i] = (AllCardsInDeck)cardToShuffle;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            
            return NewShuffledDeck;
        }
        return CreateNewShuffledDeck();
    }
}

class Program
{
    static void Main(string[] args)
    {
        
    }
}
