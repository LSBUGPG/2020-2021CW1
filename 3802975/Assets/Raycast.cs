using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    public float Light;
    public Image collectprompt;
    public bool collectprompton;
    public static int CollectTotal = 0;

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

        collectprompt.gameObject.SetActive(false);

        if (Physics.Raycast(PromptRay, out hit, Light))

        {

            if (hit.collider.tag == "collect")

            {
                collectprompton = true;

                if (collectprompton == true)
                {
                    collectprompt.gameObject.SetActive(true);
                }


                if (Input.GetKeyDown(KeyCode.Space))

                {
                    Destroy(hit.transform.gameObject); // destroy the object hit.
                    CollectTotal += 1;
                    collectprompton = false;
                }
            }

        }

    }

}