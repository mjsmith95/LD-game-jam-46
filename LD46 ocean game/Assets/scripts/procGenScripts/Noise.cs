using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Noise
{
    public static float[,] CreateNoiseMap(int mHeight, int mWidth, float scale)
    {
        //map will be of demension mWidth X mHeight 
        float[,] nMap = new float[mWidth, mHeight];
        // to prevent divide by zero with scale val  
        if (scale <= 0)
        {
            // if scale = or < 0 then make scale really really tiny 
            scale = 0.0001f;
        }
        //loop through cols 
        for (int y = 0; y < mHeight; y++)
        {
            //loop through rows  
            for (int x = 0; x < mWidth; x++)
            {
                float sampleY = y / scale;
                float sampleX = x / scale;
                // generate point with noise       
                float perlinVal = Mathf.PerlinNoise(sampleX, sampleY);
                // add said point to the map 
                nMap[x, y] = perlinVal; 
            }
        }
        return nMap; 
    }
}
