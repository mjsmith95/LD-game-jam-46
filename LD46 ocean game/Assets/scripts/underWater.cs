using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class underWater : MonoBehaviour
{
    public float waterLevel;
    private bool isUnderWater;
    public Color normalColor;
    public Color underWaterColor;
    public float fDensity;

   //normalColor = new Color(0.5f,0.5f,0.5f,0.5f);
    //underWaterColor = new Color(0.22f, 0.65f, 0.70f, 0.5f);

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if ((transform.position.y < waterLevel) != isUnderWater)
        {
            isUnderWater = transform.position.y < waterLevel;
            if (isUnderWater)
            {
                SetUnderwater();
            }
            else
            {
                SetNormal();
            }
        } 
    }

    void SetNormal()
    {
        RenderSettings.fogColor = normalColor;
        // Set the fog color to be blue
        RenderSettings.fogDensity = 0.01f;

        // And enable fog
        RenderSettings.fog = true;
    }

    void SetUnderwater()
    {
        RenderSettings.fogColor = underWaterColor;
        // Set the fog color to be blue
        RenderSettings.fogDensity = fDensity;

        // And enable fog
        RenderSettings.fog = true;

    }
}


