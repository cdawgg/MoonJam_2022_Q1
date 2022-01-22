//derived from Brackeys Dialogue-System https://github.com/Brackeys/Dialogue-System

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;

    public void TriggerDialogue()
    {
            Debug.Log("trigger enter npc collider");
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
