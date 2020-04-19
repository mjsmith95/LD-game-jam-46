using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGen : MonoBehaviour
{
    // pub prams, so that they can be changed in the editor 
    public int mWidth;
    public int mHeight;
    public float nScale;

    //call the map func from Noise.cs 
    public void GenerateMap()
    {
        float[,] noiseMap = Noise.CreateNoiseMap(mWidth, mHeight, nScale);
        MapDisplay display = FindObjectOfType<MapDisplay>();
        display.DrawMap(noiseMap);  
    }

}
