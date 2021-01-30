using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    public Sprite[] cards; // (He->Cl->Di->Sp, Ace->King)

    public enum Suit{
        hearts,
        clubs,
        diamonds,
        spades
    }

    public enum Value{
        ace,
        two,
        three,
        four,
        five,
        six,
        seven,
        eight,
        nine,
        ten,
        jack,
        queen,
        king
    }

    public Suit suit;
    public Value value;

    SpriteRenderer sr;

    Sprite faceUpSprite;
    public Sprite faceDownSprite;

    public bool faceDown = false;

    public int cardVal;

    public bool cardCalculated = false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(faceDown)
        {
            sr.sprite = faceDownSprite;
        }
        else
        {
            sr.sprite = faceUpSprite;
        }

    }

    public void CalculateCard(int index)
    {
        // suit
        int suitCalc = (int) Mathf.Floor(index / 13);

        switch(suitCalc)
        {
            case(0):
                suit = Suit.hearts;
                break;
            case(1):
                suit = Suit.clubs;
                break;
            case(2):
                suit = Suit.diamonds;
                break;
            case(3):
                suit = Suit.spades;
                break;
            default:
                print("Error calculating suit");
                break;
        }

        // value
        int valueCalc = index % 13;
        
        switch(valueCalc)
        {
            case (0):
                value = Value.ace;
                cardVal = 1;
                break;
            case (1):
                value = Value.two;
                cardVal = 2;
                break;
            case (2):
                value = Value.three;
                cardVal = 3;
                break;
            case (3):
                value = Value.four;
                cardVal = 4;
                break;
            case (4):
                value = Value.five;
                cardVal = 5;
                break;
            case (5):
                value = Value.six;
                cardVal = 6;
                break;
            case (6):
                value = Value.seven;
                cardVal = 7;
                break;
            case (7):
                value = Value.eight;
                cardVal = 8;
                break;
            case (8):
                value = Value.nine;
                cardVal = 9;
                break;
            case (9):
                value = Value.ten;
                cardVal = 10;
                break;
            case (10):
                value = Value.jack;
                cardVal = 10;
                break;
            case (11):
                value = Value.queen;
                cardVal = 10;
                break;
            case (12):
                value = Value.king;
                cardVal = 10;
                break;
            default:
                print("error calculating value");
                break;
        }

        faceUpSprite = cards[index];

        cardCalculated = true;
        // print(suit + ", " + value);
    }
}
