using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class CreateCards : MonoBehaviour
{
    [SerializeField] private GameObject _card;

    void Start()
    {
        Texture2D[] sprites = Resources.LoadAll<Texture2D>("Cards");

        if (sprites == null)
        {
            Debug.Log("Couldn't get images");
        }
        else
        {
            CreateDeck(sprites);
        }
    }


    void CreateDeck(Texture2D[] sprites)
    {
        foreach (Texture2D sprite in sprites)
        {
            string[] typeOfCard = sprite.name.Split("_");

            GameObject card = Instantiate(_card, transform.position, transform.rotation, transform);
            card.GetComponent<Card>().cardSuit = Enum.Parse<Card.CardSuit>(typeOfCard[1]);
            card.GetComponent<SpriteRenderer>().sprite = Sprite.Create(sprite,
                new Rect(0, 0, sprite.width, sprite.height), new Vector2(0.5f, 0.5f));
            if (int.TryParse(typeOfCard[2], out int x))
            {
                card.GetComponent<Card>().cardRank = (Card.CardRank)x;
                if (x < 6)
                {
                    Destroy(card);
                }
            }
            else
            {
                card.GetComponent<Card>().cardRank = Enum.Parse<Card.CardRank>(typeOfCard[2]);
            }
        }
    }
}