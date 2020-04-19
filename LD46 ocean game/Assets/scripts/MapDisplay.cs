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

        Texture2D texture = new Texture2D(width, height);
        Color[] cMap = new Color[width * height]; 

    }
}
