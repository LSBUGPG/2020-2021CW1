using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectItem : MonoBehaviour
{

    public TextMeshProUGUI itemText;
    public static int items;

    // Start is called before the first frame update
    void Start()
    {
        items = 0;

        SetItemText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetItemCount()
    {
        return items;
    }

    void SetItemText()
    {
        itemText.text = "Itmes: " + items.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            items = items + 1;

            SetItemText();
        }
    }
}
