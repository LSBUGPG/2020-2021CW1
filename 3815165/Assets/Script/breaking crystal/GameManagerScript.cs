using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public Text coinsLeft;

    public int cur_coins = 0;
    public int max_coins = 0;

    public GameObject Door;

    // Start is called before the first frame update
    void Start()
    {
        Door.SetActive (false);
        max_coins = cur_coins;
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateUI() 
    {
        if (cur_coins > 0) 
        {
            coinsLeft.text = "coin Left: " + cur_coins.ToString("D1") + "/" + max_coins.ToString("D1");
        } else if (cur_coins <= 0) {
            coinsLeft.text = "coin Left: " + cur_coins.ToString("D1") + "/" + max_coins.ToString("D1");
            Door.SetActive (true);
        }
       
    }
}
