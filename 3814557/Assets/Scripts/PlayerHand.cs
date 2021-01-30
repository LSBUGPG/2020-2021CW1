using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHand : MonoBehaviour
{

    public List<GameObject> cards = new List<GameObject>();
    public GameObject card;
    int orderInLayer = 0;

    Vector2 newCardPos;

    public Button hitBut, standBut;
    public GameObject uiBlackjack, uiBust, uiPWin, uiDWin, uiDraw;

    DealerHand dh;
    bool checkForDealerHand = false;

    // Start is called before the first frame update
    void Start()
    {
        newCardPos = transform.position;
        // two cards in hand
        AddCardToHand();
        AddCardToHand();

        if(handValue() == 21)
        {
            // blackjack
            uiBlackjack.SetActive(true);
            hitBut.interactable = false;
            standBut.interactable = false;
        }
        
    }

    void AddCardToHand()
    {
        GameObject newCard = Instantiate(card, newCardPos, Quaternion.identity);
        newCard.GetComponent<SpriteRenderer>().sortingOrder = orderInLayer;
        newCard.transform.parent = transform;

        newCard.GetComponent<CardController>().CalculateCard(Random.Range(0,51));

        cards.Add(newCard);

        newCardPos += new Vector2(.25f, .03f);
        transform.position -= new Vector3(.25f, .03f, 0);
        orderInLayer++;
    }

    int handValue()
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

    public void Hit()
    {
        AddCardToHand();

        int val = handValue();
        if(val > 21) 
        {
            // show bust overlay
            // disable hit and stand buttons
            hitBut.interactable = false; standBut.interactable = false;
            uiBust.SetActive(true);
        }

        print(val);
    }

    public void Stand()
    {
        // stop adding cards
        // reveal dealer's upside down card
        // dealer starts to hit until 17
        // dealer hand only hits if the player hasn't busted or blackjacked
        // dealer stands when hand val >= 17

        hitBut.interactable = false;
        standBut.interactable = false;
        
        dh = GameObject.Find("Dealer hand").GetComponent<DealerHand>();
        checkForDealerHand = true;
    }

    void Update()
    {
        if(checkForDealerHand)
        {
            if(dh.fin)
            {
                int d = dh.handValue();
                int p = handValue();
                checkForDealerHand = false;

                if(d > p)
                {
                    if(d > 21)
                    {
                        // p win
                        uiPWin.SetActive(true);
                    }
                    else
                    {
                        // d win
                        uiDWin.SetActive(true);
                    }
                }
                else if(d < p)
                {
                    // p win
                    uiPWin.SetActive(true);
                }
                else if(d == p)
                {
                    // draw
                    uiDraw.SetActive(true);
                }
            }
        }
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
