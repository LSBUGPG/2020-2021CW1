using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetMouseButtonDown (0)) 
         {    
             var ray = Camera.main.ScreenPointToRay(Input.mousePosition); // creating the origin as from the main camera
             
             RaycastHit hit;
 
             if (Physics.Raycast(ray, out hit)) // origin is ray and the direction is outwards for a max dist of a 100 (against all colliders in scene)
             {
                 // whatever tag you are looking for on your game object
                 if(hit.collider.tag == "Box") // check if the gameobjects hit have the tag box
                 {                         
                     //Debug.Log("---> Hit: "); 
                     Destroy(hit.collider.gameObject);   // Destroy the gameobject
                 }    
             }
         }
    }
}
