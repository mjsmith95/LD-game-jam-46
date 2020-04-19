using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeScript : MonoBehaviour
{
    public int frame;
    public float expandSensitivity;
    public Transform bringMeToLife;
    public int Modifier = 1;
    public int numFramesPerAction;
    // Start is called before the first frame update
    void Start()
    {
        frame = Random.Range(0,numFramesPerAction);
        bringMeToLife.transform.localScale += new Vector3(expandSensitivity * Modifier*frame, expandSensitivity * Modifier*frame, expandSensitivity * Modifier*frame);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bringMeToLife.transform.localScale += new Vector3(expandSensitivity*Modifier, expandSensitivity * Modifier, expandSensitivity * Modifier);
        frame++;
        if (frame == numFramesPerAction)
        {
            frame = 0;
            Modifier = (-1) * Modifier;
        }
    }
}
