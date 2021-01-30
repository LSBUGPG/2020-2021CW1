using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    //Animation variable
    public Animator animator;

    //Text variables
    public Text nameText;
    public Text dialogueText;

    //Queue where the sentences are stored
    public Queue<string> sentences;

    //Bool to check if the dialogue has started
    private bool firstSentence;

    // Start is called before the first frame update
    void Start()
    {
        //Sets that the dialogue hasn't started yet
        firstSentence = false;

        sentences = new Queue<string>();
    }

    private void Update()
    {
        //When the dialogue has started and you press R, the next sentence will appear
        if (Input.GetKeyDown(KeyCode.R) && firstSentence)
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("isOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

        //Indicates that the dialigue has started
        firstSentence = true;
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        animator.SetBool("isOpen", false);
    }

}
