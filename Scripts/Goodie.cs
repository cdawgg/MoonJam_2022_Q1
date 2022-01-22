using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goodie: MonoBehaviour, IClicked
{
    public int counter;

    public Dialogue dialogue;


    void Start()
    {
        counter = 0;
    }

    public void OnClickAction()
    {
        if (counter < 1)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            FindObjectOfType<PlayerHealth>().playerHeal();
            Debug.Log("NPCcandy first sentence");
        }
        counter++;
    }
}
