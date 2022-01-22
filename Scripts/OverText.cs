using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverText : MonoBehaviour
{

    void Update()
    {
        LookAtPlayer();
    }

    private void LookAtPlayer()
    {
        transform.LookAt(Camera.main.transform);
    }
}
