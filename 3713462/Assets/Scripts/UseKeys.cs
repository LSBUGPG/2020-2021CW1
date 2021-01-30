using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseKeys : MonoBehaviour
{
    public KeyBindsManager keyBindings;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyBindings.jumpKey))
        {
            print("hit jump key: " + keyBindings.jumpKey.ToString());
        }

        if (Input.GetKeyDown(keyBindings.punchKey))
        {
            print("hit punch key: " + keyBindings.punchKey.ToString());
        }

        if (Input.GetKeyDown(keyBindings.kickKey))
        {
            print("hit kick key: " + keyBindings.kickKey.ToString());

        }
    }
}
