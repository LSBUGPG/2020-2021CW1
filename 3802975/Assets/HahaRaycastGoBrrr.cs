using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HahaRaycastGoBrrr : MonoBehaviour

{
    public float Light;
    public Image Collectprompt;
    public Image Destroyprompt;
    public Image Frame;
    public Image Cameraprompt;
    public bool prompton;
    public bool photoprompt;
    public Text win;
    public static int evidenceCounter;
    public int timer;
    public bool Lightcollision = false;
    public AudioClip CameraShutter;
    public AudioClip Ziplock;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
        RaycastHit hit;
        Ray PromptRay = new Ray(transform.position, transform.forward);

        Debug.DrawRay(transform.position, transform.forward * Light);

        Collectprompt.gameObject.SetActive(false);
        Cameraprompt.gameObject.SetActive(false);
        Frame.gameObject.SetActive(false);
        Destroyprompt.gameObject.SetActive(false);
        win.gameObject.SetActive(false);

        if (Physics.Raycast(PromptRay, out hit, Light))

        {

            if (hit.collider.tag == "collect")

            {
                prompton = true;

                if (prompton == true)
                {
                    Collectprompt.gameObject.SetActive(true);
                }


                if (Input.GetKeyDown(KeyCode.Space))

                {
                    if (Ziplock != null)
                        AudioSource.PlayClipAtPoint(Ziplock, transform.position);
                    Destroy(hit.transform.gameObject); // destroy the object hit.
                    evidenceCounter += 1;
                    prompton = false;
                }
            }

            if (hit.collider.tag == "photo")

            {
                photoprompt = true;

                if (photoprompt == true)
                {
                    Cameraprompt.gameObject.SetActive(true);
                    Frame.gameObject.SetActive(true);
                }


                if (Input.GetKeyDown(KeyCode.Space))

                {
                    if (CameraShutter != null)
                        AudioSource.PlayClipAtPoint(CameraShutter, transform.position);
                    hit.collider.tag = "Untagged";
                    evidenceCounter += 1;
                    photoprompt = false;
                }
            }

            if (hit.collider.tag == "ghosts")
            {
                Lightcollision = true;



                if (Lightcollision == true)
                {

                    Destroyprompt.gameObject.SetActive(true);
                    //Ghostman.speed = 0;
                    //timer += 1;

                    //if (timer >= 60)
                    //{
                    //     Destroy(hit.transform.gameObject);
                    //}
                }

                if (Input.GetKeyDown(KeyCode.Space))

                {
                    Destroy(hit.transform.gameObject);
                    Lightcollision = false;
                }
            }

           
            

        }

        if (evidenceCounter == 10)
        {
            SceneManager.LoadScene("Win State");
        }

    }

}


    