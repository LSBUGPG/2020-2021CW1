using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    private Collider coll;

    public GameObject itemSwitch;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        coll = GetComponent<Collider>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (coll.Raycast(ray, out hit, 100.0f))
            {
                if (hit.collider.tag.Contains("Switch"))
                {
                    for (int i = 0; i < inventory.slots.Length; i++)
                    {
                        if (inventory.isFull[i] == false)
                        {
                            //item can be added to the inventory!
                            Debug.Log("item added");

                            inventory.isFull[i] = true;
                            Instantiate(itemSwitch, inventory.slots[i].transform, false);
                            Destroy(gameObject);
                            break;
                        }
                    }
                }
            }
        }
    }

}
