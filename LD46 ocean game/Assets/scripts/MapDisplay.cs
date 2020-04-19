    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour
{
    public Renderer texRender;
    public void DrawMap(float[,] nMap)
    {
        int width = nMap.GetLength(0);
        int height = nMap.GetLength(1);

        Texture2D texture = new Texture2D(width, height); //, TextureFormat.RGB24, false);
        Color[] cMap = new Color[width * height];
        for (int y=0; y < height; y++)
        {
            for(int x = 0; x < height; x++)
            {
                cMap[y * width + x] = Color.Lerp(Color.black, Color.white, nMap[x, y]);
            }
        }
        texture.SetPixels(cMap);
        texture.Apply (); 
        texRender.sharedMaterial.mainTexture = texture;
        texRender.transform.localScale = new Vector3(width, height); 
    }
}
