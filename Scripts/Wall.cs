using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour, IClicked
{
    public Dialogue dialogue;

    public void OnClickAction()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
