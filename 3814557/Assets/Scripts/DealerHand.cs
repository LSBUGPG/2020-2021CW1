using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealerHand : MonoBehaviour
{

    public List<GameObject> cards = new List<GameObject>();
    public GameObject card;
    int orderInLayer = 0;

    bool drawCards = false;

    float newCardTimer = 0f;
    float newCardCooldown = 1f;

    Vector2 newCardPos;

    public bool fin = false;

    // Start is called before the first frame update
    void Start()
    {
        newCardPos = transform.position;

        AddCardToHand(true);
        AddCardToHand(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(drawCards)
        {
            newCardTimer += Time.deltaTime;

            if(newCardTimer >= newCardCooldown)
            {
                newCardTimer = 0f;
                AddCardToHand(true);
            }

            if(handValue() >= 17)
            {
                drawCards = false;
                fin = true;
            }
        }
    }

    void AddCardToHand(bool faceUp)
    {
        GameObject newCard = Instantiate(card, newCardPos, Quaternion.identity);
        newCard.GetComponent<SpriteRenderer>().sortingOrder = orderInLayer;
        newCard.transform.parent = transform;

        newCard.GetComponent<CardController>().faceDown = !faceUp;
        newCard.GetComponent<CardController>().CalculateCard(Random.Range(0,51));

        cards.Add(newCard);

        newCardPos += new Vector2(.25f, .03f);
        transform.position -= new Vector3(.25f, .03f, 0);
        orderInLayer++;
    }

    public int handValue()
    {
        int aceCount = 0;
        int handVal = 0;
        foreach(GameObject c in cards)
        {
            CardController cc = c.GetComponent<CardController>();
            if(!cc.cardCalculated) cc.CalculateCard(Random.Range(0,51));

            if(cc.value == CardController.Value.ace)
            {
                aceCount++;
                handVal += 11;
            }
            else
            {
                handVal += cc.cardVal;
            }
        }

        if(handVal > 21)
        {
            if(aceCount > 0)
            {
                handVal -= 10;
                aceCount--;
            }
        }

        return handVal;
    }

    public void TurnOverCard()
    {
        foreach(GameObject g in cards)
        {
            g.GetComponent<CardController>().faceDown = false;
        }

        drawCards = true;
    }
}
