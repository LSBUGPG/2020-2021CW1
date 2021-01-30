using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ResetLevel : MonoBehaviour
{
    private Scene scene;

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTrigggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            Application.LoadLevel(scene.name);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
        


    }
}
