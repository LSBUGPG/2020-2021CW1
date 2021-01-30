using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour {

    GameManagerScript GMS;
    private float rotateSpeed = 1f;

    // Start is called before the first frame update
    void Awake()
    {

        GMS = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        GMS.cur_coins++;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed);
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {

            Destroy(gameObject);
            GMS.cur_coins--;
            GMS.UpdateUI();
        }

    }

}
