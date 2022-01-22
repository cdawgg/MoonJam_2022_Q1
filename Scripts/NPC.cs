using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IClicked
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
            Debug.Log("NPC first sentence");
        }
        if (counter >= 1 && counter < 3)
        {
            FindObjectOfType<DialogueManager>().DisplayNextSentence();
            FindObjectOfType<PlayerHealth>().playerDamage();
            if(gameObject.CompareTag("NPC"))
            {
                GetComponent<AudioSource>().Play();
                //animatorslap.SetBool("slapOn", true);
                //animatorslap.Play("hand_slap");
            }

            Debug.Log("NPC next sentence and damage");
        }

        if (counter >= 3)
        {
            FindObjectOfType<DialogueManager>().DisplayNextSentence();
            FindObjectOfType<PlayerHealth>().playerKill();
            Debug.Log("NPC kill");
        }
        counter++;
    }
}
