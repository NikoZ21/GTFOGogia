using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public enum CardSuit
    {
        clubs = 1,
        diamonds = 2,
        hearts = 3,
        spades = 4,
    }

    public enum CardRank
    {
        six = 6,
        seven = 7,
        eigth = 8,
        nine = 9,
        ten = 10,
        J = 11,
        Q = 12,
        K = 13,
        A = 14,
    }

    public CardRank cardRank;
    public CardSuit cardSuit;
}