using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaunaSpawna : MonoBehaviour
{
    public Object predator;
    public Object prey;

    public int numPredators;
    public int numPrey;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < numPredators; i++)
        {
            Instantiate(predator);
        }
        for (int i = 0; i < numPrey; i++)
        {
            Instantiate(prey);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
