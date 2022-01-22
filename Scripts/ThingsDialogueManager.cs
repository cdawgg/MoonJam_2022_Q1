//derived from Brackeys Dialogue-System https://github.com/Brackeys/Dialogue-System

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ThingsDialogueManager : MonoBehaviour
{

    public TextMeshProUGUI thingsText;

    public Animator thingsanimator;

    public void StartDialogueThings(Dialogue dialogue)
    {
        thingsanimator.SetBool("IsHit", true);

        thingsText.text = dialogue.name;

    }

    public void EndDialogueThings()
    {
        thingsanimator.SetBool("IsHit", false);
    }

}
