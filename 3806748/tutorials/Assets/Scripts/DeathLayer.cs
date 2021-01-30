using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathLayer : MonoBehaviour
{
    public bool AcceptAllStates = true;

    [SerializeField] private string[] AcceptedTags; //Array for all accepted tags, private but serialized so can be edited in inspector

    private bool NotAccepted = true; //Records if the collision tag has been accepted

    private void OnCollisionEnter(Collision collision) //Hit object with collider
    {
        if (AcceptAllStates) //All tags are accepted
        {
            AcceptedState();
        }
        else
        {
            foreach (string tags in AcceptedTags) //Iterate over the AcceptedTags array and store value
            {
                if (collision.gameObject.tag == tags) //Check if stored value is the same as collision tag. Note this -can- be set to undefined if you want all tags to run this
                {
                    AcceptedState();
                    break; //Break the loop, this is somewhat redundant seeing as you're reloading the scene but is more useful if you edit the accepted state code
                }
            }

            if (NotAccepted) //The collision tag is not accepted
            {
                Destroy(collision.gameObject); //Simply destroy the object, this can be any code
            }


            NotAccepted = true; //Reset the bool's state
        }
    }

    private void AcceptedState()
    {
        NotAccepted = false; //An accepted state has been found, don't run the delete code
        SceneManager.LoadScene(SceneManager.GetActiveScene().ToString()); //Reload the scene, this can be any code here
    }
}
