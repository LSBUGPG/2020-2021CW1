using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    GameManagerScript GMS;
    private float rotateSpeed = 4.0f;

    void Awake() 
    {
        GMS = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        GMS.cur_coins++;
    }

    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.left * rotateSpeed);
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy (gameObject);
            GMS.cur_coins--;

            GMS.UpdateUI();
        }
    }
}
