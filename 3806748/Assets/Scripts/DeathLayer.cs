using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathLayer : MonoBehaviour
{
    [SerializeField] private string[] AcceptedTags;

    private void OnCollisionEnter(Collision collision)
    {
        foreach(string tag in AcceptedTags)
        {
            if(collision.gameObject.tag == tag)
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
