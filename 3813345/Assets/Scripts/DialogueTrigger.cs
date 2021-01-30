using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public Text pressE;

    private bool dialogueOpened;

    private void Start()
    {
        dialogueOpened = false;
        pressE.enabled = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && dialogueOpened == false)
        {
            dialogueOpened = true; 
            TriggerDialogue();
            pressE.enabled = false;
        }
    }

    public void TriggerDialogue ()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }


}
