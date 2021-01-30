using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {

    public Text coinsLeft;

    public int cur_coins = 0;
    public int max_coins = 0; 

    public GameObject Door;
   
    // Start is called before the first frame update
    void Start()
    {
        Door.SetActive (false);
        max_coins = cur_coins;
        UpdateUI (); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void UpdateUI() 
    {
        if (cur_coins > 0)
        {
            coinsLeft.text = "Honey    " + cur_coins.ToString ("D");

        }
        else if (cur_coins <= 0) {
            coinsLeft.text = "Honey    " + cur_coins.ToString ("D");
            Door.SetActive (true);
        }

    }


}
