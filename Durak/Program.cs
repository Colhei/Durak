using System;
using System.Collections.Generic;
using System.Data.SqlTypes;


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

enum CardsSuits // масті карт
{
    Clubs,
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
    private bool CardAvailable = true;

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
            Console.WriteLine($"{Card.Item1} {Card.Item2}");
            
            

            card.Suit = Card.Item1;
            card.Highness = Card.Item2;
            
            iter++;
        }
        // AllCardsArray = ShuffledDeck;
        
        
    }
}



class OtherMethods // усі інші методами
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

    public static AllCardsInDeck ConvertToCard(HighnessOfCards highness, CardsSuits suit)
    {
        try
        {
            int cardIndex;
            int rankIndex = (int)highness;
            int suitIndex = (int)suit;
            AllCardsInDeck result;
            cardIndex = rankIndex + (suitIndex * 9);
            result = (AllCardsInDeck)cardIndex;
            Console.WriteLine($"{cardIndex} \n {result}");
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Виникла помилка у обробці входу --> {e.Message}");
            return default;
        }
    }
    
    public static List<AllCardsInDeck> PlayerInputConv(string input) 
    {
        try
        {
            List<AllCardsInDeck> result = new List<AllCardsInDeck>();
            (CardsSuits, HighnessOfCards) card;
            (CardsSuits, HighnessOfCards) card2;
            string[] playerInp = input.Split(" ");
            if (playerInp[0] == "six" || playerInp[0] == "6")
            {
                card.Item2 = HighnessOfCards.Six;
            }else if (playerInp[0] == "seven" || playerInp[0] == "7")
            {
                card.Item2 = HighnessOfCards.Seven;
            }else if (playerInp[0] == "eight" || playerInp[0] == "8")
            {
                card.Item2 = HighnessOfCards.Eight;
            }else if (playerInp[0] == "nine" || playerInp[0] == "9")
            {
                card.Item2 = HighnessOfCards.Nine;
            }else if (playerInp[0] == "ten" || playerInp[0] == "10")
            {
                card.Item2 = HighnessOfCards.Ten;
            }else if (playerInp[0] == "jack")
            {
                card.Item2 = HighnessOfCards.Jack;
            }else if (playerInp[0] == "queen")
            {
                card.Item2 = HighnessOfCards.Queen;
            }else if (playerInp[0] == "king")
            {
                card.Item2 = HighnessOfCards.King;
            }else if (playerInp[0] == "ace")
            {
                card.Item2 = HighnessOfCards.Ace;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }

            if (playerInp[2] == "spades")
            {
                card.Item1 = CardsSuits.Spades;
            }else if (playerInp[2] == "diamonds")
            {
                card.Item1 = CardsSuits.Diamonds;
            }else if (playerInp[2] == "hearts")
            {
                card.Item1 = CardsSuits.Hearts;
            }else if (playerInp[2] == "clubs")
            {
                card.Item1 = CardsSuits.Clubs;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
            
            if (playerInp[3] == "six" || playerInp[3] == "6")
            {
                card2.Item2 = HighnessOfCards.Six;
            }else if (playerInp[3] == "seven" || playerInp[3] == "7")
            {
                card2.Item2 = HighnessOfCards.Seven;
            }else if (playerInp[3] == "eight" || playerInp[3] == "8")
            {
                card2.Item2 = HighnessOfCards.Eight;
            }else if (playerInp[3] == "nine" || playerInp[3] == "9")
            {
                card2.Item2 = HighnessOfCards.Nine;
            }else if (playerInp[3] == "ten" || playerInp[3] == "10")
            {
                card2.Item2 = HighnessOfCards.Ten;
            }else if (playerInp[3] == "jack")
            {
                card2.Item2 = HighnessOfCards.Jack;
            }else if (playerInp[3] == "queen")
            {
                card2.Item2 = HighnessOfCards.Queen;
            }else if (playerInp[3] == "king")
            {
                card2.Item2 = HighnessOfCards.King;
            }else if (playerInp[3] == "ace")
            {
                card2.Item2 = HighnessOfCards.Ace;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }

            if (playerInp[5] == "spades")
            {
                card2.Item1 = CardsSuits.Spades;
            }else if (playerInp[5] == "diamonds")
            {
                card2.Item1 = CardsSuits.Diamonds;
            }else if (playerInp[5] == "hearts")
            {
                card2.Item1 = CardsSuits.Hearts;
            }else if (playerInp[5] == "clubs")
            {
                card2.Item1 = CardsSuits.Clubs;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
            
            
            
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine($"помилка у обробці входу -> {e.Message}");
            Game.GameInProcess = false;
            return null;
        }
    }
    
}

class Player
{
    private AllCardsInDeck[] PlayerDeck = new AllCardsInDeck[6];
    public string PlayerName;
    const int MaxCards = 6;

    public Player(string playerName)
    {
        PlayerName = playerName;
    }

    int CountCards()
    {
        int iter = 0;
        int TotalCards = 0;
        Console.WriteLine(PlayerDeck[0]);
        foreach (var card in PlayerDeck)
        {
            if (card != null && card != default)
            {
                TotalCards++;
            }
            iter++;
        }
        return TotalCards;
    }

    void GetCards()
    {
        if (CountCards() < MaxCards)
        {
            foreach (var card in PlayerDeck)
            {
                if (card != null && card != default)
                {
                    
                }
                else
                {
                    continue;
                }
            }
        }
    }
}

class Game
{
    public static int PlayerAmount = 4;
    public static bool GameInProcess = true;

    static (CardsSuits, HighnessOfCards) PlayerInput(string input)
    {
        try
        {
            (CardsSuits, HighnessOfCards) ReturnArr = (default, default);
            string[] Parts = input.Split(' ');
            // місце для перевірки вірності вводу

            switch (Parts[0]) // встановлення старшинства карти
            {
                case "6":
                    ReturnArr.Item2 = HighnessOfCards.Six;
                    break;
                case "7":
                    ReturnArr.Item2 = HighnessOfCards.Seven;
                    break;
                case "8":
                    ReturnArr.Item2 = HighnessOfCards.Eight;
                    break;
                case "9":
                    ReturnArr.Item2 = HighnessOfCards.Nine;
                    break;
                case "10":
                    ReturnArr.Item2 = HighnessOfCards.Ten;
                    break;
                case "Jack":
                    ReturnArr.Item2 = HighnessOfCards.Jack;
                    break;
                case "Queen":
                    ReturnArr.Item2 = HighnessOfCards.Queen;
                    break;
                case "King":
                    ReturnArr.Item2 = HighnessOfCards.King;
                    break;
                case "Ace":
                    ReturnArr.Item2 = HighnessOfCards.Ace;
                    break;
            }

            switch (Parts[2])
            {
                case "clubs":
                    ReturnArr.Item1 = CardsSuits.Clubs;
                    break;
                case "spades":
                    ReturnArr.Item1 = CardsSuits.Spades;
                    break;
                case "diamonds":
                    ReturnArr.Item1 = CardsSuits.Diamonds;
                    break;
                case "hearts":
                    ReturnArr.Item1 = CardsSuits.Hearts;
                    break;
            }
            return ReturnArr;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Виникла помилка {e}: {e.Message}");
            GameInProcess = false;
        }
        return default;
    }
}

class Program
{
    static void Main(string[] args)
    {
        
    }
}

/*
 *
 *
 *          ввід:
 * 
 *          ввід карти: *старшинство* of *масть*    приклад  -->   six of spades (6 of Spades) = шість пікових,   queen of hearts = чирвова дама
 *          ввід ходу:     *карта яку бити* *карта якою бити*   приклад -->   six of clubs ten of clubs = побити шістку хрестову десфткою хрестовою
 *
 * 
 */

